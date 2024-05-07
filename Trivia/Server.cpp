#include "Server.h"

#include <iostream>
#include <set>
#include "TriviaExceptions.h"
#include "json.hpp"

#define BUFSIZE 4096

using json = nlohmann::json;

const std::string Server::DATABASE_FILENAME = "USERS.db";
std::mutex Server::_coutMtx;

Server::Server() : _active(false), _dataAccess(DATABASE_FILENAME)
{
	// this server uses TCP. that's why SOCK_STREAM & IPPROTO_TCP are used
	this->_serverSocket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);

	if (_serverSocket == INVALID_SOCKET)
		throw SocketException(_serverSocket, "failed to create sever socket");
}

Server::Server(const int port) : Server()
{
	this->run(port);
}

Server::~Server()
{
	this->_active = false;
	closesocket(this->_serverSocket);
}

void Server::run(const int port)
{
	if (this->_active) return;

	static const auto log = [](const std::string& msg)
	{
		_coutMtx.lock();
		std::cout << "[MAIN/Server::run] " << msg << std::endl;
		_coutMtx.unlock();
	};

	this->_active = true;

	std::thread consoleThread(&Server::getConsoleData, this);
	consoleThread.detach();

	struct sockaddr_in sa = { 0 };

	sa.sin_port = htons(port); // port that server will listen for
	sa.sin_family = AF_INET;   // must be AF_INET
	sa.sin_addr.s_addr = INADDR_ANY;    // when there are few ip's for the machine. We will use always "INADDR_ANY"

	// Connects between the socket and the configuration (port and etc..)
	if (bind(_serverSocket, (struct sockaddr*)&sa, sizeof(sa)) == SOCKET_ERROR)
		throw SocketException(_serverSocket, "failed to bind server socket");

	// Start listening for incoming requests of clients
	if (listen(_serverSocket, SOMAXCONN) == SOCKET_ERROR)
		throw SocketException(_serverSocket, "failed to listen for connection");
	log("Listening on port " + std::to_string(port));

	while (this->_active)
	{
		// the main thread is only accepting clients 
		// and add then to the list of handlers
		log("Waiting for client connection request");
		acceptClient();
	}
}

void Server::acceptClient()
{
	static const auto log = [](const std::string& msg)
	{
		_coutMtx.lock();
		std::cout << "[MAIN/Server::acceptClient] " << msg << std::endl;
		_coutMtx.unlock();
	};

	// this accepts the client and creates a specific socket from server to this client
	// the process will not continue until a client connects to the server
	SOCKET client_socket = accept(_serverSocket, NULL, NULL);
	if (client_socket == INVALID_SOCKET)
		throw SocketException(client_socket, "failed to accpet client");

	log("Client accepted (" + std::to_string(client_socket) + "). Server and client can speak");

	// this->clientHandler(client_socket);
	std::thread(&Server::clientHandler, this, client_socket).detach();
}

THREAD_FUNC Server::clientHandler(const Socket s)
{
	const auto log = [s](const std::string& msg)
	{
		_coutMtx.lock();
		std::cout << "[THREAD/Server::clientHandler (" << s << ")] " << msg << std::endl;
		_coutMtx.unlock();
	};

	// for testing purposes, the sent messages are currently not encrypted

	
	try
	{
		while (this->_active)
		{
			std::string stringMsg = this->recvData(s);
			log("Received from socket: " + stringMsg);
			TriviaProtocolMessage msg = TriviaProtocolMessage::fromDecrypted(stringMsg);

			handlerFunc handler = _handlerMap.at(msg.getCode());
			TriviaProtocolMessage response = (this->*handler)(s, msg.getDataJson());

			std::string responseMsg = response.rawDecrypted();
			log("Sending to socket: " + responseMsg);
			this->sendData(s, responseMsg);

			if (msg.getCode() == CLOSE_PROGRAM)
			{
				break;
			}
		}
	}
	catch (std::exception& e)
	{
		log(e.what());
		log("Exception thrown in conversation with socket");
		if (isSocketLoggedIn(s))
			this->handlerLogout(s, nullptr);
	}

	log("Closing connection with socket");
	closesocket(s);
}

