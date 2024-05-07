using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TriviaClient
{
    public partial class MainWindow
    {
        private readonly Panel[] roomPanels;
        private readonly Label[] roomNameLabels;
        private readonly Label[] roomTimeLabels;
        private readonly Label[] roomPlayersLabels;
        private readonly Thread roomsListRefresherThread;
        private bool keepUpdating;

        private void RoomsListRefresherThreadFunc()
        {
            while (this.keepUpdating)
            {
                this.Invoke((MethodInvoker) RefreshRoomsList);
                Thread.Sleep(2000);
            }
        }

        private void RefreshRoomsList()
        {
            HideRooms();

            TriviaProtocolMessage getRoomsReq = new TriviaProtocolMessage(UserCodes.REFRESH_ROOMS);
            TriviaProtocolMessage response = Program.client.EnqueueMessage(getRoomsReq);

            JArray rooms = response.GetData<JArray>("rooms");
            if (rooms != null)
            {
                for (int i = 0; i < rooms.Count; i++)
                {
                    JObject roomJson = (JObject)rooms[i];
                    bool joinable = roomJson.Value<bool>("joinable");
                    string name = roomJson.Value<string>("name");
                    int qtime = roomJson.Value<int>("qtime");
                    int max_players = roomJson.Value<int>("max_players");
                    int connected_players = roomJson.Value<int>("connected_players");

                    UpdateRoom(i, joinable, name, qtime, max_players, connected_players);
                }
            }
        }

        private void UpdateRoom(int index, bool joinable, string name, int qtime, int max_players, int connected_players)
        {
            this.roomPanels[index].Visible = true;
            this.roomPanels[index].BackColor = joinable ? Color.FromArgb(192, 255, 192) : Color.FromArgb(255, 192, 192);

            this.roomNameLabels[index].Text = name;

            if (qtime != -1)
            {
                this.roomTimeLabels[index].ForeColor = Color.Black;
                TimeSpan qtimeTimespan = new TimeSpan(0, 0, qtime / 60, qtime % 60);
                this.roomTimeLabels[index].Text = qtimeTimespan.ToString("mm\\:ss");
            }
            else
            {
                this.roomTimeLabels[index].ForeColor = Color.Maroon;
                this.roomTimeLabels[index].Text = "Playing";
            }

            this.roomPlayersLabels[index].Text = $"{connected_players}/{max_players}";
            this.roomPlayersLabels[index].ForeColor = connected_players == max_players ? Color.Maroon : Color.Black;
        }

        private void HideRooms()
        {
            for (int i = 0; i < this.roomPanels.Length; i++)
            {
                roomPanels[i].Visible = false;
            }
        }

        public void ShowErr(string message)
        {
            ControlLabel.Text = message;
        }

        private void HideErr()
        {
            ShowErr(string.Empty);
        }
    }
}
