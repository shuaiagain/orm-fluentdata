using KnowledgeOne.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeOne.business
{
    /// <summary>
    /// 迭代器
    /// </summary>
    public class Iterator
    {
        #region 迭代器生成枚举器
        /// <summary>
        /// 迭代器生成枚举器
        /// </summary>
        public void Test()
        {
            MyIterator myIterator = new MyIterator();

            int i = 0;
            foreach (int item in myIterator)
            {
                Console.WriteLine("{0} = {1}", i++, item);
            }
        }
        #endregion

        #region 迭代器生成枚举类型
        /// <summary>
        /// 迭代器生成枚举类型
        /// </summary>
        public void TestOne()
        {
            MyIterate iterate = new MyIterate();

            Console.WriteLine("迭代器生成枚举器：");
            int i = 0;
            foreach (int item in iterate)
            {
                Console.WriteLine("{0} = {1}", i++, item);
            }

            Console.WriteLine("迭代器生成枚举类型：");
            int j = 0;
            foreach (int item in iterate.NumOne())
            {
                Console.WriteLine("{0} = {1}", j++, item);
            }
        } 
        #endregion
    }
}
