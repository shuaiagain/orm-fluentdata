using Knowledge.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge.bussiness
{
    public class BaseOne
    {
        public static void TestList()
        {
            List<TextDTO> list = new List<TextDTO>() { new TextDTO { TextValue = 2 }, new TextDTO() { TextValue = 2 } };
            List<TextDTO> test = list.Where(w => w.TextValue == 3).ToList();

            if (test.Count == 0)
                Console.WriteLine("count==0");

           
        }
    }
}
