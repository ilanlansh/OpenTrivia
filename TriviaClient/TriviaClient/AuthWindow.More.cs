using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TriviaClient
{
    public partial class AuthWindow
    {
        private void ShowErr(string msg)
        {
            this.ControlLabel.Text = msg;
        }

        private void HideErr()
        {
            ShowErr("");
        }

        private void AuthenticationSuccessfulGoToMainWindowWithThisUsername(string username)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow(username);
            mainWindow.FormClosed += (s, e) => { this.Close(); };
            mainWindow.ShowDialog();
        }
    }
}
