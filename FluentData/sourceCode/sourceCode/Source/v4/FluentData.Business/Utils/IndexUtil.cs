using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentData.Business.Utils
{
    /// <summary>
    /// 索引器
    /// </summary>
    public class IndexUtil
    {

        private long[] data = new long[100];

        public long this[int index]
        {
            get
            {
                if (index < 0 || index > 100)
                    return 0;
                else
                    return this.data[index];
            }
            set
            {
                if (0 < index && index <= 100)
                {
                    this.data[index] = value;
                }
            }
        }
    }
}
