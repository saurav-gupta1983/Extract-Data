using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO = ExtractData.Common.DataTransferObjects;
using BO = ExtractData.BusinessLayer;

namespace ExtractData.UI.Forms
{
    /// <summary>
    /// TestStudioIntegration
    /// </summary>
    public partial class TestStudioIntegration : Form
    {
        private DTO.TestSudio ts = new DTO.TestSudio();
        private DataSet dsData;
        private DataTable dtPropositions;

        /// <summary>
        /// TestStudioIntegration
        /// </summary>
        public TestStudioIntegration()
        {
            InitializeComponent();
        }

        /// <summary>
        /// TestStudioIntegration_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestStudioIntegration_Load(object sender, EventArgs e)
        {
            dsData = new DataSet();

            DataTable dtData = new DataTable();
            dtData.TableName = "CoreStrings";
            dtData.Columns.Add(new DataColumn("String"));
            dtData.Columns.Add(new DataColumn("MaxMatch"));
            dsData.Tables.Add(dtData);

            dtData = new DataTable();
            dtData.TableName = "Mapping";
            dtData.Columns.Add(new DataColumn("String"));
            dtData.Columns.Add(new DataColumn("TestCaseID"));
            dtData.Columns.Add(new DataColumn("MatchingPercent"));
            dtData.Columns.Add(new DataColumn("MatchingWords"));
            dsData.Tables.Add(dtData);

            dtPropositions = new DataTable();
            dtPropositions.TableName = "Propositions";
            dtPropositions.Columns.Add(new DataColumn("String"));
            ReadDatafromCSV(dtPropositions, textBoxFilePath.Text.Replace("Gkit.csv", "Propositions.csv"));

            ts.ErrorCode = "0";
            ts = BO.ExtractDataBO.GetLoginSessionID(ts);
        }

        /// <summary>
        /// buttonSubmit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            ReadDatafromCSV(dsData.Tables[0], textBoxFilePath.Text);

            ts.TestSuiteID = textBoxTestSuite.Text;
            ts.TestCasesCount = 100;
            ts = BO.ExtractDataBO.GetTestSuiteDetails(ts);

            dsData = DefineMapping(dsData, ts.TestSuiteDetails);
            WriteDatatoCSV(dsData.Tables[1], textBoxOutputFilePath.Text);
        }

        /// <summary>
        /// DefineMapping
        /// </summary>
        /// <param name="dsData"></param>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private DataSet DefineMapping(DataSet dsData, DataTable dtTCData)
        {
            DataTable dtMapping = dsData.Tables[1];
            foreach (DataRow dr in dsData.Tables[0].Rows)
            {
                bool isExists = false;
                string line = dr[0].ToString();
                string lineCopy = dr[0].ToString();

                if (lineCopy != "")
                {
                    foreach (DataRow drTC in dtTCData.Rows)
                    {
                        if (drTC[1].ToString().Contains(line) || drTC[1].ToString().Contains(line))
                        {
                            DataRow drMapping = dtMapping.NewRow();
                            drMapping[0] = line;
                            drMapping[1] = drTC[0].ToString();
                            drMapping[2] = "100";
                            dtMapping.Rows.Add(drMapping);

                            isExists = true;
                        }
                    }

                    if (!isExists)
                    {
                        foreach (DataRow drProp in dtPropositions.Rows)
                            if (lineCopy.Contains(drProp[0].ToString()))
                                lineCopy = lineCopy.Replace(" " + drProp[0].ToString() + " ", "");

                        string[] separator = new string[] { " " };
                        string[] splitline = lineCopy.Split(separator, StringSplitOptions.None);

                        int count;
                        StringBuilder words;
                        foreach (DataRow drTC in dtTCData.Rows)
                        {
                            count = 0;
                            words = new StringBuilder();
                            foreach (string str in splitline)
                                if (drTC[1].ToString().Contains(str) || drTC[1].ToString().Contains(str))
                                {
                                    words.Append(str + " ");
                                    count++;
                                }

                            if (count > 0)
                            {
                                DataRow[] drExists = dtMapping.Select("String='" + line + "' AND TestCaseID = '" + drTC[0].ToString() + "'");

                                if (drExists.Length > 0)
                                {
                                    if (((count * 100) / splitline.Length) > Convert.ToDouble(drExists[0][2].ToString()))
                                    {
                                        drExists[0][2] = ((count * 100) / splitline.Length).ToString();
                                    }
                                }
                                else
                                {
                                    DataRow drMapping = dtMapping.NewRow();
                                    drMapping[0] = line;
                                    drMapping[1] = drTC[0].ToString();
                                    drMapping[2] = ((count * 100) / splitline.Length).ToString();
                                    drMapping[3] = words.ToString().Trim();
                                    dtMapping.Rows.Add(drMapping);
                                }
                            }
                        }
                    }
                }
            }

            foreach (DataRow dr in dsData.Tables[0].Rows)
            {
                if (dtMapping.Select("String = '" + dr[0].ToString() + "'").Length == 0)
                {
                    DataRow drMapping = dtMapping.NewRow();
                    drMapping[0] = dr[0].ToString();
                    drMapping[2] = "0";
                    dtMapping.Rows.Add(drMapping);
                }
            }

            return dsData;
        }

        /// <summary>
        /// ReadDatafromCSV
        /// </summary>
        public void ReadDatafromCSV(DataTable dtTable, string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    //string[] separator = new string[] { "," };
                    //string[] splitline = line.Split(separator, StringSplitOptions.None);
                    //if (splitline[0] == "Total")
                    //{
                    //    return splitline;
                    //}
                    if (line.Trim() != "")
                    {
                        DataRow dr = dtTable.NewRow();
                        dr[0] = line.Trim();
                        dtTable.Rows.Add(dr);
                    }
                }
            }

            dtTable.Rows.RemoveAt(0);

        }

        /// <summary>
        /// WriteDatatoCSV
        /// </summary>
        public void WriteDatatoCSV(DataTable dtTable, string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);


            using (StreamWriter sw = File.CreateText(filePath))
                WriteToFile(sw, "Core String", "TestCase ID", "Matching Percent", "Matching Words");

            using (StreamWriter sw = File.AppendText(filePath))
            {
                foreach (DataRow dr in dtTable.Rows)
                    WriteToFile(sw, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }

        }

        /// <summary>
        /// WriteToFile
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="coreString"></param>
        /// <param name="testCaseID"></param>
        /// <param name="matchingPercent"></param>
        /// <param name="matchingWords"></param>
        private void WriteToFile(StreamWriter sw, string coreString, string testCaseID, string matchingPercent, string matchingWords)
        {
            try
            {
                sw.WriteLine(string.Format("{0},{1},{2},{3}", "\"" + coreString + "\"", testCaseID, matchingPercent, matchingWords));
            }
            catch (Exception)
            {
            }
        }
    }
}
