using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriviaClient
{
    public partial class CreateRoom : Form
    {
        private string username;
        private int category;
        private int difficulty;

        public CreateRoom(string username)
        {
            this.username = username;
            this.category = 0;
            this.difficulty = 0;

            InitializeComponent();
        }

        private void CreateRoom_Load(object sender, EventArgs e)
        {
            ControlLabel.Text = "";
            this.NameTextbox.Text = $"{username}'s Room";

            UpdateCategoryAndDifficultyLabels();
        }

        public void SetCategory(int category)
        {
            this.category = category;
            UpdateCategoryAndDifficultyLabels();
        }

        public void SetDifficulty(int difficulty)
        {
            this.difficulty = difficulty;
            UpdateCategoryAndDifficultyLabels();
        }

        private void UpdateCategoryAndDifficultyLabels()
        {
            this.CategoryLabel.Text = GameQuestion.CategoryStrings[this.category];
            this.DifficultyLabel.Text = GameQuestion.DifficultyStrings[this.difficulty];
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            ControlLabel.Text = "";

            int players;
            int amount;
            int time;

            if (!int.TryParse(PlayersTextbox.Text, out players))
            {
                ControlLabel.Text = "Amount of players must be a number";
                return;
            }

            if (players < 3 || players > 15)
            {
                ControlLabel.Text = "Amount of players can only be between 3 - 15";
                return;
            }

            if (!int.TryParse(NumTextBox.Text, out amount))
            {
                ControlLabel.Text = "Amount of questions must be a number";
                return;
            }

            if (amount < 5 || amount > 15)
            {
                ControlLabel.Text = "Amount of questions can only be between 5 - 15";
                return;
            }

            if (!int.TryParse(TimeTextbox.Text, out time))
            {
                ControlLabel.Text = "Time per question must be a number";
                return;
            }

            if (time < 5 || time > 90)
            {
                ControlLabel.Text = "Time per question can only be between 5 - 90 sec";
                return;
            }

            ControlLabel.Text = "Generating Questions... (This may take a while)";

            string name = NameTextbox.Text;

            TriviaProtocolMessage createRoomReq =
                new TriviaProtocolMessage(
                    UserCodes.CREATE_ROOM_REQUEST,
                    new Dictionary<string, object> {
                        { "name", name },
                        { "players", players },
                        { "time", time },
                        { "qnum", amount },
                        { "diff", this.difficulty }, // 0 - Any
                        { "cat", this.category }, // 0 - any
                    }
            );
            TriviaProtocolMessage response = Program.client.EnqueueMessage(createRoomReq);

            if (!response.GetData<bool>("success"))
            {
                ControlLabel.Text = response.GetData<string>("errmsg");
                return;
            }

            this.Close();
        }

        private void SelectDifficultyButton_Click(object sender, EventArgs e)
        {
            SelectDifficulty diffSelectPrompt = new SelectDifficulty(this, this.difficulty);
            diffSelectPrompt.ShowDialog();
        }

        private void SelectCategoryButton_Click(object sender, EventArgs e)
        {
            SelectCategory catSelectPrompt = new SelectCategory(this, this.category);
            catSelectPrompt.ShowDialog();
        }
    }
}
