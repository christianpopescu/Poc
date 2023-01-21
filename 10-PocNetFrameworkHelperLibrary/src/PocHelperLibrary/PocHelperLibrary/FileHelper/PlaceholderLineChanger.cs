using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PocHelperLibrary.FileHelper
{
    public class PlaceholderLineChanger
    {
        protected IDictionary<string, string> exchangeDictionary = null;

        private readonly string beginPattern = @"{{";
        private readonly string endPattern = @"}}";

        public string regexBeginPattern 
        {
            get { return beginPattern.Replace("{",@"\{").Replace("}", @"\}"); }
        }

        public string regexEndPattern
        {
            get { return endPattern.Replace("{", @"\{").Replace("}", @"\}"); }
        }


        public string regexPattern
        { 
            get {
                // default example Regex rx = new Regex(@"(?<=\{\{)(.*?)(?=\}\})");
                StringBuilder sb = new StringBuilder();
                sb.Append(@"(?<=")
                    .Append(regexBeginPattern)
                    .Append(@")(.*?)(?=")
                    .Append(regexEndPattern)
                    .Append(")");
                return sb.ToString();
            }
        }
        
        public PlaceholderLineChanger(IDictionary<string, string> pExchangeDictionary, string pBeginPattern = "", string pEndPattern = "")
        {
            exchangeDictionary = pExchangeDictionary;
            if (!string.IsNullOrEmpty(pBeginPattern)) beginPattern = pBeginPattern;
            if (!string.IsNullOrEmpty(pEndPattern)) endPattern = pEndPattern;
        }
        public bool  IsLineToProcess(string pLine)
        {
            Regex rx = new Regex(regexPattern);
            MatchCollection matches = rx.Matches(pLine);
            return matches.Count > 0;
        }

        /// <summary>
        /// Replace the placeholders found in line by the corresponging dictionary value
        /// If no match pOutpuLine = pLine
        /// </summary>
        /// <param name="pLine"></param>
        /// <param name="pOutputLine"></param>
        /// <returns></returns>

        public bool ProcessLIne(string pLine, out string pOutputLine)
        {
            pOutputLine = "";
            bool processed = false;
            Regex rx = new Regex(regexPattern);
            MatchCollection matches = rx.Matches(pLine);
            foreach (Match match in matches)
            {
                if (exchangeDictionary.ContainsKey(match.Value))
                {
                    
                    pOutputLine = pLine.Replace(beginPattern + match.Value + endPattern, exchangeDictionary[match.Value]);
                    processed = true;                }
                  
            }
            if (!processed) { pOutputLine = pLine; }

            return processed;
        }
    }
}
