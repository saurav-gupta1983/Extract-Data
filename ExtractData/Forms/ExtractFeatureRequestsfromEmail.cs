using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO = ExtractData.Common.DataTransferObjects;
using BO = ExtractData.BusinessLayer;

namespace ExtractData.UI.Forms
{
    public partial class ExtractFeatureRequestsfromEmail : Form
    {
        public ExtractFeatureRequestsfromEmail()
        {
            InitializeComponent();
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
            }
            textBoxFilePath.Text = openFileDialog.FileName; // <-- For debugging use only.
        }

        private void buttonExtractData_Click(object sender, EventArgs e)
        {
            BO.ExtractDataBO.SaveFeatureRequestDataToXLS(textBoxFilePath.Text, ParseData(textBoxEmailContent.Text, textBoxRequestedDate.Text));
        }

        private DTO.FeatureRequestDTO ParseData(string data, string date)
        {
            DTO.FeatureRequestDTO dataDTO = new DTO.FeatureRequestDTO();

            if (date == "")
            {
                dataDTO.RequestedDate = System.DateTime.Now.Date.ToShortDateString();
            }
            else
            {
                dataDTO.RequestedDate = date;
            }

            string[] splitData = data.Split(Environment.NewLine.ToCharArray());

            bool isFeedbackColumnReached = false;

            for (int counter = 0; counter < splitData.Length; counter++)
            {
                string[] separator = new string[] { ":" };
                string[] splitcontent = splitData[counter].Split(separator, StringSplitOptions.RemoveEmptyEntries);

                if (!isFeedbackColumnReached)
                {
                    if (splitcontent.Length > 1)
                    {
                        string key = splitcontent[0].Trim();
                        StringBuilder joinValues = new StringBuilder(splitcontent[1].Trim());

                        if (key != "HTTPREFERRER")
                        {
                            if (splitcontent.Length > 2)
                            {
                                for (int i = 2; i < splitcontent.Length; i++)
                                {
                                    joinValues.Append(" : " + splitcontent[i].Trim());
                                }
                            }

                            if (key == "Feedback Report")
                            {
                                isFeedbackColumnReached = true;
                            }

                            ParsedDataDTO(key, joinValues.ToString().Replace("'", "''"), ref dataDTO);
                        }
                    }
                }
                else
                {
                    dataDTO.Feedback = dataDTO.Feedback + Environment.NewLine + splitData[counter].Replace("'", "''");
                }
            }
            dataDTO.Feedback = dataDTO.Feedback + ";&nbsp";
            return dataDTO;
        }

        private void ParsedDataDTO(string key, string joinValues, ref DTO.FeatureRequestDTO dataDTO)
        {
            if (key == "Name")
            {
                dataDTO.Name = joinValues;
            }
            else if (key == "Email Address")
            {
                dataDTO.EmailAddress = joinValues;
            }
            else if (key == "Company/Institution")
            {
                dataDTO.Company = joinValues;
            }
            else if (key == "Product")
            {
                dataDTO.Product = joinValues;
            }
            else if (key == "Product Version")
            {
                dataDTO.ProductVersion = joinValues;
            }
            else if (key == "Product Language")
            {
                dataDTO.ProductLanguage = joinValues;
            }
            else if (key == "Feedback Report")
            {
                dataDTO.Feedback = joinValues;
            }
            else if (key == "Feature Request/Bug Report")
            {
                dataDTO.RequestType = joinValues;
            }
            else if (key == "Operating System")
            {
                dataDTO.Platform = joinValues;
            }
            else if (key == "OS version")
            {
                dataDTO.OSVersion = joinValues;
            }
            else if (key == "OS language")
            {
                dataDTO.OSLanguage = joinValues;
            }
        }

    }
}
