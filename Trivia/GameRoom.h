#pragma once

#include <map>
#include <vector>
#include <string> 
#include "TriviaQuestion.h"
#include "User.h"

class GameRoom
{
public:

	// to be continued...
	GameRoom(const std::string name, const std::vector<TriviaQuestion>& questions, const int maxPlayers, const int questionTime, const std::string creator);
	~GameRoom();

	bool isInGame() const;
	std::string getName() const;
	int getQuestionTime() const;
	int getMaxPlayers() const;
	int getAmountOfPlayers() const;
	std::string getCreator() const;
	bool isFull() const;
	std::vector<TriviaQuestion> getQuestions() const;
	TriviaDifficulty getSingleDifficulty() const;

	void startGame();
	bool addPlayer(const std::string username);
	void removePlayer(const std::string username);
	std::vector<std::string> getPlayersUsernames() const;

	bool isPlaying(const std::string username) const;
	int playerScore(const std::string username) const;

	friend std::ostream& operator<<(std::ostream& os, const GameRoom& gr);

private:

	bool _inGame;
	std::string _name;
	std::string _creatorUsername;
	int _maxPlayers;
	int _questionTime;
	std::map<std::string, int> _players;  // username : score
	std::vector<TriviaQuestion> _questions;
};