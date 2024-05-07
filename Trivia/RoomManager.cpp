#include "RoomManager.h"
#include "WebAccess.h"
#include "json.hpp"
#include "TriviaExceptions.h"
#include <algorithm>
#include <random>
#include <Windows.h>

using json = nlohmann::json;

RoomManager::RoomManager()
{

}

RoomManager::~RoomManager()
{

}

bool RoomManager::createRoom(const std::string name, const int maxPlayers, const int questionTime, const std::string creator,
							 const int qnum, const TriviaDifficulty difficuly, TriviaCategory category)
{
	for (const auto& room : this->_rooms)
	{
		if (room.getName() == name)
		{
			return false;  // name already exists
		}
	}

	std::vector<TriviaQuestion> questions = getQuestions(qnum, difficuly, category);

	this->_rooms.push_back(GameRoom(name, questions, maxPlayers, questionTime, creator));
}

void RoomManager::deleteRoom(std::string roomName)
{
	auto it = this->_rooms.begin();
	while (it != this->_rooms.end())
	{
		if (it->getName() == roomName)
		{
			it = this->_rooms.erase(it);
		}
		else
		{
			++it;
		}
	}
}

// true - active, false - not active. if the room is
// not on one of this states the room doesn't exist and then - false.
bool RoomManager::doesRoomExistAndJoinable(std::string nameOfRoom) const
{
	auto it = this->_rooms.begin();
	while (it != this->_rooms.end())
	{
		if (it->getName() == nameOfRoom)
		{
			return !it->isInGame();
		}
		else
		{
			++it;
		}
	}
	return false; // the room doesn't exist or is not joinable.
}

// does a room of this name exist
bool RoomManager::doesRoomExist(std::string nameOfRoom) const
{
	auto it = this->_rooms.begin();
	while (it != this->_rooms.end())
	{
		if (it->getName() == nameOfRoom)
		{
			return true;
		}
		else
		{
			++it;
		}
	}
	return false; // the room doesn't exist
}

int RoomManager::getAmountOfRooms() const
{
	return this->_rooms.size();
}

std::vector<GameRoom> RoomManager::getRooms() const
{
	return this->_rooms;
}

bool RoomManager::joinPlayerToRoom(const std::string roomName, const std::string username, std::string& errMsg)
{
	if (!this->doesRoomExistAndJoinable(roomName))
	{
		errMsg = "Room " + roomName + " is not joinable";
		return false;
	}

	GameRoom& room = this->getRoom(roomName);

	if (room.isPlaying(username))
	{
		errMsg = "Player " + username + " is already in the room";
		return false;
	}

	if (this->isPlayingAnywhere(username))
	{
		errMsg = "Player " + username + " is joined in another room";
		return false;
	}

	if (room.addPlayer(username))
	{
		return true;
	}
	else
	{
		errMsg = "Room " + roomName + " is full and therefore not joinable";
		return false;
	}
}

void RoomManager::removePlayerFromRoom(const std::string roomName, const std::string playerName)
{
	if (!this->doesRoomExist(roomName))
	{
		return;
	}

	GameRoom& room = this->getRoom(roomName);

	room.removePlayer(playerName);
}

void RoomManager::removePlayerFromAllRooms(const std::string username)
{
	auto it = this->_rooms.begin();
	while (it != this->_rooms.end())
	{
		it->removePlayer(username);
		++it;
	}
}

bool RoomManager::isPlayingAnywhere(const std::string username) const
{
	bool playing = false;
	for (const auto& item : this->_rooms)
	{
		playing = playing || item.isPlaying(username);
	}
	return playing;
}

std::string RoomManager::creatorOf(const std::string roomName) const
{
	auto it = this->_rooms.begin();
	while (it != this->_rooms.end())
	{
		if (it->getName() == roomName)
		{
			return it->getCreator();
		}
		++it;
	}
	return "";
}

// Returns a copy of the gameroom if exists, otherwise nullptr
GameRoom* RoomManager::findRoom(const std::string roomName) const
{
	auto it = this->_rooms.begin();
	while (it != this->_rooms.end())
	{
		if (it->getName() == roomName)
		{
			return new GameRoom(*it);
		}
		++it;
	}
	return nullptr;
}

void RoomManager::startGame(const std::string roomName)
{
	this->getRoom(roomName).startGame();
}

void RoomManager::removeRoomsByUser(const std::string username)
{
	auto it = this->_rooms.begin();
	while (it != this->_rooms.end())
	{
		if (it->getCreator() == username)
		{
			it = this->_rooms.erase(it);
		}
		else
		{
			++it;
		}
	}
}

GameRoom& RoomManager::getRoom(const std::string roomName)
{
	auto it = this->_rooms.begin();
	while (it != this->_rooms.end())
	{
		if (it->getName() == roomName)
		{
			return *it;
		}
		++it;
	}
}

std::vector<TriviaQuestion> RoomManager::getQuestions(const int amount, const TriviaDifficulty df, const TriviaCategory ct)
{
	std::string url = constructUrl(amount, df, ct);
	
	std::string response = WebAccess::fetch(url);

	if (response == "ERR!!!\n")
	{
		throw GeneralTriviaException("No internet connection");
	}
	
	json data = json::parse(response);
	int responseCode = data["response_code"].get<int>();
	if (responseCode)
	{
		throw TriviaAPIException(responseCode);
	}

	auto& results = data["results"];
	int i = 0;
	std::vector<TriviaQuestion> qs;
	for (const auto& r : results)
	{
		i++;

		TriviaCategory category = TriviaQuestion::stringToCategory(WebAccess::urlDecode(r["category"].get<std::string>()));
		TriviaDifficulty difficulty = TriviaQuestion::stringToDifficulty(WebAccess::urlDecode(r["difficulty"].get<std::string>()));
		std::string question = r["question"].get<std::string>();
		std::string correctAnswer = r["correct_answer"].get<std::string>();
		json incorrectAnswers = r["incorrect_answers"];
		std::string inc1 = incorrectAnswers[0].get<std::string>();
		std::string inc2 = incorrectAnswers[1].get<std::string>();
		std::string inc3 = incorrectAnswers[2].get<std::string>();

		qs.push_back(TriviaQuestion(difficulty, category, question, correctAnswer, { inc1, inc2, inc3 }));
	}

	return qs;
}

std::string RoomManager::constructUrl(const int amount, const TriviaDifficulty df, const TriviaCategory ct)
{
	static const std::string API_BASE_URL = "https://opentdb.com/api.php?";

	if (amount < TriviaQuestion::PARAM_AMOUNT_MIN || amount > TriviaQuestion::PARAM_AMOUNT_MAX)
	{
		throw TriviaInvalidArgument(
			"amount must be between " + std::to_string(TriviaQuestion::PARAM_AMOUNT_MIN)
			+ " and " + std::to_string(TriviaQuestion::PARAM_AMOUNT_MAX)
		);
	}
	if (!TriviaQuestion::isValid(df, ct))
	{
		throw TriviaInvalidArgument("invlaid difficulty or category parameters");
	}

	std::string url;
	url += API_BASE_URL;

	url += "encode=url3986&type=multiple";

	url += "&amount=" + std::to_string(amount);

	if (df)
	{
		url += "&difficulty=" + TriviaQuestion::difficultyToString(df);
	}

	if (ct)
	{
		url += "&category=" + std::to_string((int)ct);
	}

	return url;
}

std::ostream& operator<<(std::ostream& os, const RoomManager& gr)
{
	for (const auto& item : gr._rooms)
	{
		std::cout << item << std::endl;
	}
	return os;
}
