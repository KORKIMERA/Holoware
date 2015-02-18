using Microsoft.Win32;
using System;
using System.IO;
using Telerik.Windows.Controls;

namespace Bismonger.UILogic.Interactions
{
    public delegate RadGridView GridRequestedHandler(object sender, EventArgs e);

    public class Export
    {
        #region Events
        public event GridRequestedHandler GridRequested = null;
        #endregion

        #region Constants
        public const string EXTENSION_XLS = "xls";
        #endregion

        #region Singleton
        static Export _export = null;

        private Export() { }

        public static Export Instance
        {
            get
            {
                if (_export == null)
                {
                    _export = new Export();
                }

                return _export;
            }
        }
        #endregion

        public void ToExcel(GridRequestedHandler gridRequestHander)
        {
            var dialog = new SaveFileDialog()
            {
                DefaultExt = EXTENSION_XLS,
                Filter = String.Format("{1} files (*.{0})|*.{0}|All files (*.*)|*.*", EXTENSION_XLS, "Excel"),
                FilterIndex = 1
            };

            if (dialog.ShowDialog() == true)
            {
                using (Stream stream = dialog.OpenFile())
                {
                    var gridViewExport = gridRequestHander(this, null);
                    gridViewExport.Export(stream, new GridViewExportOptions()
                    {
                        Format = ExportFormat.Html,
                        ShowColumnHeaders = true,
                        ShowColumnFooters = true,
                        ShowGroupFooters = false
                    });
                }
            }
        }
    }
}