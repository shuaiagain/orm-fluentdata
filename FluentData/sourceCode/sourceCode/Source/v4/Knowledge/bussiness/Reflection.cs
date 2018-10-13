using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
namespace Knowledge
{
    public class Reflection
    {
        public static void getAllTypes()
        {

            Type tpString = "one".GetType();
            Console.WriteLine(" string Type: {0} ", tpString);

            FieldInfo[] strFileds = tpString.GetFields();
            foreach (FieldInfo item in strFileds)
            {
                Console.Write(" field: {0} ", item.Name);
            }
            Console.WriteLine();

            Type tpInt = 3.GetType();
            Console.WriteLine(" int Type: {0} ", tpInt);

            Type tpObject = new { }.GetType();
            Console.WriteLine(" int Type: {0} ", tpObject);

            Type tpArray = new int[2].GetType();
            Console.WriteLine(" int Type: {0} ", tpObject);

            Easy easy = new Easy() { NameProperty = "one", AgeProperty = 12, _nameField = "_one" };

            Type tpEasy = easy.GetType();

            FieldInfo[] fields = tpEasy.GetFields();
            PropertyInfo[] properties = tpEasy.GetProperties();
            MethodInfo[] methods = tpEasy.GetMethods();
            foreach (var item in fields)
            {
                Console.Write(" field:{0} ",item.Name);
            }

            Console.WriteLine();

            foreach (var item in properties)
            {
                Console.Write(" property:{0} ", item.Name);
            }

            Console.WriteLine();

            foreach (var item in methods)
            {
                Console.Write(" method:{0} ", item.Name);
            }

            Console.WriteLine();
        }
    }

    public class Easy
    {
        public string _nameField;

        public string NameProperty { get; set; }

        public int AgeProperty { get; set; }

        [Obsolete("过时的方法")]
        public string GetName()
        {
            return _nameField;
        }
    }


}
