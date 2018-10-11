using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge
{

    #region 泛型相关
    /// <summary>
    /// 泛型相关
    /// </summary>
    public class GenericParadigm
    {
        #region 泛型栈
        public static void MyStackGeneric()
        {

            MyStack<int> mySta = new MyStack<int>();
            mySta.Push(1);
            mySta.PrintStack();
            mySta.Pop();
            mySta.Print();

            MyStack<string> myStac = new MyStack<string>();
            myStac.Push("a");
            myStac.Push("b");
            myStac.Pop();
            myStac.Pop();
            myStac.Push("c");
            myStac.Push("d");
            myStac.Push("e");
            myStac.PrintStack();

            MyStack<char> myChar = new MyStack<char>();
            myChar.Push('h');
            myChar.Push('e');
            myChar.PrintStack();
        }
        #endregion

        #region 泛型方法
        public static void GenericFunctions()
        {
            int[] arr = new int[] { 1, 2, 3, 4 };
            char[] arrCh = new char[] { 'a', 'b', 'c' };
            string[] arrStr = new string[] { "aa", "bb", "cc" };
            GenericFn.ReversePrint(arr);
            GenericFn.ReversePrint(arrCh);
            GenericFn.ReversePrint(arrStr);
        }
        #endregion

        #region 泛型类的扩展
        public static void GenericClassExt()
        {
            Holder<int> hold = new Holder<int>(1, 2, 3);
            hold.Print();
        }
        #endregion

        #region 泛型结构
        public static void GenericStruct()
        {
            PieceOfData<int> data = new PieceOfData<int>(10);
            Console.WriteLine(" 泛型结构：{0} ", data.Data);
        }
        #endregion

        #region 泛型委托
        public static void GenericDelegate()
        {
            MyDelegate<int> hasParam = new MyDelegate<int>(Simple.PrintNum);
            hasParam(5);

            //系统的泛型委托
            Action<int> ac = new Action<int>(Simple.PrintNum);
            ac(6);

            MyDelegate<string> strMy = new MyDelegate<string>(Simple.PrintString);
            strMy("7");

            MyDelegateTwo<int, string> strTwo = new MyDelegateTwo<int, string>(Simple.NumToString);
            strTwo(12);

            //系统的泛型委托
            Func<int, string> fun = new Func<int, string>(Simple.NumToString);
            fun(13);

            MyDelegateTwoPlus<int, string> twoPlus = new MyDelegateTwoPlus<int, string>(Simple.NumToString);
            twoPlus(14);
        }
        #endregion

        #region 泛型接口
        public static void GenericInterface()
        {
            BigSimple<int> bs = new BigSimple<int>();
            Console.WriteLine("", bs.ReturnValues(10));
        }
        #endregion

    }
    #endregion

    #region 泛型方法
    public class GenericFn
    {
        public static void GenericFun<T>(T ele, int num)
        {
            Console.WriteLine(" Generic Function: {0} ", ele);
        }

        public static void ReversePrint<T>(T[] array)
        {
            Array.Reverse(array);

            foreach (T item in array)
            {
                Console.Write(" {0} ", item.ToString());
            }

            Console.WriteLine();
        }

    }
    #endregion

    #region 泛型类的扩展
    public static class ExtendHolder
    {
        public static void Print<T>(this Holder<T> h)
        {
            T[] vals = h.GetValues();
            foreach (T item in vals)
            {
                Console.Write(" {0} ", item);
            }
            Console.WriteLine();
        }
    }

    public class Holder<T>
    {

        T[] Vals = new T[3];
        public Holder(T one, T two, T three)
        {
            Vals[0] = one;
            Vals[1] = two;
            Vals[2] = three;
        }

        public T[] GetValues()
        {
            return Vals;
        }
    }
    #endregion

    #region 泛型结构
    struct PieceOfData<T>
    {
        public PieceOfData(T value)
        {
            _data = value;
        }

        private T _data;
        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
    #endregion

    #region 泛型委托

    delegate void MyDelegate<T>(T value);
    delegate R MyDelegateTwo<T, R>(T value);
    delegate R MyDelegateTwoPlus<in T, out R>(T value);
    public class Simple
    {
        public static void PrintString(string s)
        {
            Console.WriteLine(" 打印：{0}", s);
        }

        public static void PrintNum(int num)
        {
            Console.WriteLine(" 打印：{0}", num);
        }

        public static string NumToString(int num)
        {
            Console.WriteLine(" 打印： {0} ", num);
            return num.ToString();
        }
    }
    #endregion

    #region 泛型接口
    public interface IMyIfc<T>
    {
        T ReturnValues(T inValue);
    }

    public class BigSimple<S> : IMyIfc<S>
    {
        public S ReturnValues(S inValue)
        {
            return inValue;
        }
    }

    public class BigSimple : IMyIfc<string>, IMyIfc<int>
    {
        public int ReturnValues(int inValue)
        {
            return inValue;
        }

        public string ReturnValues(string inValue)
        {
            return inValue;
        }
    }

    //泛型接口的实现必须唯一
    //public class BigSimpleSE<S> : IMyIfc<int>, IMyIfc<S>
    //{
    //    public S ReturnValues(S inValue)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public int ReturnValues(int inValue)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    #endregion

    #region 泛型栈
    public class MyStack<TP>
    {

        TP[] StackArray;
        int StackPointer = -1;
        const int MaxStack = 10;

        public MyStack()
        {
            StackArray = new TP[MaxStack];
        }

        public MyStack(int size)
        {
            if (size <= 0)
                size = MaxStack;

            StackArray = new TP[size];
        }

        bool IsStackFull
        {
            get
            {
                return StackPointer >= MaxStack - 1;
            }
        }

        bool IsEmpty
        {
            get { return StackPointer < 0; }
        }

        public void Push(TP x)
        {

            if (!IsStackFull)
                StackArray[++StackPointer] = x;
        }

        public TP Pop()
        {
            if (IsEmpty) return StackArray[0];

            TP temp = StackArray[StackPointer];
            StackArray[StackPointer--] = default(TP);

            return temp;
        }

        public TP Peek()
        {
            return IsEmpty ? default(TP) : StackArray[StackPointer];
        }

        public void PrintStack()
        {
            for (int i = 0; i < StackArray.Length; i++)
            {
                Console.WriteLine(" value{0}: {1} ", i, StackArray[i]);
            }
        }

        public void Print()
        {
            for (int i = StackPointer - 1; i >= 0; i--)
            {
                Console.WriteLine(" value: {0} ", StackArray[i]);
            }
        }
    }
    #endregion

}
