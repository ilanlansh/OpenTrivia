namespace TriviaClient
{
    partial class ErrorWindow
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
            this.TRIVIAISDOWN = new System.Windows.Forms.Label();
            this.SERVERNOTRUN = new System.Windows.Forms.Label();
            this.QuitButton = new System.Windows.Forms.Button();
            this.TryAgainLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TRIVIAISDOWN
            // 
            this.TRIVIAISDOWN.Font = new System.Drawing.Font("Arial Rounded MT Bold", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TRIVIAISDOWN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(29)))), ((int)(((byte)(49)))));
            this.TRIVIAISDOWN.Location = new System.Drawing.Point(12, 78);
            this.TRIVIAISDOWN.Name = "TRIVIAISDOWN";
            this.TRIVIAISDOWN.Size = new System.Drawing.Size(560, 81);
            this.TRIVIAISDOWN.TabIndex = 0;
            this.TRIVIAISDOWN.Text = "TRIVIA IS DOWN";
            this.TRIVIAISDOWN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SERVERNOTRUN
            // 
            this.SERVERNOTRUN.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SERVERNOTRUN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(235)))), ((int)(((byte)(208)))));
            this.SERVERNOTRUN.Location = new System.Drawing.Point(16, 159);
            this.SERVERNOTRUN.Name = "SERVERNOTRUN";
            this.SERVERNOTRUN.Size = new System.Drawing.Size(556, 35);
            this.SERVERNOTRUN.TabIndex = 1;
            this.SERVERNOTRUN.Text = "Server is not running.";
            this.SERVERNOTRUN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QuitButton
            // 
            this.QuitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.QuitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(51)))), ((int)(((byte)(63)))));
            this.QuitButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(12)))), ((int)(((byte)(31)))));
            this.QuitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuitButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(12)))), ((int)(((byte)(31)))));
            this.QuitButton.Location = new System.Drawing.Point(245, 233);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(91, 44);
            this.QuitButton.TabIndex = 2;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = false;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // TryAgainLabel
            // 
            this.TryAgainLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TryAgainLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(153)))), ((int)(((byte)(114)))));
            this.TryAgainLabel.Location = new System.Drawing.Point(250, 280);
            this.TryAgainLabel.Name = "TryAgainLabel";
            this.TryAgainLabel.Size = new System.Drawing.Size(81, 25);
            this.TryAgainLabel.TabIndex = 3;
            this.TryAgainLabel.Text = "Try Again";
            this.TryAgainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TryAgainLabel.Click += new System.EventHandler(this.TryAgainLabel_Click);
            this.TryAgainLabel.MouseEnter += new System.EventHandler(this.TryAgainLabel_MouseEnter);
            this.TryAgainLabel.MouseLeave += new System.EventHandler(this.TryAgainLabel_MouseLeave);
            // 
            // ErrorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(13)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.TryAgainLabel);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.SERVERNOTRUN);
            this.Controls.Add(this.TRIVIAISDOWN);
            this.Name = "ErrorWindow";
            this.Text = "ErrorWindow";
            this.Load += new System.EventHandler(this.ErrorWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TRIVIAISDOWN;
        private System.Windows.Forms.Label SERVERNOTRUN;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Label TryAgainLabel;
    }
}