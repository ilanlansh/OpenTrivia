#pragma once

#include <WinSock2.h>
#include <Windows.h>
#include <map>
#include <vector>
#include <mutex>
#include <thread>
#include <string>
#include "UserDatabase.h"
#include "TriviaProtocolMessage.h"
#include "RoomManager.h"

#define THREAD_FUNC void

typedef SOCKET Socket;

class Server
{
public:

	Server();
	Server(const int port);
	~Server();

	void run(const int port);

	using handlerFunc = TriviaProtocolMessage(Server::*)(const Socket, const json&);

private:

	static const std::string DATABASE_FILENAME;

	bool _active;
	Socket _serverSocket;
	UserDatabase _dataAccess;
	std::map<Socket, std::string> _sockMap;  // Socket : username
	RoomManager _roomMgr;

	static std::mutex _coutMtx;

	void acceptClient();
	THREAD_FUNC clientHandler(const Socket s);
	void sendData(const Socket s, const TriviaProtocolMessage& msg);
	void sendData(const Socket s, const std::string message);
	std::string recvData(const Socket s);

	bool isUserLoggedIn(const std::string username) const;
	bool isSocketLoggedIn(const Socket username) const;
	void doLogout(const Socket s);

	// ========== MESSAGE HANDLER FUNCS ===========
	TriviaProtocolMessage handlerLogin(const Socket s, const json& data);
	TriviaProtocolMessage handlerLogout(const Socket s, const json& data);
	TriviaProtocolMessage handlerStats(const Socket s, const json& data);
	TriviaProtocolMessage handlerRefreshRooms(const Socket s, const json& data);
	TriviaProtocolMessage handlerCreateRoom(const Socket s, const json& data);
	TriviaProtocolMessage handlerJoinRoom(const Socket s, const json& data);
	TriviaProtocolMessage handlerLeaveRoom(const Socket s, const json& data);
	TriviaProtocolMessage handlerUpdateRoom(const Socket s, const json& data);
	TriviaProtocolMessage handlerSignup(const Socket s, const json& data);
	TriviaProtocolMessage handlerCloseRoom(const Socket s, const json& data);
	TriviaProtocolMessage handlerStartGame(const Socket s, const json& data);
	TriviaProtocolMessage handlerBestScores(const Socket s, const json& data);
	TriviaProtocolMessage handlerCloseProgram(const Socket s, const json& data);
	TriviaProtocolMessage handlerUpdateUserStats(const Socket s, const json& data);

	static const std::map<int, handlerFunc> _handlerMap;

	THREAD_FUNC getConsoleData();
};