﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace GlanApp
{
    internal class WordHelper
    {
        private FileInfo _fileInfo;
        private string _pathToSave;

        public WordHelper(string fileName, string pathToSave)
        {
            if(File.Exists(fileName))
            {
                _fileInfo = new FileInfo(fileName);
                _pathToSave = pathToSave;
            } 
            else
            {
                throw new ArgumentException("Файл не найден");
            }
        }

        public bool Process(Dictionary<string, string> items)
        {
            Word.Application app = null;
            try
            {
                app = new Word.Application();
                Object file = _fileInfo.FullName;

                Object missing = Type.Missing;

                app.Documents.Open(file);

                foreach (var item in items)
                {
                    Word.Find find = app.Selection.Find;
                    find.Text = item.Key;
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
                                ReplaceWith: missing, Replace: replace);
                }

                app.ActiveDocument.SaveAs2(_pathToSave);
                app.ActiveDocument.Close();     

                return true;
            } catch (Exception ex)
            {
                return false;
            } finally
            {
                if (app != null)
                {
                    app.Quit();
                }
            }
        }
    }
}
