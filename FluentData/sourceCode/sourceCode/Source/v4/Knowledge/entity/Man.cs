using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Knowledge
{
    public class Man
    {

        public Man()
        {

        }

        public Man(string name)
        {
            this.Name = name;
        }

        public string Hobbies;

        public string Name { get; set; }

        int Age { get; set; }

        public int GetAge()
        {
            return this.Age;
        }
    }
}
