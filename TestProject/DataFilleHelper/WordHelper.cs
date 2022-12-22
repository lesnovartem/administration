using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Core;

namespace TestProject.DataFilleHelper
{
    internal class WordHelper
    {
        private FileInfo _fileInfo;

        public WordHelper(string fileName)
        {
            if (File.Exists(fileName))
            {
                _fileInfo = new FileInfo(fileName);
            }
            else
            {
                throw new ArgumentException("File not fount");
            }
        }

        internal bool Process(Dictionary<string, string> items)
        {
            Word.Application app = null;
            try
            {
                app = new Word.Application();
                Object file = _fileInfo.FullName;

                Object missing = Type.Missing;

                app.Documents.Open(file);

                foreach(var item in items) 
                {
                    Word.Find find = app.Selection.Find;
                    find.Text= item.Key;
                    find.Replacement.Text = item.Value;

                    Object wrap = Word.WdFindWrap.wdFindContinue;
                    Object replace = Word.WdReplace.wdReplaceAll;

                    find.Execute(FindText: Type.Missing,
                        MatchCase: false,
                        MatchWholeWord: false,
                        MatchWildcards: false,
                        MatchSoundsLike: missing,
                        MatchAllWordForms: false,
                        Forward: true,
                        Wrap: wrap,
                        Format: false,
                        ReplaceWith: missing,
                        Replace: replace
                        );
                }

                Object newfile = Path.Combine(_fileInfo.DirectoryName, DateTime.Now.ToString("yyyMMdd HHmmss ") + _fileInfo.Name);
                Properties.Settings.Default.Pyt = newfile.ToString();
                app.ActiveDocument.SaveAs2(newfile);
                app.ActiveDocument.Close();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("");
            }

            finally 
            {
                if (app != null)
                {
                    app.Quit();
                }
            }
            return false;
        }
    }
}