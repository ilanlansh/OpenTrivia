using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriviaClient
{
    public partial class ErrorWindow : Form
    {
        public ErrorWindow()
        {
            InitializeComponent();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Program.tryRunAgain = false;
            this.Close();
        }

        private void ErrorWindow_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void TryAgainLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TryAgainLabel_MouseEnter(object sender, EventArgs e)
        {
            this.TryAgainLabel.ForeColor = Color.FromArgb(236, 235, 208);
        }

        private void TryAgainLabel_MouseLeave(object sender, EventArgs e)
        {
            this.TryAgainLabel.ForeColor = Color.FromArgb(207, 153, 114);
        }
    }
}
