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
            System.Windows.Forms.Label lblOutput;
            System.Windows.Forms.Label lblInput;
            this.cbxBigEndian = new System.Windows.Forms.CheckBox();
            this.cbxGame = new System.Windows.Forms.ComboBox();
            this.btnBrowseHeaderBucketCount = new System.Windows.Forms.Button();
            this.btnBrowseDataName = new System.Windows.Forms.Button();
            this.btnBrowseHeaderName = new System.Windows.Forms.Button();
            this.lblBucketDistribution = new System.Windows.Forms.Label();
            this.numBucketDistribution = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHeaderName = new System.Windows.Forms.TextBox();
            this.txtDataName = new System.Windows.Forms.TextBox();
            this.btnRepack = new System.Windows.Forms.Button();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtCurrent = new System.Windows.Forms.TextBox();
            this.pbrProgress = new System.Windows.Forms.ProgressBar();
            this.btnBrowseInput = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            lblOutput = new System.Windows.Forms.Label();
            lblInput = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numBucketDistribution)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOutput
            // 
            lblOutput.AutoSize = true;
            lblOutput.Location = new System.Drawing.Point(12, 136);
            lblOutput.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new System.Drawing.Size(84, 13);
            lblOutput.TabIndex = 29;
            lblOutput.Text = "Output Directory";
            // 
            // lblInput
            // 
            lblInput.AutoSize = true;
            lblInput.Location = new System.Drawing.Point(12, 94);
            lblInput.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            lblInput.Name = "lblInput";
            lblInput.Size = new System.Drawing.Size(76, 13);
            lblInput.TabIndex = 34;
            lblInput.Text = "Input Directory";
            // 
            // cbxBigEndian
            // 
            this.cbxBigEndian.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxBigEndian.AutoSize = true;
            this.cbxBigEndian.Location = new System.Drawing.Point(365, 205);
            this.cbxBigEndian.Name = "cbxBigEndian";
            this.cbxBigEndian.Size = new System.Drawing.Size(77, 17);
            this.cbxBigEndian.TabIndex = 26;
            this.cbxBigEndian.Text = "Big Endian";
            this.cbxBigEndian.UseVisualStyleBackColor = true;
            // 
            // cbxGame
            // 
            this.cbxGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGame.FormattingEnabled = true;
            this.cbxGame.Location = new System.Drawing.Point(448, 203);
            this.cbxGame.Name = "cbxGame";
            this.cbxGame.Size = new System.Drawing.Size(173, 21);
            this.cbxGame.TabIndex = 24;
            // 
            // btnBrowseHeaderBucketCount
            // 
            this.btnBrowseHeaderBucketCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseHeaderBucketCount.Location = new System.Drawing.Point(627, 178);
            this.btnBrowseHeaderBucketCount.Name = "btnBrowseHeaderBucketCount";
            this.btnBrowseHeaderBucketCount.Size = new System.Drawing.Size(59, 20);
            this.btnBrowseHeaderBucketCount.TabIndex = 23;
            this.btnBrowseHeaderBucketCount.Text = "Browse";
            this.btnBrowseHeaderBucketCount.UseVisualStyleBackColor = true;
            this.btnBrowseHeaderBucketCount.Click += new System.EventHandler(this.btnBrowseHeaderBucketCount_Click);
            // 
            // btnBrowseDataName
            // 
            this.btnBrowseDataName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseDataName.Location = new System.Drawing.Point(627, 68);
            this.btnBrowseDataName.Name = "btnBrowseDataName";
            this.btnBrowseDataName.Size = new System.Drawing.Size(59, 20);
            this.btnBrowseDataName.TabIndex = 22;
            this.btnBrowseDataName.Text = "Browse";
            this.btnBrowseDataName.UseVisualStyleBackColor = true;
            this.btnBrowseDataName.Click += new System.EventHandler(this.btnBrowseDataName_Click);
            // 
            // btnBrowseHeaderName
            // 
            this.btnBrowseHeaderName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseHeaderName.Location = new System.Drawing.Point(627, 25);
            this.btnBrowseHeaderName.Name = "btnBrowseHeaderName";
            this.btnBrowseHeaderName.Size = new System.Drawing.Size(59, 20);
            this.btnBrowseHeaderName.TabIndex = 21;
            this.btnBrowseHeaderName.Text = "Browse";
            this.btnBrowseHeaderName.UseVisualStyleBackColor = true;
            this.btnBrowseHeaderName.Click += new System.EventHandler(this.btnBrowseHeaderName_Click);
            // 
            // lblBucketDistribution
            // 
            this.lblBucketDistribution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBucketDistribution.AutoSize = true;
            this.lblBucketDistribution.Location = new System.Drawing.Point(340, 180);
            this.lblBucketDistribution.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblBucketDistribution.Name = "lblBucketDistribution";
            this.lblBucketDistribution.Size = new System.Drawing.Size(102, 13);
            this.lblBucketDistribution.TabIndex = 20;
            this.lblBucketDistribution.Text = "Bucket Distribution: ";
            // 
            // numBucketDistribution
            // 
            this.numBucketDistribution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numBucketDistribution.Location = new System.Drawing.Point(448, 178);
            this.numBucketDistribution.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numBucketDistribution.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBucketDistribution.Name = "numBucketDistribution";
            this.numBucketDistribution.Size = new System.Drawing.Size(173, 20);
            this.numBucketDistribution.TabIndex = 19;
            this.numBucketDistribution.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Header Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Data Name:";
            // 
            // txtHeaderName
            // 
            this.txtHeaderName.AllowDrop = true;
            this.txtHeaderName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeaderName.Location = new System.Drawing.Point(15, 25);
            this.txtHeaderName.Name = "txtHeaderName";
            this.txtHeaderName.Size = new System.Drawing.Size(606, 20);
            this.txtHeaderName.TabIndex = 15;
            this.txtHeaderName.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDrop);
            this.txtHeaderName.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            // 
            // txtDataName
            // 
            this.txtDataName.AllowDrop = true;
            this.txtDataName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataName.Location = new System.Drawing.Point(15, 68);
            this.txtDataName.Name = "txtDataName";
            this.txtDataName.Size = new System.Drawing.Size(606, 20);
            this.txtDataName.TabIndex = 16;
            this.txtDataName.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDrop);
            this.txtDataName.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            // 
            // btnRepack
            // 
            this.btnRepack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRepack.Location = new System.Drawing.Point(627, 201);
            this.btnRepack.Name = "btnRepack";
            this.btnRepack.Size = new System.Drawing.Size(59, 23);
            this.btnRepack.TabIndex = 27;
            this.btnRepack.Text = "Repack";
            this.btnRepack.UseVisualStyleBackColor = true;
            this.btnRepack.Click += new System.EventHandler(this.btnRepack_Click);
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseOutput.Location = new System.Drawing.Point(627, 152);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(59, 20);
            this.btnBrowseOutput.TabIndex = 30;
            this.btnBrowseOutput.Text = "Browse";
            this.btnBrowseOutput.UseVisualStyleBackColor = true;
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.AllowDrop = true;
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(15, 152);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(606, 20);
            this.txtOutput.TabIndex = 28;
            this.txtOutput.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDrop);
            this.txtOutput.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            // 
            // txtCurrent
            // 
            this.txtCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrent.Location = new System.Drawing.Point(12, 230);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.ReadOnly = true;
            this.txtCurrent.Size = new System.Drawing.Size(674, 20);
            this.txtCurrent.TabIndex = 32;
            // 
            // pbrProgress
            // 
            this.pbrProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbrProgress.Location = new System.Drawing.Point(12, 256);
            this.pbrProgress.Name = "pbrProgress";
            this.pbrProgress.Size = new System.Drawing.Size(674, 23);
            this.pbrProgress.TabIndex = 31;
            // 
            // btnBrowseInput
            // 
            this.btnBrowseInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseInput.Location = new System.Drawing.Point(627, 110);
            this.btnBrowseInput.Name = "btnBrowseInput";
            this.btnBrowseInput.Size = new System.Drawing.Size(59, 20);
            this.btnBrowseInput.TabIndex = 35;
            this.btnBrowseInput.Text = "Browse";
            this.btnBrowseInput.UseVisualStyleBackColor = true;
            this.btnBrowseInput.Click += new System.EventHandler(this.btnBrowseInput_Click);
            // 
            // txtInput
            // 
            this.txtInput.AllowDrop = true;
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(15, 110);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(606, 20);
            this.txtInput.TabIndex = 33;
            this.txtInput.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDrop);
            this.txtInput.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 291);
            this.Controls.Add(this.btnBrowseInput);
            this.Controls.Add(lblInput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtCurrent);
            this.Controls.Add(this.pbrProgress);
            this.Controls.Add(this.btnBrowseOutput);
            this.Controls.Add(lblOutput);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnRepack);
            this.Controls.Add(this.cbxBigEndian);
            this.Controls.Add(this.cbxGame);
            this.Controls.Add(this.btnBrowseHeaderBucketCount);
            this.Controls.Add(this.btnBrowseDataName);
            this.Controls.Add(this.btnBrowseHeaderName);
            this.Controls.Add(this.lblBucketDistribution);
            this.Controls.Add(this.numBucketDistribution);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHeaderName);
            this.Controls.Add(this.txtDataName);
            this.Name = "FormMain";
            this.Text = "DVDRebinder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numBucketDistribution)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxBigEndian;
        private System.Windows.Forms.ComboBox cbxGame;
        private System.Windows.Forms.Button btnBrowseHeaderBucketCount;
        private System.Windows.Forms.Button btnBrowseDataName;
        private System.Windows.Forms.Button btnBrowseHeaderName;
        private System.Windows.Forms.Label lblBucketDistribution;
        private System.Windows.Forms.NumericUpDown numBucketDistribution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHeaderName;
        private System.Windows.Forms.TextBox txtDataName;
        private System.Windows.Forms.Button btnRepack;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtCurrent;
        private System.Windows.Forms.ProgressBar pbrProgress;
        private System.Windows.Forms.Button btnBrowseInput;
        private System.Windows.Forms.TextBox txtInput;
    }
}