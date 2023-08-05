namespace ExtractData.UI.Forms
{
    partial class CompileFolderInformation
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
            this.BrowseFolder = new System.Windows.Forms.Button();
            this.textBoxMTFolderPath = new System.Windows.Forms.TextBox();
            this.labelMTFolderPath = new System.Windows.Forms.Label();
            this.buttonBrowseFilePath = new System.Windows.Forms.Button();
            this.textBoxMasterFilePath = new System.Windows.Forms.TextBox();
            this.labelMasterFilePath = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // BrowseFolder
            // 
            this.BrowseFolder.Location = new System.Drawing.Point(625, 72);
            this.BrowseFolder.Name = "BrowseFolder";
            this.BrowseFolder.Size = new System.Drawing.Size(51, 23);
            this.BrowseFolder.TabIndex = 7;
            this.BrowseFolder.Text = "Browse";
            this.BrowseFolder.UseVisualStyleBackColor = true;
            this.BrowseFolder.Click += new System.EventHandler(this.BrowseFolder_Click);
            // 
            // textBoxMTFolderPath
            // 
            this.textBoxMTFolderPath.Location = new System.Drawing.Point(153, 74);
            this.textBoxMTFolderPath.Name = "textBoxMTFolderPath";
            this.textBoxMTFolderPath.Size = new System.Drawing.Size(465, 20);
            this.textBoxMTFolderPath.TabIndex = 6;
            this.textBoxMTFolderPath.Text = "\\\\chinar-svr\\USERS\\A\\akotwal\\temp\\MT_Scopes";
            // 
            // labelMTFolderPath
            // 
            this.labelMTFolderPath.AutoSize = true;
            this.labelMTFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMTFolderPath.Location = new System.Drawing.Point(13, 72);
            this.labelMTFolderPath.Name = "labelMTFolderPath";
            this.labelMTFolderPath.Size = new System.Drawing.Size(131, 20);
            this.labelMTFolderPath.TabIndex = 5;
            this.labelMTFolderPath.Text = "MT Folder Path";
            // 
            // buttonBrowseFilePath
            // 
            this.buttonBrowseFilePath.Location = new System.Drawing.Point(625, 28);
            this.buttonBrowseFilePath.Name = "buttonBrowseFilePath";
            this.buttonBrowseFilePath.Size = new System.Drawing.Size(51, 23);
            this.buttonBrowseFilePath.TabIndex = 10;
            this.buttonBrowseFilePath.Text = "Browse";
            this.buttonBrowseFilePath.UseVisualStyleBackColor = true;
            this.buttonBrowseFilePath.Click += new System.EventHandler(this.buttonBrowseFilePath_Click);
            // 
            // textBoxMasterFilePath
            // 
            this.textBoxMasterFilePath.Location = new System.Drawing.Point(153, 30);
            this.textBoxMasterFilePath.Name = "textBoxMasterFilePath";
            this.textBoxMasterFilePath.Size = new System.Drawing.Size(465, 20);
            this.textBoxMasterFilePath.TabIndex = 9;
            // 
            // labelMasterFilePath
            // 
            this.labelMasterFilePath.AutoSize = true;
            this.labelMasterFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMasterFilePath.Location = new System.Drawing.Point(13, 28);
            this.labelMasterFilePath.Name = "labelMasterFilePath";
            this.labelMasterFilePath.Size = new System.Drawing.Size(140, 20);
            this.labelMasterFilePath.TabIndex = 8;
            this.labelMasterFilePath.Text = "Master File Path";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(254, 121);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(118, 23);
            this.buttonSubmit.TabIndex = 11;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(306, 152);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(0, 20);
            this.labelMessage.TabIndex = 12;
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // CompileMTData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 181);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.buttonBrowseFilePath);
            this.Controls.Add(this.textBoxMasterFilePath);
            this.Controls.Add(this.labelMasterFilePath);
            this.Controls.Add(this.BrowseFolder);
            this.Controls.Add(this.textBoxMTFolderPath);
            this.Controls.Add(this.labelMTFolderPath);
            this.Name = "CompileMTData";
            this.Text = "ExtractBugReportsfromEmail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BrowseFolder;
        private System.Windows.Forms.TextBox textBoxMTFolderPath;
        private System.Windows.Forms.Label labelMTFolderPath;
        private System.Windows.Forms.Button buttonBrowseFilePath;
        private System.Windows.Forms.TextBox textBoxMasterFilePath;
        private System.Windows.Forms.Label labelMasterFilePath;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}