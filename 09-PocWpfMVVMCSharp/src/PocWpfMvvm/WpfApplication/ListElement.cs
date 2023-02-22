using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication
{
    class ListElement
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }
        public ListElement(string firstName, string lastName, int age)
        {
            FirstName = firstName; LastName = lastName; Age = age;
        }

       
    }
}
