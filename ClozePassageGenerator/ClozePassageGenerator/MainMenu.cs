using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClozePassageGenerator
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create new passage from scratch

            PassageInput newForm = new PassageInput();
            this.Hide();

            newForm.Show();
            newForm.menuForm = this;
            newForm.Top = Top;
            newForm.Left = Left;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Open existing passage for editing
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Open and fill out an existing cloze test

            ClozeTest newForm = new ClozeTest();
            this.Hide();

            newForm.Show();
            newForm.menuForm = this;
            newForm.Top = Top;
            newForm.Left = Left;
        }
    }
}