void Server::sendData(const Socket s, const TriviaProtocolMessage& msg)
{
	this->sendData(s, msg.rawDecrypted());
}

void Server::sendData(const Socket s, const std::string message)
{
	static const auto log = [](const std::string& msg)
	{
		_coutMtx.lock();
		std::cout << "[MAIN/Server::sendData] " << msg << std::endl;
		_coutMtx.unlock();
	};

	const char* data = message.c_str();

	log("Sending to Socket " + std::to_string(s) + ": " + message);
	if (send(s, data, message.size(), 0) == INVALID_SOCKET)
	{
		throw SocketException(s, "failed to send data to socket");
	}
}

std::string Server::recvData(const Socket s)
{
	static const auto log = [](const std::string& msg)
	{
		_coutMtx.lock();
		std::cout << "[MAIN/Server::recvData] " << msg << std::endl;
		_coutMtx.unlock();
	};
	
	std::vector<char> buf(BUFSIZE); // you are using C++ not C
	int bytes = recv(s, buf.data(), buf.size(), 0);

	log("Received from Socket " + std::to_string(s) + ": " + buf.data());
	return buf.data();
}

bool Server::isUserLoggedIn(const std::string username) const
{
	for (const auto& item : this->_sockMap)
	{
		if (item.second == username) return true;
	}
	return false;
}

bool Server::isSocketLoggedIn(const Socket s) const
{
	for (const auto& item : this->_sockMap)
	{
		if (item.first == s) return true;
	}
	return false;
}

void Server::doLogout(const Socket s)
{
	try
	{
		this->_sockMap.erase(s);
	}
	catch (...) {}
}

TriviaProtocolMessage Server::handlerLogin(const Socket s, const json& data)
{
	try
	{
		std::string username = data["username"].get<std::string>();
		std::string password = data["password"].get<std::string>();
		User u = this->_dataAccess.getUserByUsernameAndPass(username, password);
		if (isUserLoggedIn(username))
		{
			return TriviaProtocolMessage(LOGIN_RESPONSE, { { "success", false }, { "errmsg", "User already logged in elsewhere" } });
		}
		else
		{
			this->_sockMap[s] = username;
			return TriviaProtocolMessage(LOGIN_RESPONSE, { { "success", true } });
		}
	}
	catch (const UserNotFoundException& e)
	{
		return TriviaProtocolMessage(LOGIN_RESPONSE, { { "success", false }, { "errmsg", "Incorrect username or password" } });
	}
}

TriviaProtocolMessage Server::handlerLogout(const Socket s, const json& data)
{
	std::string username = this->_sockMap[s];
	this->_roomMgr.removePlayerFromAllRooms(username);
	this->_roomMgr.removeRoomsByUser(username);
	doLogout(s);
	return TriviaProtocolMessage(LOGOUT_RESPONSE);
}

TriviaProtocolMessage Server::handlerStats(const Socket s, const json& data)
{
	std::string username = this->_sockMap[s];
	User u = this->_dataAccess.getUserByUsername(username);
	UserStatistics stats = u.getStats();
	json dataJson = {
		{ "gn", stats.getGamesNum() },
		{ "rn", stats.getRightNum() },
		{ "wn", stats.getWrongNum() },
		{ "at", stats.averageTimePerAns() },
	};
	return TriviaProtocolMessage(STATISTICS_RESPONSE, dataJson);
}

TriviaProtocolMessage Server::handlerRefreshRooms(const Socket s, const json& data)
{
	auto rooms = this->_roomMgr.getRooms();
	json dataJson;
	dataJson["rooms"] = {};
	for (const GameRoom& room : rooms)
	{
		dataJson["rooms"] += {
			{ "joinable", !room.isInGame() && !room.isFull() },  // if the game has started or room is full -> the room is not joinable
			{ "name", room.getName() },
			{ "qtime", room.isInGame() ? -1 : room.getQuestionTime() },
			{ "max_players", room.getMaxPlayers() },
			{ "connected_players", room.getAmountOfPlayers() },
		};
	}
	return TriviaProtocolMessage(ROOMS_LIST, dataJson);
}

