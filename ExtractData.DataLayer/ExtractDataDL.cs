using System;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Collections;
using System.IO;
using DTO = ExtractData.Common.DataTransferObjects;

namespace ExtractData.DataLayer
{
    public class ExtractDataDL
    {
        #region Variable Declaration

        private static string connectionString = string.Empty;
        private static DataSet returnDataSet;

        #endregion

        public static string GetConnectionString(string connectionType, string filePath)
        {
            StringBuilder sbConn = new StringBuilder();
            try
            {
                if (connectionType == "xls")
                {
                    sbConn = new StringBuilder();
                    sbConn.Append(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=");
                    sbConn.Append(filePath);
                    sbConn.Append(";Extended Properties=");
                    sbConn.Append(Convert.ToChar(34));
                    sbConn.Append("Excel 8.0");
                    sbConn.Append(Convert.ToChar(34));
                    //;HDR=Yes;IMEX=2
                }
                if (connectionType == "xlsx")
                {
                    sbConn = new StringBuilder();
                    sbConn.Append(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=");
                    sbConn.Append(filePath);
                    sbConn.Append(";Extended Properties=");
                    sbConn.Append(Convert.ToChar(34));
                    sbConn.Append("Excel 12.0");
                    sbConn.Append(Convert.ToChar(34));
                    //;HDR=Yes;IMEX=2
                }
                return sbConn.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveFeatureRequestToXLS(string filePath, string query)
        {
            connectionString = GetConnectionString("xls", filePath);
            returnDataSet = new DataSet();

            OleDbConnection oledbConn = new OleDbConnection(connectionString);
            try
            {
                // Open connection
                oledbConn.Open();
                OleDbCommand objCmd = new OleDbCommand(query, oledbConn);
                objCmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (oledbConn != null)
                {
                    oledbConn.Close();
                    oledbConn.Dispose();
                }
            }
        }

        public static bool SaveDataToXLS(string filePath, string query)
        {
            connectionString = GetConnectionString("xls", filePath);
            returnDataSet = new DataSet();

            OleDbConnection oledbConn = new OleDbConnection(connectionString);
            try
            {
                // Open connection
                oledbConn.Open();
                OleDbCommand objCmd = new OleDbCommand(query, oledbConn);
                objCmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (oledbConn != null)
                {
                    oledbConn.Close();
                    oledbConn.Dispose();
                }
            }
        }

        /// <summary>
        /// ExecuteQuery
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static DataSet ExecuteXLSQuery(string query, string fileName)
        {
            connectionString = GetConnectionString("xls", fileName);
            returnDataSet = new DataSet();

            OleDbConnection oledbConn = new OleDbConnection(connectionString);
            try
            {
                // Open connection
                oledbConn.Open();

                // Create OleDbCommand object and select data from worksheet Sheet1
                OleDbCommand cmd = new OleDbCommand(query, oledbConn);

                // Create new OleDbDataAdapter
                OleDbDataAdapter oleda = new OleDbDataAdapter();

                oleda.SelectCommand = cmd;

                // Fill the DataSet from the data extracted from the worksheet.
                oleda.Fill(returnDataSet, "Data");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                // Close connection
                oledbConn.Close();
            }

            return returnDataSet;
        }

        public static string[] ReadMTDatafromCSV(string filePath, DTO.MTDataDTO data)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    string[] separator = new string[] { "," };
                    string[] splitline = line.Split(separator, StringSplitOptions.None);
                    if (splitline[0] == "Total")
                    {
                        return splitline;
                    }
                }
            }

            return null;

        }

        public static DataTable ReadZStringsfromCSV(string filePath)
        {
            DataTable data = new DataTable();

            data.Columns.Add("StringID");
            data.Columns.Add("Value");

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    string[] separator = new string[] { "=" };
                    string[] splitline = line.Trim(new char[] { '"' }).Split(separator, StringSplitOptions.None);

                    DataRow dr = data.NewRow();

                    dr[0] = splitline[0].Trim();
                    dr[1] = splitline[1].Trim();

                    data.Rows.Add(dr);
                }
            }

            return data;
        }

        public static DataTable ReadExcludedZStringsfromCSV(string filePath)
        {
            return ReadExcludedZStringsfromCSV(filePath, false);
        }

        public static DataTable ReadExcludedZStringsfromCSV(string filePath, bool ignore)
        {
            DataTable data = new DataTable();

            data.Columns.Add("StringID");
            data.Columns.Add("Value");

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    if (line != "")
                    {
                        string[] separator = new string[] { "=" };
                        string[] splitline = line.Trim(new char[] { '"' }).Split(separator, StringSplitOptions.None);

                        DataRow dr = data.NewRow();

                        dr[0] = splitline[0].Trim();
                        dr[1] = GetValueString(splitline[1].Trim(), ignore).Trim();

                        data.Rows.Add(dr);
                    }
                }
            }

            return data;
        }

        /// <summary>
        /// GetValueString
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ignore"></param>
        /// <returns></returns>
        private static string GetValueString(string value, bool ignore)
        {
            if (ignore)
            {
                value = value.Replace("(*.*)", "").Replace("(*.", "");
                value = value.Replace("(*.*)", "").Replace("(*.", "");
                value = value.Replace(".0", "").Replace("...", "");

                string[] alphPatterns = new string[] { "[%alph]", "(&alph)", "(alph)", "^alph", "\alph", "%alph" };
                string[] alphabetsCapital = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z" };
                string[] alphabetsSmall = new string[] { "a", "b", "c", "c", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "x", "y", "z" };

                foreach (string pattern in alphPatterns)
                {
                    foreach (string alph in alphabetsCapital)
                        value = Replace(value, Replace(pattern, "alph", alph), "");
                    foreach (string alph in alphabetsCapital)
                        value = Replace(value, Replace(pattern, "alph", alph), "");
                }

                for (int i = 0; i <= 9; i++)
                    value = Replace(value, Convert.ToString(i), "");

                value = value.Replace("*", "").Replace("#", "").Replace("?", "").Replace("%", "").Replace("@", "").Replace("!", "").Replace("$", "").Replace("^", "").Replace("&", "");
                value = value.Replace("<", "").Replace(">", "").Replace("/", "").Replace("\\", "").Replace("+", "").Replace("-", "").Replace("=", "").Replace(":", "").Replace("\"", "").Replace(";", "");
                value = value.Replace("(", "").Replace(")", "").Replace("{", "").Replace("}", "").Replace("[", "").Replace("]", "").Replace("|", "").Replace("~", "").Replace(". ", "");

                value = value.Trim(new char[] { ',' }).Trim(new char[] { '\'' }).Trim(new char[] { '`' }).Trim(new char[] { '.' }).Trim();
            }

            return value;
        }

        /// <summary>
        /// Replace
        /// </summary>
        /// <param name="value"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        private static string Replace(string value, string oldValue, string newValue)
        {
            return value.Replace(oldValue, newValue);
        }


    }
}
