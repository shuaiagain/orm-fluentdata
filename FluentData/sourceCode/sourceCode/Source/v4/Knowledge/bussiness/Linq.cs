using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
namespace Knowledge
{
    public class Linq
    {

        public static void LinqTest()
        {
            //匿名类型
            var su = new { name = "good", age = 10 };

            Type tp = su.GetType();

            FieldInfo[] fields = tp.GetFields();

            PropertyInfo[] properties = tp.GetProperties();

            Console.WriteLine(" linq ");
            foreach (var item in fields)
            {
                Console.Write(" field: {0} ", item.Name);
            }

            Console.WriteLine();
            foreach (var item in properties)
            {
                Console.Write(" property: {0} ", item.Name);
            }

            Console.WriteLine();
        }
    }
}
