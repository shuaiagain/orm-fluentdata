using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Knowledge
{
    public class Parent
    {
        public Parent()
        {

        }

        public Parent(string name)
        {
            this.name = name;
        }


        public string name { get; set; }

        public virtual void SetName(string newName)
        {
            this.name = newName;
        }

        public virtual string GetName()
        {
            var temp = "parent_" + this.name;

            Console.WriteLine(temp);
            return temp;
        }
    }
}
