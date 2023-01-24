using PocHelperLibrary.FileHelper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FileHelper
{
    /// <summary>
    /// Responsibilty : Identify line to change + transform line
    /// </summary>
    public abstract class LineChanger : ILineChanger
    {
        protected String IdentificationPattern;
        protected Regex regIdent;

        LineChanger(String pIdentificationPattern) 
            => (IdentificationPattern, regIdent) = (pIdentificationPattern, new Regex(IdentificationPattern));

        public bool IsLineToProcess(string pLine) => regIdent.IsMatch(pLine);

        public abstract string ProcessLine(string pLine);


        public abstract void SetParameters(params string[] parameters);

    }
}
