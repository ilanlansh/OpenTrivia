#pragma once

#include <exception>
#include <string>

typedef unsigned long long Socket;

class GeneralTriviaException : public std::exception
{
public:

	GeneralTriviaException(const std::string& message);
	virtual ~GeneralTriviaException() noexcept = default;

	virtual const char* what() const noexcept;

protected:

	std::string _message;
};

class UserNotFoundException : public GeneralTriviaException
{
public:

	UserNotFoundException(const std::string& message);
	virtual ~UserNotFoundException() noexcept = default;
};

class TriviaInvalidArgument : public GeneralTriviaException
{
public:

	TriviaInvalidArgument(const std::string& message);
	virtual ~TriviaInvalidArgument() noexcept = default;
};

class TriviaSQLException : public GeneralTriviaException
{
public:

	TriviaSQLException(const std::string& message);
	virtual ~TriviaSQLException() noexcept = default;
};

class TriviaAPIException : public GeneralTriviaException
{
public:

	TriviaAPIException(const int errorCode);
	virtual ~TriviaAPIException() noexcept = default;

private:

	static std::string getError(const int errorCode);
};

class SocketException : public GeneralTriviaException
{
public:

	SocketException(const Socket s, const std::string& message);
	virtual ~SocketException() noexcept = default;
};
