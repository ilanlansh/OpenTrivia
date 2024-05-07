#include "TriviaProtocolMessage.h"
#include "json.hpp"
#include <random>
#include <map>

using json = nlohmann::json;

const std::string TriviaProtocolMessage::DELIM = ";;";

TriviaProtocolMessage::TriviaProtocolMessage(const std::string rawEnc)
{
    std::vector<std::string> parts = split(rawEnc, DELIM);
    
    this->_code = std::stoi(parts[0]);
    this->_encKey = decryptKey(parts[2]);
    std::string messageDataBeforeDecryption = parts[1];
    this->_dataString = decryptData(messageDataBeforeDecryption, this->_encKey);
    this->_dataJson = json::parse(this->_dataString);
}

TriviaProtocolMessage::TriviaProtocolMessage(const int code)
    : TriviaProtocolMessage(code, std::string("{}"))
{

}

TriviaProtocolMessage::TriviaProtocolMessage(const int code, const std::string data)
    : TriviaProtocolMessage(code, data, genRandomKey(KEY_MIN, KEY_MAX))
{
    
}

TriviaProtocolMessage::TriviaProtocolMessage(const int code, const json& data)
    : TriviaProtocolMessage(code, data, genRandomKey(KEY_MIN, KEY_MAX))
{

}

TriviaProtocolMessage::TriviaProtocolMessage(const int code, const std::string data, const int encKey)
    : _code(code), _dataString(data), _dataJson(json::parse(data)), _encKey(encKey)
{

}

TriviaProtocolMessage::TriviaProtocolMessage(const int code, const json& data, const int encKey)
    : _code(code), _dataJson(data), _dataString(data.dump()), _encKey(encKey)
{

}

TriviaProtocolMessage::~TriviaProtocolMessage()
{

}

int TriviaProtocolMessage::getCode() const
{
    return this->_code;
}

int TriviaProtocolMessage::getKey() const
{
    return this->_encKey;
}

std::string TriviaProtocolMessage::getDataString() const
{
    return this->_dataString;
}

json TriviaProtocolMessage::getDataJson() const
{
    return this->_dataJson;
}

std::string TriviaProtocolMessage::rawDecrypted() const
{
    return std::to_string(this->_code) + DELIM + this->_dataString + DELIM + std::to_string(this->_encKey);
}

std::string TriviaProtocolMessage::rawEncrypted() const
{
    return std::to_string(this->_code) + DELIM + encryptedData() + DELIM + encryptedKey();
}

TriviaProtocolMessage TriviaProtocolMessage::fromDecrypted(const std::string msgDec)
{
    std::vector<std::string> parts = split(msgDec, DELIM);

    int code = std::stoi(parts[0]);
    std::string dataString = parts[1];
    int encKey = std::stoi(parts[2]);

    return TriviaProtocolMessage(code, dataString, encKey);
}

int TriviaProtocolMessage::decryptKey(const std::string keyEnc)
{
    static std::map<std::string, int> wordMap = { //the number as words after base 64
        { "b25lCg==", 1 },
        { "dHdvCg==", 2 },
        { "dGhyZWUKCg==", 3 },
        { "Zm91cgoK", 4 },
        { "Zml2ZQoK", 5 },
        { "c2l4", 6 },
        { "c2V2ZW4=", 7 },
        { "ZWlnaHQ=", 8 },
        { "bmluZQ==", 9 },
        { "dGVu", 10 }
    };

    return wordMap[keyEnc];
}

std::string TriviaProtocolMessage::encryptKey(const int keyDec)
{
    static std::map<int, std::string> wordMap = { //the number as words after base 64
        { 1, "b25lCg==" },
        { 2, "dHdvCg==" },
        { 3, "dGhyZWUKCg==" },
        { 4, "Zm91cgoK" },
        { 5, "Zml2ZQoK" },
        { 6, "c2l4" },
        { 7, "c2V2ZW4=" },
        { 8, "ZWlnaHQ=" },
        { 9, "bmluZQ==" },
        { 10, "dGVu" }
    };

    return wordMap[keyDec];
}

std::string TriviaProtocolMessage::encryptData(const std::string data, int key)
{
    std::string result = data;

    for (char& c : result) {
        if (std::isalpha(c)) {
            char base = std::isupper(c) ? 'A' : 'a';
            c = ((c - base + key) % 26) + base;
            key++;
        }
    }

    return result;
}

std::string TriviaProtocolMessage::decryptData(const std::string data, int key)
{
    std::string result = data;

    for (char& c : result) {
        if (std::isalpha(c)) {
            char base = std::isupper(c) ? 'Z' : 'z';
            c = ((c - base - key) % 26) + base;
            key++;
        }
    }

    return result;
}

int TriviaProtocolMessage::genRandomKey(const int lowerBound, const int upperBound)
{
    std::random_device rd;
    std::mt19937 gen(rd());

    // Create a uniform distribution for random numbers within the defined range
    std::uniform_int_distribution<> dis(lowerBound, upperBound);

    // Generate a random number
    int key = dis(gen);

    return key;
}

std::string TriviaProtocolMessage::encryptedKey() const
{
    return encryptKey(this->_encKey);
}

std::string TriviaProtocolMessage::encryptedData() const
{
    return encryptData(this->_dataString, this->_encKey);
}

std::vector<std::string> TriviaProtocolMessage::split(const std::string str, const std::string delimiter)
{
    std::vector<std::string> parts;
    std::string message = str;

    size_t pos = 0;
    while ((pos = message.find(delimiter)) != std::string::npos) {
        std::string part = message.substr(0, pos);
        parts.push_back(part);
        message.erase(0, pos + delimiter.length());
    }
    parts.push_back(message);

    return parts;
}

std::ostream& operator<<(std::ostream& os, const TriviaProtocolMessage& tpm)
{
    return os << tpm.rawDecrypted();
}
