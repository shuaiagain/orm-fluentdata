using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using KnowledgeOne.entity;

namespace KnowledgeOne.business
{
    /// <summary>
    /// 枚举器
    /// </summary>
    public class Enumerator
    {
        public Enumerator()
        {
        }

        #region 测试枚举器
        /// <summary>
        /// 测试枚举器
        /// </summary>
        public void Test()
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
        #endregion

        #region 让一个类的实例可以进行遍历
        /// <summary>
        /// 让一个类的实例可以进行遍历
        /// </summary>
        public void GetEnumeratorSelfDefination()
        {
            MyEnumerate myenum = new MyEnumerate();

            int i = 0;
            foreach (int item in myenum)
            {
                Console.WriteLine("{0} = {1}", i, item);
            }
        }
        #endregion
    }
}
