using System.IO;
using System.Reflection;

namespace Bizmonger.IO
{
    public class DocumentUtilities
    {
        public static string GetText(string filePath)
        {
            var rangeText = "ERROR: Failed to get text";

            var assembly = Assembly.GetExecutingAssembly();
            var binPath = System.IO.Path.GetDirectoryName(assembly.Location);

            var inputFile = Path.Combine(binPath, filePath);

            //  create & define filename object with temp.doc
            object inputDocFilename = inputFile;

            if (File.Exists((string)inputDocFilename))
            {
                object readOnly = false;
                object isVisible = false;

                //  create missing object
                object missing = Missing.Value;

                //  create Word application object
                var wordApp = new Microsoft.Office.Interop.Word.Application();

                wordApp.Visible = false;

                var inputDocument = wordApp.Documents.Open(ref inputDocFilename, ref missing,
                        ref readOnly, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref isVisible, ref missing, ref missing,
                        ref missing, ref missing);

                inputDocument.Activate();

                rangeText = inputDocument.Range().Text;

                inputDocument.Close(Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges);

                wordApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
            }

            return rangeText;
        }
    }
}