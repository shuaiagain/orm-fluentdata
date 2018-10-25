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

            object objAA = (object)strAA;
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

        #region 引用类型和ref引用参数
        public static void Refference(Refference re, int num)
        {
            re.num += 1;
            num += 1;

            Console.WriteLine("re.num :{0} ", re.num);
            Console.WriteLine("num :{0} ", num);
        }

        public static void Refference(ref Refference re, ref int num)
        {
            re.num += 1;
            num += 1;

            Console.WriteLine("re.num :{0} ", re.num);
            Console.WriteLine("num :{0} ", num);
        }

        #endregion

        #region 将引用类型对象作为值传递
        public static void MyRefAsParameter(Refference re)
        {

            Console.WriteLine();
            re.num = 2;
            Console.WriteLine("num :{0}", re.num);

            re = new Refference();
            re.num = 5;
            Console.WriteLine("num:{0}", re.num);
        }
        #endregion

        #region 输出参数out
        public static void MyOutAsParameter(out Refference re)
        {
            Console.WriteLine();

            re = new Refference();
            re.num = 5;
            Console.WriteLine("out re.num:{0}", re.num);

            //re = new Refference();

            //Console.WriteLine("out re.num:{0}", re.num);
        }
        #endregion

        #region 参数数组
        public static void ParamsArray(params int[] vals)
        {
            Console.WriteLine();
            for (int i = 0; i < vals.Length; i++)
            {
                Console.WriteLine("第{0}个值：{1} ", i + 1, vals[i]);
            }
        }
        #endregion

        #region 类型
        public static void Types()
        {
            Console.WriteLine("{0}", typeof(int));
        }
        #endregion

        #region StringAndStringBuilder  
        public static void StringAndStringBuilder()
        {
            string aa = "12345", bb = aa;

            aa = "123";
            Console.WriteLine("aa = {0} ,bb = {1} ", aa, bb);

            StringBuilder a = new StringBuilder("abcde"), b = a;

            Console.WriteLine(" first a = {0},b = {1} ", a, b);
            a = a.Append("f");
            Console.WriteLine(" after a = {0}, b = {1} ", a, b);
        } 
        #endregion
    }
}
