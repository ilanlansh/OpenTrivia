using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TriviaClient
{
    public partial class TheGame : Form
    {
        private GameData gameData;

        public TheGame(JObject jsonGameData)
        {
            InitializeComponent();

            this.gameData = new GameData(jsonGameData);
            this.currentQuestionIndex = 0;
            this.correctAnswers = 0;
            this.answerButtons = new Button[4] { this.AnswerButton_1, this.AnswerButton_2, this.AnswerButton_3, this.AnswerButton_4 };
            this.playTimer = true;
            this.timerPassedQuestion = false;
        }

        private void TheGame_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            this.AnswerButton_1.FlatAppearance.BorderSize = 0;
            this.AnswerButton_2.FlatAppearance.BorderSize = 0;
            this.AnswerButton_3.FlatAppearance.BorderSize = 0;
            this.AnswerButton_4.FlatAppearance.BorderSize = 0;

            PromptQuestion();
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            this.playTimer = false;
            this.totalTime += this.delta.TotalSeconds;

            Button button = (Button)sender;
            Button correctButton = CorrectAnswerButton();

            if (this.timerPassedQuestion)
            {
                button.FlatAppearance.BorderColor = Color.OrangeRed;
                button.FlatAppearance.BorderSize = 5;
            }
            else
            {
                string clickedAnswer = button.Text;

                button.FlatAppearance.BorderColor = Color.Red;
                button.FlatAppearance.BorderSize = 5;

                correctButton.FlatAppearance.BorderColor = Color.Green;
                correctButton.FlatAppearance.BorderSize = 5;

                bool correct = clickedAnswer == this.gameData.Questions[currentQuestionIndex].CorrectAnswer;
                if (correct) this.correctAnswers++;
            }

            this.Update();
            Thread.Sleep(3000);

            button.FlatAppearance.BorderSize = 0;
            correctButton.FlatAppearance.BorderSize = 0;

            this.timerPassedQuestion = false;

            this.currentQuestionIndex++;
            if (!PromptQuestion())
            {
                ThisGameHasFinished();
            }
        }

        private void QuestionLabel_TextChanged(object sender, EventArgs e)
        {
            Font f = QuestionLabel.Font;
            if (QuestionLabel.Text.Length > 52)
            {
                QuestionLabel.Font = new Font(f.Name, 18, f.Unit);
            }
            else
            {
                QuestionLabel.Font = new Font(f.Name, 24, f.Unit);
            }
        }

        private void AnswerButton_TextChanged(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Font f = btn.Font;
            if (btn.Text.Length > 25)
            {
                btn.Font = new Font(f.Name, 10, f.Unit);
            }
            else
            {
                btn.Font = new Font(f.Name, 14, f.Unit);
            }
        }

        private void TheGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.playTimer = false;
            this.timerThread?.Abort();
        }
    }
}