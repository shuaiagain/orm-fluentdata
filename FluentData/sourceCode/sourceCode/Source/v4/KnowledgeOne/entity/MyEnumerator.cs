using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeOne.entity
{
    #region 枚举器
    /// <summary>
    /// 枚举器
    /// </summary>
    public class MyEnumerator : IEnumerator
    {
        int[] _nums;
        int _index = -1;

        #region 构造函数
        public MyEnumerator(int[] numbers)
        {
            _nums = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
                _nums[i] = numbers[i];
        }
        #endregion

        #region 获取当前值
        public object Current
        {
            get
            {
                if (_index == -1 || _index >= _nums.Length)
                    throw new InvalidOperationException();

                return _nums[_index];
            }
        }
        #endregion

        #region 移动到下一个位置
        public bool MoveNext()
        {
            if (_index >= _nums.Length - 1)
                return false;

            _index++;
            return true;
        }
        #endregion

        #region 重置
        public void Reset()
        {
            _index = -1;
        }
        #endregion
    }
    #endregion

    #region 可枚举类型
    /// <summary>
    /// 可枚举类型
    /// </summary>
    public class MyEnumerate : IEnumerable
    {
        int[] numbers = { 1, 2, 3, 4 };

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(numbers);
        }
    } 
    #endregion
}
