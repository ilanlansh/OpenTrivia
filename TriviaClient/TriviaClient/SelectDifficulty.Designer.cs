namespace TriviaClient
{
    partial class SelectDifficulty
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
            this.SelectDifficultyLabel = new System.Windows.Forms.Label();
            this.DiffAnyBtn = new System.Windows.Forms.RadioButton();
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.DiffMediumBtn = new System.Windows.Forms.RadioButton();
            this.DiffHardBtn = new System.Windows.Forms.RadioButton();
            this.DiffEasyBtn = new System.Windows.Forms.RadioButton();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.ButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectDifficultyLabel
            // 
            this.SelectDifficultyLabel.AutoSize = true;
            this.SelectDifficultyLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectDifficultyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(26)))), ((int)(((byte)(35)))));
            this.SelectDifficultyLabel.Location = new System.Drawing.Point(12, 9);
            this.SelectDifficultyLabel.Name = "SelectDifficultyLabel";
            this.SelectDifficultyLabel.Size = new System.Drawing.Size(153, 22);
            this.SelectDifficultyLabel.TabIndex = 0;
            this.SelectDifficultyLabel.Text = "Select Difficulty";
            // 
            // DiffAnyBtn
            // 
            this.DiffAnyBtn.AutoSize = true;
            this.DiffAnyBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiffAnyBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(26)))), ((int)(((byte)(35)))));
            this.DiffAnyBtn.Location = new System.Drawing.Point(12, 9);
            this.DiffAnyBtn.Name = "DiffAnyBtn";
            this.DiffAnyBtn.Size = new System.Drawing.Size(57, 22);
            this.DiffAnyBtn.TabIndex = 1;
            this.DiffAnyBtn.Tag = "0";
            this.DiffAnyBtn.Text = "Any";
            this.DiffAnyBtn.UseVisualStyleBackColor = true;
            this.DiffAnyBtn.CheckedChanged += new System.EventHandler(this.RadioBtn_CheckedChanged);
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(158)))), ((int)(((byte)(126)))));
            this.ButtonsPanel.Controls.Add(this.DiffMediumBtn);
            this.ButtonsPanel.Controls.Add(this.DiffHardBtn);
            this.ButtonsPanel.Controls.Add(this.DiffEasyBtn);
            this.ButtonsPanel.Controls.Add(this.DiffAnyBtn);
            this.ButtonsPanel.Location = new System.Drawing.Point(32, 41);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(109, 128);
            this.ButtonsPanel.TabIndex = 2;
            // 
            // DiffMediumBtn
            // 
            this.DiffMediumBtn.AutoSize = true;
            this.DiffMediumBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiffMediumBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(26)))), ((int)(((byte)(35)))));
            this.DiffMediumBtn.Location = new System.Drawing.Point(12, 64);
            this.DiffMediumBtn.Name = "DiffMediumBtn";
            this.DiffMediumBtn.Size = new System.Drawing.Size(87, 22);
            this.DiffMediumBtn.TabIndex = 4;
            this.DiffMediumBtn.Tag = "2";
            this.DiffMediumBtn.Text = "Medium";
            this.DiffMediumBtn.UseVisualStyleBackColor = true;
            this.DiffMediumBtn.CheckedChanged += new System.EventHandler(this.RadioBtn_CheckedChanged);
            // 
            // DiffHardBtn
            // 
            this.DiffHardBtn.AutoSize = true;
            this.DiffHardBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiffHardBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(26)))), ((int)(((byte)(35)))));
            this.DiffHardBtn.Location = new System.Drawing.Point(12, 92);
            this.DiffHardBtn.Name = "DiffHardBtn";
            this.DiffHardBtn.Size = new System.Drawing.Size(65, 22);
            this.DiffHardBtn.TabIndex = 3;
            this.DiffHardBtn.Tag = "3";
            this.DiffHardBtn.Text = "Hard";
            this.DiffHardBtn.UseVisualStyleBackColor = true;
            this.DiffHardBtn.CheckedChanged += new System.EventHandler(this.RadioBtn_CheckedChanged);
            // 
            // DiffEasyBtn
            // 
            this.DiffEasyBtn.AutoSize = true;
            this.DiffEasyBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiffEasyBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(26)))), ((int)(((byte)(35)))));
            this.DiffEasyBtn.Location = new System.Drawing.Point(12, 37);
            this.DiffEasyBtn.Name = "DiffEasyBtn";
            this.DiffEasyBtn.Size = new System.Drawing.Size(65, 22);
            this.DiffEasyBtn.TabIndex = 2;
            this.DiffEasyBtn.Tag = "1";
            this.DiffEasyBtn.Text = "Easy";
            this.DiffEasyBtn.UseVisualStyleBackColor = true;
            this.DiffEasyBtn.CheckedChanged += new System.EventHandler(this.RadioBtn_CheckedChanged);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(199)))), ((int)(((byte)(152)))));
            this.ConfirmButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(48)))));
            this.ConfirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmButton.Location = new System.Drawing.Point(53, 177);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(65, 31);
            this.ConfirmButton.TabIndex = 3;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = false;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // SelectDifficulty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(239)))), ((int)(((byte)(178)))));
            this.ClientSize = new System.Drawing.Size(176, 216);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.ButtonsPanel);
            this.Controls.Add(this.SelectDifficultyLabel);
            this.Name = "SelectDifficulty";
            this.Text = "SelectDifficulty";
            this.Load += new System.EventHandler(this.SelectDifficulty_Load);
            this.ButtonsPanel.ResumeLayout(false);
            this.ButtonsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SelectDifficultyLabel;
        private System.Windows.Forms.RadioButton DiffAnyBtn;
        private System.Windows.Forms.Panel ButtonsPanel;
        private System.Windows.Forms.RadioButton DiffMediumBtn;
        private System.Windows.Forms.RadioButton DiffHardBtn;
        private System.Windows.Forms.RadioButton DiffEasyBtn;
        private System.Windows.Forms.Button ConfirmButton;
    }
}