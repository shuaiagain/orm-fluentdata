using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeOne.business
{
    public class MyContext
    {
        public MyContext()
        {
            this.Enumerator = new Enumerator();
            this.Iterator = new Iterator();
            this.LockEX = new LockEX();
        }

        /// <summary>
        /// 枚举器
        /// </summary>
        public Enumerator Enumerator { get; set; }

        /// <summary>
        /// 迭代器
        /// </summary>
        public Iterator Iterator { get; set; }

        /// <summary>
        /// lock
        /// </summary>
        public LockEX LockEX { get; set; }
    }
}
