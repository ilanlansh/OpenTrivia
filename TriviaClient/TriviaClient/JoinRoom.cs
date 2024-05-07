using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
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
    public partial class JoinRoom : Form
    {
        private readonly MainWindow context;
        private readonly string roomName;
        private readonly bool creator;
        private bool keepUpdating;
        private readonly Thread roomUpdaterThread;

        public JoinRoom(MainWindow context, string roomName, bool creator)
        {
            InitializeComponent();
            this.context = context;
            this.roomName = roomName;
            this.creator = creator;

            this.keepUpdating = true;
            this.roomUpdaterThread = new Thread(new ThreadStart(this.RoomUpdaterThreadFunc));
        }

        private void JoinRoom_Load(object sender, EventArgs e)
        {
            this.Text += " " + this.roomName;
            this.NameLabel.Text = this.roomName;
            this.StartButton.Visible = this.creator;
            this.DeleteButton.Visible = this.creator;

            this.ControlLabel.Text = this.creator ? "" : "Only room creator can start the game";

            UpdateRoom();

            this.roomUpdaterThread.Start();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.keepUpdating = false;
            this.roomUpdaterThread.Join();
            this.Close();
        }

        private void RoomUpdaterThreadFunc()
        {
            while (this.keepUpdating)
            {
                this.Invoke((MethodInvoker) UpdateRoom);
                Thread.Sleep(2000);
            }
        }

        private void UpdateRoom()
        {

            TriviaProtocolMessage updateRoom = new TriviaProtocolMessage(
                UserCodes.UPDADE_ROOM_REQUEST,
                new Dictionary<string, object> {
                    { "room_name", this.roomName }
                }
            );
            TriviaProtocolMessage response = Program.client.EnqueueMessage(updateRoom);

            this.PlayersListLabel.Text = "";
            this.PlayerCountLabel.Text = "";

            if (response.GetData<bool>("game_cancelled"))
            {
                context.ShowErr($"{this.roomName} has been deleted");
                this.keepUpdating = false;
                this.Close();
            }
            else
            {
                foreach (var item in response.GetData<JArray>("player_names"))
                {
                    this.PlayersListLabel.Text += item.Value<string>() + '\n';
                }

                int con = response.GetData<JArray>("player_names").Count();
                long max = response.GetData<long>("max_players");
                this.PlayerCountLabel.Text = $"({con} / {max})";

                UpdateRoomPropertiesLabel(response);

                if (response.GetData<bool>("game_start"))
                {
                    this.keepUpdating = false;
                    JObject jsonGameData = response.GetData<JObject>("game_data");
                    StartTheGame(jsonGameData);
                }
            }
        }

        private void UpdateRoomPropertiesLabel(TriviaProtocolMessage response)
        {
            RoomPropertiesLabel.Text = "";
            string rplText = "";

            rplText += "# of questions:\n";
            rplText += $"{response.GetData<long>("qnum")}\n\n";
            
            rplText += "Time per Question:\n";
            int qtime = (int)response.GetData<long>("qtime");
            TimeSpan qtimeTimespan = new TimeSpan(0, 0, qtime / 60, qtime % 60);
            rplText += qtimeTimespan.ToString("mm\\:ss");
            rplText += "\n\n";

            long diff = response.GetData<long>("diff");
            rplText += $"Difficulty:\n{GameQuestion.DifficultyStrings[diff]}\n\n";

            JArray cats = response.GetData<JArray>("cats");
            rplText += $"{cats.Count} Categories\nof Questions";

            RoomPropertiesLabel.Text = rplText;

            HoverForCats.Tag = "";
            foreach (JToken c in cats)
            {
                string cat = GameQuestion.CategoryStrings[c.Value<int>()];
                HoverForCats.Tag += cat.Replace("&&", "&") + "\n";
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            TriviaProtocolMessage startGameRequest = new TriviaProtocolMessage(
                UserCodes.START_GAME_REQUEST,
                new Dictionary<string, object> {
                    { "room_name", this.roomName }
                }
            );
            Program.client.EnqueueMessage(startGameRequest);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            TriviaProtocolMessage closeRoomRequest = new TriviaProtocolMessage(
                UserCodes.CLOSE_ROOM_REQUEST,
                new Dictionary<string, object> {
                    { "room_name", this.roomName }
                }
            );
            Program.client.EnqueueMessage(closeRoomRequest);
        }

        private void Button_MouseHover(object sender, EventArgs e)
        {
            this.Tooltip.Show((sender as Control).Tag as string, (IWin32Window)sender);
        }

        private void StartTheGame(JObject jsonGameData)
        {
            TheGame theGame = new TheGame(jsonGameData);
            theGame.FormClosed += (sender, e) =>
            {
                // When TheGame window closes, take player out of the room
                TriviaProtocolMessage leaveRoomRequest = new TriviaProtocolMessage(
                    UserCodes.LEAVE_ROOM_REQUEST,
                    new Dictionary<string, object> {
                        { "room_name", roomName },
                    }
                );
                TriviaProtocolMessage leaveRoomResponse = Program.client.EnqueueMessage(leaveRoomRequest);

                // If TheGame window closes, and there are no players left in the room, remove it
                TriviaProtocolMessage updateRoom = new TriviaProtocolMessage(
                    UserCodes.UPDADE_ROOM_REQUEST,
                    new Dictionary<string, object> {
                        { "room_name", this.roomName }
                    }
                );
                TriviaProtocolMessage response = Program.client.EnqueueMessage(updateRoom);

                if (response.GetData<JArray>("player_names").Count == 0)
                {
                    TriviaProtocolMessage closeRoomRequest = new TriviaProtocolMessage(
                        UserCodes.CLOSE_ROOM_REQUEST,
                        new Dictionary<string, object> {
                            { "room_name", this.roomName }
                        }
                    );
                    Program.client.EnqueueMessage(closeRoomRequest);
                }

                this.Close();
            };
            this.Hide();
            theGame.ShowDialog();
        }
    }
}