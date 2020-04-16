using System;
using System.Collections;

namespace H3_Foreach_B
{
    static class GradeHashtable
    {
        static readonly Hashtable score = new Hashtable();

        public static void Initialize()
        {
            score.Add("张三", 92);
            score.Add("李四", 98);
            score.Add("王五", 60);
            score.Add("孙六", 71);
        }

        public static void PrintTable()
        {
            Console.WriteLine("━━━━━━");
            Console.WriteLine("姓名\t成绩");
            Console.WriteLine("━━━━━━");
            foreach (string name in score.Keys)
            {
                Console.WriteLine($"{name}\t{score[name]}");
            }
            Console.WriteLine("━━━━━━");
        }
    }
    class Program
    {
        static void Main()
        {
            GradeHashtable.Initialize();
            GradeHashtable.PrintTable();
            Exit();
        }

        public static void Exit()
        {
            Console.WriteLine("按任意键退出");
            Console.ReadKey(true);
            Environment.Exit(0);
        }
    }
}
