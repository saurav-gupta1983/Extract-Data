using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DTO = ExtractData.Common.DataTransferObjects;
using BO = ExtractData.BusinessLayer;

namespace ExtractData.UI.Forms
{
    public partial class CompileFolderInformation : Form
    {
        public CompileFolderInformation()
        {
            InitializeComponent();
        }

        private void buttonBrowseFilePath_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
            }
            textBoxMasterFilePath.Text = openFileDialog.FileName; // <-- For debugging use only.
        }

        private void BrowseFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
            }
            textBoxMTFolderPath.Text = folderBrowserDialog.SelectedPath; // <-- For debugging use only.
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            DTO.MTDataDTO data;

            DirectoryInfo dir = new DirectoryInfo(textBoxMTFolderPath.Text);

            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                data = new DTO.MTDataDTO();


                if (file.Name.Contains(".csv"))
                {
                    ReadData(file, data);
                    WriteData(data);
                }
            }

        }

        private void WriteData(DTO.MTDataDTO data)
        {
            if (BO.ExtractDataBO.SaveDataToXLS(textBoxMasterFilePath.Text, data))
            {
                labelMessage.Text += "Data Saved successfully for " + data.FileName + Environment.NewLine;
            }
            else
            {
                labelMessage.Text += "Data not saved for " + data.FileName + Environment.NewLine;
            }
        }

        private void ReadData(FileInfo file, DTO.MTDataDTO data)
        {
            string[] separator = new string[] { "_" };
            string[] splitFileName = file.Name.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            data.FileName = file.Name;
            data.Product = splitFileName[0];
            data.ProductLanguage = splitFileName[splitFileName.Length - 1].Replace(".csv", "");
            data.HandOff = splitFileName[1] + "_" + splitFileName[2];
            data.HandOffDate = file.LastWriteTime.ToShortDateString();

            //DataRow[] dataRow = BO.ExtractDataBO.ReadMTDatafromXLS(textBoxMTFolderPath.Text + "\\" + data.FileName, data).Select("Asset = 'Total'");
            string[] assetData = BO.ExtractDataBO.ReadMTDatafromCSV(textBoxMTFolderPath.Text + "\\" + data.FileName, data);

            if (assetData != null)
            {
                data.Total = assetData[1].ToString();
                data.ICEMatch = assetData[2].ToString();
                data.HundredMatch = assetData[3].ToString();
                data.NinetyMatch = assetData[4].ToString();
                data.SeventyMatch = assetData[5].ToString();
                data.ZeroMatch = assetData[6].ToString();
                data.Repeatitions = assetData[7].ToString();
                data.FuzzyWords = assetData[8].ToString();
            }
        }
    }
}
