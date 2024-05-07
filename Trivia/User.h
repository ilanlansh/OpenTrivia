#pragma once

#include "UserStatistics.h"
#include <string>
#include <iostream>

class User
{
public:

	User(const std::string name, const UserStatistics& stats);
	User(const std::string name);
	User(const User& other);
	User();
	~User() = default;

	std::string getName() const;
	UserStatistics getStats() const;

	std::string toString() const;
	friend std::ostream& operator<<(std::ostream& os, const User& user);

private:

	std::string _name;
	UserStatistics _stats;
};