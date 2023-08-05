namespace ExtractData.UI.Forms
{
    partial class ExtractFeatureRequestsfromEmail
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
            this.textBoxEmailContent = new System.Windows.Forms.TextBox();
            this.labelEmailContent = new System.Windows.Forms.Label();
            this.labelFilePath = new System.Windows.Forms.Label();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.Browse = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonExtractData = new System.Windows.Forms.Button();
            this.textBoxRequestedDate = new System.Windows.Forms.TextBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxEmailContent
            // 
            this.textBoxEmailContent.Location = new System.Drawing.Point(168, 25);
            this.textBoxEmailContent.Multiline = true;
            this.textBoxEmailContent.Name = "textBoxEmailContent";
            this.textBoxEmailContent.Size = new System.Drawing.Size(523, 187);
            this.textBoxEmailContent.TabIndex = 0;
            // 
            // labelEmailContent
            // 
            this.labelEmailContent.AutoSize = true;
            this.labelEmailContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmailContent.Location = new System.Drawing.Point(28, 25);
            this.labelEmailContent.Name = "labelEmailContent";
            this.labelEmailContent.Size = new System.Drawing.Size(122, 20);
            this.labelEmailContent.TabIndex = 1;
            this.labelEmailContent.Text = "Email Content";
            // 
            // labelFilePath
            // 
            this.labelFilePath.AutoSize = true;
            this.labelFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilePath.Location = new System.Drawing.Point(28, 252);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(80, 20);
            this.labelFilePath.TabIndex = 2;
            this.labelFilePath.Text = "File Path";
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(168, 254);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(465, 20);
            this.textBoxFilePath.TabIndex = 3;
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(640, 252);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(51, 23);
            this.Browse.TabIndex = 4;
            this.Browse.Text = "Browse";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // buttonExtractData
            // 
            this.buttonExtractData.Location = new System.Drawing.Point(299, 339);
            this.buttonExtractData.Name = "buttonExtractData";
            this.buttonExtractData.Size = new System.Drawing.Size(118, 23);
            this.buttonExtractData.TabIndex = 5;
            this.buttonExtractData.Text = "ExtractData";
            this.buttonExtractData.UseVisualStyleBackColor = true;
            this.buttonExtractData.Click += new System.EventHandler(this.buttonExtractData_Click);
            // 
            // textBoxRequestedDate
            // 
            this.textBoxRequestedDate.Location = new System.Drawing.Point(168, 218);
            this.textBoxRequestedDate.Name = "textBoxRequestedDate";
            this.textBoxRequestedDate.Size = new System.Drawing.Size(465, 20);
            this.textBoxRequestedDate.TabIndex = 7;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.Location = new System.Drawing.Point(28, 216);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(141, 20);
            this.labelDate.TabIndex = 6;
            this.labelDate.Text = "Requested Date";
            // 
            // ExtractFeatureRequestsfromEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 544);
            this.Controls.Add(this.textBoxRequestedDate);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.buttonExtractData);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.labelFilePath);
            this.Controls.Add(this.labelEmailContent);
            this.Controls.Add(this.textBoxEmailContent);
            this.Name = "ExtractFeatureRequestsfromEmail";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEmailContent;
        private System.Windows.Forms.Label labelEmailContent;
        private System.Windows.Forms.Label labelFilePath;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonExtractData;
        private System.Windows.Forms.TextBox textBoxRequestedDate;
        private System.Windows.Forms.Label labelDate;
    }
}

