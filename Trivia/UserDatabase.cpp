#include "UserDatabase.h"

#include "TriviaExceptions.h"
#include <io.h>
#include <sstream>

UserDatabase::UserDatabase(const std::string filename)
{
	this->open(filename);
}

UserDatabase::~UserDatabase()
{
	this->close();
}

User UserDatabase::getUserByUsernameAndPass(const std::string username, const std::string pass) const
{
	static const auto callback = [](void* data, int argc, char** argv, char** azColName)
	{
		std::string username =              argv[0];
		// std::string password =           argv[1];
		// std::string email =              argv[2];
		int num_games =           std::atoi(argv[3]);
		int num_correct_answers = std::atoi(argv[4]);
		int num_wrong_answers =   std::atoi(argv[5]);
		int total_time =          std::atoi(argv[6]);
		
		*static_cast<User**>(data) = new User(username, { num_games, num_correct_answers, num_wrong_answers, total_time });
		
		return 0;
	};

	User* up = nullptr;
	std::string sql = "SELECT * FROM USERS WHERE username = '" + username + "' AND password = '" + pass + "';";

	executeQuery(sql, callback, &up);

	if (!up)
	{
		throw UserNotFoundException("No user matches credentials: username = " + username + ", password = " + pass);
	}

	User u(*up);
	delete up;
	return u;
}

User UserDatabase::getUserByUsername(const std::string username) const
{
	static const auto callback = [](void* data, int argc, char** argv, char** azColName)
	{
		std::string username =              argv[0];
		// std::string password =           argv[1];
		// std::string email =              argv[2];
		int num_games =           std::atoi(argv[3]);
		int num_correct_answers = std::atoi(argv[4]);
		int num_wrong_answers =   std::atoi(argv[5]);
		int total_time =          std::atoi(argv[6]);

		*static_cast<User**>(data) = new User(username, { num_games, num_correct_answers, num_wrong_answers, total_time });

		return 0;
	};

	User* up = nullptr;
	std::string sql = "SELECT * FROM USERS WHERE username = '" + username + "';";

	executeQuery(sql, callback, &up);

	if (!up)
	{
		throw UserNotFoundException("No user with username = " + username);
	}

	User u(*up);
	delete up;
	return u;
}

std::vector<User> UserDatabase::getAllUsers() const
{
	const auto callback = [](void* data, int argc, char** argv, char** azColName)
	{
		std::string username =              argv[0];
		// std::string password =           argv[1];
		// std::string email =              argv[2];
		int num_games =           std::atoi(argv[3]);
		int num_correct_answers = std::atoi(argv[4]);
		int num_wrong_answers =   std::atoi(argv[5]);
		int total_time =          std::atoi(argv[6]);

		User u(username, { num_games, num_correct_answers, num_wrong_answers, total_time });

		( static_cast<std::vector<User>*> (data) )->push_back(u);

		return 0;
	};

	std::vector<User> v;
	std::string sql = "SELECT * FROM USERS;";

	executeQuery(sql, callback, &v);

	return v;
}

void UserDatabase::updateUserStats(const std::string username, const UserStatistics& stats)
{
	if (!this->doesUsernameExist(username))
	{
		return;
	}	

	UserStatistics currentStats = this->getUserByUsername(username).getStats();
	UserStatistics newStats = currentStats + stats;

	std::string sql =
		"UPDATE USERS SET num_games = " + std::to_string(newStats.getGamesNum()) +
		", num_correct_answers = " + std::to_string(newStats.getRightNum()) +
		", num_wrong_answers = " + std::to_string(newStats.getWrongNum()) +
		", total_time = " + std::to_string(newStats.getTotalTime()) +
		" WHERE username = '" + username + "';";

	executeQuery(sql);
}

bool UserDatabase::doesUsernameExist(const std::string username) const
{
	static const auto callback = [](void* data, int argc, char** argv, char** azColName)
	{
		* static_cast<bool*>(data) = true;
		return 0;
	};

	bool found = false;
	std::string sql = "SELECT * FROM USERS WHERE username = '" + username + "';";

	executeQuery(sql, callback, &found);

	return found;
}

std::vector<std::pair<std::string, int>> UserDatabase::getTopScores(const int amount) const
{
	static const auto callback = [](void* data, int argc, char** argv, char** azColName)
	{
		std::string username = argv[0];
		int score = std::stoi(argv[1]);
		static_cast<std::vector<std::pair<std::string, int>>*>(data)->push_back(std::make_pair(username, score));
		return 0;
	};

	std::vector<std::pair<std::string, int>> v;
	std::string sql = "SELECT username, num_correct_answers FROM USERS ORDER BY num_correct_answers DESC LIMIT " + std::to_string(amount) + ";";

	executeQuery(sql, callback, &v);

	return v;
}

void UserDatabase::addUser(const std::string username, const std::string password, const std::string email) const
{
	executeQuery("INSERT INTO USERS (username, password, email) VALUES ('" + username + "', '" + password + "', '" + email + "'); ");
}

void UserDatabase::dumpEntireDatabase() const
{
	static const auto callback = [](void* data, int argc, char** argv, char** azColName)
	{
		std::stringstream nextRecord;
		for (int i = 0; i < argc; i++)
		{
			nextRecord << azColName[i] << ": " << argv[i] << ", ";
		}
		std::cout << nextRecord.str() << std::endl;
		return 0;
	};

	std::string sql = "SELECT * FROM USERS;";

	executeQuery(sql, callback, nullptr);
}

void UserDatabase::open(const std::string filename)
{
	int doesFileExist = _access(filename.c_str(), 0);
	int res = sqlite3_open(filename.c_str(), &this->_db);
	if (res != SQLITE_OK)
	{
		this->_db = nullptr;
		throw TriviaSQLException("Failed to open DB");
	}
	if (doesFileExist != 0)
	{
		std::stringstream sqlQuery;

		sqlQuery << "CREATE TABLE USERS ("
            "username TEXT PRIMARY KEY NOT NULL,"
            "password TEXT NOT NULL,"
            "email TEXT NOT NULL,"
            "num_games INTEGER DEFAULT 0,"
            "num_correct_answers INTEGER DEFAULT 0,"
            "num_wrong_answers INTEGER DEFAULT 0,"
            "total_time INTEGER DEFAULT 0"
			");";


		executeQuery(sqlQuery.str());

		sqlQuery.str("");
	}
}

void UserDatabase::close()
{
	sqlite3_close(this->_db);
	this->_db = nullptr;
}

void UserDatabase::executeQuery(const std::string query) const
{
	char* errMessage = nullptr;
	int res = sqlite3_exec(this->_db, query.c_str(), nullptr, nullptr, &errMessage);
	std::string msg(errMessage ? errMessage : "");
	delete errMessage;
	if (res != SQLITE_OK)
	{
		throw TriviaSQLException(msg);
	}

}
void UserDatabase::executeQuery(const std::string sql, int(*callback)(void*, int, char**, char**), void* data) const
{
	char* errMessage = nullptr;
	int res = sqlite3_exec(this->_db, sql.c_str(), callback, data, &errMessage);
	std::string msg(errMessage ? errMessage : "");
	delete errMessage;
	if (res != SQLITE_OK)
	{
		throw TriviaSQLException(msg);
	}
}