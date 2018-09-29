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

    }
}
