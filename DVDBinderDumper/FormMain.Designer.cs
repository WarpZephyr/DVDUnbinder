namespace DVDBinderDumper
{
    partial class FormMain
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
            System.Windows.Forms.Label lblOutput;
            System.Windows.Forms.Label lblDictionary;
            this.txtCurrent = new System.Windows.Forms.TextBox();
            this.pbrProgress = new System.Windows.Forms.ProgressBar();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnDump = new System.Windows.Forms.Button();
            this.cbxGame = new System.Windows.Forms.ComboBox();
            this.btnBrowseHeader = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHeader = new System.Windows.Forms.TextBox();
            this.chxOption1 = new System.Windows.Forms.CheckBox();
            this.chxOption2 = new System.Windows.Forms.CheckBox();
            this.chxOption3 = new System.Windows.Forms.CheckBox();
            this.cbxOption1 = new System.Windows.Forms.ComboBox();
            this.cbxOption2 = new System.Windows.Forms.ComboBox();
            this.cbxOption3 = new System.Windows.Forms.ComboBox();
            this.lblGame = new System.Windows.Forms.Label();
            this.btnBrowseDictionary = new System.Windows.Forms.Button();
            this.txtDictionary = new System.Windows.Forms.TextBox();
            this.lblDumpOption = new System.Windows.Forms.Label();
            this.cbxDumpOption = new System.Windows.Forms.ComboBox();
            lblOutput = new System.Windows.Forms.Label();
            lblDictionary = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblOutput
            // 
            lblOutput.AutoSize = true;
            lblOutput.Location = new System.Drawing.Point(12, 94);
            lblOutput.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new System.Drawing.Size(87, 13);
            lblOutput.TabIndex = 49;
            lblOutput.Text = "Output Directory:";
            // 
            // lblDictionary
            // 
            lblDictionary.AutoSize = true;
            lblDictionary.Location = new System.Drawing.Point(12, 52);
            lblDictionary.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            lblDictionary.Name = "lblDictionary";
            lblDictionary.Size = new System.Drawing.Size(57, 13);
            lblDictionary.TabIndex = 61;
            lblDictionary.Text = "Dictionary:";
            // 
            // txtCurrent
            // 
            this.txtCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrent.Location = new System.Drawing.Point(12, 246);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.ReadOnly = true;
            this.txtCurrent.Size = new System.Drawing.Size(815, 20);
            this.txtCurrent.TabIndex = 52;
            // 
            // pbrProgress
            // 
            this.pbrProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbrProgress.Location = new System.Drawing.Point(12, 272);
            this.pbrProgress.Name = "pbrProgress";
            this.pbrProgress.Size = new System.Drawing.Size(815, 23);
            this.pbrProgress.TabIndex = 51;
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseOutput.Location = new System.Drawing.Point(768, 110);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(59, 20);
            this.btnBrowseOutput.TabIndex = 50;
            this.btnBrowseOutput.Text = "Browse";
            this.btnBrowseOutput.UseVisualStyleBackColor = true;
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.AllowDrop = true;
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(15, 110);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(747, 20);
            this.txtOutput.TabIndex = 48;
            this.txtOutput.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDrop);
            this.txtOutput.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            // 
            // btnDump
            // 
            this.btnDump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDump.Location = new System.Drawing.Point(768, 217);
            this.btnDump.Name = "btnDump";
            this.btnDump.Size = new System.Drawing.Size(59, 23);
            this.btnDump.TabIndex = 47;
            this.btnDump.Text = "Dump";
            this.btnDump.UseVisualStyleBackColor = true;
            this.btnDump.Click += new System.EventHandler(this.btnDump_Click);
            // 
            // cbxGame
            // 
            this.cbxGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGame.FormattingEnabled = true;
            this.cbxGame.Location = new System.Drawing.Point(582, 219);
            this.cbxGame.Name = "cbxGame";
            this.cbxGame.Size = new System.Drawing.Size(180, 21);
            this.cbxGame.TabIndex = 45;
            // 
            // btnBrowseHeader
            // 
            this.btnBrowseHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseHeader.Location = new System.Drawing.Point(768, 26);
            this.btnBrowseHeader.Name = "btnBrowseHeader";
            this.btnBrowseHeader.Size = new System.Drawing.Size(59, 20);
            this.btnBrowseHeader.TabIndex = 42;
            this.btnBrowseHeader.Text = "Browse";
            this.btnBrowseHeader.UseVisualStyleBackColor = true;
            this.btnBrowseHeader.Click += new System.EventHandler(this.btnBrowseHeader_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Header File:";
            // 
            // txtHeader
            // 
            this.txtHeader.AllowDrop = true;
            this.txtHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeader.Location = new System.Drawing.Point(15, 26);
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.Size = new System.Drawing.Size(747, 20);
            this.txtHeader.TabIndex = 36;
            this.txtHeader.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDrop);
            this.txtHeader.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            // 
            // chxOption1
            // 
            this.chxOption1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chxOption1.AutoSize = true;
            this.chxOption1.Location = new System.Drawing.Point(582, 138);
            this.chxOption1.Name = "chxOption1";
            this.chxOption1.Size = new System.Drawing.Size(66, 17);
            this.chxOption1.TabIndex = 53;
            this.chxOption1.Text = "Option 1";
            this.chxOption1.UseVisualStyleBackColor = true;
            // 
            // chxOption2
            // 
            this.chxOption2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chxOption2.AutoSize = true;
            this.chxOption2.Location = new System.Drawing.Point(582, 165);
            this.chxOption2.Name = "chxOption2";
            this.chxOption2.Size = new System.Drawing.Size(66, 17);
            this.chxOption2.TabIndex = 54;
            this.chxOption2.Text = "Option 2";
            this.chxOption2.UseVisualStyleBackColor = true;
            // 
            // chxOption3
            // 
            this.chxOption3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chxOption3.AutoSize = true;
            this.chxOption3.Location = new System.Drawing.Point(582, 192);
            this.chxOption3.Name = "chxOption3";
            this.chxOption3.Size = new System.Drawing.Size(66, 17);
            this.chxOption3.TabIndex = 55;
            this.chxOption3.Text = "Option 3";
            this.chxOption3.UseVisualStyleBackColor = true;
            // 
            // cbxOption1
            // 
            this.cbxOption1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxOption1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOption1.FormattingEnabled = true;
            this.cbxOption1.Items.AddRange(new object[] {
            "Offset",
            "Hash",
            "Name"});
            this.cbxOption1.Location = new System.Drawing.Point(654, 136);
            this.cbxOption1.Name = "cbxOption1";
            this.cbxOption1.Size = new System.Drawing.Size(173, 21);
            this.cbxOption1.TabIndex = 56;
            // 
            // cbxOption2
            // 
            this.cbxOption2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxOption2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOption2.FormattingEnabled = true;
            this.cbxOption2.Items.AddRange(new object[] {
            "Offset",
            "Hash",
            "Name"});
            this.cbxOption2.Location = new System.Drawing.Point(654, 163);
            this.cbxOption2.Name = "cbxOption2";
            this.cbxOption2.Size = new System.Drawing.Size(173, 21);
            this.cbxOption2.TabIndex = 57;
            // 
            // cbxOption3
            // 
            this.cbxOption3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxOption3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOption3.FormattingEnabled = true;
            this.cbxOption3.Items.AddRange(new object[] {
            "Offset",
            "Hash",
            "Name"});
            this.cbxOption3.Location = new System.Drawing.Point(654, 190);
            this.cbxOption3.Name = "cbxOption3";
            this.cbxOption3.Size = new System.Drawing.Size(173, 21);
            this.cbxOption3.TabIndex = 58;
            // 
            // lblGame
            // 
            this.lblGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGame.AutoSize = true;
            this.lblGame.Location = new System.Drawing.Point(538, 223);
            this.lblGame.Name = "lblGame";
            this.lblGame.Size = new System.Drawing.Size(38, 13);
            this.lblGame.TabIndex = 59;
            this.lblGame.Text = "Game:";
            // 
            // btnBrowseDictionary
            // 
            this.btnBrowseDictionary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseDictionary.Location = new System.Drawing.Point(768, 68);
            this.btnBrowseDictionary.Name = "btnBrowseDictionary";
            this.btnBrowseDictionary.Size = new System.Drawing.Size(59, 20);
            this.btnBrowseDictionary.TabIndex = 62;
            this.btnBrowseDictionary.Text = "Browse";
            this.btnBrowseDictionary.UseVisualStyleBackColor = true;
            this.btnBrowseDictionary.Click += new System.EventHandler(this.btnBrowseDictionary_Click);
            // 
            // txtDictionary
            // 
            this.txtDictionary.AllowDrop = true;
            this.txtDictionary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDictionary.Location = new System.Drawing.Point(15, 68);
            this.txtDictionary.Name = "txtDictionary";
            this.txtDictionary.Size = new System.Drawing.Size(747, 20);
            this.txtDictionary.TabIndex = 60;
            this.txtDictionary.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDrop);
            this.txtDictionary.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            // 
            // lblDumpOption
            // 
            this.lblDumpOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDumpOption.AutoSize = true;
            this.lblDumpOption.Location = new System.Drawing.Point(12, 223);
            this.lblDumpOption.Name = "lblDumpOption";
            this.lblDumpOption.Size = new System.Drawing.Size(72, 13);
            this.lblDumpOption.TabIndex = 63;
            this.lblDumpOption.Text = "Dump Option:";
            // 
            // cbxDumpOption
            // 
            this.cbxDumpOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxDumpOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDumpOption.FormattingEnabled = true;
            this.cbxDumpOption.Items.AddRange(new object[] {
            "All",
            "Known Names Only",
            "Unknown Names Only"});
            this.cbxDumpOption.Location = new System.Drawing.Point(90, 219);
            this.cbxDumpOption.Name = "cbxDumpOption";
            this.cbxDumpOption.Size = new System.Drawing.Size(173, 21);
            this.cbxDumpOption.TabIndex = 64;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 306);
            this.Controls.Add(this.cbxDumpOption);
            this.Controls.Add(this.lblDumpOption);
            this.Controls.Add(this.btnBrowseDictionary);
            this.Controls.Add(lblDictionary);
            this.Controls.Add(this.txtDictionary);
            this.Controls.Add(this.lblGame);
            this.Controls.Add(this.cbxOption3);
            this.Controls.Add(this.cbxOption2);
            this.Controls.Add(this.cbxOption1);
            this.Controls.Add(this.chxOption3);
            this.Controls.Add(this.chxOption2);
            this.Controls.Add(this.chxOption1);
            this.Controls.Add(this.txtCurrent);
            this.Controls.Add(this.pbrProgress);
            this.Controls.Add(this.btnBrowseOutput);
            this.Controls.Add(lblOutput);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnDump);
            this.Controls.Add(this.cbxGame);
            this.Controls.Add(this.btnBrowseHeader);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHeader);
            this.MinimumSize = new System.Drawing.Size(430, 345);
            this.Name = "FormMain";
            this.Text = "DVDBinder Dumper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtCurrent;
        private System.Windows.Forms.ProgressBar pbrProgress;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnDump;
        private System.Windows.Forms.ComboBox cbxGame;
        private System.Windows.Forms.Button btnBrowseHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHeader;
        private System.Windows.Forms.CheckBox chxOption1;
        private System.Windows.Forms.CheckBox chxOption2;
        private System.Windows.Forms.CheckBox chxOption3;
        private System.Windows.Forms.ComboBox cbxOption1;
        private System.Windows.Forms.ComboBox cbxOption2;
        private System.Windows.Forms.ComboBox cbxOption3;
        private System.Windows.Forms.Label lblGame;
        private System.Windows.Forms.Button btnBrowseDictionary;
        private System.Windows.Forms.TextBox txtDictionary;
        private System.Windows.Forms.Label lblDumpOption;
        private System.Windows.Forms.ComboBox cbxDumpOption;
    }
}

