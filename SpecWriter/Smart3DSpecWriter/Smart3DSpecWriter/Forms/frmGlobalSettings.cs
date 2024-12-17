using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart3DSpecWriter.Forms
{
    /// <summary>
    /// Global setting dialog
    /// </summary>
    public partial class frmGlobalSettings : Form
    {
        /// <summary>
        /// Load settings
        /// </summary>
        public frmGlobalSettings()
        {
            InitializeComponent();
        }

        private void bnSave_Click(object sender, EventArgs e)
        {
            GlobalSettings.ShowTooltip = chkShowTooltip.Checked;
            GlobalSettings.Save();
            Close();
        }

        private void frmGlobalSettings_Load(object sender, EventArgs e)
        {
            GlobalSettings.Load();
            chkShowTooltip.Checked = GlobalSettings.ShowTooltip;
            txtIconPath.Text = GlobalSettings.IconPath; 
        }

        private void bnSelectIconPath_Click(object sender, EventArgs e)
        {

           

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFolderPath = folderBrowserDialog.SelectedPath;
                txtIconPath.Text = selectedFolderPath;
                GlobalSettings.IconPath = selectedFolderPath;
                // Use the selected folder path as needed
                MessageBox.Show("Selected folder: " + selectedFolderPath);
            }
        }
    }
}
