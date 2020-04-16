using System;
using System.Threading;

namespace H4_construction
{
    internal class Boyfriend
    {
        private readonly string name;
        private readonly int metDate;
        private readonly int loveDuration;

        internal Boyfriend(string name, int loveDuration)
        {
            this.name = name;
            this.loveDuration = loveDuration;
        }
        internal Boyfriend(string name, int metDate, int loveDuration)
        {
            this.name = name;
            this.metDate = metDate;
            this.loveDuration = loveDuration;
        }

        internal static void PrintTable(Boyfriend[] bfs)
        {
            Console.WriteLine("以下为所有已记录的男友\n");
            Console.WriteLine($"{"姓名",-5}{"相识日期",-6}{"恋爱天数"}");
            Console.WriteLine("━━━━━━━━━━━━━");
            foreach (Boyfriend boyfriend in bfs)
            {
                string metDate = boyfriend.metDate == 0 ? " 未记录 " : Convert.ToString(boyfriend.metDate);
                Console.WriteLine($"{boyfriend.name}" + "   " + $"{metDate}" +
                    $"{boyfriend.loveDuration,7}");
            }

            Console.WriteLine("━━━━━━━━━━━━━\n");
            Console.WriteLine("以下为上表中恋爱长度超过30天的男友\n");
            Console.WriteLine($"{"姓名",-5}{"相识日期",-6}{"恋爱天数"}");
            Console.WriteLine("━━━━━━━━━━━━━");
            foreach (Boyfriend boyfriend in bfs)
            {
                if (boyfriend.loveDuration > 30)
                {
                    string metDate = boyfriend.metDate == 0 ? " 未记录 " : Convert.ToString(boyfriend.metDate);
                    Console.WriteLine($"{boyfriend.name}" + "   " + $"{metDate}" +
                        $"{boyfriend.loveDuration,7}");
                }
            }
            Console.WriteLine("━━━━━━━━━━━━━");
        }
    }

    internal static class Program
    {
        static void Main()
        {
            Boyfriend[] bfs = new Boyfriend[5];
            string[] names = { "张三", "李四", "王五", "赵六", "孙七" };
            int[] loveDurations = { 11, 22, 33, 44, 55 };
            int[] metDate = { 20190101, 20200101 };
            for (int i = 0; i < bfs.Length; i++)
            {
                if (i < 2)
                {
                    bfs[i] = new Boyfriend(names[i], metDate[i], loveDurations[i]);
                }
                else
                    bfs[i] = new Boyfriend(names[i], loveDurations[i]);
            }
            Boyfriend.PrintTable(bfs);

            Console.WriteLine("\n按任意键退出");
            Console.ReadKey();

        }
    }
}