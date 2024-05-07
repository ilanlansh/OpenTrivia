#include "TriviaExceptions.h"

GeneralTriviaException::GeneralTriviaException(const std::string& message) : _message(message)
{
}

const char* GeneralTriviaException::what() const noexcept
{
	return this->_message.c_str();
}


UserNotFoundException::UserNotFoundException(const std::string& message) : GeneralTriviaException("UserNotFoundException: " + message) {}
TriviaInvalidArgument::TriviaInvalidArgument(const std::string& message) : GeneralTriviaException("TriviaInvalidArgument: " + message) {}
TriviaSQLException::TriviaSQLException(const std::string& message) : GeneralTriviaException("TriviaSQLException: " + message) {}
SocketException::SocketException(const Socket s, const std::string& message) : GeneralTriviaException("SocketException (" + std::to_string(s) + "): " + message) {}


TriviaAPIException::TriviaAPIException(const int errorCode) : GeneralTriviaException("APIError (" + std::to_string(errorCode) + "): " + getError(errorCode)) {}
std::string TriviaAPIException::getError(const int errorCode)
{
	if (errorCode == 1)
	{
		return "Too many questions for selected category.";
	}
	else if (errorCode == 2)
	{
		return "Invalid parameter.";
	}
	else if (errorCode == 3)
	{
		return "Token not found.";
	}
	else if (errorCode == 4)
	{
		return "Token has exhausted all possible questions.";
	}
	else if (errorCode == 5)
	{
		return "Rate limit reached.Wait and try again.";
	}

	return "???";
}
