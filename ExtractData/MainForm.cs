using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExtractData.UI.Forms;

namespace ExtractData.UI
{
    /// <summary>
    /// MainForm
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// MainForm
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// featureRequestsToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void featureRequestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtractFeatureRequestsfromEmail form = new ExtractFeatureRequestsfromEmail();
            form.MdiParent = this;
            form.Show();
        }

        /// <summary>
        /// mTDataToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mTDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompileFolderInformation form = new CompileFolderInformation();
            form.MdiParent = this;
            form.Show();
        }

        /// <summary>
        /// zStringsToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zStringsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompareZStringsData form = new CompareZStringsData();
            form.MdiParent = this;
            form.Show();
        }

        /// <summary>
        /// compileFolderInformationToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void compileFolderInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompileFolderInformationForm form = new CompileFolderInformationForm();
            form.MdiParent = this;
            form.Show();
        }

        private void testStudioIntegrationTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestStudioIntegration form = new TestStudioIntegration();
            form.MdiParent = this;
            form.Show();
        }
    }
}
