using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Knowledge
{
    /// <summary>
    /// 算法
    /// </summary>
    public partial class Algorithm
    {

        #region 斐波那契数列
        public static int Reverse(int num)
        {

            if (num <= 0)
                return 0;
            else if (0 < num && num <= 2)
                return 1;
            else
                return Reverse(num - 1) + Reverse(num - 2);
        }
        #endregion

        #region 栈实现斐波那契数列
        public static int FibonacciStack(int n)
        {

            if (n < 0)
                throw new ArgumentOutOfRangeException("n must > 0");

            if (n == 1 || n == 2)
                return 1;

            Stack<int> stack = new Stack<int>(2);
            stack.Push(1);
            stack.Push(1);

            for (int i = 3; i <= n; i++)
            {
                var top = stack.Pop();
                var bottom = stack.Pop();
                var sum = top + bottom;

                stack.Push(top);
                stack.Push(sum);
            }

            Console.WriteLine(stack.Peek());
            return stack.Peek();
        }
        #endregion

        #region 栈实现斐波那契数列2
        public static int FibonacciStackTwo(int n)
        {
            if (n < 0)
                throw new IndexOutOfRangeException("n must > 0");

            if (n == 1 && n == 2)
                return 1;

            Stack<int> stack = new Stack<int>(2);

            stack.Push(1);
            stack.Push(1);
            for (int i = 3; i <= n; i++)
            {
                var top = stack.Pop();
                var bottom = stack.Pop();

                var sum = top + bottom;
                stack.Push(top);
                stack.Push(sum);
            }

            Console.WriteLine(stack.Peek());
            return stack.Peek();
        }
        #endregion

        #region 斐波那契3
        public static int Fabri3(int n)
        {

            if (n <= 0)
            {
                throw new IndexOutOfRangeException("n must >0");
            }

            if (n == 1 || n == 2) return 1;

            Stack<int> stack = new Stack<int>();

            stack.Push(1);
            stack.Push(1);
            for (int i = 3; i <= n; i++)
            {
                int top = stack.Pop();
                int bottom = stack.Pop();

                int sum = top + bottom;
                stack.Push(top);
                stack.Push(sum);
            }

            Console.WriteLine(stack.Peek());

            return stack.Peek();
        }
        #endregion

        #region 阶乘
        public static int Factorial(int num)
        {
            if (0 <= num && num <= 1)
                return 1;
            else
                return num * Factorial(num - 1);
        }
        #endregion

        #region 冒泡排序-1
        public static void BubbleSort(int[] arr)
        {

            int temp;
            string item;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }

                }

                item = string.Empty;
                for (int k = 0; k < arr.Length; k++)
                {
                    item += arr[k].ToString() + " ";
                }
                item = " 第" + (i + 1) + "轮：" + item;
                Console.WriteLine(item);
            }

            string result = string.Empty;
            for (int i = 0; i < arr.Length; i++)
            {
                result += arr[i].ToString() + " ";
            }

            Console.WriteLine(" 排序后的结果：{0}", result);
        }
        #endregion

        #region 冒泡排序-2
        public static void BubbleSort2(int[] arr)
        {
            int temp;
            string item;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                    Console.WriteLine("j= {0}", j);
                }

                item = string.Empty;
                for (int k = 0; k < arr.Length; k++)
                {
                    item += arr[k].ToString() + " ";
                }
                item = " 第" + (i + 1) + "轮：" + item;
                Console.WriteLine(item);
            }

            string result = string.Empty;
            for (int i = 0; i < arr.Length; i++)
            {
                result += arr[i].ToString() + " ";
            }

            Console.WriteLine(" 排序后的结果：{0}", result);

        }
        #endregion

        #region 两个数交换
        public static void TwoExchange(ref int a, ref int b)
        {

            a = a - b;
            b = a + b;
            a = b - a;

            Console.WriteLine(" a = {0},b = {1} ", a, b);
        }
        #endregion

        #region 二分查找
        public static int BinarySearch(int[] arr, int key)
        {

            int low = 0;
            int high = arr.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (key == arr[mid])
                    return mid;
                else if (key < arr[mid])
                    high = mid - 1;
                else if (key > arr[mid])
                    low = mid + 1;
            }

            return -1;
        }
        #endregion

        #region 二分查找2
        public static int BinarySearch2(int[] arr, int low, int high, int key)
        {

            if (low > high) return -1;

            int mid = (low + high) / 2; ;

            if (key == arr[mid])
                return mid;
            else if (key < arr[mid])
                return BinarySearch2(arr, low, mid - 1, key);
            else if (key > arr[mid])
                return BinarySearch2(arr, mid + 1, high, key);
            else
                return -1;
        }
        #endregion

        #region 二分查找3
        public static int Binary3(int[] arr, int key)
        {

            int low = 0, high = arr.Length - 1;

            while (low <= high)
            {

                int mid = (low + high) / 2;
                if (key == arr[mid])
                    return mid;
                else if (key < arr[mid])
                    high = mid - 1;
                else if (key > arr[mid])
                    low = mid + 1;
            }

            return -1;
        }
        #endregion

        #region 判断大括号左右是否相等
        public static bool IsBracketEquals(string str)
        {

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < str.Length; i++)
            {

                if (str[i] == '(' || str[i] == '{' || str[i] == '[')
                    stack.Push(str[i]);
                else if (str[i] == ')' || str[i] == '}' || str[i] == ']')
                    stack.Pop();
            }

            Console.WriteLine(" bracket is equal:{0} ", stack.Count == 0);
            if (stack.Count == 0) return true;

            return false;
        }
        #endregion

        #region 26个字母随机取4个然后排序

        public static void RandomA_Z()
        {
            string[] arr = new string[4];

            string[] sourceArr = new string[] {
                "A","B","C","D","E","F","G",
                "H","I","J","K","L","M","N",
                "O","P","Q","R","S","T","U",
                "V","W","X","Y","Z"};
        }

        public static void RandomAZ()
        {
            string str = "";
            string[] strArr = new string[4];
            string[] arr = new string[] {
                "A","B","C","D","E","F","G",
                "H","I","J","K","L","M","N",
                "O","P","Q","R","S","T","U",
                "V","W","X","Y","Z"
            };

            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                int temp = random.Next(0, 26);
                str += arr[temp];
                string tempVal = arr[temp];
                strArr[i] = tempVal;
            }

            Array.Sort(strArr);
            //翻转字符串
            //Array.Reverse(strArr);

            str = string.Join(",", strArr);

            Console.WriteLine(" 字符串排序: ");
            foreach (var item in strArr)
            {
                Console.Write(" {0}", item);
            }

            Console.WriteLine(" 字符串排序：{0} ", str);



            //字符串、数组互相转换
            string[] arrA = new string[] { };
            string strB = "a,b,c,d";

            var arrB = strB.Split(',');

            foreach (var item in arrB)
            {
                Console.Write(" {0} ", item);
            }
            Console.WriteLine();
        }
        #endregion

    }
}
