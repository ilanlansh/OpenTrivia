namespace TriviaClient
{
    partial class CreateRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateRoom));
            this.Title = new System.Windows.Forms.Label();
            this.TimeTextbox = new System.Windows.Forms.TextBox();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.PlayersTextbox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextbox = new System.Windows.Forms.TextBox();
            this.PlayersLabel = new System.Windows.Forms.Label();
            this.CreateButton = new System.Windows.Forms.Button();
            this.ControlLabel = new System.Windows.Forms.Label();
            this.NumTextBox = new System.Windows.Forms.TextBox();
            this.NumLabel = new System.Windows.Forms.Label();
            this.SelectDifficultyButton = new System.Windows.Forms.Button();
            this.SelectCategoryButton = new System.Windows.Forms.Button();
            this.DifficultyLabel = new System.Windows.Forms.Label();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.QuitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Font = new System.Drawing.Font("Arial Rounded MT Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(204)))), ((int)(((byte)(148)))));
            this.Title.Location = new System.Drawing.Point(35, 45);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(366, 74);
            this.Title.TabIndex = 0;
            this.Title.Text = "Create Room";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimeTextbox
            // 
            this.TimeTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(238)))));
            this.TimeTextbox.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(102)))));
            this.TimeTextbox.Location = new System.Drawing.Point(310, 297);
            this.TimeTextbox.MaxLength = 2;
            this.TimeTextbox.Name = "TimeTextbox";
            this.TimeTextbox.Size = new System.Drawing.Size(67, 40);
            this.TimeTextbox.TabIndex = 16;
            this.TimeTextbox.Text = "30";
            this.TimeTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(237)))));
            this.TimeLabel.Location = new System.Drawing.Point(29, 300);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(254, 32);
            this.TimeLabel.TabIndex = 15;
            this.TimeLabel.Text = "Time per Question";
            // 
            // PlayersTextbox
            // 
            this.PlayersTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(238)))));
            this.PlayersTextbox.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayersTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(102)))));
            this.PlayersTextbox.Location = new System.Drawing.Point(310, 196);
            this.PlayersTextbox.MaxLength = 2;
            this.PlayersTextbox.Name = "PlayersTextbox";
            this.PlayersTextbox.Size = new System.Drawing.Size(67, 40);
            this.PlayersTextbox.TabIndex = 14;
            this.PlayersTextbox.Text = "5";
            this.PlayersTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(237)))));
            this.NameLabel.Location = new System.Drawing.Point(132, 110);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(173, 32);
            this.NameLabel.TabIndex = 11;
            this.NameLabel.Text = "Room Name";
            // 
            // NameTextbox
            // 
            this.NameTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(238)))));
            this.NameTextbox.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(102)))));
            this.NameTextbox.Location = new System.Drawing.Point(68, 145);
            this.NameTextbox.MaxLength = 32;
            this.NameTextbox.Name = "NameTextbox";
            this.NameTextbox.Size = new System.Drawing.Size(293, 40);
            this.NameTextbox.TabIndex = 13;
            this.NameTextbox.Text = "\'s Room";
            this.NameTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PlayersLabel
            // 
            this.PlayersLabel.AutoSize = true;
            this.PlayersLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayersLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(237)))));
            this.PlayersLabel.Location = new System.Drawing.Point(109, 199);
            this.PlayersLabel.Name = "PlayersLabel";
            this.PlayersLabel.Size = new System.Drawing.Size(172, 32);
            this.PlayersLabel.TabIndex = 12;
            this.PlayersLabel.Text = "Max Players";
            // 
            // CreateButton
            // 
            this.CreateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(237)))));
            this.CreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.CreateButton.Location = new System.Drawing.Point(145, 501);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(138, 46);
            this.CreateButton.TabIndex = 17;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = false;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // ControlLabel
            // 
            this.ControlLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControlLabel.ForeColor = System.Drawing.Color.IndianRed;
            this.ControlLabel.Location = new System.Drawing.Point(9, 458);
            this.ControlLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ControlLabel.Name = "ControlLabel";
            this.ControlLabel.Size = new System.Drawing.Size(416, 40);
            this.ControlLabel.TabIndex = 19;
            this.ControlLabel.Text = "Error Message";
            this.ControlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NumTextBox
            // 
            this.NumTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(238)))));
            this.NumTextBox.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(102)))));
            this.NumTextBox.Location = new System.Drawing.Point(310, 247);
            this.NumTextBox.MaxLength = 2;
            this.NumTextBox.Name = "NumTextBox";
            this.NumTextBox.Size = new System.Drawing.Size(67, 40);
            this.NumTextBox.TabIndex = 21;
            this.NumTextBox.Text = "7";
            this.NumTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NumLabel
            // 
            this.NumLabel.AutoSize = true;
            this.NumLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(237)))));
            this.NumLabel.Location = new System.Drawing.Point(81, 250);
            this.NumLabel.Name = "NumLabel";
            this.NumLabel.Size = new System.Drawing.Size(200, 32);
            this.NumLabel.TabIndex = 20;
            this.NumLabel.Text = "# of Questions";
            // 
            // SelectDifficultyButton
            // 
            this.SelectDifficultyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(237)))));
            this.SelectDifficultyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectDifficultyButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectDifficultyButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.SelectDifficultyButton.Location = new System.Drawing.Point(26, 410);
            this.SelectDifficultyButton.Name = "SelectDifficultyButton";
            this.SelectDifficultyButton.Size = new System.Drawing.Size(93, 47);
            this.SelectDifficultyButton.TabIndex = 22;
            this.SelectDifficultyButton.Text = "Select Difficulty";
            this.SelectDifficultyButton.UseVisualStyleBackColor = false;
            this.SelectDifficultyButton.Click += new System.EventHandler(this.SelectDifficultyButton_Click);
            // 
            // SelectCategoryButton
            // 
            this.SelectCategoryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(237)))));
            this.SelectCategoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectCategoryButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectCategoryButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.SelectCategoryButton.Location = new System.Drawing.Point(26, 343);
            this.SelectCategoryButton.Name = "SelectCategoryButton";
            this.SelectCategoryButton.Size = new System.Drawing.Size(93, 52);
            this.SelectCategoryButton.TabIndex = 23;
            this.SelectCategoryButton.Text = "Select Category";
            this.SelectCategoryButton.UseVisualStyleBackColor = false;
            this.SelectCategoryButton.Click += new System.EventHandler(this.SelectCategoryButton_Click);
            // 
            // DifficultyLabel
            // 
            this.DifficultyLabel.AutoSize = true;
            this.DifficultyLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DifficultyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(237)))));
            this.DifficultyLabel.Location = new System.Drawing.Point(125, 421);
            this.DifficultyLabel.Name = "DifficultyLabel";
            this.DifficultyLabel.Size = new System.Drawing.Size(76, 22);
            this.DifficultyLabel.TabIndex = 24;
            this.DifficultyLabel.Text = "Normal";
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoryLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(205)))), ((int)(((byte)(237)))));
            this.CategoryLabel.Location = new System.Drawing.Point(125, 357);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(246, 22);
            this.CategoryLabel.TabIndex = 25;
            this.CategoryLabel.Text = "Japanese Anime && Manga";
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
            this.QuitButton.UseVisualStyleBackColor = false;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // CreateRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(102)))));
            this.ClientSize = new System.Drawing.Size(434, 561);
            this.Controls.Add(this.CategoryLabel);
            this.Controls.Add(this.DifficultyLabel);
            this.Controls.Add(this.SelectCategoryButton);
            this.Controls.Add(this.SelectDifficultyButton);
            this.Controls.Add(this.NumTextBox);
            this.Controls.Add(this.NumLabel);
            this.Controls.Add(this.ControlLabel);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.TimeTextbox);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.PlayersTextbox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameTextbox);
            this.Controls.Add(this.PlayersLabel);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CreateRoom";
            this.Text = "CreateRoom";
            this.Load += new System.EventHandler(this.CreateRoom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.TextBox TimeTextbox;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.TextBox PlayersTextbox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameTextbox;
        private System.Windows.Forms.Label PlayersLabel;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Label ControlLabel;
        private System.Windows.Forms.TextBox NumTextBox;
        private System.Windows.Forms.Label NumLabel;
        private System.Windows.Forms.Button SelectDifficultyButton;
        private System.Windows.Forms.Button SelectCategoryButton;
        private System.Windows.Forms.Label DifficultyLabel;
        private System.Windows.Forms.Label CategoryLabel;
    }
}