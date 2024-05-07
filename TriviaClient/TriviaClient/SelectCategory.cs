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
    public partial class SelectCategory : Form
    {
        private CreateRoom context;
        private RadioButton[] radioBtns;
        private int cat;

        public SelectCategory(CreateRoom context, int current)
        {
            InitializeComponent();
            this.context = context;
            this.cat = current;

            radioBtns = new RadioButton[]
            {
                this.Cat00Btn, null, null, null, null, null, null, null, null,
                this.Cat09Btn, this.Cat10Btn, this.Cat11Btn, this.Cat12Btn,
                this.Cat13Btn, this.Cat14Btn, this.Cat15Btn, this.Cat16Btn, this.Cat17Btn,
                this.Cat18Btn, this.Cat19Btn, this.Cat20Btn, this.Cat21Btn, this.Cat22Btn,
                this.Cat23Btn, this.Cat24Btn, this.Cat25Btn, this.Cat26Btn, this.Cat27Btn,
                this.Cat28Btn, this.Cat29Btn, this.Cat30Btn, this.Cat31Btn, this.Cat32Btn,
            };

            radioBtns[current].Checked = true;
        }

        private void SelectCategory_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            this.context.SetCategory(this.cat);
            this.Close();
        }

        private void RadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            this.cat = int.Parse((sender as RadioButton).Tag as string);
        }
    }
}
