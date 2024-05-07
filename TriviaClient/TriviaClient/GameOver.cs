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

namespace TriviaClient
{
    public partial class GameOver : Form
    {
        private readonly Thread timerThread;
        private bool playTimer;

        public GameOver(int totalAnswers, int correctAnswers, double totalAnsTime)
        {
            InitializeComponent();

            this.CorrectAnsData.Text = correctAnswers.ToString();
            this.IncorrectAnsData.Text = (totalAnswers - correctAnswers).ToString();
            this.AvgTPAData.Text = (totalAnsTime / totalAnswers).ToString("F2") + " sec";

            this.playTimer = true;
            this.timerThread = new Thread(new ThreadStart(this.TimerThreadFunc));
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            this.timerThread.Start();
            this.CenterToParent();
        }

        private void TimerThreadFunc()
        {
            int timer = 20_000; // milliseconds
            DateTime start = DateTime.Now;

            int delta_ms;
            do
            {
                DateTime now = DateTime.Now;
                TimeSpan delta = now.Subtract(start);
                delta_ms = (int)delta.TotalMilliseconds;
                float percentage = (float)delta_ms / timer;
                this.Invoke((MethodInvoker) delegate {
                    Size s = this.ProgBarFront.Size;
                    this.ProgBarFront.Size = new Size((int)(percentage * this.ProgBarBack.Size.Width), s.Height);
                    this.TimeLeftLabel.Text = (new TimeSpan(0, 0, 0, 1, timer) - delta).ToString("mm\\:ss");
                });
                Thread.Sleep(100);
            } while (delta_ms < timer && this.playTimer);

            // When timer is over, close window
            this.Invoke((MethodInvoker) Close);
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.timerThread.Abort();
            this.playTimer = false;
            this.Close();
        }
    }
}
