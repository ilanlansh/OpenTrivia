namespace TriviaClient
{
    partial class AuthWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Thumbnail = new System.Windows.Forms.PictureBox();
            this.QuitButton = new System.Windows.Forms.Button();
            this.LoginTitle = new System.Windows.Forms.Label();
            this.LoginUsernameLabel = new System.Windows.Forms.Label();
            this.LoginPasswordLabel = new System.Windows.Forms.Label();
            this.LoginUsernameTextbox = new System.Windows.Forms.TextBox();
            this.LoginPasswordTextbox = new System.Windows.Forms.TextBox();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.LoginButton = new System.Windows.Forms.Button();
            this.ControlLabel = new System.Windows.Forms.Label();
            this.SignupPanel = new System.Windows.Forms.Panel();
            this.SignupEmailTextbox = new System.Windows.Forms.TextBox();
            this.SignupEmailLabel = new System.Windows.Forms.Label();
            this.SignupButton = new System.Windows.Forms.Button();
            this.SignupPasswordTextbox = new System.Windows.Forms.TextBox();
            this.SignupUsernameLabel = new System.Windows.Forms.Label();
            this.SignupUsernameTextbox = new System.Windows.Forms.TextBox();
            this.SignupPasswordLabel = new System.Windows.Forms.Label();
            this.SignupTitle = new System.Windows.Forms.Label();
            this.AuthPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Thumbnail)).BeginInit();
            this.LoginPanel.SuspendLayout();
            this.SignupPanel.SuspendLayout();
            this.AuthPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Thumbnail
            // 
            this.Thumbnail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Thumbnail.Image = global::TriviaClient.Properties.Resources.thumbnail;
            this.Thumbnail.Location = new System.Drawing.Point(861, 12);
            this.Thumbnail.Name = "Thumbnail";
            this.Thumbnail.Size = new System.Drawing.Size(391, 92);
            this.Thumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Thumbnail.TabIndex = 0;
            this.Thumbnail.TabStop = false;
            this.Thumbnail.Visible = false;
            // 
            // QuitButton
            // 
            this.QuitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.QuitButton.BackColor = System.Drawing.Color.Maroon;
            this.QuitButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.QuitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuitButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.QuitButton.Location = new System.Drawing.Point(1143, 616);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(109, 53);
            this.QuitButton.TabIndex = 1;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = false;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // LoginTitle
            // 
            this.LoginTitle.AutoSize = true;
            this.LoginTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(111)))), ((int)(((byte)(94)))));
            this.LoginTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.LoginTitle.Location = new System.Drawing.Point(0, 0);
            this.LoginTitle.Margin = new System.Windows.Forms.Padding(0);
            this.LoginTitle.Name = "LoginTitle";
            this.LoginTitle.Padding = new System.Windows.Forms.Padding(73, 0, 73, 0);
            this.LoginTitle.Size = new System.Drawing.Size(300, 55);
            this.LoginTitle.TabIndex = 3;
            this.LoginTitle.Text = "Login";
            this.LoginTitle.Click += new System.EventHandler(this.LoginTitle_Click);
            // 
            // LoginUsernameLabel
            // 
            this.LoginUsernameLabel.AutoSize = true;
            this.LoginUsernameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginUsernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.LoginUsernameLabel.Location = new System.Drawing.Point(236, 55);
            this.LoginUsernameLabel.Name = "LoginUsernameLabel";
            this.LoginUsernameLabel.Size = new System.Drawing.Size(145, 32);
            this.LoginUsernameLabel.TabIndex = 4;
            this.LoginUsernameLabel.Text = "username";
            // 
            // LoginPasswordLabel
            // 
            this.LoginPasswordLabel.AutoSize = true;
            this.LoginPasswordLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginPasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.LoginPasswordLabel.Location = new System.Drawing.Point(236, 168);
            this.LoginPasswordLabel.Name = "LoginPasswordLabel";
            this.LoginPasswordLabel.Size = new System.Drawing.Size(144, 32);
            this.LoginPasswordLabel.TabIndex = 5;
            this.LoginPasswordLabel.Text = "password";
            // 
            // LoginUsernameTextbox
            // 
            this.LoginUsernameTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(197)))), ((int)(((byte)(182)))));
            this.LoginUsernameTextbox.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginUsernameTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(151)))), ((int)(((byte)(117)))));
            this.LoginUsernameTextbox.Location = new System.Drawing.Point(156, 90);
            this.LoginUsernameTextbox.MaxLength = 16;
            this.LoginUsernameTextbox.Name = "LoginUsernameTextbox";
            this.LoginUsernameTextbox.Size = new System.Drawing.Size(293, 40);
            this.LoginUsernameTextbox.TabIndex = 6;
            this.LoginUsernameTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LoginPasswordTextbox
            // 
            this.LoginPasswordTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(197)))), ((int)(((byte)(182)))));
            this.LoginPasswordTextbox.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginPasswordTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(151)))), ((int)(((byte)(117)))));
            this.LoginPasswordTextbox.Location = new System.Drawing.Point(156, 203);
            this.LoginPasswordTextbox.MaxLength = 16;
            this.LoginPasswordTextbox.Name = "LoginPasswordTextbox";
            this.LoginPasswordTextbox.Size = new System.Drawing.Size(293, 40);
            this.LoginPasswordTextbox.TabIndex = 7;
            this.LoginPasswordTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LoginPanel
            // 
            this.LoginPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(111)))), ((int)(((byte)(94)))));
            this.LoginPanel.Controls.Add(this.LoginButton);
            this.LoginPanel.Controls.Add(this.LoginPasswordTextbox);
            this.LoginPanel.Controls.Add(this.LoginUsernameLabel);
            this.LoginPanel.Controls.Add(this.LoginUsernameTextbox);
            this.LoginPanel.Controls.Add(this.LoginPasswordLabel);
            this.LoginPanel.Location = new System.Drawing.Point(0, 55);
            this.LoginPanel.Margin = new System.Windows.Forms.Padding(0);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(600, 358);
            this.LoginPanel.TabIndex = 5;
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(151)))), ((int)(((byte)(117)))));
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.LoginButton.Location = new System.Drawing.Point(242, 297);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(138, 46);
            this.LoginButton.TabIndex = 8;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // ControlLabel
            // 
            this.ControlLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(111)))), ((int)(((byte)(94)))));
            this.ControlLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControlLabel.ForeColor = System.Drawing.Color.IndianRed;
            this.ControlLabel.Location = new System.Drawing.Point(0, 413);
            this.ControlLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ControlLabel.Name = "ControlLabel";
            this.ControlLabel.Size = new System.Drawing.Size(600, 31);
            this.ControlLabel.TabIndex = 11;
            this.ControlLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SignupPanel
            // 
            this.SignupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(111)))), ((int)(((byte)(94)))));
            this.SignupPanel.Controls.Add(this.SignupEmailTextbox);
            this.SignupPanel.Controls.Add(this.SignupEmailLabel);
            this.SignupPanel.Controls.Add(this.SignupButton);
            this.SignupPanel.Controls.Add(this.SignupPasswordTextbox);
            this.SignupPanel.Controls.Add(this.SignupUsernameLabel);
            this.SignupPanel.Controls.Add(this.SignupUsernameTextbox);
            this.SignupPanel.Controls.Add(this.SignupPasswordLabel);
            this.SignupPanel.Location = new System.Drawing.Point(0, 55);
            this.SignupPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SignupPanel.Name = "SignupPanel";
            this.SignupPanel.Size = new System.Drawing.Size(600, 358);
            this.SignupPanel.TabIndex = 9;
            // 
            // SignupEmailTextbox
            // 
            this.SignupEmailTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(197)))), ((int)(((byte)(182)))));
            this.SignupEmailTextbox.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignupEmailTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(151)))), ((int)(((byte)(117)))));
            this.SignupEmailTextbox.Location = new System.Drawing.Point(156, 246);
            this.SignupEmailTextbox.MaxLength = 16;
            this.SignupEmailTextbox.Name = "SignupEmailTextbox";
            this.SignupEmailTextbox.Size = new System.Drawing.Size(293, 40);
            this.SignupEmailTextbox.TabIndex = 10;
            this.SignupEmailTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SignupEmailLabel
            // 
            this.SignupEmailLabel.AutoSize = true;
            this.SignupEmailLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignupEmailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.SignupEmailLabel.Location = new System.Drawing.Point(261, 211);
            this.SignupEmailLabel.Name = "SignupEmailLabel";
            this.SignupEmailLabel.Size = new System.Drawing.Size(84, 32);
            this.SignupEmailLabel.TabIndex = 9;
            this.SignupEmailLabel.Text = "email";
            // 
            // SignupButton
            // 
            this.SignupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(151)))), ((int)(((byte)(117)))));
            this.SignupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SignupButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.SignupButton.Location = new System.Drawing.Point(242, 297);
            this.SignupButton.Name = "SignupButton";
            this.SignupButton.Size = new System.Drawing.Size(138, 46);
            this.SignupButton.TabIndex = 8;
            this.SignupButton.Text = "Signup";
            this.SignupButton.UseVisualStyleBackColor = false;
            this.SignupButton.Click += new System.EventHandler(this.SignupButton_Click);
            // 
            // SignupPasswordTextbox
            // 
            this.SignupPasswordTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(197)))), ((int)(((byte)(182)))));
            this.SignupPasswordTextbox.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignupPasswordTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(151)))), ((int)(((byte)(117)))));
            this.SignupPasswordTextbox.Location = new System.Drawing.Point(156, 153);
            this.SignupPasswordTextbox.MaxLength = 16;
            this.SignupPasswordTextbox.Name = "SignupPasswordTextbox";
            this.SignupPasswordTextbox.Size = new System.Drawing.Size(293, 40);
            this.SignupPasswordTextbox.TabIndex = 7;
            this.SignupPasswordTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SignupUsernameLabel
            // 
            this.SignupUsernameLabel.AutoSize = true;
            this.SignupUsernameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignupUsernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.SignupUsernameLabel.Location = new System.Drawing.Point(236, 27);
            this.SignupUsernameLabel.Name = "SignupUsernameLabel";
            this.SignupUsernameLabel.Size = new System.Drawing.Size(145, 32);
            this.SignupUsernameLabel.TabIndex = 4;
            this.SignupUsernameLabel.Text = "username";
            // 
            // SignupUsernameTextbox
            // 
            this.SignupUsernameTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(197)))), ((int)(((byte)(182)))));
            this.SignupUsernameTextbox.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignupUsernameTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(151)))), ((int)(((byte)(117)))));
            this.SignupUsernameTextbox.Location = new System.Drawing.Point(156, 62);
            this.SignupUsernameTextbox.MaxLength = 16;
            this.SignupUsernameTextbox.Name = "SignupUsernameTextbox";
            this.SignupUsernameTextbox.Size = new System.Drawing.Size(293, 40);
            this.SignupUsernameTextbox.TabIndex = 6;
            this.SignupUsernameTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SignupPasswordLabel
            // 
            this.SignupPasswordLabel.AutoSize = true;
            this.SignupPasswordLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignupPasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.SignupPasswordLabel.Location = new System.Drawing.Point(236, 118);
            this.SignupPasswordLabel.Name = "SignupPasswordLabel";
            this.SignupPasswordLabel.Size = new System.Drawing.Size(144, 32);
            this.SignupPasswordLabel.TabIndex = 5;
            this.SignupPasswordLabel.Text = "password";
            // 
            // SignupTitle
            // 
            this.SignupTitle.AutoSize = true;
            this.SignupTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.SignupTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignupTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.SignupTitle.Location = new System.Drawing.Point(300, 0);
            this.SignupTitle.Margin = new System.Windows.Forms.Padding(0);
            this.SignupTitle.Name = "SignupTitle";
            this.SignupTitle.Padding = new System.Windows.Forms.Padding(56, 0, 57, 0);
            this.SignupTitle.Size = new System.Drawing.Size(300, 55);
            this.SignupTitle.TabIndex = 10;
            this.SignupTitle.Text = "Signup";
            this.SignupTitle.Click += new System.EventHandler(this.SignupTitle_Click);
            // 
            // AuthPanel
            // 
            this.AuthPanel.Controls.Add(this.LoginTitle);
            this.AuthPanel.Controls.Add(this.ControlLabel);
            this.AuthPanel.Controls.Add(this.SignupTitle);
            this.AuthPanel.Controls.Add(this.SignupPanel);
            this.AuthPanel.Controls.Add(this.LoginPanel);
            this.AuthPanel.Location = new System.Drawing.Point(329, 146);
            this.AuthPanel.Name = "AuthPanel";
            this.AuthPanel.Size = new System.Drawing.Size(602, 446);
            this.AuthPanel.TabIndex = 12;
            // 
            // AuthWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.AuthPanel);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.Thumbnail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AuthWindow";
            this.Text = "Trivia Client";
            this.Load += new System.EventHandler(this.AuthWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Thumbnail)).EndInit();
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.SignupPanel.ResumeLayout(false);
            this.SignupPanel.PerformLayout();
            this.AuthPanel.ResumeLayout(false);
            this.AuthPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Thumbnail;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Label LoginTitle;
        private System.Windows.Forms.Label LoginPasswordLabel;
        private System.Windows.Forms.Label LoginUsernameLabel;
        private System.Windows.Forms.TextBox LoginPasswordTextbox;
        private System.Windows.Forms.TextBox LoginUsernameTextbox;
        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Panel SignupPanel;
        private System.Windows.Forms.TextBox SignupEmailTextbox;
        private System.Windows.Forms.Label SignupEmailLabel;
        private System.Windows.Forms.Button SignupButton;
        private System.Windows.Forms.TextBox SignupPasswordTextbox;
        private System.Windows.Forms.Label SignupUsernameLabel;
        private System.Windows.Forms.TextBox SignupUsernameTextbox;
        private System.Windows.Forms.Label SignupPasswordLabel;
        private System.Windows.Forms.Label SignupTitle;
        private System.Windows.Forms.Label ControlLabel;
        private System.Windows.Forms.Panel AuthPanel;
    }
}