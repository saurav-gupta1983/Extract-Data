namespace ExtractData.UI.Forms
{
    partial class TestStudioIntegration
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
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.labelCoreStringsFilePath = new System.Windows.Forms.Label();
            this.textBoxTestSuite = new System.Windows.Forms.TextBox();
            this.labelTestSuiteNo = new System.Windows.Forms.Label();
            this.textBoxOutputFilePath = new System.Windows.Forms.TextBox();
            this.labelResults = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(261, 158);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(118, 23);
            this.buttonSubmit.TabIndex = 19;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(207, 32);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(465, 20);
            this.textBoxFilePath.TabIndex = 18;
            this.textBoxFilePath.Text = "C:\\Saurav\\Projects\\ExtractData\\Data\\Gkit.csv";
            // 
            // labelCoreStringsFilePath
            // 
            this.labelCoreStringsFilePath.AutoSize = true;
            this.labelCoreStringsFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCoreStringsFilePath.Location = new System.Drawing.Point(12, 32);
            this.labelCoreStringsFilePath.Name = "labelCoreStringsFilePath";
            this.labelCoreStringsFilePath.Size = new System.Drawing.Size(178, 20);
            this.labelCoreStringsFilePath.TabIndex = 17;
            this.labelCoreStringsFilePath.Text = "Core string File Path:";
            // 
            // textBoxTestSuite
            // 
            this.textBoxTestSuite.Location = new System.Drawing.Point(207, 58);
            this.textBoxTestSuite.Name = "textBoxTestSuite";
            this.textBoxTestSuite.Size = new System.Drawing.Size(465, 20);
            this.textBoxTestSuite.TabIndex = 16;
            this.textBoxTestSuite.Text = "TS_39072";
            // 
            // labelTestSuiteNo
            // 
            this.labelTestSuiteNo.AutoSize = true;
            this.labelTestSuiteNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTestSuiteNo.Location = new System.Drawing.Point(12, 58);
            this.labelTestSuiteNo.Name = "labelTestSuiteNo";
            this.labelTestSuiteNo.Size = new System.Drawing.Size(193, 20);
            this.labelTestSuiteNo.TabIndex = 15;
            this.labelTestSuiteNo.Text = "TestStudio Test Suite#";
            // 
            // textBoxOutputFilePath
            // 
            this.textBoxOutputFilePath.Location = new System.Drawing.Point(207, 95);
            this.textBoxOutputFilePath.Name = "textBoxOutputFilePath";
            this.textBoxOutputFilePath.Size = new System.Drawing.Size(465, 20);
            this.textBoxOutputFilePath.TabIndex = 21;
            this.textBoxOutputFilePath.Text = "C:\\Saurav\\Projects\\ExtractData\\Data\\Output.csv";
            // 
            // labelResults
            // 
            this.labelResults.AutoSize = true;
            this.labelResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResults.Location = new System.Drawing.Point(12, 95);
            this.labelResults.Name = "labelResults";
            this.labelResults.Size = new System.Drawing.Size(100, 20);
            this.labelResults.TabIndex = 20;
            this.labelResults.Text = "Result File:";
            // 
            // TestStudioIntegration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 202);
            this.Controls.Add(this.textBoxOutputFilePath);
            this.Controls.Add(this.labelResults);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.labelCoreStringsFilePath);
            this.Controls.Add(this.textBoxTestSuite);
            this.Controls.Add(this.labelTestSuiteNo);
            this.Name = "TestStudioIntegration";
            this.Text = "TestStudioIntegration";
            this.Load += new System.EventHandler(this.TestStudioIntegration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Label labelCoreStringsFilePath;
        private System.Windows.Forms.TextBox textBoxTestSuite;
        private System.Windows.Forms.Label labelTestSuiteNo;
        private System.Windows.Forms.TextBox textBoxOutputFilePath;
        private System.Windows.Forms.Label labelResults;
    }
}