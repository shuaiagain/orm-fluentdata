using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Linq.Expressions;
using System.Reflection;

namespace Knowledge
{
    /// <summary>
    /// 1.匿名方法
    /// 2.lambda表达式、表达式树
    /// </summary>
    class Program
    {
        //在 2.0 之前的 C# 版本中，声明委托的唯一方式是使用命名方法。 C# 2.0 引入匿名方法，
        //在 C# 3.0 及更高版本中，Lambda 表达式取代匿名方法作为编写内联代码的首选方式。 但是，
        //本主题中有关匿名方法的信息也适用于 Lambda 表达式。 在有一种情况下，匿名方法提供 Lambda 表达式中没有的功能。
        //使用匿名方法可省略参数列表。 这意味着匿名方法可转换为具有多种签名的委托。 Lambda 表达式无法实现这一点。 
        //有关 Lambda 表达式的详细信息，请参阅 Lambda 表达式。
        //创建匿名方法实际上是一种将代码块作为委托参数传递的方式
        delegate void Del(int x);
        delegate int Dele(int x);
        delegate TResult Func<in T, out TResult>(T arg);
        static void Main(string[] args)
        {
            //匿名委托
            Del de = delegate(int k) { Console.WriteLine(k); };
            de(1);

            Thread thread = new Thread(delegate()
            {
                Console.WriteLine("start");
            });

            thread.Start();

            int i = 1;
            Del del = delegate(int a)
            {
                i++;
                Console.WriteLine(i);
            };
            del(1);

            //lambda表达式
            Dele lam = x => x * x;
            Console.WriteLine(lam(2));

            //lambda表达式(用于表达式树)
            Expression<Dele> la = a => a * a;

            //lambda语句
            Del deOne = (aa) => { Console.WriteLine(aa); };
            deOne(6);

            #region 表达式树

            //创建一个表达式树中的参数，作为一个节点，这里是最下层的节点
            ParameterExpression aaa = Expression.Parameter(typeof(int), "i");
            ParameterExpression bbb = Expression.Parameter(typeof(int), "j");
            //这里i*j,生成表达式树中的一个节点，比上面节点高一级
            BinaryExpression resultOne = Expression.Multiply(aaa, bbb);

            ParameterExpression c = Expression.Parameter(typeof(int), "w");
            ParameterExpression d = Expression.Parameter(typeof(int), "x");
            BinaryExpression resultTwo = Expression.Multiply(c, d);
            //运算两个中级节点，产生终结点
            BinaryExpression result = Expression.Add(resultOne, resultTwo);

            Expression<Func<int, int, int, int, int>> lambda = Expression.Lambda<Func<int, int, int, int, int>>(result, aaa, bbb, c, d);
            Console.WriteLine(lambda);

            Func<int, int, int, int, int> fu = lambda.Compile();
            Console.WriteLine(fu(1, 2, 3, 4));
            #endregion


            Man man = new Man();
            Type manTypesTwo = man.GetType();
            Type manTypes = typeof(Man);

            #region reflection
            MemberInfo[] members = manTypes.GetMembers();
            MethodInfo[] methods = manTypes.GetMethods();
            FieldInfo[] fields = manTypes.GetFields();
            PropertyInfo[] proerties = manTypes.GetProperties();

            string mem = "";
            bool met = false;

            foreach (MemberInfo item in members)
            {
                mem = item.Name;
            }

            foreach (MethodInfo item in methods)
            {
                met = item.IsPublic;
            }

            foreach (FieldInfo item in fields)
            {

            }

            foreach (PropertyInfo item in proerties)
            {

            }
            #endregion

        }

    }
}
