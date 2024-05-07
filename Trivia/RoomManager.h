#pragma once

#include "GameRoom.h"
#include "TriviaQuestion.h"
#include <vector>
#include <string>

class RoomManager
{
public:

	static const int MAX_ROOMS = 7;

	RoomManager();
	~RoomManager();

	bool createRoom(const std::string roomName, const int maxPlayers, const int questionTime, const std::string creator, const int qnum, const TriviaDifficulty difficuly, TriviaCategory category);
	void deleteRoom(const std::string roomName);
	bool doesRoomExistAndJoinable(const std::string roomName) const; //true - active, false - not active.
	bool doesRoomExist(const std::string roomName) const;
	int getAmountOfRooms() const;
	std::vector<GameRoom> getRooms() const;

	void startGame(const std::string roomName);
	void removeRoomsByUser(const std::string username);
	bool joinPlayerToRoom(const std::string roomName, const std::string username, std::string& errMsg);
	void removePlayerFromRoom(const std::string roomName, const std::string username);
	void removePlayerFromAllRooms(const std::string username);
	bool isPlayingAnywhere(const std::string username) const;
	std::string creatorOf(const std::string roomName) const;

	GameRoom* findRoom(const std::string roomName) const;

	friend std::ostream& operator<<(std::ostream& os, const RoomManager& gr);

private:

	std::vector<GameRoom> _rooms;

	GameRoom& getRoom(const std::string roomName);

	// Open Trivia Database API
	static std::vector<TriviaQuestion> getQuestions(const int amount, const TriviaDifficulty df, const TriviaCategory ct);
	static std::string constructUrl(const int amount, const TriviaDifficulty df, const TriviaCategory ct);
};