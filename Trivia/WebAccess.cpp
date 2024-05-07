#include "WebAccess.h"

#include <string>
#include <iostream>
#include <sstream>
#include <string>
#include <cstdlib>
#include "TriviaExceptions.h"

#define BUFSIZE 4096

std::string WebAccess::fetch(const std::string url)
{
    std::string response;

    try
    {
        response = captureOutput("python http_get.py \"" + url + "\"");
        if (response == "ERR!!!")
        {
            throw std::runtime_error("");
        }
    }
    catch (std::runtime_error& e)
    {
        throw GeneralTriviaException("Error: Failed to fetch " + url);
    }

    return response;
}

std::string WebAccess::urlDecode(const std::string& encodedUrl)
{
    std::stringstream decodedUrl;
    for (size_t i = 0; i < encodedUrl.length(); ++i)
    {
        if (encodedUrl[i] == '%')
        {
            int value;
            std::istringstream hex(encodedUrl.substr(i + 1, 2));
            hex >> std::hex >> value;
            decodedUrl << static_cast<char>(value);
            i += 2;
        }
        else if (encodedUrl[i] == '+')
        {
            decodedUrl << ' ';
        }
        else
        {
            decodedUrl << encodedUrl[i];
        }
    }
    return decodedUrl.str();
}

std::string WebAccess::captureOutput(const std::string cmd)
{
    std::vector<char> buffer(BUFSIZE);
    std::string result;

    std::shared_ptr<FILE> pipe(_popen(cmd.c_str(), "r"), _pclose);
    if (!pipe)
        throw std::runtime_error("popen() failed!");

    while (fgets(buffer.data(), static_cast<int>(buffer.size()), pipe.get()) != nullptr)
    {
        result += buffer.data();
    }

    return result;
}