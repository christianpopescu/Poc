using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocHelperLibrary.FileHelper
{
    internal interface ILineChanger
    {
        public bool IsLineToProcess(string pLine);

        public string ProcessLine (string pLine);
    }
}
