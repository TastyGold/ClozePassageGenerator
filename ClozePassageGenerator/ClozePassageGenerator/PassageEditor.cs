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
        public Form previousForm;
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
                    "Are you sure you want to go back? Any unsaved changes made here will be lost.", 
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "cloz files (*.cloz)|*.cloz",
                FilterIndex = 2,
                InitialDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\SavedPassages",
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                passageManager.WriteToFile(saveFileDialog1.FileName);
            }
        }

        private string stringToPrint = "";
        private void print_Click(object sender, EventArgs e)
        {
            printDocument1.DocumentName = "Cloze Passage";

            stringToPrint = GetStringToPrint();

            var confirmResult = printDialog1.ShowDialog();
            if (confirmResult == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void preivewButton_Click(object sender, EventArgs e)
        {
            printDocument1.DocumentName = "Cloze Passage";

            stringToPrint = GetStringToPrint(); 
            ((ToolStripButton)((ToolStrip)printPreviewDialog1.Controls[1]).Items[0]).Enabled = false;

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private string GetStringToPrint()
        {
            string output = "Word Bank:\n";

            for (int i = 0; i < blankedWordIndexes.Count; i++)
            {
                output += $"{passageManager.words[blankedWordIndexes[i]].centre.ToLower()}";
                if (i < blankedWordIndexes.Count - 1) output += ", ";
            }

            output += "\n\nFill in the blanks:\n";

            for (int i = 0; i < passageManager.words.Count; i++)
            {
                output += $"{passageManager.words[i].GetString()} ";
            }

            return output;
        }
        int i = 10;

        //https://docs.microsoft.com/en-us/dotnet/desktop/winforms/printing/how-to-print-text-document?view=netdesktop-6.0
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;

            Font f = new Font(this.Font.FontFamily, 16f);

            // Sets the value of charactersOnPage to the number of characters
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrint, f,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);


            // Draws the string within the bounds of the page
            e.Graphics.DrawString(stringToPrint, f, Brushes.Black,
                e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);
        }
    }
}