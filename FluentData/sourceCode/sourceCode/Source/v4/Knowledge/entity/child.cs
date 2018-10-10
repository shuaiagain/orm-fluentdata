using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Knowledge
{
    public class Child : Parent
    {

        bool sex;
        public string GetName()
        {

            var temp = "child_" + this.name;

            Console.WriteLine(temp);
            return temp;
        }

        public void GetSex()
        {
      
        }

    }
}
