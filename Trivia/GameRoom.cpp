#include "GameRoom.h"

#include "TriviaExceptions.h"

GameRoom::GameRoom(const std::string name, const std::vector<TriviaQuestion>& questions, const int maxPlayers, const int questionTime, const std::string creator)
	: _inGame(false), _name(name), _maxPlayers(maxPlayers), _questions(questions), _questionTime(questionTime), _creatorUsername(creator)
{
	
}

GameRoom::~GameRoom()
{

}

bool GameRoom::isInGame() const
{
	return this->_inGame;
}

std::string GameRoom::getName() const
{
	return this->_name;
}

int GameRoom::getQuestionTime() const
{
	return this->_questionTime;
}

int GameRoom::getMaxPlayers() const
{
	return this->_maxPlayers;
}

int GameRoom::getAmountOfPlayers() const
{
	return this->_players.size();
}

std::string GameRoom::getCreator() const
{
	return this->_creatorUsername;
}

bool GameRoom::isFull() const
{
	return getAmountOfPlayers() == this->_maxPlayers;
}

std::vector<TriviaQuestion> GameRoom::getQuestions() const
{
	return this->_questions;
}

TriviaDifficulty GameRoom::getSingleDifficulty() const
{
	TriviaDifficulty d = this->_questions[0].getDifficulty();

	for (TriviaQuestion q : this->_questions)
	{
		if (q.getDifficulty() != d)
		{
			return DIFF_ANY;
		}
	}

	return d;
}

void GameRoom::startGame()
{
	this->_inGame = true;
}

bool GameRoom::addPlayer(const std::string username)
{
	if (isFull())  // full room
	{
		return false;
	}
	else
	{
		this->_players[username] = 0;
		return true;
	}
}

void GameRoom::removePlayer(const std::string username)
{
	auto it = this->_players.begin();
	while (it != this->_players.end())
	{
		if (it->first == username)
		{
			it = this->_players.erase(it);
		}
		else
		{
			++it;
		}
	}
}

std::vector<std::string> GameRoom::getPlayersUsernames() const
{
	std::vector<std::string> usernames;

	for (const auto& item : this->_players)
	{
		usernames.push_back(item.first);
	}
	
	return usernames;
}

bool GameRoom::isPlaying(const std::string username) const
{
	return this->_players.find(username) != this->_players.end();
}

int GameRoom::playerScore(const std::string username) const
{
	if (!this->isPlaying(username))
	{
		throw UserNotFoundException("User " + username + " not in game room");
	}

	return this->_players.at(username);
}

std::ostream& operator<<(std::ostream& os, const GameRoom& gr)
{
	return os << "GameRoom " << gr._name << " (" << gr._players.size() << " / " << gr._maxPlayers << ")" << "{" << gr._creatorUsername << "}";
}
