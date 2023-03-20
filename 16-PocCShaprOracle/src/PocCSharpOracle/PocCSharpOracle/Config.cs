using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocCSharpOracle
{
    internal class Config
    {
        private Config ()
        {
            OracleConnectionString = "";
        }

        public static Config Instance { get;  } = new Config ();
        
        public string OracleConnectionString { get; private set; }

    }
}
