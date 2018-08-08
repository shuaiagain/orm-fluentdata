using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Knowledge
{
    class Man
    {
        public string Hobbies;

        public string Name { get; set; }

        int Age { get; set; }

        public int GetAge()
        {
            return this.Age;
        }
    }
}
