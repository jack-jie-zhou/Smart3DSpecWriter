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
    public partial class SettingsForm : Form
    {
        private string _symbolIconPath;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void BnSymbolIcon_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fld = new FolderBrowserDialog
            {
                RootFolder = Environment.SpecialFolder.MyComputer
            };
            if (fld.ShowDialog()==DialogResult.OK)
            {
                txtSymbolIcon.Text = fld.SelectedPath;
                Properties.Settings.Default.IConPath = fld.SelectedPath;
                Properties.Settings.Default.Save();
            }

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            _symbolIconPath = Properties.Settings.Default.IConPath;
            if(!string.IsNullOrWhiteSpace(_symbolIconPath))
            {
                txtSymbolIcon.Text = _symbolIconPath;
            }
        }

        private void BnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
