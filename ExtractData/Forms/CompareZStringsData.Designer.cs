namespace ExtractData.UI.Forms
{
    partial class CompareZStringsData
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
            this.buttonCompare = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonBrowseFilePath = new System.Windows.Forms.Button();
            this.textBoxMasterFilePath = new System.Windows.Forms.TextBox();
            this.labelMasterFilePath = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.BrowseFolder = new System.Windows.Forms.Button();
            this.textBoxMTFolderPath = new System.Windows.Forms.TextBox();
            this.labelMTFolderPath = new System.Windows.Forms.Label();
            this.buttonDuplicateHotKeys = new System.Windows.Forms.Button();
            this.buttonCharacterLengthComparison = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCompare
            // 
            this.buttonCompare.Location = new System.Drawing.Point(53, 146);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(118, 23);
            this.buttonCompare.TabIndex = 18;
            this.buttonCompare.Text = "Compare ZStrings";
            this.buttonCompare.UseVisualStyleBackColor = true;
            this.buttonCompare.Click += new System.EventHandler(this.buttonCompare_Click);
            // 
            // buttonBrowseFilePath
            // 
            this.buttonBrowseFilePath.Location = new System.Drawing.Point(658, 53);
            this.buttonBrowseFilePath.Name = "buttonBrowseFilePath";
            this.buttonBrowseFilePath.Size = new System.Drawing.Size(51, 23);
            this.buttonBrowseFilePath.TabIndex = 17;
            this.buttonBrowseFilePath.Text = "Browse";
            this.buttonBrowseFilePath.UseVisualStyleBackColor = true;
            // 
            // textBoxMasterFilePath
            // 
            this.textBoxMasterFilePath.Location = new System.Drawing.Point(186, 55);
            this.textBoxMasterFilePath.Name = "textBoxMasterFilePath";
            this.textBoxMasterFilePath.Size = new System.Drawing.Size(465, 20);
            this.textBoxMasterFilePath.TabIndex = 16;
            this.textBoxMasterFilePath.Text = "\\\\rajjain-w7\\resources\\en_US\\zstring_mac\\illustrator\\Illustrator.ztx";
            // 
            // labelMasterFilePath
            // 
            this.labelMasterFilePath.AutoSize = true;
            this.labelMasterFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMasterFilePath.Location = new System.Drawing.Point(12, 53);
            this.labelMasterFilePath.Name = "labelMasterFilePath";
            this.labelMasterFilePath.Size = new System.Drawing.Size(127, 20);
            this.labelMasterFilePath.TabIndex = 15;
            this.labelMasterFilePath.Text = "Reference File";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // BrowseFolder
            // 
            this.BrowseFolder.Location = new System.Drawing.Point(658, 97);
            this.BrowseFolder.Name = "BrowseFolder";
            this.BrowseFolder.Size = new System.Drawing.Size(51, 23);
            this.BrowseFolder.TabIndex = 14;
            this.BrowseFolder.Text = "Browse";
            this.BrowseFolder.UseVisualStyleBackColor = true;
            // 
            // textBoxMTFolderPath
            // 
            this.textBoxMTFolderPath.Location = new System.Drawing.Point(186, 99);
            this.textBoxMTFolderPath.Name = "textBoxMTFolderPath";
            this.textBoxMTFolderPath.Size = new System.Drawing.Size(465, 20);
            this.textBoxMTFolderPath.TabIndex = 13;
            this.textBoxMTFolderPath.Text = "\\\\rajjain-w7\\resources";
            // 
            // labelMTFolderPath
            // 
            this.labelMTFolderPath.AutoSize = true;
            this.labelMTFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMTFolderPath.Location = new System.Drawing.Point(12, 97);
            this.labelMTFolderPath.Name = "labelMTFolderPath";
            this.labelMTFolderPath.Size = new System.Drawing.Size(175, 20);
            this.labelMTFolderPath.TabIndex = 12;
            this.labelMTFolderPath.Text = "ZStrings Folder Path";
            // 
            // buttonDuplicateHotKeys
            // 
            this.buttonDuplicateHotKeys.Location = new System.Drawing.Point(216, 146);
            this.buttonDuplicateHotKeys.Name = "buttonDuplicateHotKeys";
            this.buttonDuplicateHotKeys.Size = new System.Drawing.Size(118, 23);
            this.buttonDuplicateHotKeys.TabIndex = 19;
            this.buttonDuplicateHotKeys.Text = "Duplicate HotKeys";
            this.buttonDuplicateHotKeys.UseVisualStyleBackColor = true;
            this.buttonDuplicateHotKeys.Click += new System.EventHandler(this.buttonDuplicateHotKeys_Click);
            // 
            // buttonCharacterLengthComparison
            // 
            this.buttonCharacterLengthComparison.Location = new System.Drawing.Point(375, 146);
            this.buttonCharacterLengthComparison.Name = "buttonCharacterLengthComparison";
            this.buttonCharacterLengthComparison.Size = new System.Drawing.Size(118, 23);
            this.buttonCharacterLengthComparison.TabIndex = 20;
            this.buttonCharacterLengthComparison.Text = "Compare Character Lengths";
            this.buttonCharacterLengthComparison.UseVisualStyleBackColor = true;
            this.buttonCharacterLengthComparison.Click += new System.EventHandler(this.buttonCharacterLengthComparison_Click);
            // 
            // CompareZStringsData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 266);
            this.Controls.Add(this.buttonCharacterLengthComparison);
            this.Controls.Add(this.buttonDuplicateHotKeys);
            this.Controls.Add(this.buttonCompare);
            this.Controls.Add(this.buttonBrowseFilePath);
            this.Controls.Add(this.textBoxMasterFilePath);
            this.Controls.Add(this.labelMasterFilePath);
            this.Controls.Add(this.BrowseFolder);
            this.Controls.Add(this.textBoxMTFolderPath);
            this.Controls.Add(this.labelMTFolderPath);
            this.Name = "CompareZStringsData";
            this.Text = "ExtractBugReportsfromEmail";
            this.Load += new System.EventHandler(this.CompareZStringsData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCompare;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button buttonBrowseFilePath;
        private System.Windows.Forms.TextBox textBoxMasterFilePath;
        private System.Windows.Forms.Label labelMasterFilePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button BrowseFolder;
        private System.Windows.Forms.TextBox textBoxMTFolderPath;
        private System.Windows.Forms.Label labelMTFolderPath;
        private System.Windows.Forms.Button buttonDuplicateHotKeys;
        private System.Windows.Forms.Button buttonCharacterLengthComparison;

    }
}