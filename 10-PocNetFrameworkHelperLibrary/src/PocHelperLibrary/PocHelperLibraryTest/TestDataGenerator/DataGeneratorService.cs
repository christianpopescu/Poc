using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PocHelperLibraryTest.TestDataGenerator
{
    internal class DataGeneratorService
    {
        public IDictionary<string, string> GetPlacehoderDictionary() 
        { 
            var dictionary = new Dictionary<string, string>();

            dictionary["abc"] = "123";
            dictionary["bcd"] = "345";

            return dictionary;
        }
    }
}
