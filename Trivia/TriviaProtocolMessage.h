#pragma once

#include <string>
#include "json.hpp"
#include <vector>
#include "TriviaExceptions.h"

enum UserCodes
{
    LOGIN_REQUEST = 101,
    LOGOUT_REQUEST,
    STATISTICS_REQUEST,
    REFRESH_ROOMS,
    CREATE_ROOM_REQUEST,
    JOIN_ROOM_REQUEST,
    LEAVE_ROOM_REQUEST,
    UPDATE_ROOM_REQUEST,
    SCORES_TABLE_REQUEST,
    REGISTER_REQUEST,
    CLOSE_ROOM_REQUEST,
    START_GAME_REQUEST,
    FINISH_GAME,
    CLOSE_PROGRAM,
    UPDATE_USER_STATS
};

enum ServerCodes
{
    LOGIN_RESPONSE = 301,
    LOGOUT_RESPONSE,
    STATISTICS_RESPONSE,
    ROOMS_LIST,
    CREATE_ROOM_RESPONSE,
    JOIN_ROOM_RESPONSE,
    LEAVE_ROOM_RESPONSE,
    UPDATE_ROOM_RESPONSE,
    SCORES_TABLE,
    REGISTER_RESPONSE,
    CLOSE_ROOM_RESPONSE,
    START_GAME_RESPONSE,
    FINISH_GAME_RESPONSE,
    CLOSE_PROGRAM_RESPONSE,
    UPDATE_USER_STATS_RESPONSE
};

using json = nlohmann::json;

class TriviaProtocolMessage
{
public:

    TriviaProtocolMessage(const std::string rawEnc);
    TriviaProtocolMessage(const int code);
    TriviaProtocolMessage(const int code, const std::string data);
    TriviaProtocolMessage(const int code, const json& data);
    TriviaProtocolMessage(const int code, const std::string data, const int key);
    TriviaProtocolMessage(const int code, const json& data, const int key);
    ~TriviaProtocolMessage();

    int getCode() const;
    int getKey() const;
    std::string getDataString() const;
    json getDataJson() const;

    template <typename T>
    T getData(const std::string keyName) const;

    std::string rawDecrypted() const;
    std::string rawEncrypted() const;

    // temporary
    static TriviaProtocolMessage fromDecrypted(const std::string msgDec);

    friend std::ostream& operator<<(std::ostream& os, const TriviaProtocolMessage& tpm);
    
private:

    static const int KEY_MIN = 1;
    static const int KEY_MAX = 10;
    static const std::string DELIM;

    int _code;
    std::string _dataString;
    json _dataJson;
    int _encKey;

    std::string encryptedKey() const;
    std::string encryptedData() const;

    static int decryptKey(const std::string keyEnc);
    static std::string encryptKey(const int keyDec);
    static std::string encryptData(const std::string dataDecrypted, int key);
    static std::string decryptData(const std::string dataEncrypted, int key);

    static int genRandomKey(const int lowerBound, const int upperBound);
    static std::vector<std::string> split(const std::string str, const std::string delimiter);
};


template <typename T>
inline T TriviaProtocolMessage::getData(const std::string keyName) const
{
    try
    {
        return this->_dataJson[keyName].get<T>();
    }
    catch (std::exception& e)
    {
        throw TriviaInvalidArgument("No data member: " + keyName);
    }
}