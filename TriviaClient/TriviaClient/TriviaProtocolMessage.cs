using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TriviaClient
{

    public sealed class UserCodes
    {
        public const int LOGIN_REQUEST        = 101;
        public const int LOGOUT_REQUEST       = 102;
        public const int STATISTICS_REQUEST   = 103;
        public const int REFRESH_ROOMS        = 104;
        public const int CREATE_ROOM_REQUEST  = 105;
        public const int JOIN_ROOM_REQUEST    = 106;
        public const int LEAVE_ROOM_REQUEST   = 107;
        public const int UPDADE_ROOM_REQUEST  = 108;
        public const int SCORES_TABLE_REQUEST = 109;
        public const int REGISTER_REQUEST     = 110;
        public const int CLOSE_ROOM_REQUEST   = 111;
        public const int START_GAME_REQUEST   = 112;
        public const int FINISH_GAME          = 113;
        public const int CLOSE_PROGRAM        = 114;
        public const int UPDATE_USER_STATS    = 115;
    }


    public class TriviaProtocolMessage
    {
        private const int KEY_MIN = 1;
        private const int KEY_MAX = 10;
        private const string DELIM = ";;";

        private static readonly Dictionary<string, int> wordMap = new Dictionary<string, int>
        {
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

        private static readonly Dictionary<int, string> numberMap = new Dictionary<int, string>
        {
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

        public int Code { get; }
        public int Key { get; }
        public string DataString { get; }
        public Dictionary<string, object> DataJson { get; }

        public TriviaProtocolMessage(string rawEnc)
        {
            string[] parts = Split(rawEnc, DELIM);
            Code = int.Parse(parts[0]);
            Key = DecryptKey(parts[2]);
            string messageDataBeforeDecryption = parts[1];
            DataString = DecryptData(messageDataBeforeDecryption, Key);
            DataJson = JsonConvert.DeserializeObject<Dictionary<string, object>>(DataString);
        }

        public TriviaProtocolMessage(int code)
            : this(code, "{}")
        {

        }

        public TriviaProtocolMessage(int code, string data)
            : this(code, data, GenRandomKey(KEY_MIN, KEY_MAX))
        {

        }

        public TriviaProtocolMessage(int code, Dictionary<string, object> data)
            : this(code, data, GenRandomKey(KEY_MIN, KEY_MAX))
        {

        }

        public TriviaProtocolMessage(int code, string data, int encKey)
        {
            Code = code;
            DataString = data;
            DataJson = JsonConvert.DeserializeObject<Dictionary<string, object>>(data);
            Key = encKey;
        }

        public TriviaProtocolMessage(int code, Dictionary<string, object> data, int encKey)
        {
            Code = code;
            DataJson = data;
            DataString = JsonConvert.SerializeObject(data);
            Key = encKey;
        }

        public T GetData<T>(string keyName)
        {
            if (DataJson.TryGetValue(keyName, out object value))
                return (T)value;

            throw new ArgumentException("No data member: " + keyName);
        }

        public string RawDecrypted()
        {
            return Code + DELIM + DataString + DELIM + Key;
        }

        public string RawEncrypted()
        {
            return Code + DELIM + EncryptedData() + DELIM + EncryptedKey();
        }

        public static TriviaProtocolMessage FromDecrypted(string msgDec)
        {
            string[] parts = Split(msgDec, DELIM);

            int code = int.Parse(parts[0]);
            string dataString = parts[1];
            int encKey = int.Parse(parts[2]);

            return new TriviaProtocolMessage(code, dataString, encKey);
        }

        private static int DecryptKey(string keyEnc)
        {
            if (wordMap.TryGetValue(keyEnc, out int keyDec))
                return keyDec;

            throw new ArgumentException("Invalid keyEnc: " + keyEnc);
        }

        private static string EncryptKey(int keyDec)
        {
            if (numberMap.TryGetValue(keyDec, out string keyEnc))
                return keyEnc;

            throw new ArgumentException("Invalid keyDec: " + keyDec);
        }

        private static string EncryptData(string data, int key)
        {
            char[] result = data.ToCharArray();

            for (int i = 0; i < result.Length; i++)
            {
                char c = result[i];
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    result[i] = (char)(((c - baseChar + key) % 26) + baseChar);
                    key++;
                }
            }

            return new string(result);
        }

        private static string DecryptData(string data, int key)
        {
            char[] result = data.ToCharArray();

            for (int i = 0; i < result.Length; i++)
            {
                char c = result[i];
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'Z' : 'z';
                    result[i] = (char)(((c - baseChar - key) % 26) + baseChar);
                    key++;
                }
            }

            return new string(result);
        }

        private static int GenRandomKey(int lowerBound, int upperBound)
        {
            Random random = new Random();
            return random.Next(lowerBound, upperBound + 1);
        }

        private string EncryptedKey()
        {
            return EncryptKey(Key);
        }

        private string EncryptedData()
        {
            return EncryptData(DataString, Key);
        }

        private static string[] Split(string str, string delimiter)
        {
            return str.Split(new[] { delimiter }, StringSplitOptions.None);
        }

        public override string ToString()
        {
            return RawDecrypted();
        }
    }

}
