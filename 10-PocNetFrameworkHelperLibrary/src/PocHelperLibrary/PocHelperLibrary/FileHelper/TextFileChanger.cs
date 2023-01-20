using System;
using System.Collections.Generic;
using System.IO;

namespace FileHelper
{
    /// <summary>
    /// Responsibility : Allow small changes (by line) in text file
    /// Scenarios : Changing Configuration files, Project Files, ....
    /// </summary>
    public class TextFileChanger
    {
        private LineChanger aLineChanger;
        public String InputFile { get; set; }
        public String TmpFile { get; set; }
        public String BackupFilePrefix { get; set; }
        public String  BackupFile => BackupFilePrefix + DateTime.Now.ToString(@"yyyyMMdd_HHmmss");
        public List<string> FileContent = new List<string>();

        public void SetLineChanger(LineChanger pLineChanger)
        {
            aLineChanger = pLineChanger;
        }

        public void ChangeFile()
        {
            using var input = File.OpenText(InputFile);
            using var output = new StreamWriter(TmpFile);
            string line;
            while (null != (line = input.ReadLine()))
            {
                FileContent.Add(line);
            }

            foreach (var ln in FileContent)
            {
                output.WriteLine(aLineChanger.IsLineToProcess(ln) ? aLineChanger.Process(ln) : ln);
            }

            File.Replace(TmpFile, InputFile, BackupFile);
        }
    }
}
