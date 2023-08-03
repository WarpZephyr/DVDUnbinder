namespace DVDUnbinder
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label lblHeader;
            System.Windows.Forms.Label lblData;
            System.Windows.Forms.Label lblOutput;
            System.Windows.Forms.Label lblDictionary;
            this.txtHeader = new System.Windows.Forms.TextBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnBrowseHeader = new System.Windows.Forms.Button();
            this.btnBrowseData = new System.Windows.Forms.Button();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.btnUnpack = new System.Windows.Forms.Button();
            this.pbrProgress = new System.Windows.Forms.ProgressBar();
            this.cbxGame = new System.Windows.Forms.ComboBox();
            this.gameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtCurrent = new System.Windows.Forms.TextBox();
            this.btnBrowseDictionary = new System.Windows.Forms.Button();
            this.txtDictionary = new System.Windows.Forms.TextBox();
            this.btnDumpBuckets = new System.Windows.Forms.Button();
            this.cbxGenerateCleanDict = new System.Windows.Forms.CheckBox();
            lblHeader = new System.Windows.Forms.Label();
            lblData = new System.Windows.Forms.Label();
            lblOutput = new System.Windows.Forms.Label();
            lblDictionary = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gameBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Location = new System.Drawing.Point(12, 9);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new System.Drawing.Size(61, 13);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Header File";
            // 
            // lblData
            // 
            lblData.AutoSize = true;
            lblData.Location = new System.Drawing.Point(12, 48);
            lblData.Name = "lblData";
            lblData.Size = new System.Drawing.Size(49, 13);
            lblData.TabIndex = 1;
            lblData.Text = "Data File";
            // 
            // lblOutput
            // 
            lblOutput.AutoSize = true;
            lblOutput.Location = new System.Drawing.Point(12, 127);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new System.Drawing.Size(84, 13);
            lblOutput.TabIndex = 5;
            lblOutput.Text = "Output Directory";
            // 
            // lblDictionary
            // 
            lblDictionary.AutoSize = true;
            lblDictionary.Location = new System.Drawing.Point(12, 87);
            lblDictionary.Name = "lblDictionary";
            lblDictionary.Size = new System.Drawing.Size(54, 13);
            lblDictionary.TabIndex = 13;
            lblDictionary.Text = "Dictionary";
            // 
            // txtHeader
            // 
            this.txtHeader.AllowDrop = true;
            this.txtHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeader.Location = new System.Drawing.Point(12, 25);
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.Size = new System.Drawing.Size(637, 20);
            this.txtHeader.TabIndex = 2;
            this.txtHeader.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDrop);
            this.txtHeader.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            // 
            // txtData
            // 
            this.txtData.AllowDrop = true;
            this.txtData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtData.Location = new System.Drawing.Point(12, 64);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(637, 20);
            this.txtData.TabIndex = 3;
            this.txtData.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDrop);
            this.txtData.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            // 
            // txtOutput
            // 
            this.txtOutput.AllowDrop = true;
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(12, 143);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(637, 20);
            this.txtOutput.TabIndex = 4;
            this.txtOutput.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDrop);
            this.txtOutput.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            // 
            // btnBrowseHeader
            // 
            this.btnBrowseHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseHeader.Location = new System.Drawing.Point(655, 25);
            this.btnBrowseHeader.Name = "btnBrowseHeader";
            this.btnBrowseHeader.Size = new System.Drawing.Size(64, 20);
            this.btnBrowseHeader.TabIndex = 6;
            this.btnBrowseHeader.Text = "Browse";
            this.btnBrowseHeader.UseVisualStyleBackColor = true;
            this.btnBrowseHeader.Click += new System.EventHandler(this.BrowseHeaderFile_Click);
            // 
            // btnBrowseData
            // 
            this.btnBrowseData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseData.Location = new System.Drawing.Point(655, 64);
            this.btnBrowseData.Name = "btnBrowseData";
            this.btnBrowseData.Size = new System.Drawing.Size(64, 20);
            this.btnBrowseData.TabIndex = 7;
            this.btnBrowseData.Text = "Browse";
            this.btnBrowseData.UseVisualStyleBackColor = true;
            this.btnBrowseData.Click += new System.EventHandler(this.BrowseDataFile_Click);
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseOutput.Location = new System.Drawing.Point(655, 143);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(64, 20);
            this.btnBrowseOutput.TabIndex = 8;
            this.btnBrowseOutput.Text = "Browse";
            this.btnBrowseOutput.UseVisualStyleBackColor = true;
            this.btnBrowseOutput.Click += new System.EventHandler(this.BrowseOutputFolder_Click);
            // 
            // btnUnpack
            // 
            this.btnUnpack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnpack.Location = new System.Drawing.Point(644, 169);
            this.btnUnpack.Name = "btnUnpack";
            this.btnUnpack.Size = new System.Drawing.Size(75, 23);
            this.btnUnpack.TabIndex = 9;
            this.btnUnpack.Text = "Unpack";
            this.btnUnpack.UseVisualStyleBackColor = true;
            this.btnUnpack.Click += new System.EventHandler(this.BtnUnpack_Click);
            // 
            // pbrProgress
            // 
            this.pbrProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbrProgress.Location = new System.Drawing.Point(12, 224);
            this.pbrProgress.Name = "pbrProgress";
            this.pbrProgress.Size = new System.Drawing.Size(707, 23);
            this.pbrProgress.TabIndex = 10;
            // 
            // cbxGame
            // 
            this.cbxGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGame.FormattingEnabled = true;
            this.cbxGame.Location = new System.Drawing.Point(409, 170);
            this.cbxGame.Name = "cbxGame";
            this.cbxGame.Size = new System.Drawing.Size(121, 21);
            this.cbxGame.TabIndex = 11;
            // 
            // gameBindingSource
            // 
            this.gameBindingSource.DataSource = typeof(SoulsFormats.BHD5.Game);
            // 
            // txtCurrent
            // 
            this.txtCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrent.Location = new System.Drawing.Point(12, 198);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.ReadOnly = true;
            this.txtCurrent.Size = new System.Drawing.Size(707, 20);
            this.txtCurrent.TabIndex = 12;
            // 
            // btnBrowseDictionary
            // 
            this.btnBrowseDictionary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseDictionary.Location = new System.Drawing.Point(655, 104);
            this.btnBrowseDictionary.Name = "btnBrowseDictionary";
            this.btnBrowseDictionary.Size = new System.Drawing.Size(64, 20);
            this.btnBrowseDictionary.TabIndex = 15;
            this.btnBrowseDictionary.Text = "Browse";
            this.btnBrowseDictionary.UseVisualStyleBackColor = true;
            this.btnBrowseDictionary.Click += new System.EventHandler(this.BrowseDictFile_Click);
            // 
            // txtDictionary
            // 
            this.txtDictionary.AllowDrop = true;
            this.txtDictionary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDictionary.Location = new System.Drawing.Point(12, 104);
            this.txtDictionary.Name = "txtDictionary";
            this.txtDictionary.Size = new System.Drawing.Size(637, 20);
            this.txtDictionary.TabIndex = 14;
            this.txtDictionary.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDrop);
            this.txtDictionary.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            // 
            // btnDumpBuckets
            // 
            this.btnDumpBuckets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDumpBuckets.Location = new System.Drawing.Point(536, 169);
            this.btnDumpBuckets.Name = "btnDumpBuckets";
            this.btnDumpBuckets.Size = new System.Drawing.Size(102, 23);
            this.btnDumpBuckets.TabIndex = 17;
            this.btnDumpBuckets.Text = "Dump Buckets";
            this.btnDumpBuckets.UseVisualStyleBackColor = true;
            this.btnDumpBuckets.Click += new System.EventHandler(this.btnDumpBuckets_Click);
            // 
            // cbxGenerateCleanDict
            // 
            this.cbxGenerateCleanDict.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxGenerateCleanDict.AutoSize = true;
            this.cbxGenerateCleanDict.Checked = true;
            this.cbxGenerateCleanDict.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxGenerateCleanDict.Location = new System.Drawing.Point(253, 172);
            this.cbxGenerateCleanDict.Name = "cbxGenerateCleanDict";
            this.cbxGenerateCleanDict.Size = new System.Drawing.Size(150, 17);
            this.cbxGenerateCleanDict.TabIndex = 18;
            this.cbxGenerateCleanDict.Text = "Generate Clean Dictionary";
            this.cbxGenerateCleanDict.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 257);
            this.Controls.Add(this.cbxGenerateCleanDict);
            this.Controls.Add(this.btnDumpBuckets);
            this.Controls.Add(this.btnBrowseDictionary);
            this.Controls.Add(this.txtDictionary);
            this.Controls.Add(lblDictionary);
            this.Controls.Add(this.txtCurrent);
            this.Controls.Add(this.cbxGame);
            this.Controls.Add(this.pbrProgress);
            this.Controls.Add(this.btnUnpack);
            this.Controls.Add(this.btnBrowseOutput);
            this.Controls.Add(this.btnBrowseData);
            this.Controls.Add(this.btnBrowseHeader);
            this.Controls.Add(lblOutput);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.txtHeader);
            this.Controls.Add(lblData);
            this.Controls.Add(lblHeader);
            this.MinimumSize = new System.Drawing.Size(267, 257);
            this.Name = "FormMain";
            this.Text = "DVDUnbinder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gameBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHeader;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnBrowseHeader;
        private System.Windows.Forms.Button btnBrowseData;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.Button btnUnpack;
        private System.Windows.Forms.ProgressBar pbrProgress;
        private System.Windows.Forms.ComboBox cbxGame;
        private System.Windows.Forms.BindingSource gameBindingSource;
        private System.Windows.Forms.TextBox txtCurrent;
        private System.Windows.Forms.Button btnBrowseDictionary;
        private System.Windows.Forms.TextBox txtDictionary;
        private System.Windows.Forms.Button btnDumpBuckets;
        private System.Windows.Forms.CheckBox cbxGenerateCleanDict;
    }
}

