﻿using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools;
using Serilog;
using Smart3DSpecWriter.Excel;
using Smart3DSpecWriter.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Smart3DSpecWriter
{
    /// <summary>
    ///  This is the entry point of the Addin
    /// </summary>
    public partial class Smart3DAddIn
    {
        /// <summary>
        /// Excel 窗口顶部的命令面板
        /// </summary>
        public CustomTaskPane _customTaskPane;

        /// <summary>
        /// Excel 右侧的编辑窗口
        /// </summary>
        public BrowserControl _browserControl;

        /// <summary>
        /// A string list that contains all the sheets in current opened Excel file
        /// </summary>
        public List<string> _sheetNameList = new List<string>();
        private Worksheet _sheet;
        private SheetInfo _sheetInfo;

        //Copy
        private List<CellInfo> _definitionInformationForCopy;
        private List<CellInfo> _detailInformationForCopy;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            _browserControl = new BrowserControl();
            _customTaskPane = CustomTaskPanes.Add(_browserControl, "Editor");
            _customTaskPane.Width = 600;

            _customTaskPane.Visible = true;
            SetLogger();
            RegisterEventHandlers();
        }

       public void SetBrowserControlToNewFile()
        {
            try
            {
               CustomTaskPanes.Remove(Globals.Smart3DAddIn._customTaskPane);
               _browserControl = new BrowserControl();
                
               _customTaskPane = Globals.Smart3DAddIn.CustomTaskPanes.Add(Globals.Smart3DAddIn._browserControl, "Editor");
                _customTaskPane.Width = 600;
               _customTaskPane.Visible = true;
                if (Application.ActiveWorkbook != null)
                {
                    WorkbookActivate(Application.ActiveWorkbook);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SetLogger()
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("Smart3DSpecWriterLog.log").CreateLogger();
        }

        #region "Events"
        private void RegisterEventHandlers()
        {
            Application.WorkbookActivate += Application_WorkbookActivate;
            Application.SheetSelectionChange += Application_SheetSelectionChange;
            Application.SheetActivate += Application_SheetActivate;
        }



        private void Application_SheetActivate(object Sh)
        {
            Log.Information("Application_SheetActivate(object Sh)");
            ActiveSheetChanged(Sh);
        }
        private void Application_WorkbookActivate(Microsoft.Office.Interop.Excel.Workbook Wb)
        {
            Log.Information("WorkbookActivate");
            SetBrowserControlToNewFile();
            WorkbookActivate(Wb);
        }
        private void Application_SheetSelectionChange(object Sh, Microsoft.Office.Interop.Excel.Range Target)
        {
            Log.Information("Application_SheetSelectionChange");
            SheetSelectionChanged(Target);
        }

        #endregion

        private void SheetSelectionChanged(Range Target)
        {
            if (_sheetInfo != null)
            {
                int row = Target.Row;
                _detailInformationForCopy = null;

                //Details
                List<CellInfo> cellInfos = _sheetInfo.ReadDetailsRow(row);
                if (cellInfos != null && _browserControl != null)
                {
                    _browserControl.SetDetailInformation(cellInfos,_sheet);
                    _detailInformationForCopy = cellInfos;
                    _definitionInformationForCopy = null;
                }

                //Definition
                List<CellInfo> cellInfoDef = _sheetInfo.DefinitionRowInfomation;
                if (cellInfos != null)
                {
                    _browserControl.SetDefinitionInformation(cellInfoDef,_sheet);
                    _definitionInformationForCopy = cellInfoDef;
                }
            }
        }

        private void ActiveSheetChanged(object Sh)
        {
            _sheet = Sh as Worksheet;
            _sheetInfo = new SheetInfo(_sheet);
            if (_browserControl != null)
            {
                _browserControl.CurrentSheetName = _sheetInfo.SheetName;
                _browserControl.PartClassType = _sheetInfo.PartClassType;

                //Definition
                List<CellInfo> cellInfos = _sheetInfo.DefinitionRowInfomation;
                if (cellInfos!=null )
                {
                    _browserControl.SetDefinitionInformation(cellInfos,_sheet);
                    _definitionInformationForCopy = cellInfos;
                }

                //Details
                List<CellInfo> cellInfoDetails = _sheetInfo.DetailTitleRowInformation;
                if (cellInfoDetails != null)
                {
                    _browserControl.SetDetailInformation(cellInfoDetails,_sheet);
                    _detailInformationForCopy = cellInfoDetails;
                }
            }
        }

        private void WorkbookActivate(Workbook Wb)
        {
            try
            {
                _sheetNameList = GetSheetNameFromBook.GetSheetNames(Wb);
                _browserControl.AddSheetNameList(_sheetNameList);

            }
            catch (System.Exception ex)
            {
                Log.Error("{0}", ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }




        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            Startup += new System.EventHandler(ThisAddIn_Startup);
            Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
