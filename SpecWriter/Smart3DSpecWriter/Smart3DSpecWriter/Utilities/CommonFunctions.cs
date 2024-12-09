using CodelistLibrary;
using Dapper;
using Smart3DSpecWriter.Excel;
using Smart3DSpecWriter.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart3DSpecWriter.Utilities
{
    /// <summary>
    /// Some helper functions
    /// </summary>
    public class CommonFunctions
    {
        /// <summary>
        /// Set the width of the Editor on the right
        /// </summary>
        /// <param name="width">The width to set</param>
        public static void SetBrowserWidth(int width)
        {
            Microsoft.Office.Tools.CustomTaskPane ctp = Globals.Smart3DAddIn._customTaskPane;
            // BrowserControl ctrl = ctp.Control as BrowserControl;
            ctp.Width = width;
        }

        /// <summary>
        /// Set the color for piping connections in the Editor
        /// </summary>
        /// <param name="rows">All rows in the Editor control</param>
        /// <param name="rowCount">Number of row</param>
        /// <param name="numberOfColumns">Number of columns to set color</param>
        public static void Coloring(DataGridViewRowCollection rows, int rowCount, int numberOfColumns = 2)
        {
            for (int i = 0; i < rowCount; i++)
            {
                DataGridViewCell cell = rows[i].Cells[0];
                string value = cell.Value as string;
                if (string.IsNullOrWhiteSpace(value)) continue;
                if (value.Contains("1") || value.Contains("5"))
                {
                    cell.Style.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
                }
                else if (value.Contains("2") || value.Contains("6"))
                {
                    cell.Style.BackColor = System.Drawing.Color.FromArgb(255, 192, 255);
                }
                else if (value.Contains("3") || value.Contains("7"))
                {
                    cell.Style.BackColor = System.Drawing.Color.FromArgb(192, 192, 192);
                }
                else if (value.Contains("4") || value.Contains("8"))
                {
                    cell.Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
                }
                rows[i].Cells[1].Style.BackColor = cell.Style.BackColor;
                if (numberOfColumns == 3)
                {
                    rows[i].Cells[2].Style.BackColor = cell.Style.BackColor;
                }
            }
        }
        /// <summary>
        /// Display the Icon of current editing piping component. 
        /// <para>If the icon path is not set, or iconName is empty, or icon image is not found, warning will be displayed</para>
        /// <para>Call DiaplayIconForm is display the Icon</para>
        /// </summary>
        /// <param name="list">A list of cells of the row of SymbolIcon</param>
        public static void DisplayIcon(List<CellInfo> list)
        {
            string iconName = "";
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name == "SymbolIcon")
                {
                    iconName = list[i].Value;
                    break;
                }
            }

            if (iconName == "")
            {
                MessageBox.Show("No symbolIcon value is provided in the worksheet");
                return;
            }

            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.IConPath))
            {
                MessageBox.Show("Please set up symbol path first!");
                return;
            }
            string fileName = Properties.Settings.Default.IConPath + "\\" + iconName;

            if (!File.Exists(fileName))
            {
                MessageBox.Show($"File doesn't exist {fileName}");
            }
            DisplayIconForm frm = new DisplayIconForm
            {
                FileName = fileName,
                TopMost = true
            };
            frm.Show();
        }




    }
}
