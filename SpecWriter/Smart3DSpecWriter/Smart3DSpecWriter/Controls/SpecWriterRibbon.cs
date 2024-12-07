using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;
using Smart3DSpecWriter.Forms;
using Smart3DSpecWriter.PipeBranchTable;
using Smart3DSpecWriter.Utilities;

namespace Smart3DSpecWriter
{
    public partial class SpecWriterRibbon
    {
        private void SpecWriterRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void bnSettings_Click(object sender, RibbonControlEventArgs e)
        {
            SettingsForm frm = new SettingsForm
            {
                StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            };
            frm.ShowDialog();
        }

        private void bnEditor_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.Smart3DAddIn.SetBrowserControlToNewFile();
        }

        private void bnBrowserWide_Click(object sender, RibbonControlEventArgs e)
        {
            CommonFunctions.SetBrowserWidth(600);
        }

        private void bnBrowserNormal_Click(object sender, RibbonControlEventArgs e)
        {
            CommonFunctions.SetBrowserWidth(360);
        }

        private void bnBrowserNarrow_Click(object sender, RibbonControlEventArgs e)
        {
            CommonFunctions.SetBrowserWidth(180);
        }

        private void bnReadPipeBranch_Click(object sender, RibbonControlEventArgs e)
        {
            
        //   Worksheet _sheet = Globals.Smart3DAddIn.Application.ActiveSheet;
        //    PipeBranchSheet pbs = new PipeBranchSheet(_sheet);

        //ReadPipeBranchTable.GenerateTemporaryPipeBranchSheet();
        //    //  ReadPipeBranchTable.MakeSelection();

            ReadPipeBranchTable.ReadSheet();
        }

        private void bnKillExcel_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName("excel"))
                {
                    proc.Kill();
                }
            }
            catch (Exception)
            {
            }
        }

        private void bnWritePipeBranchTable_Click(object sender, RibbonControlEventArgs e)
        {
            WritePipeBranchTable.WritePipeBranch();

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName("excel"))
                {
                    proc.Kill();
                }
            }
            catch (Exception)
            {
            }
        }

        private void button3_Click(object sender, RibbonControlEventArgs e)
        {
            ReadPipeBranchTable.ReadSheet();

        }
    }
}
