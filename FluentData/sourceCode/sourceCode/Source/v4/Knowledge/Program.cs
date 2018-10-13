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
        #region 匿名委托
        //在 2.0 之前的 C# 版本中，声明委托的唯一方式是使用命名方法。 C# 2.0 引入匿名方法，
        //在 C# 3.0 及更高版本中，Lambda 表达式取代匿名方法作为编写内联代码的首选方式。 但是，
        //本主题中有关匿名方法的信息也适用于 Lambda 表达式。 在有一种情况下，匿名方法提供 Lambda 表达式中没有的功能。
        //使用匿名方法可省略参数列表。 这意味着匿名方法可转换为具有多种签名的委托。 Lambda 表达式无法实现这一点。 
        //有关 Lambda 表达式的详细信息，请参阅 Lambda 表达式。
        //创建匿名方法实际上是一种将代码块作为委托参数传递的方式 
        #endregion

        delegate void Del(int x);
        delegate int Dele(int x);
        delegate TResult Func<in T, out TResult>(T arg);

        static void Main(string[] args)
        {
            //匿名委托
            Del de = delegate (int k) { Console.WriteLine(k); };
            de(1);

            #region 线程

            Thread thread = new Thread(delegate ()
            {
                Console.WriteLine("start");
            });

            thread.Start();
            #endregion

            #region 委托
            int i = 1;
            Del del = delegate (int a)
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
            #endregion

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

            #region reflection
            Man man = new Man();
            Type manTypesTwo = man.GetType();
            Type manTypes = typeof(Man);


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

            #region 算法
            //斐波那契数列
            Console.WriteLine("斐波那契数列：{0}", Algorithm.Reverse(7));
            //n！的阶乘
            Console.WriteLine("n！的阶乘：{0}", Algorithm.Factorial(5));
            //冒泡排序
            //TestOne.BubbleSort(new int[] { 5, 4, 3, 2, 1 });
            //冒泡排序2
            Algorithm.BubbleSort2(new int[] { 5, 4, 3, 2, 1 });
            #endregion

            #region 基础知识
            BaseKonwledes.EqualDifference();
            #endregion

            #region 算法
            int aaaa = 1, bbbb = 2;
            Algorithm.TwoExchange(ref aaaa, ref bbbb);

            Algorithm.FibonacciStack(7);
            #endregion

            #region 基础知识-继承
            Parent ch = new Child();
            ch.SetName("a");
            ch.GetName();

            Child cc = new Child();


            Console.WriteLine("{{0}} = {0}", 1);

            //int? ab;
            //Console.WriteLine("ab:", ab.Value);

            //Parent p;
            //Console.WriteLine("Parent:",p);
            #endregion

            #region 基础-引用类型
            Refference re = new Refference();
            int numA = 1;
            BaseKonwledes.Refference(re, numA);

            Console.WriteLine("re.num :{0}", re.num);
            Console.WriteLine("num :{0}", numA);


            Refference ree = new Refference();
            int numB = 1;
            BaseKonwledes.Refference(ref ree, ref numB);

            Console.WriteLine("re.num :{0}", ree.num);
            Console.WriteLine("num :{0}", numB);

            #endregion

            #region 基础-ref-out

            Refference myRef = new Refference();
            BaseKonwledes.MyRefAsParameter(myRef);
            Console.WriteLine("myRef :{0} ", myRef.num);

            Refference myOut;
            BaseKonwledes.MyOutAsParameter(out myOut);

            Console.WriteLine("myOut.num :{0}", myOut.num);
            #endregion

            #region 参数数组
            BaseKonwledes.ParamsArray();
            BaseKonwledes.ParamsArray(1);
            BaseKonwledes.ParamsArray(1, 2);

            #endregion

            #region 二分查找
            Console.WriteLine("二分查找");
            Console.WriteLine(Algorithm.BinarySearch(new int[] { 1, 2, 3, 4, 5 }, 4));
            Console.WriteLine(Algorithm.BinarySearch2(new int[] { 1, 2, 3, 4 }, 0, 3, 1));
            Console.WriteLine(Algorithm.Binary3(new int[] { 1, 2, 3, 4 }, 0));
            #endregion

            #region 泛型
            GenericParadigm.MyStackGeneric();
            //泛型方法、推断类型
            GenericParadigm.GenericFunctions();
            //泛型类的扩展
            GenericParadigm.GenericClassExt();
            //泛型结构
            GenericParadigm.GenericStruct();
            //泛型委托
            GenericParadigm.GenericDelegate();
            //泛型接口
            GenericParadigm.GenericInterface();
            #endregion

            #region 基础-反射

            ReflectionSyntax.ExcuteMethod();
            #endregion

            #region 反射
            Reflection.getAllTypes();
            #endregion

            #region linq
            Linq.LinqTest();
            #endregion
        }

    }
}