TriviaProtocolMessage Server::handlerJoinRoom(const Socket s, const json& data)
{
	std::string roomName = data["room_name"].get<std::string>();
	std::string username = this->_sockMap[s];
	std::string errMsg = "";

	return TriviaProtocolMessage(
		JOIN_ROOM_RESPONSE,
		{
			{ "success", this->_roomMgr.joinPlayerToRoom(roomName, username, errMsg) },
			{ "errmsg", errMsg },
			{ "creator", this->_roomMgr.creatorOf(roomName) },
		}
	);
}

TriviaProtocolMessage Server::handlerLeaveRoom(const Socket s, const json& data)
{
	std::string roomName = data["room_name"].get<std::string>();

	this->_roomMgr.removePlayerFromRoom(roomName, this->_sockMap[s]);

	return TriviaProtocolMessage(LEAVE_ROOM_RESPONSE);
}

TriviaProtocolMessage Server::handlerCreateRoom(const Socket s, const json& data)
{
	if (this->_roomMgr.getAmountOfRooms() == RoomManager::MAX_ROOMS)
	{
		return TriviaProtocolMessage(CREATE_ROOM_RESPONSE, { { "success", false }, { "errmsg", "Room amount limit reached" } });
	}

	std::string name = data["name"].get<std::string>();
	int players = data["players"].get<int>();
	int time = data["time"].get<int>();
	int qnum = data["qnum"].get<int>();
	TriviaDifficulty diff = data["diff"].get<TriviaDifficulty>();
	TriviaCategory cat = data["cat"].get<TriviaCategory>();

	std::string creator = this->_sockMap[s];

	try
	{
		if (this->_roomMgr.createRoom(name, players, time, creator, qnum, diff, cat))
		{
			return TriviaProtocolMessage(CREATE_ROOM_RESPONSE, { { "success", true } });
		}
		else
		{
			return TriviaProtocolMessage(CREATE_ROOM_RESPONSE, { { "success", false }, { "errmsg", "Room with same name already exists" } });
		}
	}
	catch (GeneralTriviaException& e)
	{
		return TriviaProtocolMessage(CREATE_ROOM_RESPONSE, { { "success", false }, { "errmsg", e.what() } });
	}
}

TriviaProtocolMessage Server::handlerUpdateRoom(const Socket s, const json& data)
{
	std::string roomName = data["room_name"].get<std::string>();
	GameRoom* room = this->_roomMgr.findRoom(roomName);

	if (room)
	{
		json gameDataJson;
		if (room->isInGame())
		{
			gameDataJson["questions"] = {};
			for (const auto& q : room->getQuestions())
			{
				gameDataJson["questions"] += {
					{ "question", q.getQuestion() },
					{ "correct_answer", q.getCorrectAnswer() },
					{ "incorrect_answers", q.getIncorrectAnswers() },
					{ "difficulty", q.getDifficulty() },
					{ "category", q.getCategory() }
				};
				gameDataJson["qtime"] = room->getQuestionTime();
			}
		}

		std::set<TriviaCategory> cats;
		for (const auto& q : room->getQuestions())
		{
			cats.insert(q.getCategory());
		}
		json qcatsJson;
		for (const auto& c : cats)
		{
			qcatsJson += c;
		}
		TriviaProtocolMessage response(
			UPDATE_ROOM_RESPONSE,
			{
				{ "game_cancelled", false },
				{ "player_names", room->getPlayersUsernames() },
				{ "game_start", room->isInGame() },
				{ "max_players", room->getMaxPlayers() },
				{ "game_data", gameDataJson },
				{ "qtime", room->getQuestionTime() },
				{ "qnum", room->getQuestions().size() },
				{ "diff", room->getSingleDifficulty() },
				{ "cats", qcatsJson }
			}
		);

		delete room;
		return response;
	}
	else
	{
		TriviaProtocolMessage response(
			UPDATE_ROOM_RESPONSE,
			{
				{ "game_cancelled", true },
			}
		);
		return response;
	}
}

