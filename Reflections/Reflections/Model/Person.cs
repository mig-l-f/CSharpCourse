using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflections.Model
{
    public class Person
    {
        public Person() 
        {
            name = "";
            age = 0;
        }

        public override string ToString()
        {
            return String.Format("My name is {0} and i'm {1} years old", name, age);
        }

        #region Properties

        public String name { get; set; }
        public int age { get; set; }

        #endregion
    }
}
