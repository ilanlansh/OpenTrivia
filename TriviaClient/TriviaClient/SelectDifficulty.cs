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
    public partial class SelectDifficulty : Form
    {
        private CreateRoom context;
        private RadioButton[] radioBtns;
        private int diff;

        public SelectDifficulty(CreateRoom context, int current)
        {
            InitializeComponent();
            this.context = context;
            this.diff = current;

            radioBtns = new RadioButton[] { this.DiffAnyBtn, this.DiffEasyBtn, this.DiffMediumBtn, this.DiffHardBtn };

            radioBtns[current].Checked = true;
        }

        private void SelectDifficulty_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            this.context.SetDifficulty(this.diff);
            this.Close();
        }

        private void RadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            this.diff = int.Parse((sender as RadioButton).Tag as string);
        }
    }
}
