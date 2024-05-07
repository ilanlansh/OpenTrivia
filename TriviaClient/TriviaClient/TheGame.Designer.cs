namespace TriviaClient
{
    partial class TheGame
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
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.CategoryTitleLabel = new System.Windows.Forms.Label();
            this.DifficultyTitleLabel = new System.Windows.Forms.Label();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.DifficultyLabel = new System.Windows.Forms.Label();
            this.AnswerButton_1 = new System.Windows.Forms.Button();
            this.AnswerButton_2 = new System.Windows.Forms.Button();
            this.AnswerButton_3 = new System.Windows.Forms.Button();
            this.AnswerButton_4 = new System.Windows.Forms.Button();
            this.QuestionNumberLabel = new System.Windows.Forms.Label();
            this.QuestionNumberTitle = new System.Windows.Forms.Label();
            this.ProgBarFront = new System.Windows.Forms.Label();
            this.ProgBarBack = new System.Windows.Forms.Label();
            this.TimeLeftLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(255)))), ((int)(((byte)(218)))));
            this.QuestionLabel.Location = new System.Drawing.Point(12, 137);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Padding = new System.Windows.Forms.Padding(50, 0, 50, 0);
            this.QuestionLabel.Size = new System.Drawing.Size(760, 97);
            this.QuestionLabel.TabIndex = 0;
            this.QuestionLabel.Text = "What is the capital city of Australia?";
            this.QuestionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.QuestionLabel.TextChanged += new System.EventHandler(this.QuestionLabel_TextChanged);
            // 
            // CategoryTitleLabel
            // 
            this.CategoryTitleLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoryTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            this.CategoryTitleLabel.Location = new System.Drawing.Point(16, 18);
            this.CategoryTitleLabel.Name = "CategoryTitleLabel";
            this.CategoryTitleLabel.Size = new System.Drawing.Size(126, 23);
            this.CategoryTitleLabel.TabIndex = 1;
            this.CategoryTitleLabel.Text = "Category";
            this.CategoryTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DifficultyTitleLabel
            // 
            this.DifficultyTitleLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DifficultyTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            this.DifficultyTitleLabel.Location = new System.Drawing.Point(19, 51);
            this.DifficultyTitleLabel.Name = "DifficultyTitleLabel";
            this.DifficultyTitleLabel.Size = new System.Drawing.Size(123, 23);
            this.DifficultyTitleLabel.TabIndex = 2;
            this.DifficultyTitleLabel.Text = "Difficulty";
            this.DifficultyTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoryLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(176)))), ((int)(((byte)(134)))));
            this.CategoryLabel.Location = new System.Drawing.Point(138, 10);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(387, 31);
            this.CategoryLabel.TabIndex = 3;
            this.CategoryLabel.Text = "Geography (SAMPLE QUESTION)";
            this.CategoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DifficultyLabel
            // 
            this.DifficultyLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DifficultyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(176)))), ((int)(((byte)(134)))));
            this.DifficultyLabel.Location = new System.Drawing.Point(138, 43);
            this.DifficultyLabel.Name = "DifficultyLabel";
            this.DifficultyLabel.Size = new System.Drawing.Size(104, 31);
            this.DifficultyLabel.TabIndex = 4;
            this.DifficultyLabel.Text = "Easy";
            this.DifficultyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AnswerButton_1
            // 
            this.AnswerButton_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(176)))), ((int)(((byte)(134)))));
            this.AnswerButton_1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.AnswerButton_1.FlatAppearance.BorderSize = 5;
            this.AnswerButton_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AnswerButton_1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnswerButton_1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(44)))), ((int)(((byte)(29)))));
            this.AnswerButton_1.Location = new System.Drawing.Point(62, 257);
            this.AnswerButton_1.Name = "AnswerButton_1";
            this.AnswerButton_1.Size = new System.Drawing.Size(294, 50);
            this.AnswerButton_1.TabIndex = 5;
            this.AnswerButton_1.Text = "Sydney";
            this.AnswerButton_1.UseVisualStyleBackColor = false;
            this.AnswerButton_1.TextChanged += new System.EventHandler(this.AnswerButton_TextChanged);
            this.AnswerButton_1.Click += new System.EventHandler(this.AnswerButton_Click);
            // 
            // AnswerButton_2
            // 
            this.AnswerButton_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(176)))), ((int)(((byte)(134)))));
            this.AnswerButton_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AnswerButton_2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnswerButton_2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(44)))), ((int)(((byte)(29)))));
            this.AnswerButton_2.Location = new System.Drawing.Point(425, 257);
            this.AnswerButton_2.Name = "AnswerButton_2";
            this.AnswerButton_2.Size = new System.Drawing.Size(294, 50);
            this.AnswerButton_2.TabIndex = 6;
            this.AnswerButton_2.Text = "New South Wales";
            this.AnswerButton_2.UseVisualStyleBackColor = false;
            this.AnswerButton_2.TextChanged += new System.EventHandler(this.AnswerButton_TextChanged);
            this.AnswerButton_2.Click += new System.EventHandler(this.AnswerButton_Click);
            // 
            // AnswerButton_3
            // 
            this.AnswerButton_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(176)))), ((int)(((byte)(134)))));
            this.AnswerButton_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AnswerButton_3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnswerButton_3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(44)))), ((int)(((byte)(29)))));
            this.AnswerButton_3.Location = new System.Drawing.Point(62, 352);
            this.AnswerButton_3.Name = "AnswerButton_3";
            this.AnswerButton_3.Size = new System.Drawing.Size(294, 50);
            this.AnswerButton_3.TabIndex = 7;
            this.AnswerButton_3.Text = "Melbourne";
            this.AnswerButton_3.UseVisualStyleBackColor = false;
            this.AnswerButton_3.TextChanged += new System.EventHandler(this.AnswerButton_TextChanged);
            this.AnswerButton_3.Click += new System.EventHandler(this.AnswerButton_Click);
            // 
            // AnswerButton_4
            // 
            this.AnswerButton_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(176)))), ((int)(((byte)(134)))));
            this.AnswerButton_4.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.AnswerButton_4.FlatAppearance.BorderSize = 5;
            this.AnswerButton_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AnswerButton_4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnswerButton_4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(44)))), ((int)(((byte)(29)))));
            this.AnswerButton_4.Location = new System.Drawing.Point(425, 352);
            this.AnswerButton_4.Name = "AnswerButton_4";
            this.AnswerButton_4.Size = new System.Drawing.Size(294, 50);
            this.AnswerButton_4.TabIndex = 8;
            this.AnswerButton_4.Text = "Canberra";
            this.AnswerButton_4.UseVisualStyleBackColor = false;
            this.AnswerButton_4.TextChanged += new System.EventHandler(this.AnswerButton_TextChanged);
            this.AnswerButton_4.Click += new System.EventHandler(this.AnswerButton_Click);
            // 
            // QuestionNumberLabel
            // 
            this.QuestionNumberLabel.AutoSize = true;
            this.QuestionNumberLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionNumberLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            this.QuestionNumberLabel.Location = new System.Drawing.Point(397, 120);
            this.QuestionNumberLabel.Name = "QuestionNumberLabel";
            this.QuestionNumberLabel.Size = new System.Drawing.Size(38, 17);
            this.QuestionNumberLabel.TabIndex = 9;
            this.QuestionNumberLabel.Text = "2 / 7";
            // 
            // QuestionNumberTitle
            // 
            this.QuestionNumberTitle.AutoSize = true;
            this.QuestionNumberTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionNumberTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            this.QuestionNumberTitle.Location = new System.Drawing.Point(314, 120);
            this.QuestionNumberTitle.Name = "QuestionNumberTitle";
            this.QuestionNumberTitle.Size = new System.Drawing.Size(73, 17);
            this.QuestionNumberTitle.TabIndex = 10;
            this.QuestionNumberTitle.Text = "Question";
            // 
            // ProgBarFront
            // 
            this.ProgBarFront.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            this.ProgBarFront.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgBarFront.Location = new System.Drawing.Point(63, 432);
            this.ProgBarFront.Name = "ProgBarFront";
            this.ProgBarFront.Size = new System.Drawing.Size(50, 10);
            this.ProgBarFront.TabIndex = 15;
            this.ProgBarFront.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ProgBarBack
            // 
            this.ProgBarBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(82)))), ((int)(((byte)(51)))));
            this.ProgBarBack.Location = new System.Drawing.Point(63, 432);
            this.ProgBarBack.Name = "ProgBarBack";
            this.ProgBarBack.Size = new System.Drawing.Size(628, 10);
            this.ProgBarBack.TabIndex = 14;
            // 
            // TimeLeftLabel
            // 
            this.TimeLeftLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLeftLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(176)))), ((int)(((byte)(134)))));
            this.TimeLeftLabel.Location = new System.Drawing.Point(700, 421);
            this.TimeLeftLabel.Name = "TimeLeftLabel";
            this.TimeLeftLabel.Size = new System.Drawing.Size(60, 31);
            this.TimeLeftLabel.TabIndex = 16;
            this.TimeLeftLabel.Text = "00:28";
            this.TimeLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TheGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(48)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.TimeLeftLabel);
            this.Controls.Add(this.ProgBarFront);
            this.Controls.Add(this.ProgBarBack);
            this.Controls.Add(this.QuestionNumberTitle);
            this.Controls.Add(this.QuestionNumberLabel);
            this.Controls.Add(this.AnswerButton_4);
            this.Controls.Add(this.AnswerButton_3);
            this.Controls.Add(this.AnswerButton_2);
            this.Controls.Add(this.AnswerButton_1);
            this.Controls.Add(this.DifficultyLabel);
            this.Controls.Add(this.CategoryLabel);
            this.Controls.Add(this.DifficultyTitleLabel);
            this.Controls.Add(this.CategoryTitleLabel);
            this.Controls.Add(this.QuestionLabel);
            this.Name = "TheGame";
            this.Text = "The Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TheGame_FormClosing);
            this.Load += new System.EventHandler(this.TheGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label QuestionLabel;
        private System.Windows.Forms.Label CategoryTitleLabel;
        private System.Windows.Forms.Label DifficultyTitleLabel;
        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.Label DifficultyLabel;
        private System.Windows.Forms.Button AnswerButton_1;
        private System.Windows.Forms.Button AnswerButton_2;
        private System.Windows.Forms.Button AnswerButton_3;
        private System.Windows.Forms.Button AnswerButton_4;
        private System.Windows.Forms.Label QuestionNumberLabel;
        private System.Windows.Forms.Label QuestionNumberTitle;
        private System.Windows.Forms.Label ProgBarFront;
        private System.Windows.Forms.Label ProgBarBack;
        private System.Windows.Forms.Label TimeLeftLabel;
    }
}