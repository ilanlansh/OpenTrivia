#pragma once

#include "TriviaQuestion.h"
#include <string>
#include <vector>
#include <mutex>

class WebAccess
{
public:

	static std::string fetch(const std::string url);
	static std::string urlDecode(const std::string& encodedUrl);

private:

	static std::string captureOutput(const std::string cmd);

};