TriviaProtocolMessage Server::handlerSignup(const Socket s, const json& data)
{
	std::string username = data["username"].get<std::string>();

	if (this->_dataAccess.doesUsernameExist(username))
	{
		return TriviaProtocolMessage(REGISTER_RESPONSE, { { "success", false } });
	}
	else
	{
		std::string password = data["password"].get<std::string>();
		std::string email = data["email"].get<std::string>();
		this->_dataAccess.addUser(username, password, email);
		this->_sockMap[s] = username;
		return TriviaProtocolMessage(REGISTER_RESPONSE, { { "success", true } });
	}
}

TriviaProtocolMessage Server::handlerCloseRoom(const Socket s, const json& data)
{
	std::string roomName = data["room_name"].get<std::string>();
	this->_roomMgr.deleteRoom(roomName);
	return TriviaProtocolMessage(CLOSE_ROOM_RESPONSE);
}

TriviaProtocolMessage Server::handlerStartGame(const Socket s, const json& data)
{
	std::string roomName = data["room_name"].get<std::string>();
	this->_roomMgr.startGame(roomName);
	return TriviaProtocolMessage(START_GAME_RESPONSE);
}

TriviaProtocolMessage Server::handlerCloseProgram(const Socket s, const json& data)
{
	return TriviaProtocolMessage(CLOSE_PROGRAM_RESPONSE);
}

TriviaProtocolMessage Server::handlerUpdateUserStats(const Socket s, const json& data)
{
	std::string username = this->_sockMap[s];
	int correctAnswers = data["correct"].get<int>();
	int incorrectAnswers = data["incorrect"].get<int>();
	int totalTime = data["time"].get<int>();

	this->_dataAccess.updateUserStats(username, UserStatistics(1, correctAnswers, incorrectAnswers, totalTime));
	return TriviaProtocolMessage(UPDATE_USER_STATS_RESPONSE);
}

TriviaProtocolMessage Server::handlerBestScores(const Socket s, const json& data)
{
	int amount = data["amount"].get<int>();
	std::vector<std::pair<std::string, int>> scores = this->_dataAccess.getTopScores(amount);

	json dataJson;

	for (const auto& kv : scores)
	{
		dataJson[kv.first] = kv.second;
	}

	return TriviaProtocolMessage(SCORES_TABLE, dataJson);
}

THREAD_FUNC Server::getConsoleData()
{
	static const auto log = [](auto& msg)
	{
		_coutMtx.lock();
		std::cout << "[THREAD/Server::getConsoleData] " << msg << std::endl;
		_coutMtx.unlock();
	};

	std::string input;
	while (this->_active && input != "EXIT")
	{
		std::getline(std::cin, input);

		if (input == "SOCKMAP")
		{
			log("sockmap: ");
			for (const auto& item : this->_sockMap)
			{
				std::cout << "Socket: " << item.first << " --> User id: " << item.second << std::endl;
			}
		}
		else if (input == "ROOMSLST")
		{
			log("rooms: ");
			std::cout << this->_roomMgr;
		}
	}
	log("Terminating...");
	this->_active = false;
	closesocket(this->_serverSocket);
	exit(0);
}

const std::map<int, Server::handlerFunc> Server::_handlerMap =
{
	{ LOGIN_REQUEST, &Server::handlerLogin },
	{ LOGOUT_REQUEST, &Server::handlerLogout },
	{ STATISTICS_REQUEST, &Server::handlerStats },
	{ REFRESH_ROOMS, &Server::handlerRefreshRooms },
	{ CREATE_ROOM_REQUEST, &Server::handlerCreateRoom },
	{ JOIN_ROOM_REQUEST, &Server::handlerJoinRoom },
	{ LEAVE_ROOM_REQUEST, &Server::handlerLeaveRoom },
	{ UPDATE_ROOM_REQUEST, &Server::handlerUpdateRoom },
	{ REGISTER_REQUEST, &Server::handlerSignup },
	{ CLOSE_ROOM_REQUEST, &Server::handlerCloseRoom },
	{ START_GAME_REQUEST, &Server::handlerStartGame },
	{ SCORES_TABLE_REQUEST, &Server::handlerBestScores },
	{ CLOSE_PROGRAM, &Server::handlerCloseProgram },
	{ UPDATE_USER_STATS, &Server::handlerUpdateUserStats }
};