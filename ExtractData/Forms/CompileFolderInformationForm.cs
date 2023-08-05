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
    /// <summary>
    /// CompileFolderInformationForm
    /// </summary>
    public partial class CompileFolderInformationForm : Form
    {
        private string logFilePath;

        /// <summary>
        /// CompileFolderInformationForm
        /// </summary>
        public CompileFolderInformationForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// buttonSubmit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            //textBoxFolderPath.Text = @"C:\Saurav";
            logFilePath = textBoxFileName.Text;

            using (StreamWriter sw = FileStream(logFilePath, 0))
            {
                //WriteToFile(sw, "FileName", "Type", "FileSize", "#Files", "#SubDirectories", "CreatedOn", "LastAccessedOn");
                GetFolderInfo(sw, textBoxFolderPath.Text, 0);
            }
        }

        /// <summary>
        /// FileStream
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        private StreamWriter FileStream(string filePath, int level)
        {
            filePath = filePath.Replace("Level", "Level" + level.ToString());
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    WriteToFile(sw, "FileName", "Directory", "#Files", "#SubDirectories", "CreatedOn", "LastAccessedOn");
                }
            }

            return File.AppendText(filePath);

        }

        /// <summary>
        /// GetFolderInfo
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="folder"></param>
        private long GetFolderInfo(StreamWriter sw, string folder, int level)
        {
            DirectoryInfo dir = new DirectoryInfo(folder);
            DirectoryInfo[] subDirectories = null;
            FileInfo[] files = null;
            string fileCount;
            string subDirectoryCount;
            long fileSize = 0;
            long subDirectorySize = 0;

            try
            {
                subDirectories = dir.GetDirectories();
                subDirectoryCount = subDirectories.Length.ToString();
            }
            catch (Exception ex)
            {
                subDirectoryCount = "Failed:" + ex.Message;
            }

            try
            {
                files = dir.GetFiles();
                fileCount = files.Length.ToString();
            }
            catch (Exception ex)
            {
                fileCount = "Failed:" + ex.Message;
            }

            //try
            //{
            //    //sw.WriteLine("\"" + folder.Replace(textBoxFolderPath.Text + @"\", "") + "\"" + ",Directory,," + fileCount + "," + subDirectoryCount + "," + dir.CreationTime.ToShortDateString() + "," + dir.LastAccessTime.ToShortDateString());
            //}
            //catch (Exception)
            //{
            //}

            try
            {
                if (files != null)
                    foreach (FileInfo file in files)
                    {
                        fileSize += file.Length;
                        //WriteToFile(sw, folder + @"\" + file.Name, "File", file.Length.ToString(), "", "", file.CreationTime.ToShortDateString(), file.LastAccessTime.ToShortDateString());
                    }
            }
            catch (Exception)
            {
            }

            try
            {
                if (subDirectories != null)
                    foreach (DirectoryInfo directory in subDirectories)
                    {
                        using (StreamWriter sw1 = FileStream(logFilePath, level + 1))
                        {
                            subDirectorySize += GetFolderInfo(sw1, folder + @"\" + directory.Name, level + 1);
                        }
                    }
            }
            catch (Exception)
            {
            }

            WriteToFile(sw, folder, (fileSize + subDirectorySize).ToString(), fileCount, subDirectoryCount, dir.CreationTime.ToShortDateString(), dir.LastAccessTime.ToShortDateString());

            return fileSize + subDirectorySize;
        }

        /// <summary>
        /// WriteToFile
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="fileName"></param>
        /// <param name="fileSize"></param>
        /// <param name="fileCount"></param>
        /// <param name="dirCount"></param>
        /// <param name="createdOn"></param>
        /// <param name="lastAccessedOn"></param>
        private void WriteToFile(StreamWriter sw, string fileName, string fileType, string fileSize, string fileCount, string dirCount, string createdOn, string lastAccessedOn)
        {
            try
            {
                sw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6}", "\"" + fileName.Replace(textBoxFolderPath.Text + @"\", "") + "\"", fileType, fileSize, fileCount, dirCount, createdOn, lastAccessedOn));
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// WriteToFile
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="fileName"></param>
        /// <param name="fileSize"></param>
        /// <param name="fileCount"></param>
        /// <param name="dirCount"></param>
        /// <param name="createdOn"></param>
        /// <param name="lastAccessedOn"></param>
        private void WriteToFile(StreamWriter sw, string fileName, string fileSize, string fileCount, string dirCount, string createdOn, string lastAccessedOn)
        {
            try
            {
                sw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5}", "\"" + fileName.Replace(textBoxFolderPath.Text, "") + "\"", "\"" + fileSize + "\"", "\"" + fileCount + "\"", "\"" + dirCount + "\"", createdOn, lastAccessedOn));
            }
            catch (Exception)
            {
            }
        }

    }
}
