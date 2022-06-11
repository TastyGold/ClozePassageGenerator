using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ClozePassageGenerator
{
    public partial class PassageInput : Form
    {
        public MainMenu menuForm;

        public int wordCount = 0;

        public PassageInput()
        {
            InitializeComponent();
        }

        //Open file
        private void button1_Click(object sender, EventArgs e)
        {
            //Based on https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.openfiledialog?view=windowsdesktop-6.0

            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            string ext = Path.GetExtension(filePath);
            if (ext == ".txt")
            {
                //replaces the text inside the textbox to the .txt file contents
                textBox1.Text = fileContent;
            }
            else
            {
                MessageBox.Show($"Please ensure file is of .txt format. (selected file is {ext})");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            wordCount = CountWords(textBox1);
            label2.Text = $"{wordCount.ToString()} words";
        }

        //Counts words in a passage
        private int CountWords(TextBox text)
        {
            int words = 0;
            for (int i = 0; i < text.Lines.Length; i++)
            {
                string[] vs = text.Lines[i].Split(' ');
                for (int j = 0; j < vs.Length; j++)
                {
                    //does not count double space as a word
                    if (vs[j] != "") words++;
                }
            }
            return words;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Next button
            //Loads the passage preview page

            if (wordCount == 0)
            {
                MessageBox.Show("Cannot continue - text passage is empty.");
            }
            else
            {
                PassageEditor newForm = new PassageEditor();
                this.Hide();

                newForm.Show();
                newForm.previousForm = this;
                newForm.Top = this.Top;
                newForm.Left = this.Left;
                newForm.passageManager.LoadPassage(textBox1.Text);
                newForm.Initialise();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var confirmResult = wordCount == 0 ? DialogResult.Yes :
                MessageBox.Show(
                    "Are you sure you want to return to the main menu? This passage will be lost.",
                    "Go back",
                    MessageBoxButtons.YesNo
                );

            if (confirmResult == DialogResult.Yes)
            {
                menuForm.Show();
                menuForm.Top = Top;
                menuForm.Left = Left;
                this.Close();
            }
        }
    }
}
