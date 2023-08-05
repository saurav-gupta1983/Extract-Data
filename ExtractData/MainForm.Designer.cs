namespace ExtractData.UI
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adobeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractDataFromEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.featureRequestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mTDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zStringsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileFolderInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testStudioIntegrationTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adobeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(901, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adobeToolStripMenuItem
            // 
            this.adobeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractDataFromEmailToolStripMenuItem,
            this.compileDataToolStripMenuItem,
            this.compareDataToolStripMenuItem,
            this.compileFolderInformationToolStripMenuItem,
            this.testStudioIntegrationTestToolStripMenuItem});
            this.adobeToolStripMenuItem.Name = "adobeToolStripMenuItem";
            this.adobeToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.adobeToolStripMenuItem.Text = "Adobe";
            // 
            // extractDataFromEmailToolStripMenuItem
            // 
            this.extractDataFromEmailToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.featureRequestsToolStripMenuItem});
            this.extractDataFromEmailToolStripMenuItem.Name = "extractDataFromEmailToolStripMenuItem";
            this.extractDataFromEmailToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.extractDataFromEmailToolStripMenuItem.Text = "Extract Data from Email";
            // 
            // featureRequestsToolStripMenuItem
            // 
            this.featureRequestsToolStripMenuItem.Name = "featureRequestsToolStripMenuItem";
            this.featureRequestsToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.featureRequestsToolStripMenuItem.Text = "Feature Requests and Bug Report";
            this.featureRequestsToolStripMenuItem.Click += new System.EventHandler(this.featureRequestsToolStripMenuItem_Click);
            // 
            // compileDataToolStripMenuItem
            // 
            this.compileDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mTDataToolStripMenuItem});
            this.compileDataToolStripMenuItem.Name = "compileDataToolStripMenuItem";
            this.compileDataToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.compileDataToolStripMenuItem.Text = "Compile Data";
            // 
            // mTDataToolStripMenuItem
            // 
            this.mTDataToolStripMenuItem.Name = "mTDataToolStripMenuItem";
            this.mTDataToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.mTDataToolStripMenuItem.Text = "MT Data";
            this.mTDataToolStripMenuItem.Click += new System.EventHandler(this.mTDataToolStripMenuItem_Click);
            // 
            // compareDataToolStripMenuItem
            // 
            this.compareDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zStringsToolStripMenuItem});
            this.compareDataToolStripMenuItem.Name = "compareDataToolStripMenuItem";
            this.compareDataToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.compareDataToolStripMenuItem.Text = "Compare Data";
            // 
            // zStringsToolStripMenuItem
            // 
            this.zStringsToolStripMenuItem.Name = "zStringsToolStripMenuItem";
            this.zStringsToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.zStringsToolStripMenuItem.Text = "ZStrings";
            this.zStringsToolStripMenuItem.Click += new System.EventHandler(this.zStringsToolStripMenuItem_Click);
            // 
            // compileFolderInformationToolStripMenuItem
            // 
            this.compileFolderInformationToolStripMenuItem.Name = "compileFolderInformationToolStripMenuItem";
            this.compileFolderInformationToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.compileFolderInformationToolStripMenuItem.Text = "CompileFolderInformation";
            this.compileFolderInformationToolStripMenuItem.Click += new System.EventHandler(this.compileFolderInformationToolStripMenuItem_Click);
            // 
            // testStudioIntegrationTestToolStripMenuItem
            // 
            this.testStudioIntegrationTestToolStripMenuItem.Name = "testStudioIntegrationTestToolStripMenuItem";
            this.testStudioIntegrationTestToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.testStudioIntegrationTestToolStripMenuItem.Text = "Test Studio Integration Test";
            this.testStudioIntegrationTestToolStripMenuItem.Click += new System.EventHandler(this.testStudioIntegrationTestToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 597);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adobeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractDataFromEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem featureRequestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compileDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mTDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zStringsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compileFolderInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testStudioIntegrationTestToolStripMenuItem;
    }
}