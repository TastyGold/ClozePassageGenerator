using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClozePassageGenerator
{
    public partial class PassageEditor : Form
    {
        public PassageInput previousForm;
        public ClozePassage passageManager = new ClozePassage();
        public List<int> blankedWordIndexes = new List<int>();

        public PassageEditor()
        {
            InitializeComponent();
        }

        public void Initialise()
        {
            RefreshPassagePreview();
        }

        public void RefreshPassagePreview()
        {
            preview.Text = passageManager.GetClozePassage();
        }
        public void RefreshBlankedWordsList()
        {
            removeBlankButton.Enabled = false;
            blankedWordIndexes.Clear();
            blankedWordsListBox.Items.Clear();
            for (int i = 0; i < passageManager.words.Count; i++)
            {
                Word word = passageManager.words[i];
                if (word.blanked)
                {
                    blankedWordIndexes.Add(i);
                    blankedWordsListBox.Items.Add(word.centre.ToLower());
                }
            }
            blankedWordsListBox.EndUpdate();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void preview_TextChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
        private void PassageEditor_Load(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void nthSuffix_Click(object sender, EventArgs e) { }
        private void lengthComboBox_SelectedIndexChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int ones = (int)nthWordNumericBox.Value % 10;
            int tens = ((int)nthWordNumericBox.Value / 10) % 10;
            string suffix = "th";
            if (tens != 1)
            {
                switch (ones)
                {
                    case 1:
                        suffix = "st";
                        break;
                    case 2:
                        suffix = "nd";
                        break;
                    case 3:
                        suffix = "rd";
                        break;
                    default:
                        suffix = "th";
                        break;
                }
            }
            nthSuffix.Text = suffix + " word";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (occurrenceType.SelectedIndex == 2) occurrencesLabel.Text = "occurrences of";
            else occurrencesLabel.Text = "occurrence of";
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var confirmResult = blankedWordIndexes.Count == 0 ? DialogResult.Yes : 
                MessageBox.Show(
                    "Are you sure you want to return to the text input? Any changes made here will be lost.", 
                    "Go back", 
                    MessageBoxButtons.YesNo
                );

            if (confirmResult == DialogResult.Yes)
            {
                previousForm.Top = this.Top;
                previousForm.Left = this.Left;
                previousForm.Show();
                this.Close();
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nthWordApply_Click(object sender, EventArgs e)
        {
            int n = (int)nthWordNumericBox.Value;
            for (int i = n - 1; i < passageManager.words.Count; i += n)
            {
                passageManager.words[i].blanked = true;
            }
            RefreshPassagePreview();
            RefreshBlankedWordsList();
        }

        private void lettersLongApply_Click(object sender, EventArgs e)
        {
            int type = lengthComboBox.SelectedIndex;
            int wordLength = (int)lettersLongNumeric.Value;

            for (int i = 0; i < passageManager.words.Count; i++)
            {
                Word word = passageManager.words[i];
                switch (type)
                {
                    case 0: //exact length
                        if (word.centre.Length == wordLength)
                        {
                            word.blanked = true;
                        }
                        break;
                    case 1: //at least length
                        if (word.centre.Length >= wordLength)
                        {
                            word.blanked = true;
                        }
                        break;
                    case 2: //at most length
                        if (word.centre.Length <= wordLength)
                        {
                            word.blanked = true;
                        }
                        break;
                }
            }

            RefreshPassagePreview();
            RefreshBlankedWordsList();
        }

        private void clearBlanked_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < passageManager.words.Count; i++)
            {
                passageManager.words[i].blanked = false;
            }
            RefreshPassagePreview();
            RefreshBlankedWordsList();
        }

        private void occurrenceApply_Click(object sender, EventArgs e)
        {
            int type = occurrenceType.SelectedIndex;
            Word wordToRemove = new Word(occurrenceTextBox.Text, -1);
            string removeQuery = wordToRemove.centre;

            if (removeQuery.Length == 0) MessageBox.Show($"Query word must contain at least one letter or digit: \"{occurrenceTextBox.Text}\" is invalid.");
            else
            {
                bool found = false;

                if (type == 0) //first occurrence
                {
                    for (int i = 0; i < passageManager.words.Count; i++)
                    {
                        if (passageManager.words[i].centre.ToLower() == removeQuery.ToLower())
                        {
                            passageManager.words[i].blanked = true;
                            found = true;
                            i = passageManager.words.Count; //terminates loop
                        }
                    }
                }
                else if (type == 1) //last occurrence
                {
                    for (int i = passageManager.words.Count - 1; i > 0; i--)
                    {
                        if (passageManager.words[i].centre.ToLower() == removeQuery.ToLower())
                        {
                            passageManager.words[i].blanked = true;
                            found = true;
                            i = 0; //terminates loop
                        }
                    }
                }
                else if (type == 2)
                {
                    for (int i = 0; i < passageManager.words.Count; i++)
                    {
                        if (passageManager.words[i].centre.ToLower() == removeQuery.ToLower())
                        {
                            passageManager.words[i].blanked = true;
                            found = true;
                        }
                    }
                }

                if (found)
                {
                    RefreshPassagePreview();
                    RefreshBlankedWordsList();
                }
                else
                {
                    MessageBox.Show($"Zero instances of \"{occurrenceTextBox.Text}\" were found in the passage.");
                }
            }
        }

        private void blankedWordsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeBlankButton.Enabled = true;
        }

        private void removeBlankButton_Click(object sender, EventArgs e)
        {
            int index = blankedWordsListBox.SelectedIndex;
            passageManager.words[blankedWordIndexes[index]].blanked = false;
            RefreshPassagePreview();
            RefreshBlankedWordsList();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "cloz files (*.cloz)|*.cloz",
                FilterIndex = 2,
                InitialDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "/SavedPassages",
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                passageManager.WriteToFile(saveFileDialog1.FileName);
            }
        }
    }
}