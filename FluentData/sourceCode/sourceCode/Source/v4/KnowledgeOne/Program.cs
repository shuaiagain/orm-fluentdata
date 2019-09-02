using KnowledgeOne.business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeOne
{
    class Program
    {
        static void Main(string[] args)
        {
            MyContext context = new MyContext();

            #region 枚举器、枚举类型

            context.Enumerator.Test();
            context.Enumerator.GetEnumeratorSelfDefination();

            #endregion

            #region 迭代器

            context.Iterator.Test();
            context.Iterator.TestOne();

            #endregion

            #region lock锁

            context.LockEX.Test();

            #endregion

        }
    }
}
