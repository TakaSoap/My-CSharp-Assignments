using System;
using System.Threading;

namespace H2_sort
{
    class Program
    {
        static void Main()
        {
            int length = ReadInt();//询问需要排序多少位数字\

            int[] array = new int[length];
            for (int i = 0; i < length; i++)
                array[i] = i + 1;       //初始化数组

            Console.WriteLine("为你生成的随机数组是：");
            int swapingCursorPosition = Console.CursorTop;
            Random random = new Random();
            for (int i = length - 1; i > 0; i--)
            {
                Console.SetCursorPosition(0, swapingCursorPosition);
                PrintArray(array.Length, array);
                Thread.Sleep(30);
                Swap(ref array[i], ref array[random.Next(0, length - 1)]);
                //用洗牌算法打乱数组
            }

            Console.WriteLine("按任意键开始排序");
            Console.ReadKey(true);     //true表示按下的按键不上屏

            Console.WriteLine("排序中……（为使冒泡算法效果可视化，不立即完成排序）");
            Bubble(array);

            Console.WriteLine("排序完成！");

            Console.WriteLine("按任意键退出");
            Console.ReadKey(true);
        }
        static int ReadInt()
        {
            //异常处理
            while (true)
            {
                try
                {
                    Console.Write("请输入你想排序的数字个数：");
                    int number = Convert.ToInt32(Console.ReadLine());
                    if(number <= 1)
                    {
                        Console.WriteLine("输入有误，请重新输入！");
                        continue;
                    }
                    return number;
                }
                catch
                {
                    Console.WriteLine("输入有误，请重新输入！");
                }
            }
        }
        static void Bubble(int[] array)
        {
            int cursorPosition = Console.CursorTop;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        Thread.Sleep(100);  //体现冒泡排序效果
                        Console.SetCursorPosition(0, cursorPosition);
                        PrintArray(array.Length, array);
                    }
                }
            }
        }
        static void Swap(ref int a, ref int b)
        {
            int temp;
            temp = a;
            a = b;
            b = temp;
        }
        static void PrintArray(int length, int[] array)
        {
            for (int i = 0; i < length; i++)
            {
                if (i == length - 1)
                {
                    Console.WriteLine($"{array[i]}");
                    break;
                }
                else
                    Console.Write($"{array[i]}, ");
            }
        }
    }
}