using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Smart3DSpecWriter
{
    /// <summary>
    /// Global Settings
    /// </summary>
    public static class GlobalSettings
    {
        const string SETTINGFILENAME = "sp3dSpecWriterSettings.json";
        /// <summary>
        /// Select the file path for "SymbolIcon"
        /// </summary>
        public static string IconPath;

        /// <summary>
        /// higtlight the selected row and column
        /// </summary>
        public static bool HighlightSelectedRowAndCol { get; set; } = false;

        /// <summary>
        /// Show tool tip in Browser Control DetailDataGridView, true = show, false = no shown
        /// </summary>
        public static bool ShowTooltip { get; set; } = true;

        // Method to Save Settings to File
        /// <summary>
        /// Write Settings to JSON File
        /// </summary>
        /// <param name="filePath"></param>
        public static void Save()
        {
            /*
             Since it is impossible to direct serialize a static class, we need a instance of 
            GlobalSettings static class, that is where GlobalSettingsData class fit in. 
            We set all the values of the static class to this new class and serialze it to a file
             
             */
            var settings = new GlobalSettingsData
            {
                ShowTooltip = ShowTooltip,
                iconPath = IconPath,
                highLightSelectedRowAndCol = HighlightSelectedRowAndCol
            };
            string json = JsonConvert.SerializeObject(settings);
            File.WriteAllText(SETTINGFILENAME, json);
        }

        // Method to Load Settings from File
        /// <summary>
        /// Load settings from JSON file
        /// </summary>
        public static void Load()
        {
            if (System.IO.File.Exists(SETTINGFILENAME))
            {
                var json = System.IO.File.ReadAllText(SETTINGFILENAME);
                var settings = JsonConvert.DeserializeObject<GlobalSettingsData>(json);
                ShowTooltip = settings.ShowTooltip;
                IconPath=settings.iconPath;
                HighlightSelectedRowAndCol=settings.highLightSelectedRowAndCol;
            }
        }

        // Helper Class to Map Data
        private class GlobalSettingsData
        {
            public bool ShowTooltip;
            public bool highLightSelectedRowAndCol;
            public string iconPath = "";
        }
    }
}
