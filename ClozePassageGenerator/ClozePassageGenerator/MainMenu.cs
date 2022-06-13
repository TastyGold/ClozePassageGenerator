using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ClozePassageGenerator
{
    public partial class MainMenu : Form
    {
        private bool blockDevEvent = true;

        public MainMenu()
        {
            InitializeComponent();
            CheckForDevMode();
        }

        public string DevPath => Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\dev_enable.txt";

        public void CheckForDevMode()
        {
            if (File.Exists(DevPath))
            {
                GlobalData.devModeEnabled = true;
                enableDevMode.Checked = true;
            }
            blockDevEvent = false;
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
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Cloz Files (*.cloz*)|*.cloz*";
            dialog.FilterIndex = 1;
            dialog.InitialDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\SavedPassages";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ClozePassage passage = ClozeTest.ReadPassageFromFile(dialog.FileName, out bool found);

                if (found)
                {
                    PassageEditor newForm = new PassageEditor();
                    this.Hide();

                    newForm.Show();
                    newForm.previousForm = this;
                    newForm.Top = this.Top;
                    newForm.Left = this.Left;
                    newForm.passageManager = passage;
                    newForm.Initialise();
                    newForm.RefreshBlankedWordsList();
                }
            }
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

        //https://stackoverflow.com/questions/4580263/how-to-open-in-default-browser-in-c-sharp
        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var confirmResult =
                   MessageBox.Show(
                       "Open source code in browser? - https://github.com/TastyGold/ClozePassageGenerator/tree/main",
                       "Github",
                       MessageBoxButtons.YesNo
                   );

            if (confirmResult == DialogResult.Yes)
            {
                OpenUrl("https://github.com/TastyGold/ClozePassageGenerator/tree/main");
            }
        }

        private void enableDevMode_CheckedChanged(object sender, EventArgs e)
        {
            if (blockDevEvent) return;

            if (enableDevMode.Checked)
            {
                blockDevEvent = true;
                enableDevMode.Checked = false;

                var confirmResult =
                       MessageBox.Show(
                           "Developer mode is not targetted at the end user. It includes a few extra features for ease of testing and exploring the program. Are you sure you want to enable?",
                           "Enable developer mode",
                           MessageBoxButtons.YesNo
                       );

                if (confirmResult == DialogResult.Yes)
                {
                    enableDevMode.Checked = true;

                    if (!File.Exists(DevPath))
                    {
                        StreamWriter s = File.CreateText(DevPath);
                        s.Close();
                    }
                }

                blockDevEvent = false;
            }
            else
            {
                if (File.Exists(DevPath))
                {
                    File.Delete(DevPath);
                }
            }

            GlobalData.devModeEnabled = enableDevMode.Checked;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
