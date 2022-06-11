using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace ClozePassageGenerator
{
    public partial class ClozeTest : Form
    {
        public MainMenu menuForm;
        public ClozePassage passageManager = new ClozePassage();

        public static Random rng = new Random();

        public const int lineHeight = 25;
        public const int leftMarginWidth = 5;
        public const int rightMarginWidth = 20;

        public static Color invalidWordColor = Color.FromArgb(255, 230, 227);
        public static Color correctColor = Color.FromArgb(198, 255, 191);
        public static Color incorrectColor = Color.FromArgb(255, 205, 194);

        public List<TextBox> answerBoxes = new List<TextBox>();
        public List<AnswerBoxMouseHoverHandler> answerBoxHoverHandlers;

        public List<int> blankWordIndexes = new List<int>();
        public bool[] blankedWordsSolved;

        private int currentX = leftMarginWidth;
        private int currentLine = 0;

        public int longestBlankWidth = 10;
        public int longestWordLetters = 1;

        public static bool finished = false;
        public static int finalScore = -1;

        public void FindAndSetLongestBlank()
        {
            for (int i = 0; i < passageManager.words.Count; i++)
            {
                if (passageManager.words[i].blanked)
                {
                    longestBlankWidth = Math.Max(longestBlankWidth, TextRenderer.MeasureText(passageManager.words[i].centre, Font).Width + 8);
                }
            }
        }

        public void LoadPassage()
        {
            loadingPanel.Visible = true;
            passageLoadProgressBar.Value = 0;
            passageLoadProgressBar.Maximum = passageManager.words.Count;
            for (int i = 0; i < passageManager.words.Count; i++)
            {
                AddWordControl(i);
                passageLoadProgressBar.Value = Math.Min(i + 1, passageManager.words.Count);
                passageLoadProgressBar.Value = i;
                passageLoadProgressBar.Update();
            }
            loadingPanel.Visible = false;
            InitialiseWordBank();

            passageHeader.Text = "Fill in the blanks:";
            Finish.Enabled = true;
            answerRandomly.Enabled = true;
        }

        public void ResetForm()
        {
            currentLine = 0;
            currentX = 0;
            wordBankBox.Items.Clear();
            answerBoxes = new List<TextBox>();
            blankWordIndexes = new List<int>();
            longestBlankWidth = 10;
            longestWordLetters = -1;
            answerBoxHoverHandlers = new List<AnswerBoxMouseHoverHandler>();
            passageManager = new ClozePassage();
            finished = false;
            finalScore = -1;

            mainPanel.Controls.Clear();

            percentageCheckBox.Checked = false;
            percentageCheckBox.Visible = false;
            mouseOverTip.Visible = false;
            Finish.Enabled = false;
            answerRandomly.Visible = true;
            scoreLabel.Visible = false;
        }

        public void ReadPassageFromFile(string filePath)
        {
            ResetForm();

            passageHeader.Text = "Loading passage:";
            passageHeader.Update();
            string ext = Path.GetExtension(filePath);
            if (ext != ".cloz")
            {
                MessageBox.Show($"Invalid file type \"{ext}\", please select a \".cloz\" file instead.");
            }
            else
            {
                Stream s = File.OpenRead(filePath);
                BinaryReader bin = new BinaryReader(s);
                using (bin)
                {
                    int wordCount = bin.ReadInt32();
                    bool[] blanked = new bool[wordCount];

                    for (int i = 0; i < wordCount; i++)
                    {
                        blanked[i] = bin.ReadBoolean();
                    }

                    for (int i = 0; i < wordCount; i++)
                    {
                        string rawWord = bin.ReadString();
                        passageManager.words.Add(new Word(rawWord, i) { blanked = blanked[i] });
                    }
                }
            }
        }

        public void InitialiseWordBank()
        {
            blankWordIndexes.Clear();
            for (int i = 0; i < passageManager.words.Count; i++)
            {
                if (passageManager.words[i].blanked)
                {
                    blankWordIndexes.Add(i);
                }
            }
            blankedWordsSolved = new bool[blankWordIndexes.Count];

            blankWordIndexes.Shuffle();

            for (int i = 0; i < blankWordIndexes.Count; i++)
            {
                wordBankBox.Items.Add(passageManager.words[blankWordIndexes[i]].centre.ToLower());
            }
        }

        public void UpdateWordBankStrikethrough()
        {
            for (int i = 0; i < blankedWordsSolved.Length; i++)
            {
                blankedWordsSolved[i] = false;
            }
            for (int i = 0; i < answerBoxes.Count; i++)
            {
                string answer = answerBoxes[i].Text.ToLower();
                if (answer != string.Empty)
                {
                    for (int l = 0; l < blankWordIndexes.Count; l++) //linear search for first occurence in wordbank to cross out
                    {
                        if (blankedWordsSolved[l] == false && answer == passageManager.words[blankWordIndexes[l]].centre.ToLower())
                        {
                            blankedWordsSolved[l] = true;
                            l = blankWordIndexes.Count; //terminate loop
                        }
                    }
                }
            }
            wordBankBox.Refresh();
        }

        public void AddWordControl(int index)
        {
            if (passageManager.words[index].blanked == false) //label
            {
                Label l = new Label()
                {
                    Location = new Point(currentX, 11 + (lineHeight * currentLine)),
                    Margin = Padding.Empty,
                };
                l.Text = GetWordLabelText(index);
                l.Width = TextRenderer.MeasureText(l.Text, l.Font).Width;
                l.Height = TextRenderer.MeasureText(l.Text, l.Font).Height;

                currentX += l.Width + 1;

                if (index < passageManager.words.Count - 1 && passageManager.words[index + 1].blanked == false)
                {
                    currentX -= 4;
                }

                if (currentX > mainPanel.Width - rightMarginWidth)
                {
                    currentX = leftMarginWidth;
                    currentLine++;
                    l.Location = new Point(currentX, 11 + (lineHeight * currentLine));
                    currentX = leftMarginWidth + l.Width + 1;
                }

                mainPanel.Controls.Add(l);
            }
            else
            {
                blankWordIndexes.Add(index);

                TextBox t = new TextBox()
                {
                    TextAlign = HorizontalAlignment.Center,
                    Width = longestBlankWidth,
                    Margin = Padding.Empty,
                    Location = new Point(currentX, 7 + (lineHeight * currentLine)),
                };
                currentX += t.Width + 1;

                if (index < passageManager.words.Count - 1 && passageManager.words[index + 1].blanked == true)
                {
                    currentX += 4;
                }

                if (currentX > mainPanel.Width - rightMarginWidth)
                {
                    currentX = leftMarginWidth;
                    currentLine++;
                    t.Location = new Point(currentX, 7 + (lineHeight * currentLine));
                    currentX = leftMarginWidth + t.Width + 1;
                }

                t.TextChanged += (sender, e) => OnAnswerBoxChanged(sender, e);
                t.LostFocus += (sender, e) => OnAnswerBoxLostFocus(sender, e);
                answerBoxes.Add(t);
                mainPanel.Controls.Add(t);
            }
        }

        private void OnAnswerBoxChanged(object sender, EventArgs e)
        {
            if (!finished)
            {
                TextBox t = sender as TextBox;
                t.BackColor = Color.White;

                UpdateWordBankStrikethrough();
            }
        }

        public void OnAnswerBoxLostFocus(object sender, EventArgs e)
        {
            if (!finished)
            {
                TextBox t = sender as TextBox;
                t.Text = t.Text.Trim();
                t.BackColor = IsValidGuess(t.Text.ToLower()) || t.Text == string.Empty ? Color.White : invalidWordColor;
            }
        }

        public bool IsValidGuess(string word)
        {
            //Simple linear search of word bank
            bool found = false;
            for (int i = 0; i < blankWordIndexes.Count; i++)
            {
                if (passageManager.words[blankWordIndexes[i]].centre.ToLower() == word.ToLower())
                {
                    i = blankWordIndexes.Count;
                    found = true;
                }
            }
            return found;
        }

        public bool IsAnyTextboxEmpty()
        {
            bool anyEmpty = false;
            for (int i = 0; i < answerBoxes.Count; i++)
            {
                if (answerBoxes[i].Text == string.Empty)
                {
                    anyEmpty = true;
                    i = answerBoxes.Count;
                }
            }
            return anyEmpty;
        }
        public bool IsAnyTextboxInvalid()
        {
            bool invalid = false;
            for (int i = 0; i < answerBoxes.Count; i++)
            {
                if (!IsValidGuess(answerBoxes[i].Text.ToLower()))
                {
                    invalid = true;
                    i = answerBoxes.Count;
                }
            }
            return invalid;
        }

        public string GetWordLabelText(int index)
        {
            string output = passageManager.words[index].RawString;

            if (index > 0 && passageManager.words[index - 1].blanked)
            {
                output = passageManager.words[index - 1].suffix + " " + output;
            }
            if (index < passageManager.words.Count - 1 && passageManager.words[index + 1].blanked)
            {
                output = output + " " + passageManager.words[index + 1].prefix;
            }

            return output;
        }

        public ClozeTest()
        {
            InitializeComponent();
        }

        private void ClozeTest_Load(object sender, EventArgs e)
        {

        }

        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Cloz Files (*.cloz*)|*.cloz*";
            dialog.FilterIndex = 1;
            dialog.InitialDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "/SavedPassages";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ReadPassageFromFile(dialog.FileName);
                FindAndSetLongestBlank();
                LoadPassage();
            }
        }

        private void wordBankBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
                e.Graphics.DrawString(wordBankBox.Items[e.Index].ToString(), new Font(Font.FontFamily, 8, blankedWordsSolved[e.Index] == true ? System.Drawing.FontStyle.Strikeout : System.Drawing.FontStyle.Regular), Brushes.Black, e.Bounds);
            e.DrawFocusRectangle();
        }

        private void wordBankBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            wordBankBox.SelectedIndex = -1;
        }

        private void Finish_Click(object sender, EventArgs e)
        {
            string warning = string.Empty;
            if (IsAnyTextboxEmpty())
            {
                warning = "You have not put a word in all boxes. Are you sure you want to finish?";
            }
            else if (IsAnyTextboxInvalid())
            {
                warning = "One or more answers are not present in the word bank. Are you sure you want to finish?";
            }

            var confirmResult = warning == string.Empty ? DialogResult.Yes :
                MessageBox.Show(
                    warning,
                    "Finish Test",
                    MessageBoxButtons.YesNo
                );

            if (confirmResult == DialogResult.Yes)
            {
                Finish.Enabled = false;
                FinishTest();
            }
        }

        private void FinishTest()
        {
            passageHeader.Text = "Review:";
            mouseOverTip.Visible = true;

            finished = true;
            finalScore = 0;

            answerBoxHoverHandlers = new List<AnswerBoxMouseHoverHandler>();

            int answerBoxIndex = 0;
            for (int word = 0; word < passageManager.words.Count; word++)
            {
                if (passageManager.words[word].blanked)
                {
                    TextBox t = answerBoxes[answerBoxIndex];

                    string correctAnswer = passageManager.words[word].centre.ToLower();
                    bool isAnswerCorrect = t.Text.ToLower() == correctAnswer;

                    //Hover to see given answer implementation--
                    AnswerBoxMouseHoverHandler handler = new AnswerBoxMouseHoverHandler()
                    {
                        boxIndex = answerBoxIndex,
                        correct = isAnswerCorrect,
                        userAnswer = t.Text.ToLower(),
                        correctAnswer = string.Copy(correctAnswer),
                    };
                    answerBoxHoverHandlers.Add(handler);

                    t.ReadOnly = true;
                    t.Cursor = Cursors.Default;
                    t.MouseEnter += (sender, e) => OnMouseHoverAnswerBox(sender, e, handler.boxIndex, true);
                    t.MouseLeave += (sender, e) => OnMouseHoverAnswerBox(sender, e, handler.boxIndex, false);
                    //--

                    if (isAnswerCorrect)
                    {
                        //Correct answer
                        t.BackColor = correctColor;
                        finalScore++;
                    }
                    else
                    {
                        //Incorrect answer
                        t.Text = correctAnswer;
                        t.BackColor = incorrectColor;
                    }


                    answerBoxIndex++;
                }
            }

            UpdateScoreLabel();
            scoreLabel.Visible = true;
            percentageCheckBox.Visible = true;
        }

        public void OnMouseHoverAnswerBox(object sender, EventArgs e, int answerBoxIndex, bool enter)
        {
            AnswerBoxMouseHoverHandler a = answerBoxHoverHandlers[answerBoxIndex];

            if (!a.correct)
            {
                answerBoxes[answerBoxIndex].BackColor = enter ? invalidWordColor : incorrectColor;
                answerBoxes[answerBoxIndex].Text = enter ? a.userAnswer : a.correctAnswer;
            }
        }

        public void UpdateScoreLabel()
        {
            scoreLabel.Text = percentageCheckBox.Checked ? $"Total Mark: {Math.Round((float)finalScore / answerBoxes.Count * 100, MidpointRounding.AwayFromZero)}%" : $"Total Marks: {finalScore}/{answerBoxes.Count}";

            scoreLabel.Left = mainPanel.Right - scoreLabel.Width;
        }

        private void percentageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateScoreLabel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var confirmResult = 
                MessageBox.Show(
                    "Are you sure you want to return to the main menu? Any progress will be lost.",
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

        public void TestRandomAnswers()
        {
            int boxIndex = 0;
            for (int wi = 0; wi < passageManager.words.Count; wi++) //wi: word index in passage
            {
                if (passageManager.words[wi].blanked == true)
                {
                    // 25% chance to automatically get an answer correct
                    int r = rng.Next(0, 4);
                    if (r == 0)
                    {
                        answerBoxes[boxIndex].Text = passageManager.words[wi].centre.ToLower();
                    }
                    else
                    {
                        //otherwise, guess random word from wordbank
                        r = rng.Next(0, blankWordIndexes.Count);
                        answerBoxes[boxIndex].Text = passageManager.words[blankWordIndexes[r]].centre.ToLower();
                    }

                    boxIndex++;
                }
            }
            FinishTest();
            Finish.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!finished)
            {
                TestRandomAnswers();
                answerRandomly.Visible = false;
                Finish.Enabled = false;
            }
        }
    }

    public class AnswerBoxMouseHoverHandler
    {
        public int boxIndex;
        public bool correct;
        public string userAnswer;
        public string correctAnswer;
    }
}
