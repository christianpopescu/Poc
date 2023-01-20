using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractDataHelper.Exceptions;

namespace AbstractDataHelper.Collections
{
    /// <summary>
    /// Responsibility:
    /// - Read from file / Write to file
    /// - Compare lists
    /// - ...
    /// Constraint:
    /// - T could be represented as 1 line string
    /// </summary>
    /// <typeparam name="T"></typeparam>
    
    public class ListOfElements<T> 
    {
        public readonly List<T> TheList = new List<T>();

        protected Func<T, string> ToLine;
        protected Func<string, T> FromLine;

        protected ListOfElements(){} 

        public static ListOfElements<T> CreateListOfElements<T> (Func<T, string> pToLine, Func<string, T>pFromLine)
        {
            if (pToLine == null || pFromLine == null)
                throw new CollectionsException("Create List of Elements null delegates");

            return new ListOfElements<T>
            {
                ToLine = pToLine, FromLine = pFromLine

            };
        }

        public void WriteToFile(string pFile)
        {
            // todo: add file exception + choose append or override
            using var output = new StreamWriter(pFile);
            {
                foreach (var elem in TheList)
                {
                    output.WriteLine(ToLine(elem));
                }
            }
        }

        public void ReadFromFile(string pFile)
        {
            // todo: add file exception + choose append or override
            using var input = File.OpenText(pFile);
            {
                string line;
                while (null != (line = input.ReadLine()))
                {
                    TheList.Add(FromLine(line));
                }

            }
        }
    }
}
