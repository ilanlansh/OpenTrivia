#include "UserStatistics.h"
#include "UserDatabase.h"

UserStatistics::UserStatistics(const int gn, const int rn, const int wn, const int tt)
	: _gamesNum(gn), _rightNum(rn), _wrongNum(wn), _totalTime(tt)
{

}

UserStatistics::UserStatistics() : UserStatistics(0, 0, 0, 0)
{

}

UserStatistics::UserStatistics(const UserStatistics& other)
	: UserStatistics(other._gamesNum, other._rightNum, other._wrongNum, other._totalTime)
{
}

int UserStatistics::getGamesNum() const
{
	return this->_gamesNum;
}

int UserStatistics::getRightNum() const
{
	return this->_rightNum;
}

int UserStatistics::getWrongNum() const
{
	return this->_wrongNum;
}

int UserStatistics::getTotalTime() const
{
	return this->_totalTime;
}

float UserStatistics::averageTimePerAns() const
{
	int total_answers = this->_rightNum + this->_wrongNum;
	
	// I know this can be a one-liner, here is to readability

	if (total_answers != 0)
	{
		return (float)this->_totalTime / total_answers;
	}

	return 0;
}

UserStatistics UserStatistics::operator+(const UserStatistics& other)
{
	return UserStatistics(
		this->_gamesNum + other._gamesNum,
		this->_rightNum + other._rightNum,
		this->_wrongNum + other._wrongNum,
		this->_totalTime + other._totalTime
	);
}

std::ostream& operator<<(std::ostream& os, const UserStatistics& stats)
{
	return os <<
		"Number of games: " << stats._gamesNum << std::endl <<
		"Right answers: " << stats._rightNum << std::endl <<
		"Wrong answers: " << stats._wrongNum << std::endl <<
		"Total answer time: " << stats._totalTime << " sec";
}
