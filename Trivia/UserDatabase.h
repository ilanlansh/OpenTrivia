#pragma once

#include <string>
#include "User.h"
#include "UserStatistics.h"
#include "sqlite3.h"
#include <vector>

class UserDatabase
{
public:

	UserDatabase(const std::string filename);
	~UserDatabase();

	User getUserByUsernameAndPass(const std::string username, const std::string pass) const;
	User getUserByUsername(const std::string username) const;
	std::vector<User> getAllUsers() const;
	void updateUserStats(const std::string username, const UserStatistics& stats);
	bool doesUsernameExist(const std::string username) const;
	std::vector<std::pair<std::string, int>> getTopScores(const int amount) const;

	void addUser(const std::string username, const std::string password, const std::string email) const;

	// more methods soon

	void dumpEntireDatabase() const;

private:

	sqlite3* _db;  // change to sqlite3*

	void open(const std::string filename);
	void close();

	void executeQuery(const std::string query) const;
	void executeQuery(const std::string sql, int(*callback)(void*, int, char**, char**), void* data) const;
};