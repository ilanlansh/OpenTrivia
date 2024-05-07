using Newtonsoft.Json.Linq;
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
    public partial class MainWindow : Form
    {
        private string activeUsername;

        public MainWindow(string activeUsername)
        {
            this.activeUsername = activeUsername;

            InitializeComponent();

            this.roomPanels = new Panel[7] { this.RoomPanel_1, this.RoomPanel_2, this.RoomPanel_3, this.RoomPanel_4, this.RoomPanel_5, this.RoomPanel_6, this.RoomPanel_7 };

            this.roomNameLabels = new Label[7] { this.RoomNameLabel_1, this.RoomNameLabel_2, this.RoomNameLabel_3, this.RoomNameLabel_4, this.RoomNameLabel_5, this.RoomNameLabel_6, this.RoomNameLabel_7 };

            this.roomTimeLabels = new Label[7] { this.RoomTimeLabel_1, this.RoomTimeLabel_2, this.RoomTimeLabel_3, this.RoomTimeLabel_4, this.RoomTimeLabel_5, this.RoomTimeLabel_6, this.RoomTimeLabel_7 };

            this.roomPlayersLabels = new Label[7] { this.RoomPlayersLabel_1, this.RoomPlayersLabel_2, this.RoomPlayersLabel_3, this.RoomPlayersLabel_4, this.RoomPlayersLabel_5, this.RoomPlayersLabel_6, this.RoomPlayersLabel_7 };

            this.keepUpdating = true;
            this.roomsListRefresherThread = new Thread(new ThreadStart(RoomsListRefresherThreadFunc));
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            HideErr();

            this.Text += $"({this.activeUsername})";
            this.HelloUser.Text += this.activeUsername;

            this.TopScores.Text = string.Empty;
            this.TopScores.Visible = false;

            this.Statistics.Text = string.Empty;
            this.Statistics.Visible = false;

            this.roomsListRefresherThread.Start();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            // stop updating rooms
            this.keepUpdating = false;

            // logout
            TriviaProtocolMessage logoutMsg = new TriviaProtocolMessage(UserCodes.LOGOUT_REQUEST);
            Program.client.EnqueueMessage(logoutMsg);

            // quit
            TriviaProtocolMessage quitMsg = new TriviaProtocolMessage(UserCodes.CLOSE_PROGRAM);
            Program.client.EnqueueMessage(quitMsg);
            this.Close();
        }

        private void TopScoresButton_Click(object sender, EventArgs e)
        {
            this.Statistics.Visible = false;
            this.TopScores.Visible = true;

            TriviaProtocolMessage topScoresReq = new TriviaProtocolMessage(
                UserCodes.SCORES_TABLE_REQUEST, new Dictionary<string, object> { { "amount", 5 } }
            );
            TriviaProtocolMessage response = Program.client.EnqueueMessage(topScoresReq);

            // WHAT THE FUCK
            var topScoresData = from entry in response.DataJson orderby entry.Value descending select entry;
            
            this.TopScores.Text = string.Empty;
            int i = 1;
            foreach (var item in topScoresData)
            {
                if (this.TopScores.Text != string.Empty) this.TopScores.Text += "\n\n";

                this.TopScores.Text += $"#{i} - {item.Key} : {item.Value}";
                i++;
            }
        }

        private void StatsButton_Click(object sender, EventArgs e)
        {
            this.TopScores.Visible = false;
            this.Statistics.Visible = true;

            TriviaProtocolMessage statsReq = new TriviaProtocolMessage(UserCodes.STATISTICS_REQUEST);
            TriviaProtocolMessage response = Program.client.EnqueueMessage(statsReq);
            var statsData = response.DataJson;
            this.Statistics.Text = string.Empty;
            this.Statistics.Text += $"Num of games: {statsData["gn"]}\n\n";
            this.Statistics.Text += $"Correct answers: {statsData["rn"]}\n\n";
            this.Statistics.Text += $"Inorrect answers: {statsData["wn"]}\n\n";
            this.Statistics.Text += $"Avg time per answer: {(double)statsData["at"]:F2} sec";
        }

        private void TopScoresLabel_Click(object sender, EventArgs e)
        {
            TopScoresButton_Click(sender, e);
        }

        private void StatsLabel_Click(object sender, EventArgs e)
        {
            StatsButton_Click(sender, e);
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            TriviaProtocolMessage logoutMsg = new TriviaProtocolMessage(UserCodes.LOGOUT_REQUEST);
            Program.client.EnqueueMessage(logoutMsg);
            this.Close();
            AuthWindow authWindow = new AuthWindow();
            authWindow.ShowDialog();
        }

        private void RoomsRefreshButton_Click(object sender, EventArgs e)
        {
            RefreshRoomsList();
        }

        private void RoomsAddButton_Click(object sender, EventArgs e)
        {
            CreateRoom createRoom = new CreateRoom(activeUsername);
            createRoom.FormClosed += (s, ev) => { this.RefreshRoomsList(); };
            createRoom.ShowDialog();
        }

        private void RoomPanel_MouseClick(object sender, MouseEventArgs e)
        {
            ShowErr("Double click a room to join");
        }

        private void RoomPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            HideErr();

            int roomIndex = (sender as Control).Name.Last() - '0' - 1;
            string roomName = this.roomNameLabels[roomIndex].Text;

            TriviaProtocolMessage joinRoomRequest = new TriviaProtocolMessage(
                UserCodes.JOIN_ROOM_REQUEST,
                new Dictionary<string, object> {
                    { "room_name", roomName }
                }
            );

            TriviaProtocolMessage response = Program.client.EnqueueMessage(joinRoomRequest);
            ShowErr(response.GetData<string>("errmsg"));

            if (response.GetData<bool>("success"))
            {
                RefreshRoomsList();

                JoinRoom joinRoom = new JoinRoom(this, roomName, response.GetData<string>("creator") == this.activeUsername);
                joinRoom.FormClosed += (s, ev) =>
                {
                    TriviaProtocolMessage leaveRoomRequest = new TriviaProtocolMessage(
                        UserCodes.LEAVE_ROOM_REQUEST,
                        new Dictionary<string, object> {
                            { "room_name", roomName },
                        }
                    );
                    TriviaProtocolMessage leaveRoomResponse = Program.client.EnqueueMessage(leaveRoomRequest);
                };
                joinRoom.ShowDialog();
            }

            RefreshRoomsList();
        }

        private void Button_MouseHover(object sender, EventArgs e)
        {
            this.Tooltip.Show((sender as Button).Tag as string, (IWin32Window)sender);
        }
    }
}
