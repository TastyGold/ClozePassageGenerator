
namespace ClozePassageGenerator
{
    partial class ClozeTest
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
            this.passageHeader = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.loadingPanel = new System.Windows.Forms.Panel();
            this.passageLoadProgressBar = new System.Windows.Forms.ProgressBar();
            this.wordBankBox = new System.Windows.Forms.ListBox();
            this.openButton = new System.Windows.Forms.Button();
            this.Finish = new System.Windows.Forms.Button();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.percentageCheckBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.mouseOverTip = new System.Windows.Forms.Label();
            this.answerRandomly = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.loadingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // passageHeader
            // 
            this.passageHeader.AutoSize = true;
            this.passageHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passageHeader.Location = new System.Drawing.Point(12, 9);
            this.passageHeader.Name = "passageHeader";
            this.passageHeader.Size = new System.Drawing.Size(241, 25);
            this.passageHeader.TabIndex = 4;
            this.passageHeader.Text = "Please open a .cloz file:";
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.BackColor = System.Drawing.SystemColors.Control;
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.loadingPanel);
            this.mainPanel.Location = new System.Drawing.Point(17, 38);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(645, 368);
            this.mainPanel.TabIndex = 5;
            // 
            // loadingPanel
            // 
            this.loadingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loadingPanel.Controls.Add(this.passageLoadProgressBar);
            this.loadingPanel.Location = new System.Drawing.Point(231, 166);
            this.loadingPanel.Name = "loadingPanel";
            this.loadingPanel.Size = new System.Drawing.Size(174, 31);
            this.loadingPanel.TabIndex = 9;
            this.loadingPanel.Visible = false;
            // 
            // passageLoadProgressBar
            // 
            this.passageLoadProgressBar.Location = new System.Drawing.Point(3, 3);
            this.passageLoadProgressBar.Name = "passageLoadProgressBar";
            this.passageLoadProgressBar.Size = new System.Drawing.Size(166, 23);
            this.passageLoadProgressBar.TabIndex = 8;
            // 
            // wordBankBox
            // 
            this.wordBankBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.wordBankBox.FormattingEnabled = true;
            this.wordBankBox.Location = new System.Drawing.Point(668, 38);
            this.wordBankBox.Name = "wordBankBox";
            this.wordBankBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.wordBankBox.Size = new System.Drawing.Size(120, 368);
            this.wordBankBox.TabIndex = 6;
            this.wordBankBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.wordBankBox_DrawItem);
            this.wordBankBox.SelectedIndexChanged += new System.EventHandler(this.wordBankBox_SelectedIndexChanged);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(98, 415);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 7;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // Finish
            // 
            this.Finish.Enabled = false;
            this.Finish.Location = new System.Drawing.Point(713, 415);
            this.Finish.Name = "Finish";
            this.Finish.Size = new System.Drawing.Size(75, 23);
            this.Finish.TabIndex = 8;
            this.Finish.Text = "Finish";
            this.Finish.UseVisualStyleBackColor = true;
            this.Finish.Click += new System.EventHandler(this.Finish_Click);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(471, 9);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.scoreLabel.Size = new System.Drawing.Size(191, 25);
            this.scoreLabel.TabIndex = 9;
            this.scoreLabel.Text = "Total Marks: 12/24";
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.scoreLabel.Visible = false;
            // 
            // percentageCheckBox
            // 
            this.percentageCheckBox.AutoSize = true;
            this.percentageCheckBox.Location = new System.Drawing.Point(676, 14);
            this.percentageCheckBox.Name = "percentageCheckBox";
            this.percentageCheckBox.Size = new System.Drawing.Size(107, 17);
            this.percentageCheckBox.TabIndex = 10;
            this.percentageCheckBox.Text = "View Percentage";
            this.percentageCheckBox.UseVisualStyleBackColor = true;
            this.percentageCheckBox.Visible = false;
            this.percentageCheckBox.CheckedChanged += new System.EventHandler(this.percentageCheckBox_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mouseOverTip
            // 
            this.mouseOverTip.AutoSize = true;
            this.mouseOverTip.Location = new System.Drawing.Point(358, 409);
            this.mouseOverTip.Name = "mouseOverTip";
            this.mouseOverTip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mouseOverTip.Size = new System.Drawing.Size(304, 13);
            this.mouseOverTip.TabIndex = 12;
            this.mouseOverTip.Text = "Tip: Mouse hover over an incorrect answer to view your guess.";
            this.mouseOverTip.Visible = false;
            // 
            // answerRandomly
            // 
            this.answerRandomly.Enabled = false;
            this.answerRandomly.Location = new System.Drawing.Point(521, 415);
            this.answerRandomly.Name = "answerRandomly";
            this.answerRandomly.Size = new System.Drawing.Size(186, 23);
            this.answerRandomly.TabIndex = 13;
            this.answerRandomly.Text = "Answer Randomly (For Testing)";
            this.answerRandomly.UseVisualStyleBackColor = true;
            this.answerRandomly.Click += new System.EventHandler(this.button2_Click);
            // 
            // ClozeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.answerRandomly);
            this.Controls.Add(this.mouseOverTip);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.percentageCheckBox);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.Finish);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.wordBankBox);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.passageHeader);
            this.Name = "ClozeTest";
            this.Text = "ClozeTest";
            this.Load += new System.EventHandler(this.ClozeTest_Load);
            this.mainPanel.ResumeLayout(false);
            this.loadingPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label passageHeader;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ListBox wordBankBox;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.ProgressBar passageLoadProgressBar;
        private System.Windows.Forms.Panel loadingPanel;
        private System.Windows.Forms.Button Finish;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.CheckBox percentageCheckBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label mouseOverTip;
        private System.Windows.Forms.Button answerRandomly;
    }
}