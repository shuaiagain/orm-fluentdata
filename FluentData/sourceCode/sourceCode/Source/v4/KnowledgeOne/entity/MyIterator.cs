using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeOne.entity
{
    #region 迭代器生成枚举器
    /// <summary>
    /// 迭代器生成枚举器
    /// </summary>
    public class MyIterator
    {
        #region 迭代器生成枚举器方式1
        /// <summary>
        /// 迭代器生成枚举器方式1
        /// </summary>
        /// <returns></returns>
        public IEnumerator<int> Num()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }
        #endregion

        #region 迭代器生成枚举器方式1
        /// <summary>
        /// 迭代器生成枚举器方式1
        /// </summary>
        /// <returns></returns>
        public IEnumerator<int> NumOne()
        {
            int[] arr = { 2, 3, 4 };
            for (int i = 0; i < arr.Length; i++)
                yield return arr[i];
        }
        #endregion

        #region 实现GetEnumerator
        /// <summary>
        /// 实现GetEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<int> GetEnumerator()
        {
            int[] arr = { 3, 4, 5 };
            for (int i = 0; i < arr.Length; i++)
                yield return arr[i];
        }
        #endregion
    }
    #endregion

    #region 迭代器生成可枚举类型
    /// <summary>
    /// 迭代器生成可枚举类型
    /// </summary>
    public class MyIterate
    {
        #region 迭代器生成枚举器看
        /// <summary>
        /// 迭代器生成枚举器看
        /// </summary>
        /// <returns></returns>
        public IEnumerator<int> GetEnumerator()
        {
            IEnumerable<int> enumerator = NumOne();
            return enumerator.GetEnumerator();
        }
        #endregion

        #region 迭代器生成可枚举类型
        /// <summary>
        /// 迭代器生成可枚举类型
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> NumOne()
        {
            int[] arr = { 11, 22, 33 };
            foreach (int item in arr)
            {
                yield return item;
            }
        }
        #endregion
    }
    #endregion
}
