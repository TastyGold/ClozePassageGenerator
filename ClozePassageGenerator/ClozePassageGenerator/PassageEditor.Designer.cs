namespace ClozePassageGenerator
{
    partial class PassageEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PassageEditor));
            this.preview = new System.Windows.Forms.TextBox();
            this.blankedWordsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.printButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nthSuffix = new System.Windows.Forms.Label();
            this.nthWordApply = new System.Windows.Forms.Button();
            this.lettersLongApply = new System.Windows.Forms.Button();
            this.lengthComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nthWordNumericBox = new System.Windows.Forms.NumericUpDown();
            this.lettersLongNumeric = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.occurrenceApply = new System.Windows.Forms.Button();
            this.occurrenceType = new System.Windows.Forms.ComboBox();
            this.clearBlanked = new System.Windows.Forms.Button();
            this.occurrencesLabel = new System.Windows.Forms.Label();
            this.occurrenceTextBox = new System.Windows.Forms.TextBox();
            this.backButton = new System.Windows.Forms.Button();
            this.removeBlankButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nthWordNumericBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lettersLongNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(12, 36);
            this.preview.Multiline = true;
            this.preview.Name = "preview";
            this.preview.ReadOnly = true;
            this.preview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.preview.Size = new System.Drawing.Size(293, 359);
            this.preview.TabIndex = 0;
            this.preview.TabStop = false;
            this.preview.TextChanged += new System.EventHandler(this.preview_TextChanged);
            // 
            // blankedWordsListBox
            // 
            this.blankedWordsListBox.FormattingEnabled = true;
            this.blankedWordsListBox.Location = new System.Drawing.Point(311, 36);
            this.blankedWordsListBox.Name = "blankedWordsListBox";
            this.blankedWordsListBox.Size = new System.Drawing.Size(179, 329);
            this.blankedWordsListBox.TabIndex = 1;
            this.blankedWordsListBox.SelectedIndexChanged += new System.EventHandler(this.blankedWordsListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Passage Preview";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(307, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Blanked Words";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(508, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Word Actions";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(713, 415);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(75, 23);
            this.printButton.TabIndex = 5;
            this.printButton.Text = "Print";
            this.toolTip1.SetToolTip(this.printButton, "Send this passage to a printer");
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.print_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(509, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Every";
            // 
            // nthSuffix
            // 
            this.nthSuffix.AutoSize = true;
            this.nthSuffix.Location = new System.Drawing.Point(582, 41);
            this.nthSuffix.Name = "nthSuffix";
            this.nthSuffix.Size = new System.Drawing.Size(42, 13);
            this.nthSuffix.TabIndex = 8;
            this.nthSuffix.Text = "th word";
            this.nthSuffix.Click += new System.EventHandler(this.nthSuffix_Click);
            // 
            // nthWordApply
            // 
            this.nthWordApply.Location = new System.Drawing.Point(739, 36);
            this.nthWordApply.Name = "nthWordApply";
            this.nthWordApply.Size = new System.Drawing.Size(49, 23);
            this.nthWordApply.TabIndex = 10;
            this.nthWordApply.Text = "Apply";
            this.toolTip1.SetToolTip(this.nthWordApply, "Add every Nth word to the blanked list");
            this.nthWordApply.UseVisualStyleBackColor = true;
            this.nthWordApply.Click += new System.EventHandler(this.nthWordApply_Click);
            // 
            // lettersLongApply
            // 
            this.lettersLongApply.Location = new System.Drawing.Point(739, 94);
            this.lettersLongApply.Name = "lettersLongApply";
            this.lettersLongApply.Size = new System.Drawing.Size(49, 23);
            this.lettersLongApply.TabIndex = 11;
            this.lettersLongApply.Text = "Apply";
            this.toolTip1.SetToolTip(this.lettersLongApply, "Add any words that meet the specified condition to the blanked list");
            this.lettersLongApply.UseVisualStyleBackColor = true;
            this.lettersLongApply.Click += new System.EventHandler(this.lettersLongApply_Click);
            // 
            // lengthComboBox
            // 
            this.lengthComboBox.FormattingEnabled = true;
            this.lengthComboBox.Items.AddRange(new object[] {
            "exactly",
            "at least",
            "at most"});
            this.lengthComboBox.Location = new System.Drawing.Point(547, 96);
            this.lengthComboBox.Name = "lengthComboBox";
            this.lengthComboBox.Size = new System.Drawing.Size(64, 21);
            this.lengthComboBox.TabIndex = 12;
            this.lengthComboBox.Text = "exactly";
            this.lengthComboBox.SelectedIndexChanged += new System.EventHandler(this.lengthComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(509, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Words";
            // 
            // nthWordNumericBox
            // 
            this.nthWordNumericBox.Location = new System.Drawing.Point(543, 39);
            this.nthWordNumericBox.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nthWordNumericBox.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nthWordNumericBox.Name = "nthWordNumericBox";
            this.nthWordNumericBox.Size = new System.Drawing.Size(38, 20);
            this.nthWordNumericBox.TabIndex = 15;
            this.nthWordNumericBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nthWordNumericBox.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nthWordNumericBox.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // lettersLongNumeric
            // 
            this.lettersLongNumeric.Location = new System.Drawing.Point(617, 97);
            this.lettersLongNumeric.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.lettersLongNumeric.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.lettersLongNumeric.Name = "lettersLongNumeric";
            this.lettersLongNumeric.Size = new System.Drawing.Size(38, 20);
            this.lettersLongNumeric.TabIndex = 16;
            this.lettersLongNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lettersLongNumeric.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.lettersLongNumeric.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(661, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "letters long";
            // 
            // occurrenceApply
            // 
            this.occurrenceApply.Location = new System.Drawing.Point(739, 65);
            this.occurrenceApply.Name = "occurrenceApply";
            this.occurrenceApply.Size = new System.Drawing.Size(49, 23);
            this.occurrenceApply.TabIndex = 18;
            this.occurrenceApply.Text = "Apply";
            this.toolTip1.SetToolTip(this.occurrenceApply, "Add a specific word to the blanked list");
            this.occurrenceApply.UseVisualStyleBackColor = true;
            this.occurrenceApply.Click += new System.EventHandler(this.occurrenceApply_Click);
            // 
            // occurrenceType
            // 
            this.occurrenceType.FormattingEnabled = true;
            this.occurrenceType.Items.AddRange(new object[] {
            "First",
            "Last",
            "All"});
            this.occurrenceType.Location = new System.Drawing.Point(512, 67);
            this.occurrenceType.Name = "occurrenceType";
            this.occurrenceType.Size = new System.Drawing.Size(64, 21);
            this.occurrenceType.TabIndex = 19;
            this.occurrenceType.Text = "First";
            this.occurrenceType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // clearBlanked
            // 
            this.clearBlanked.Location = new System.Drawing.Point(312, 372);
            this.clearBlanked.Name = "clearBlanked";
            this.clearBlanked.Size = new System.Drawing.Size(87, 23);
            this.clearBlanked.TabIndex = 20;
            this.clearBlanked.Text = "Clear All";
            this.toolTip1.SetToolTip(this.clearBlanked, "Remove all blanked words");
            this.clearBlanked.UseVisualStyleBackColor = true;
            this.clearBlanked.Click += new System.EventHandler(this.clearBlanked_Click);
            // 
            // occurrencesLabel
            // 
            this.occurrencesLabel.AutoSize = true;
            this.occurrencesLabel.Location = new System.Drawing.Point(582, 70);
            this.occurrencesLabel.Name = "occurrencesLabel";
            this.occurrencesLabel.Size = new System.Drawing.Size(73, 13);
            this.occurrencesLabel.TabIndex = 21;
            this.occurrencesLabel.Text = "occurrence of";
            // 
            // occurrenceTextBox
            // 
            this.occurrenceTextBox.Location = new System.Drawing.Point(658, 67);
            this.occurrenceTextBox.Name = "occurrenceTextBox";
            this.occurrenceTextBox.Size = new System.Drawing.Size(72, 20);
            this.occurrenceTextBox.TabIndex = 22;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 415);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 23;
            this.backButton.Text = "Back";
            this.toolTip1.SetToolTip(this.backButton, "Return to previous form. Warning: unsaved changes will be lost.");
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // removeBlankButton
            // 
            this.removeBlankButton.Enabled = false;
            this.removeBlankButton.Location = new System.Drawing.Point(405, 371);
            this.removeBlankButton.Name = "removeBlankButton";
            this.removeBlankButton.Size = new System.Drawing.Size(85, 23);
            this.removeBlankButton.TabIndex = 24;
            this.removeBlankButton.Text = "Remove";
            this.toolTip1.SetToolTip(this.removeBlankButton, "Remove selected word from list");
            this.removeBlankButton.UseVisualStyleBackColor = true;
            this.removeBlankButton.Click += new System.EventHandler(this.removeBlankButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(551, 415);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 25;
            this.exportButton.Text = "Save";
            this.toolTip1.SetToolTip(this.exportButton, "Save this passage to a .cloz file for editing later, and for interactive tests");
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(632, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "Preview";
            this.toolTip1.SetToolTip(this.button1, "Preview what the printed document will look like");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.preivewButton_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // PassageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.removeBlankButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.occurrenceTextBox);
            this.Controls.Add(this.occurrencesLabel);
            this.Controls.Add(this.clearBlanked);
            this.Controls.Add(this.occurrenceType);
            this.Controls.Add(this.occurrenceApply);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lettersLongNumeric);
            this.Controls.Add(this.nthWordNumericBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lengthComboBox);
            this.Controls.Add(this.lettersLongApply);
            this.Controls.Add(this.nthWordApply);
            this.Controls.Add(this.nthSuffix);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.blankedWordsListBox);
            this.Controls.Add(this.preview);
            this.Name = "PassageEditor";
            this.Text = "Cloz3 - Passage Editor";
            this.Load += new System.EventHandler(this.PassageEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nthWordNumericBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lettersLongNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox preview;
        private System.Windows.Forms.ListBox blankedWordsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label nthSuffix;
        private System.Windows.Forms.Button nthWordApply;
        private System.Windows.Forms.Button lettersLongApply;
        private System.Windows.Forms.ComboBox lengthComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nthWordNumericBox;
        private System.Windows.Forms.NumericUpDown lettersLongNumeric;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button occurrenceApply;
        private System.Windows.Forms.ComboBox occurrenceType;
        private System.Windows.Forms.Button clearBlanked;
        private System.Windows.Forms.Label occurrencesLabel;
        private System.Windows.Forms.TextBox occurrenceTextBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button removeBlankButton;
        private System.Windows.Forms.Button exportButton;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}