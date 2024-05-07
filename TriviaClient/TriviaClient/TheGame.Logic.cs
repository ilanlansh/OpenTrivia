using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriviaClient
{
    public partial class TheGame
    {
        private Button[] answerButtons;
        private int currentQuestionIndex;
        private int correctAnswers;
        private double totalTime;

        private Thread timerThread;
        private bool playTimer;
        private bool timerPassedQuestion;
        private TimeSpan delta;

        private void TimerThreadFunc()
        {
            int timer = this.gameData.QTime * 1000; // milliseconds
            DateTime start = DateTime.Now;

            int delta_ms;
            do
            {
                DateTime now = DateTime.Now;
                this.delta = now.Subtract(start);
                delta_ms = (int)this.delta.TotalMilliseconds;
                float percentage = (float)delta_ms / timer;
                this.Invoke((MethodInvoker)delegate {
                    Size s = this.ProgBarFront.Size;
                    this.ProgBarFront.Size = new Size((int)(percentage * this.ProgBarBack.Size.Width), s.Height);
                    this.TimeLeftLabel.Text = (new TimeSpan(0, 0, 0, 1, timer) - this.delta).ToString("mm\\:ss");
                });
                Thread.Sleep(100);
            } while (delta_ms < timer && playTimer);

            // When timer is over, click button
            if (playTimer)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.timerPassedQuestion = true;
                    this.AnswerButton_Click(this.CorrectAnswerButton(), new EventArgs());
                }));
            }
        }

        private bool PromptQuestion()
        {
            this.timerThread?.Abort();

            GameQuestion cq;
            try
            {
                cq = this.gameData.Questions[currentQuestionIndex];
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }

            this.playTimer = true;
            this.timerThread = new Thread(new ThreadStart(this.TimerThreadFunc));
            this.timerThread.Start();

            List<string> answers = (List<string>) Shuffle(new List<string> { cq.CorrectAnswer, cq.IncorrectAnswers[0], cq.IncorrectAnswers[1], cq.IncorrectAnswers[2] });

            QuestionNumberLabel.Text = $"{currentQuestionIndex + 1} / {this.gameData.Questions.Count}";
            QuestionLabel.Text = cq.Question;
            answerButtons[0].Text = answers[0];
            answerButtons[1].Text = answers[1];
            answerButtons[2].Text = answers[2];
            answerButtons[3].Text = answers[3];
            DifficultyLabel.Text = cq.DifficultyString;
            CategoryLabel.Text = cq.CategoryString;

            return true;
        }

        private static IList<T> Shuffle<T>(IList<T> list)
        {
            Random rng = new Random();

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (list[n], list[k]) = (list[k], list[n]);
            }

            return list;
        }

        private Button CorrectAnswerButton()
        {
            foreach (Button b in this.answerButtons)
            {
                if (b.Text == this.gameData.Questions[this.currentQuestionIndex].CorrectAnswer)
                {
                    return b;
                }
            }

            return null;
        }

        private void ThisGameHasFinished()
        {
            foreach (var b in this.answerButtons)
            {
                b.Visible = false;
            }
            this.CategoryTitleLabel.Visible = false;
            this.CategoryLabel.Visible = false;
            this.DifficultyTitleLabel.Visible = false;
            this.DifficultyLabel.Visible = false;
            this.QuestionNumberTitle.Visible = false;
            this.QuestionNumberLabel.Visible = false;
            this.ProgBarBack.Visible = false;
            this.ProgBarFront.Visible = false;
            this.TimeLeftLabel.Visible = false;
            this.QuestionLabel.Text = "Thx for Playing :P";
            Point newLocation = new Point(this.QuestionLabel.Location.X, 0);
            this.QuestionLabel.Location = newLocation;

            TriviaProtocolMessage updateStatsReq = new TriviaProtocolMessage(
                UserCodes.UPDATE_USER_STATS,
                new Dictionary<string, object>
                {
                    { "correct", this.correctAnswers },
                    { "incorrect", this.gameData.Questions.Count - this.correctAnswers },
                    { "time", (int)this.totalTime }
                }
            );
            Program.client.EnqueueMessage(updateStatsReq);

            GameOver gameOver = new GameOver(this.gameData.Questions.Count, this.correctAnswers, this.totalTime);
            gameOver.FormClosed += (s, e) => { this.Close(); };
            gameOver.ShowDialog();

            // Send message to server with gameover data
        }
    }
}