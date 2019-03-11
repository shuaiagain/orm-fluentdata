using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge.bussiness
{
    public class ExpressionList
    {
        public delegate T Function<T>(T a, T b);

        protected static string Appends(string a, string b)
        {
            return a + b;
        }

        #region 实名委托/匿名函数/lambda表达式/表达式
        /// <summary>
        /// 实名委托/匿名函数/lambda表达式/表达式
        /// </summary>
        public static void One()
        {
            //实名委托
            Function<string> result = new Function<string>(Appends);
            Console.WriteLine(result("a", "b"));

            //匿名函数
            Function<string> asyn = new Function<string>(delegate (string a, string b) { return string.Format("{0}@{1}", a, b); });
            Console.WriteLine(asyn("a", "b"));

            //lambda表达式
            Function<string> lambda = (a, b) => { return string.Format("{0}+{1}", a, b); };
            Console.WriteLine(lambda("a", "b"));

            //表达式
            Expression<Function<string>> expre;
            expre = (a, b) => string.Format("{0}-{1}", a, b);
            Console.WriteLine(expre.Compile()("a", "b"));
        }
        #endregion

        #region 表达式Expression
        /// <summary>
        /// 表达式Expression
        /// </summary>
        public static void Two()
        {
            ParameterExpression paramA = Expression.Parameter(typeof(object), "a");
            ParameterExpression paramB = Expression.Parameter(typeof(object), "b");
            ConstantExpression constExp = Expression.Constant("{0} _ {1}", typeof(string));
            MethodCallExpression bodyExp = Expression.Call(typeof(string).GetMethod("Format", new Type[] {
                typeof(string),
                typeof(object),
                typeof(object)
            }), new Expression[] {
                constExp,paramA,paramB
            });

            LambdaExpression lam = Expression.Lambda(bodyExp, paramA, paramB);
            Delegate dg = lam.Compile();
            Console.WriteLine(dg.DynamicInvoke("hello","world"));
            Console.WriteLine(lam.Compile().DynamicInvoke("hello", "world"));
        }
        #endregion
    }
}
