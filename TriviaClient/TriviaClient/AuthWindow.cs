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
    public partial class AuthWindow : Form
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void AuthWindow_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            this.LoginPanel.Visible = true;
            this.SignupPanel.Visible = false;

            this.FormClosed += (s, ev) => { Environment.Exit(0); };
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            TriviaProtocolMessage quitMsg = new TriviaProtocolMessage(UserCodes.CLOSE_PROGRAM);
            Program.client.EnqueueMessage(quitMsg);
            this.Close();
        }

        private void LoginTitle_Click(object sender, EventArgs e)
        {
            HideErr();
            this.SignupPanel.Visible = false;
            this.LoginPanel.Visible = true;
            this.SignupTitle.BackColor = Color.FromArgb(49, 91, 83);
            this.LoginTitle.BackColor = Color.FromArgb(55, 111, 94);
        }

        private void SignupTitle_Click(object sender, EventArgs e)
        {
            HideErr();
            this.LoginPanel.Visible = false;
            this.SignupPanel.Visible = true;
            this.LoginTitle.BackColor = Color.FromArgb(49, 91, 83);
            this.SignupTitle.BackColor = Color.FromArgb(55, 111, 94);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.LoginButton.Enabled = false;

            HideErr();

            string username = this.LoginUsernameTextbox.Text;
            string password = this.LoginPasswordTextbox.Text;

            if (!Client.ValidUsername(username))
            {
                ShowErr("Invalid username format");
                this.LoginButton.Enabled = true;
                return;
            }

            if (!Client.ValidPassword(password))
            {
                ShowErr("Invalid password format");
                this.LoginButton.Enabled = true;
                return;
            }

            TriviaProtocolMessage loginMsg =
                new TriviaProtocolMessage(
                    UserCodes.LOGIN_REQUEST,
                    new Dictionary<string, object> {
                        { "username", username },
                        { "password", password }
                    }
                );
            
            TriviaProtocolMessage response = Program.client.EnqueueMessage(loginMsg);

            if (response.GetData<bool>("success"))
            {
                AuthenticationSuccessfulGoToMainWindowWithThisUsername(username);
            }
            else
            {
                ShowErr(response.GetData<string>("errmsg"));
            }

            this.LoginButton.Enabled = true;
        }

        private void SignupButton_Click(object sender, EventArgs e)
        {
            this.SignupButton.Enabled = false;

            HideErr();

            string username = this.SignupUsernameTextbox.Text;
            string password = this.SignupPasswordTextbox.Text;
            string email = this.SignupEmailTextbox.Text;

            if (!Client.ValidUsername(username))
            {
                ShowErr("Invalid username format");
                this.SignupButton.Enabled = true;
                return;
            }

            if (!Client.ValidPassword(password))
            {
                ShowErr("Invalid password format");
                this.SignupButton.Enabled = true;
                return;
            }

            if (!Client.ValidEmail(email))
            {
                ShowErr("Invalid email format");
                this.SignupButton.Enabled = true;
                return;
            }

            TriviaProtocolMessage signupMsg =
                new TriviaProtocolMessage(
                    UserCodes.REGISTER_REQUEST,
                    new Dictionary<string, object> {
                        { "username", username },
                        { "password", password },
                        { "email", email }
                    }
                );
            
            TriviaProtocolMessage response = Program.client.EnqueueMessage(signupMsg);

            if (response.GetData<bool>("success"))
            {
                AuthenticationSuccessfulGoToMainWindowWithThisUsername(username);
            }
            else
            {
                ShowErr("Username already taken");
            }

            this.SignupButton.Enabled = true;
        }
    }
}
