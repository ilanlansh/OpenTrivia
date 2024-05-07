using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaClient
{
    internal class GameData
    {
        public List<GameQuestion> Questions { get; }
        public int QTime { get; }

        public GameData(JObject jsonData)
        {
            QTime = jsonData.Value<int>("qtime");
            Questions = new List<GameQuestion>();
            foreach (JObject qj in jsonData.Value<JArray>("questions"))
            {
                // For some reason, & should be escaped as &&
                Questions.Add(new GameQuestion(
                    Uri.UnescapeDataString(qj.Value<string>("question")).Replace("&", "&&"),
                    Uri.UnescapeDataString(qj.Value<string>("correct_answer")).Replace("&", "&&"),
                    Uri.UnescapeDataString(qj.Value<JArray>("incorrect_answers")[0].Value<string>()).Replace("&", "&&"),
                    Uri.UnescapeDataString(qj.Value<JArray>("incorrect_answers")[1].Value<string>()).Replace("&", "&&"),
                    Uri.UnescapeDataString(qj.Value<JArray>("incorrect_answers")[2].Value<string>()).Replace("&", "&&"),
                    qj.Value<int>("difficulty"),
                    qj.Value<int>("category")
                ));
            }
        }
    }

    internal class GameQuestion
    {
        public static string[] CategoryStrings = new string[]
        {
            "Any",
            "", "", "", "", "", "", "", "",
            "General Knowledge",
            "Books",
            "Film",
            "Music",
            "Musicals && Theatres",
            "Television",
            "Video Games",
            "Board Games",
            "Science && Nature",
            "Computers",
            "Mathematics",
            "Mythology",
            "Sports",
            "Geography",
            "History",
            "Politics",
            "Art",
            "Celebrities",
            "Animals",
            "Vehicles",
            "Comics",
            "Gadgets",
            "Japanese Anime && Manga",
            "Cartoon && Animations",
        };

        public static string[] DifficultyStrings = new string[]
        {
            "Any",
            "Easy",
            "Medium",
            "Hard"
        };

        public string Question { get; }
        public string CorrectAnswer { get; }
        public string[] IncorrectAnswers { get; }
        public int Difficulty { get; }
        public int Category { get; }
        public string DifficultyString
        {
            get => DifficultyStrings[Difficulty];
        }
        public string CategoryString
        {
            get => CategoryStrings[Category];
        }

        public GameQuestion(string qu, string ca, string i1, string i2, string i3, int df, int ct)
        {
            Question = qu;
            CorrectAnswer = ca;
            IncorrectAnswers = new string[3] { i1, i2, i3 };
            Difficulty = df;
            Category = ct;
        }
    }
}
