#pragma once

#include <iostream>
#include <map>

class UserStatistics
{
public:

	UserStatistics(const int gn, const int rn, const int wn, const int tt);
	UserStatistics();
	UserStatistics(const UserStatistics& other);
	~UserStatistics() = default;

	int getGamesNum() const;
	int getRightNum() const;
	int getWrongNum() const;
	int getTotalTime() const;

	float averageTimePerAns() const;

	UserStatistics operator+(const UserStatistics& other);

	friend std::ostream& operator<<(std::ostream& os, const UserStatistics& stats);

private:

	int _gamesNum;
	int _rightNum;
	int _wrongNum;
	int _totalTime;
};