using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Knowledge
{

    /// <summary>
    /// c# 基础知识
    /// </summary>
    public partial class BaseKonwledes
    {

        #region Equals和==的区别
        /// <summary>
        /// Equals和==的区别
        /// https://www.cnblogs.com/chen0720/p/3209398.html
        /// </summary>
        public static void EqualDifference()
        {
            Console.WriteLine();

            Man manA = new Man("aa");
            Man manB = new Man("aa");

            Console.WriteLine("manA == manB is {0} ", manA == manB);
            Console.WriteLine("manA.Equals(manB) is {0} \n", manA.Equals(manB));

            string strA = new string(new char[] { 'a', 'b' });
            string strB = new string(new char[] { 'a', 'b' });

            Console.WriteLine("strA == strB is {0} ", strA == strB);
            Console.WriteLine("strA.Equals(strB) is {0} \n", strA.Equals(strB));

            object objA = (object)strA;
            object objB = (object)strB;

            Console.WriteLine("objA == objB is {0} ", objA == objB);
            Console.WriteLine("objA.Equals(objB) is {0} \n", objA.Equals(objB));

            string strAA = "aa";
            string strBB = "aa";

            object objAA=(object)strAA;
            object objBB = (object)strBB;

            Console.WriteLine("objAA == objBB is {0} ", objAA == objBB);
            Console.WriteLine("objAA.Equals(objBB) is {0} \n", objAA.Equals(objBB));

            int numA = 1;
            int numB = 1;

            Console.WriteLine("numA == numB is {0} ", numA == numB);
            Console.WriteLine("numA.Equals(numB) is {0} \n", numA.Equals(numB));

            //manA.Equals
        }
        #endregion

        public void OOP()
        {

        }

        public void Scope()
        {

        }
    }
}
