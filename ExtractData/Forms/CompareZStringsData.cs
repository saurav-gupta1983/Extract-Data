using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO = ExtractData.Common.DataTransferObjects;
using BO = ExtractData.BusinessLayer;
using System.Collections;

namespace ExtractData.UI.Forms
{
    /// <summary>
    /// CompareZStringsData
    /// </summary>
    public partial class CompareZStringsData : Form
    {
        #region Variables

        string logFilePath = @"C:\Saurav\Projects\ExtractData\ExtractData\Files\Exceptionreport\<Language>.txt";
        DataTable excludedStringIDData;
        StringBuilder issuesWithExcludedStrings = new StringBuilder("/*This file contains ZStrings that cannot be excluded. */");
        StringBuilder canBeExcluded = new StringBuilder("/*This file contains ZStrings that can be excluded. */");
        Hashtable uniqueStringIDs = new Hashtable();
        int subDirCount = 0;
        string outputFilePath = @"C:\Saurav\Projects\ExtractData\Data\ZStringsOutput\";

        #endregion

        #region Constructor

        /// <summary>
        /// CompareZStringsData
        /// </summary>
        public CompareZStringsData()
        {
            InitializeComponent();
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBrowseFilePath_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
            }
            textBoxMasterFilePath.Text = openFileDialog.FileName; // <-- For debugging use only.
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowseFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
            }
            textBoxMTFolderPath.Text = folderBrowserDialog.SelectedPath; // <-- For debugging use only.
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCompare_Click(object sender, EventArgs e)
        {
            excludedStringIDData = BO.ExtractDataBO.ReadExcludedZStringsfromCSV(@"C:\Saurav\Projects\ExtractData\ExtractData\Files\IgnoredZStringsComparisonStringIDs.txt");


            DataTable refdata;
            refdata = BO.ExtractDataBO.ReadZStringsfromCSV(textBoxMasterFilePath.Text);
            refdata.Columns.Add("Count", typeof(Int32));
            foreach (DataRow refRow in refdata.Rows)
            {
                refRow[2] = 0;
            }

            string followingPath = @"\zstring_mac\illustrator\Illustrator.ztx";

            DirectoryInfo dir = new DirectoryInfo(textBoxMTFolderPath.Text);
            DirectoryInfo[] subDirs = dir.GetDirectories();

            subDirCount = 0;
            foreach (DirectoryInfo subDir in subDirs)
            {
                string language = subDir.Name;
                string filePath = textBoxMTFolderPath.Text + @"\" + language + followingPath;


                if (File.Exists(filePath))
                {
                    DataTable langdata;
                    langdata = BO.ExtractDataBO.ReadZStringsfromCSV(filePath);
                    CompareAndLogData(language, filePath, refdata, langdata);
                }
                else
                {
                    Console.WriteLine("File Doesn't exist: " + filePath + "\n");
                }

                subDirCount++;
            }

            PrintExcludedFileIssues();
            PrintCanBeExcluded(refdata);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refdata"></param>
        private void PrintCanBeExcluded(DataTable refdata)
        {
            string canbeExcludedPath = logFilePath.Replace("<Language>", "CanBeExcluded"); ;
            if (!File.Exists(canbeExcludedPath))
            {
                StreamWriter sr = File.CreateText(canbeExcludedPath);
                sr.Close();
            }
            using (StreamWriter sw = new StreamWriter(canbeExcludedPath))
            {
                sw.WriteLine(canBeExcluded.ToString());

                foreach (DataRow refRow in refdata.Rows)
                {
                    if ((Int32)refRow[2] == subDirCount)
                    {
                        sw.WriteLine(refRow[0] + "=" + refRow[1]);
                    }
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        private void PrintExcludedFileIssues()
        {
            string issuesWithExcludedFile = logFilePath.Replace("<Language>", "ExcludedFileIssues"); ;
            if (!File.Exists(issuesWithExcludedFile))
            {
                StreamWriter sr = File.CreateText(issuesWithExcludedFile);
                sr.Close();
            }
            using (StreamWriter sw = new StreamWriter(issuesWithExcludedFile))
            {
                sw.WriteLine(issuesWithExcludedStrings);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lang"></param>
        /// <param name="filePath"></param>
        /// <param name="refdata"></param>
        /// <param name="langdata"></param>
        private void CompareAndLogData(string lang, string filePath, DataTable refdata, DataTable langdata)
        {
            string langLogFilePath = logFilePath.Replace("<Language>", lang);

            if (!File.Exists(langLogFilePath))
            {
                StreamWriter sr = File.CreateText(langLogFilePath);
                sr.Close();
            }

            using (StreamWriter sw = new StreamWriter(langLogFilePath))
            {
                sw.WriteLine(WriteHeader(refdata));
                sw.WriteLine("Language: " + lang);
                sw.WriteLine("-------------------");
                sw.WriteLine("StringID Count: " + langdata.Rows.Count.ToString());
                sw.WriteLine("FilePath: " + filePath);

                StringBuilder stringIDNotFound = new StringBuilder("******StringID Not Found: ******\n");
                StringBuilder stringIDNotLocalized = new StringBuilder("******StringID Not Localized: ******\n");
                stringIDNotFound.AppendLine("");
                stringIDNotLocalized.AppendLine("");

                foreach (DataRow refRow in refdata.Rows)
                {
                    DataRow[] langRows = langdata.Select("StringID = '" + refRow[0].ToString() + "'");

                    if (langRows.Length == 0)
                    {
                        stringIDNotFound.AppendLine(refRow[0].ToString());
                    }
                    else
                    {
                        foreach (DataRow langRow in langRows)
                        {
                            DataRow[] excludedData = excludedStringIDData.Select("StringID = '" + langRow[0].ToString() + "'");

                            if (excludedData.Length == 0)
                            {
                                if (refRow[1].ToString() == langRow[1].ToString())
                                {
                                    stringIDNotLocalized.AppendLine(refRow[0].ToString() + "=" + langRow[1].ToString());
                                    refRow[2] = (Int32)refRow[2] + 1;
                                }
                            }
                            else
                            {
                                if (excludedData[0].ItemArray[1].ToString() != langRow[1].ToString())
                                {
                                    issuesWithExcludedStrings.AppendLine("(" + lang + ")" + refRow[0].ToString() + "=" + langRow[1].ToString());
                                }
                            }
                        }
                    }

                }

                StringBuilder stringIDDuplicated = new StringBuilder("******StringID Duplicated: ******\n");
                stringIDDuplicated.AppendLine("");

                foreach (DataRow langRow in langdata.Rows)
                {

                    DataRow[] langRows = langdata.Select("StringID = '" + langRow[0].ToString() + "'");

                    if (langRows.Length > 1)
                    {
                        stringIDDuplicated.AppendLine(langRow[0].ToString() + " Count:=" + langRows.Length);
                    }
                }

                sw.WriteLine(stringIDNotFound.ToString());
                sw.WriteLine(stringIDNotLocalized.ToString());
                sw.WriteLine(stringIDDuplicated.ToString());

                sw.WriteLine("-------------------");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string WriteHeader(DataTable data)
        {
            StringBuilder header = new StringBuilder("/*This file contains exception report for Ztsrings Comparison. */ \n");
            header.AppendLine("This is the header for the file.");
            header.AppendLine("-------------------");
            // Arbitrary objects can also be written to the file.
            header.AppendLine("The date is: " + DateTime.Now.ToString());
            header.AppendLine("The English Words Count: " + data.Rows.Count);
            header.AppendLine("-------------------");
            return header.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompareZStringsData_Load(object sender, EventArgs e)
        {
            issuesWithExcludedStrings.AppendLine("");
        }

        /// <summary>
        /// buttonDuplicateHotKeys_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDuplicateHotKeys_Click(object sender, EventArgs e)
        {
            string directoryPath = @"\\rajjain-w7\Resources";
            string menuListPath = @"C:\Saurav\Projects\ExtractData\ExtractData\Files\MenuList.txt";
            string followingPath = @"\zstring_mac\illustrator\Illustrator.ztx";

            DataTable dtMenuList = BO.ExtractDataBO.ReadExcludedZStringsfromCSV(menuListPath);
            DataTable dtEnglishList = BO.ExtractDataBO.ReadExcludedZStringsfromCSV(directoryPath + @"\en_US" + followingPath);

            DirectoryInfo dir = new DirectoryInfo(directoryPath);
            DirectoryInfo[] subDirs = dir.GetDirectories();

            subDirCount = 0;
            foreach (DirectoryInfo subDir in subDirs)
            {
                string language = subDir.Name;
                string filePath = directoryPath + @"\" + language + followingPath;

                if (File.Exists(filePath))
                //if (File.Exists(filePath) && language == "en_US")
                {
                    DuplicateHotkeys(dtEnglishList, dtMenuList, filePath, language);
                }
                else
                {
                    Console.WriteLine("File Doesn't exist: " + filePath + "\n");
                }

                subDirCount++;
            }
            //string localeFilePath = @"C:\Saurav\Projects\ExtractData\ExtractData\Files\Illustrator.ztx";
            //string language = "en_GB";
            //DuplicateHotkeys(localeFilePath, language);
        }

        /// <summary>
        /// buttonDuplicateHotKeys_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DuplicateHotkeys(DataTable dtEnglishList, DataTable dtMenuList, string localeFilePath, string language)
        {
            string outputFilePath = @"C:\Saurav\Projects\ExtractData\ExtractData\Files\Hotkeys\" + language;
            excludedStringIDData = BO.ExtractDataBO.ReadExcludedZStringsfromCSV(localeFilePath);
            ArrayList distinctMenus = new ArrayList();

            DataTable dtData = new DataTable();
            dtData = excludedStringIDData.Clone();

            dtData.Columns.Add("StringIDRoot");
            dtData.Columns.Add("HotKey");
            dtData.Columns.Add("EnglishHotKey");
            dtData.Columns.Add("EnglishValue");

            foreach (DataRow dr in excludedStringIDData.Rows)
            {
                //if (dr["value"].ToString().Contains("&") && dr["StringID"].ToString().Contains("Menus") && !dr["value"].ToString().Contains("& "))
                //if (dr["StringID"].ToString().Contains("$$$/_MBAR/Mnu/Edit/ColorSettings") || dr["StringID"].ToString().Contains("$$$/Perspective/str/presets/GridPresets"))
                //{


                DataRow[] drExistsinMenuList = dtMenuList.Select("Value = '" + dr["StringID"].ToString() + "'");
                if (drExistsinMenuList.Length == 1)
                {
                    DataRow[] drEnglishList = dtEnglishList.Select("StringID = '" + dr[0].ToString() + "'");
                    DataRow drNew = dtData.NewRow();

                    drNew[0] = dr[0];
                    drNew[1] = dr[1];
                    drNew[2] = drExistsinMenuList[0][0].ToString();
                    drNew[3] = GetHotKey(dr[1].ToString());
                    drNew[4] = drEnglishList[0][1].ToString();
                    drNew[5] = GetHotKey(drEnglishList[0][1].ToString());
                    dtData.Rows.Add(drNew);

                    Keys key = new Keys();
                    key.keyID = drExistsinMenuList[0][0].ToString();
                    key.value = drNew[3].ToString();

                    bool exists = false;
                    foreach (Keys tempKey in distinctMenus)
                    {
                        if (IsEqual(tempKey.keyID, key.keyID) && IsEqual(tempKey.value, key.value))
                        {
                            exists = true;
                        }
                    }

                    if (!exists)
                        distinctMenus.Add(key);
                }
                //    }
            }

            string filePath = outputFilePath + "_DuplicateHotKeysList.csv";

            if (!File.Exists(filePath))
            {
                StreamWriter sr = File.CreateText(filePath);
                sr.Close();
            }
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("Menu,StringID,Localized Value,Localized HotKey,English Value,English Hotkey");
                foreach (Keys key in distinctMenus)
                {
                    if (key.value != "")
                    {
                        DataRow[] rows = dtData.Select("StringIDRoot = '" + key.keyID + "' AND HotKey = '" + key.value + "'");

                        if (rows.Length > 1)
                        {
                            foreach (DataRow refRow in rows)
                            {
                                sw.WriteLine(refRow[2].ToString() + "," + refRow[0].ToString() + "," + refRow[1].ToString() + "," + refRow[3].ToString() + "," + refRow[4].ToString() + "," + refRow[5].ToString());
                            }
                        }
                    }
                }
            }

            filePath = outputFilePath + "_AllHotKeysList.csv";
            if (!File.Exists(filePath))
            {
                StreamWriter sr = File.CreateText(filePath);
                sr.Close();
            }
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("Menu,StringID,Localized Value,Localized HotKey,English Value,English Hotkey");
                foreach (Keys key in distinctMenus)
                {
                    DataRow[] rows = dtData.Select("StringIDRoot = '" + key.keyID + "' AND HotKey = '" + key.value + "'");

                    foreach (DataRow refRow in dtData.Rows)
                    {
                        sw.WriteLine(refRow[2].ToString() + "," + refRow[0].ToString() + "," + refRow[1].ToString() + "," + refRow[3].ToString() + "," + refRow[4].ToString() + "," + refRow[5].ToString());
                    }
                }
            }

        }

        /// <summary>
        /// GetHotKey
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string GetHotKey(string value)
        {
            int hotkeyLocation = -1;
            string tempValue = value;

            while (true)
            {
                hotkeyLocation = tempValue.LastIndexOf("&&");

                if (hotkeyLocation == -1)
                    break;
                else
                {
                    tempValue = tempValue.Substring(0, hotkeyLocation);
                }
            }

            hotkeyLocation = tempValue.LastIndexOf("&");
            if (hotkeyLocation != -1)
            {
                return tempValue.Substring(hotkeyLocation + 1, 1);
            }

            return "";
        }

        /// <summary>
        /// IsEqual
        /// </summary>
        /// <param name="string1"></param>
        /// <param name="string2"></param>
        /// <returns></returns>
        public bool IsEqual(string string1, string string2)
        {
            return (string.Compare(string1, string2, true) == 0);
        }

        /// <summary>
        /// buttonCharacterLengthComparison_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCharacterLengthComparison_Click(object sender, EventArgs e)
        {
            string englishLocaleCode = "en_US";
            string directoryPath = @"\\rajjain-w7\Resources";
            //string outPut = @"C:\Saurav\Projects\ExtractData\ExtractData\Files\CompareCharacters";
            string followingPath = @"\zstring_mac\illustrator\Illustrator.ztx";

            DataTable dtStringsList = BO.ExtractDataBO.ReadExcludedZStringsfromCSV(directoryPath + @"\" + englishLocaleCode + followingPath, true);
            dtStringsList.Columns["Value"].ColumnName = englishLocaleCode;

            DirectoryInfo dir = new DirectoryInfo(directoryPath);
            DirectoryInfo[] subDirs = dir.GetDirectories();

            subDirCount = 0;
            foreach (DirectoryInfo subDir in subDirs)
            {
                //if (subDirCount > 2)
                //    break;

                string localeCode = subDir.Name;
                if (localeCode != "en_US" && localeCode != "zz_ZZ")
                {
                    string filePath = directoryPath + @"\" + localeCode + followingPath;

                    if (File.Exists(filePath))
                        GetLocalesData(dtStringsList, filePath, localeCode);
                    else
                        Console.WriteLine("File Doesn't exist: " + filePath + "\n");

                    subDirCount++;
                }
            }

            DataTable dtFinalSet = EliminateData(dtStringsList);
            DumpData(dtFinalSet, "Interim1");
            //DataTable dtFinalSet = ReadData("Interim1");
            //dtFinalSet.Columns.RemoveAt(0);
            DataTable dtCompilation = CompilationReport(dtFinalSet);
            DumpData(dtFinalSet, "Interim2");
            DumpData(dtCompilation, "FinalResult");
        }

        /// <summary>
        /// CompilationReport
        /// </summary>
        /// <param name="dtFinalSet"></param>
        /// <returns></returns>
        private DataTable CompilationReport(DataTable dtFinalSet)
        {
            DataTable dtCompileInfo = new DataTable();

            string suffix_space = "_WO";
            string suffix_Word = "_Word";

            int columnLength = dtFinalSet.Columns.Count;
            for (int colCount = 1; colCount < columnLength; colCount++)
            {
                string columnName = dtFinalSet.Columns[colCount].ColumnName;
                DataColumn colWOSpace = new DataColumn(columnName + suffix_space, Type.GetType("System.String"));
                dtFinalSet.Columns.Add(colWOSpace);
                DataColumn colWordCount = new DataColumn(columnName + suffix_Word, Type.GetType("System.String"));
                dtFinalSet.Columns.Add(colWordCount);
            }

            DataColumn stringIDValue = new DataColumn("StringIDValue", Type.GetType("System.String"));
            dtFinalSet.Columns.Add(stringIDValue);

            ArrayList distinctCharacterSet = new ArrayList();

            for (int colCount = 1; colCount < columnLength; colCount++)
            {
                string columnName = dtFinalSet.Columns[colCount].ColumnName;

                foreach (DataRow drString in dtFinalSet.Rows)
                {
                    string value = drString[colCount].ToString();

                    if (value.Contains("xxxx"))
                    {
                        value = "x";
                    }

                    int charSpacesCount = 0;
                    int wordCount = 0;

                    for (int i = 1; i < value.Length; i++)
                    {
                        if (char.IsWhiteSpace(value[i - 1]) == true)
                        {
                            charSpacesCount++;
                            if (char.IsLetterOrDigit(value[i]) == true || char.IsPunctuation(value[i]))
                            {
                                wordCount++;
                            }
                        }
                    }
                    wordCount++;

                    if (colCount == 1 && !distinctCharacterSet.Contains(value.Length))
                    {
                        distinctCharacterSet.Add(value.Length);
                    }

                    if (columnName == "en_US")
                        drString["StringIDValue"] = value;
                    drString[columnName] = value.Length;
                    drString[columnName + suffix_space] = value.Length - charSpacesCount;
                    drString[columnName + suffix_Word] = wordCount;
                }
            }

            distinctCharacterSet.Sort();

            DataColumn colStringLength = new DataColumn("StringLength", Type.GetType("System.String"));
            dtCompileInfo.Columns.Add(colStringLength);
            DataColumn colStringsCount = new DataColumn("StringCount", Type.GetType("System.String"));
            dtCompileInfo.Columns.Add(colStringsCount);

            for (int colCount = 2; colCount < columnLength; colCount++)
            {
                DataColumn colAgg = new DataColumn(dtFinalSet.Columns[colCount].ColumnName + "_MIN", Type.GetType("System.String"));
                dtCompileInfo.Columns.Add(colAgg);
                colAgg = new DataColumn(dtFinalSet.Columns[colCount].ColumnName + "_AVG", Type.GetType("System.String"));
                dtCompileInfo.Columns.Add(colAgg);
                colAgg = new DataColumn(dtFinalSet.Columns[colCount].ColumnName + "_MAX", Type.GetType("System.String"));
                dtCompileInfo.Columns.Add(colAgg);
                //colAgg = new DataColumn(dtFinalSet.Columns[colCount].ColumnName + "_MinStringID", Type.GetType("System.String"));
                //dtCompileInfo.Columns.Add(colAgg);
                colAgg = new DataColumn(dtFinalSet.Columns[colCount].ColumnName + "_MAXStringID", Type.GetType("System.String"));
                dtCompileInfo.Columns.Add(colAgg);
            }

            DataColumn minCountLocaleValue = new DataColumn("MinimumForLocaleValue", Type.GetType("System.String"));
            dtCompileInfo.Columns.Add(minCountLocaleValue);
            DataColumn minCountLocale = new DataColumn("MinimumForLocale", Type.GetType("System.String"));
            dtCompileInfo.Columns.Add(minCountLocale);

            DataColumn avgCountLocaleValue = new DataColumn("AverageForLocaleValue", Type.GetType("System.String"));
            dtCompileInfo.Columns.Add(avgCountLocaleValue);
            DataColumn avgCountLocale = new DataColumn("AverageForLocale", Type.GetType("System.String"));
            dtCompileInfo.Columns.Add(avgCountLocale);

            DataColumn maxCountLocaleValue = new DataColumn("MaximumForLocaleValue", Type.GetType("System.String"));
            dtCompileInfo.Columns.Add(maxCountLocaleValue);
            DataColumn maxCountLocale = new DataColumn("MaximumForLocale", Type.GetType("System.String"));
            dtCompileInfo.Columns.Add(maxCountLocale);

            string columnSuffix = "";
            foreach (int strLength in distinctCharacterSet)
            {
                double average = 0.00;
                double minimum = 0.00;
                double maximum = 0.00;
                string averageForLocale = "en_US";
                string minimumForLocale = "en_US";
                string maximumForLocale = "en_US";

                DataRow[] drData = dtFinalSet.Select("en_US = '" + strLength + "'");

                if (drData.Length > 0)
                {
                    DataRow drCompileInfo = dtCompileInfo.NewRow();
                    drCompileInfo[0] = strLength;
                    drCompileInfo[1] = drData.Length;

                    for (int colCount = 2; colCount < columnLength; colCount++)
                    {
                        int min = 0;
                        int max = 0;
                        double avg = 0.00;
                        string minStringID = "";
                        string maxStringID = "";
                        foreach (DataRow dr in drData)
                        {
                            int count = Convert.ToInt32(dr[dtFinalSet.Columns[colCount].ColumnName + columnSuffix].ToString());

                            if (min > count || min == 0)
                            {
                                minStringID = dr[0].ToString();
                                min = count;
                            }
                            if (max < count)
                            {
                                max = count;
                                maxStringID = dr[0].ToString();
                            }
                            avg += count;
                        }

                        avg = avg / drData.Length;
                        drCompileInfo[dtFinalSet.Columns[colCount].ColumnName + "_MIN"] = min;
                        drCompileInfo[dtFinalSet.Columns[colCount].ColumnName + "_AVG"] = string.Format("{0:f4}", Convert.ToDouble(avg));
                        drCompileInfo[dtFinalSet.Columns[colCount].ColumnName + "_MAX"] = max;
                        //drCompileInfo[dtFinalSet.Columns[colCount].ColumnName + "_MINStringID"] = minStringID;
                        drCompileInfo[dtFinalSet.Columns[colCount].ColumnName + "_MAXStringID"] = maxStringID;

                        if (average < avg)
                        {
                            average = avg;
                            averageForLocale = dtFinalSet.Columns[colCount].ColumnName;
                        }
                        if (minimum < min)
                        {
                            minimum = min;
                            minimumForLocale = dtFinalSet.Columns[colCount].ColumnName;
                        }
                        if (maximum < max)
                        {
                            maximum = max;
                            maximumForLocale = dtFinalSet.Columns[colCount].ColumnName;
                        }
                    }

                    drCompileInfo["MinimumForLocaleValue"] = minimum;
                    drCompileInfo["MinimumForLocale"] = minimumForLocale;
                    drCompileInfo["AverageForLocaleValue"] = average;
                    drCompileInfo["AverageForLocale"] = averageForLocale;
                    drCompileInfo["MaximumForLocaleValue"] = maximum;
                    drCompileInfo["MaximumForLocale"] = maximumForLocale;
                    dtCompileInfo.Rows.Add(drCompileInfo);
                }
            }

            return dtCompileInfo;
        }

        /// <summary>
        /// EliminateData
        /// </summary>
        /// <param name="dtStringsList"></param>
        private DataTable EliminateData(DataTable dtStringsList)
        {
            DataTable dtFinalSet = dtStringsList.Clone();

            foreach (DataRow dr in dtStringsList.Rows)
            {
                string value = dr[1].ToString();

                if (value.Trim() != "")
                {
                    for (int colCount = 2; colCount < dtStringsList.Columns.Count; colCount++)
                    {
                        if (dr[colCount].ToString() != value)
                        {
                            DataRow drNew = dtFinalSet.NewRow();
                            drNew.ItemArray = dr.ItemArray;
                            dtFinalSet.Rows.Add(drNew);
                            break;
                        }
                    }
                }
            }

            return dtFinalSet;
        }

        /// <summary>
        /// GetLocalesData
        /// </summary>
        /// <param name="dtStringsList"></param>
        /// <param name="localeFilePath"></param>
        /// <param name="localeCode"></param>
        private void GetLocalesData(DataTable dtStringsList, string localeFilePath, string localeCode)
        {
            DataTable stringIDData = BO.ExtractDataBO.ReadExcludedZStringsfromCSV(localeFilePath, true);

            DataColumn colLocale = new DataColumn(localeCode, Type.GetType("System.String"));
            dtStringsList.Columns.Add(colLocale);

            foreach (DataRow dr in dtStringsList.Rows)
            {
                DataRow[] drLocaleValue = stringIDData.Select("StringID = '" + dr["StringID"].ToString() + "'");

                if (drLocaleValue.Length == 1)
                    dr[colLocale] = drLocaleValue[0]["Value"];

            }
        }

        /// <summary>
        /// DumpData
        /// </summary>
        /// <param name="dtFinalSet"></param>
        /// <param name="p"></param>
        private void DumpData(DataTable dtFinalSet, string fileName)
        {
            string file = outputFilePath + fileName + ".csv";

            if (File.Exists(file))
            {
                File.Delete(file);
            }

            StreamWriter sr = File.CreateText(file);
            sr.Close();

            int rowNo = 0;
            using (StreamWriter sw = new StreamWriter(file))
            {
                StringBuilder fileData = new StringBuilder("S.No.");

                foreach (DataColumn dc in dtFinalSet.Columns)
                    fileData.Append("," + dc.ColumnName);

                sw.WriteLine(fileData.ToString());

                foreach (DataRow dr in dtFinalSet.Rows)
                {
                    rowNo++;
                    fileData = new StringBuilder(rowNo.ToString());

                    foreach (DataColumn dc in dtFinalSet.Columns)
                        fileData.Append(",\"" + dr[dc].ToString() + "\"");

                    sw.WriteLine(fileData.ToString());
                }
            }
        }

        /// <summary>
        /// ReadData
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private DataTable ReadData(string filePath)
        {
            DataTable dtFinalSet = new DataTable();

            filePath = outputFilePath + filePath + ".csv";

            int counter = 0;
            using (StreamReader sr = new StreamReader(filePath))
            {

                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    counter++;
                    if (line != "")
                    {
                        string[] separator;
                        string[] splitline;

                        if (counter == 1)
                        {
                            separator = new string[] { "," };
                            splitline = line.Trim(new char[] { '"' }).Split(separator, StringSplitOptions.None);
                            foreach (string columnName in splitline)
                            {
                                DataColumn column = new DataColumn(columnName, Type.GetType("System.String"));
                                dtFinalSet.Columns.Add(column);
                            }
                        }
                        else
                        {
                            separator = new string[] { "\"," };
                            splitline = line.Trim(new char[] { '"' }).Split(separator, StringSplitOptions.None);
                            DataRow dr = dtFinalSet.NewRow();

                            dr[0] = splitline[0].Split(new string[] { "," }, StringSplitOptions.None)[0];
                            dr[1] = splitline[0].Substring(dr[0].ToString().Length, splitline[0].Length - dr[0].ToString().Length).Replace(",\"", "");

                            for (int colCount = 2; colCount < dtFinalSet.Columns.Count; colCount++)
                            {
                                dr[colCount] = splitline[colCount - 1].Replace("\"", "");
                            }

                            dtFinalSet.Rows.Add(dr);
                        }
                    }
                }
            }
            return dtFinalSet;
        }

    }

    /// <summary>
    /// Keys
    /// </summary>
    public class Keys
    {
        public string keyID;
        public string value;
    }
}