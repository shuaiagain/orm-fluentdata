using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge.bussiness
{
    public class Enumerator
    {
        public Enumerator()
        {

        }

        public static void Test()
        {
            int[] arr = { 1, 2, 3, 4 };

            IEnumerator ie = arr.GetEnumerator();
            int i = 0;
            while (ie.MoveNext())
            {
                int temp = (int)ie.Current;
                Console.WriteLine("arr[{0}] = {1}", i++, temp);
            }
        }
    }
}
