namespace TriviaClient
{
    partial class JoinRoom
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JoinRoom));
            this.Title = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.PlayersLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            this.PlayersListLabel = new System.Windows.Forms.Label();
            this.PlayerCountLabel = new System.Windows.Forms.Label();
            this.ControlLabel = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.RoomPropertiesLabel = new System.Windows.Forms.Label();
            this.GameSettingsLabel = new System.Windows.Forms.Label();
            this.HoverForCats = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Font = new System.Drawing.Font("Arial Rounded MT Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(204)))), ((int)(((byte)(148)))));
            this.Title.Location = new System.Drawing.Point(35, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(366, 74);
            this.Title.TabIndex = 0;
            this.Title.Text = "Joined Room";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(237)))));
            this.NameLabel.Location = new System.Drawing.Point(132, 72);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(173, 32);
            this.NameLabel.TabIndex = 11;
            this.NameLabel.Text = "Room Name";
            // 
            // PlayersLabel
            // 
            this.PlayersLabel.AutoSize = true;
            this.PlayersLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayersLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(237)))));
            this.PlayersLabel.Location = new System.Drawing.Point(243, 115);
            this.PlayersLabel.Name = "PlayersLabel";
            this.PlayersLabel.Size = new System.Drawing.Size(113, 32);
            this.PlayersLabel.TabIndex = 12;
            this.PlayersLabel.Text = "Players";
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.StartButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.StartButton.FlatAppearance.BorderSize = 2;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.StartButton.Image = ((System.Drawing.Image)(resources.GetObject("StartButton.Image")));
            this.StartButton.Location = new System.Drawing.Point(223, 475);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(48, 48);
            this.StartButton.TabIndex = 17;
            this.StartButton.Tag = "Start Game";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            this.StartButton.MouseHover += new System.EventHandler(this.Button_MouseHover);
            // 
            // QuitButton
            // 
            this.QuitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.QuitButton.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.QuitButton.FlatAppearance.BorderSize = 2;
            this.QuitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuitButton.Image = ((System.Drawing.Image)(resources.GetObject("QuitButton.Image")));
            this.QuitButton.Location = new System.Drawing.Point(380, 6);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(48, 48);
            this.QuitButton.TabIndex = 18;
            this.QuitButton.Tag = "Leave Room";
            this.QuitButton.UseVisualStyleBackColor = false;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            this.QuitButton.MouseHover += new System.EventHandler(this.Button_MouseHover);
            // 
            // PlayersListLabel
            // 
            this.PlayersListLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(238)))));
            this.PlayersListLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayersListLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(37)))), ((int)(((byte)(51)))));
            this.PlayersListLabel.Location = new System.Drawing.Point(187, 150);
            this.PlayersListLabel.Name = "PlayersListLabel";
            this.PlayersListLabel.Padding = new System.Windows.Forms.Padding(5);
            this.PlayersListLabel.Size = new System.Drawing.Size(223, 278);
            this.PlayersListLabel.TabIndex = 20;
            this.PlayersListLabel.Text = resources.GetString("PlayersListLabel.Text");
            this.PlayersListLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PlayerCountLabel
            // 
            this.PlayerCountLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerCountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(237)))));
            this.PlayerCountLabel.Location = new System.Drawing.Point(236, 429);
            this.PlayerCountLabel.Name = "PlayerCountLabel";
            this.PlayerCountLabel.Size = new System.Drawing.Size(121, 37);
            this.PlayerCountLabel.TabIndex = 21;
            this.PlayerCountLabel.Text = "(15 / 15)";
            this.PlayerCountLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ControlLabel
            // 
            this.ControlLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControlLabel.ForeColor = System.Drawing.Color.LightCoral;
            this.ControlLabel.Location = new System.Drawing.Point(9, 524);
            this.ControlLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ControlLabel.Name = "ControlLabel";
            this.ControlLabel.Size = new System.Drawing.Size(416, 28);
            this.ControlLabel.TabIndex = 22;
            this.ControlLabel.Text = "Error Message";
            this.ControlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.DeleteButton.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.DeleteButton.FlatAppearance.BorderSize = 2;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
            this.DeleteButton.Location = new System.Drawing.Point(160, 475);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(48, 48);
            this.DeleteButton.TabIndex = 23;
            this.DeleteButton.Tag = "Delete Room";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            this.DeleteButton.MouseHover += new System.EventHandler(this.Button_MouseHover);
            // 
            // RoomPropertiesLabel
            // 
            this.RoomPropertiesLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(180)))), ((int)(((byte)(221)))));
            this.RoomPropertiesLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomPropertiesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(37)))), ((int)(((byte)(51)))));
            this.RoomPropertiesLabel.Location = new System.Drawing.Point(18, 214);
            this.RoomPropertiesLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RoomPropertiesLabel.Name = "RoomPropertiesLabel";
            this.RoomPropertiesLabel.Size = new System.Drawing.Size(141, 190);
            this.RoomPropertiesLabel.TabIndex = 24;
            this.RoomPropertiesLabel.Text = "# of questions:\r\n5\r\n\r\nTime per Question:\r\n00:30\r\n\r\nDifficulty:\r\nMedium\r\n\r\nXX Cate" +
    "gories\r\nof Questions\r\n";
            // 
            // GameSettingsLabel
            // 
            this.GameSettingsLabel.AutoSize = true;
            this.GameSettingsLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameSettingsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(237)))));
            this.GameSettingsLabel.Location = new System.Drawing.Point(24, 191);
            this.GameSettingsLabel.Name = "GameSettingsLabel";
            this.GameSettingsLabel.Size = new System.Drawing.Size(125, 18);
            this.GameSettingsLabel.TabIndex = 25;
            this.GameSettingsLabel.Text = "Game Settings";
            // 
            // HoverForCats
            // 
            this.HoverForCats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(180)))), ((int)(((byte)(221)))));
            this.HoverForCats.Location = new System.Drawing.Point(121, 374);
            this.HoverForCats.Name = "HoverForCats";
            this.HoverForCats.Size = new System.Drawing.Size(38, 26);
            this.HoverForCats.TabIndex = 26;
            this.HoverForCats.Tag = "ctgrs";
            this.HoverForCats.Text = "hover for list";
            this.HoverForCats.MouseHover += new System.EventHandler(this.Button_MouseHover);
            // 
            // JoinRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(102)))));
            this.ClientSize = new System.Drawing.Size(434, 561);
            this.Controls.Add(this.HoverForCats);
            this.Controls.Add(this.GameSettingsLabel);
            this.Controls.Add(this.RoomPropertiesLabel);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.ControlLabel);
            this.Controls.Add(this.PlayerCountLabel);
            this.Controls.Add(this.PlayersListLabel);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.PlayersLabel);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "JoinRoom";
            this.Text = "Join Room";
            this.Load += new System.EventHandler(this.JoinRoom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label PlayersLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Label PlayersListLabel;
        private System.Windows.Forms.Label PlayerCountLabel;
        private System.Windows.Forms.Label ControlLabel;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.ToolTip Tooltip;
        private System.Windows.Forms.Label RoomPropertiesLabel;
        private System.Windows.Forms.Label GameSettingsLabel;
        private System.Windows.Forms.Label HoverForCats;
    }
}