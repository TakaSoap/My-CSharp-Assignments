using System;
using System.Collections;
using System.Text;
using System.Threading;

namespace H3_Foreach
{
    static class Menu
    {
        public static void StartMenu()
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Hashtable成绩管理程序");
                GradeHashtable.PrintTable();

                Console.WriteLine("\n请通过输入对应数字选择功能");
                Console.WriteLine("1. 修改某人成绩");
                Console.WriteLine("2. 新增一个人的成绩");
                Console.WriteLine("3. 删除某人及其成绩");
                Console.WriteLine("4. 退出程序");

                switch (Selecting())
                {
                    case '1':
                        GradeHashtable.ChangeGrade();
                        break;
                    case '2':
                        GradeHashtable.AddScore();
                        break;
                    case '3':
                        GradeHashtable.RemoveGrade();
                        break;
                    case '4':
                        Program.Exit();
                        break;
                    default:
                        continue;
                }
            } while (true);
        }
        private static int Selecting()
        {
            ConsoleKeyInfo info = Console.ReadKey(true);
            return info.KeyChar;
        }
    }

    static class GradeHashtable
    {
        static readonly Hashtable score = new Hashtable();

        const string notFound = "查无此人，请重试！";

        public static void Initialize()
        {
            score.Add("张三", 92);
            score.Add("李四", 98);
            score.Add("王五", 60);
            score.Add("孙六", 71);
        }

        public static void ChangeGrade()
        {
            do
            {
                Console.Write("\n请输入被更改人的姓名（留空返回主菜单）：");
                string key = Console.ReadLine();
                if (string.IsNullOrEmpty(key))
                {
                    return;
                }
                else if (score.ContainsKey(key))
                {
                    int changedScore = ReadScore();
                    score[key] = changedScore;
                    return;
                }
                else
                {
                    Console.WriteLine(notFound);
                    continue;
                }
            }
            while (true);
        }

        public static void RemoveGrade()
        {
            do
            {
                Console.Write("\n请输入被移除人的姓名（留空返回主菜单）：");
                string key = Console.ReadLine();
                if (string.IsNullOrEmpty(key))
                {
                    return;
                }
                else if (score.ContainsKey(key))
                {
                    score.Remove(key);
                    return;
                }
                else
                {
                    Console.WriteLine(notFound);
                    continue;
                }
            }
            while (true);
        }

        public static void PrintTable()
        {
            Console.WriteLine("━━━━━━━━━━━");
            Console.WriteLine("姓名\t\t成绩");
            Console.WriteLine("━━━━━━━━━━━");
            foreach (string key in score.Keys)
            {
                string name = key.Length < 4 ? key + "\t" : key.Length < 7 ? key : key.Substring(0, 6) + "…";
                Console.WriteLine($"{name}\t{score[key]}");
            }
            Console.WriteLine("━━━━━━━━━━━");
        }

        static int ReadScore()
        {
            //异常处理
            while (true)
            {
                try
                {
                    Console.Write("请输入分数：");
                    int score = Convert.ToInt32(Console.ReadLine());
                    if (score < 0 || score > 1600) //还有总分比SAT更高的考试么（
                    {
                        Console.WriteLine("输入有误，请重新输入！");
                        continue;
                    }
                    return score;
                }
                catch
                {
                    Console.WriteLine("输入有误，请重新输入！");
                }
            }
        }

        public static void AddScore()
        {
            do
            {
                Console.Write("\n请输入被添加的人的姓名（留空返回主菜单）：");
                string key = Console.ReadLine();
                if (string.IsNullOrEmpty(key))
                {
                    return;
                }
                else if (2 * key.Length != Encoding.Default.GetByteCount(key))
                {
                    Console.WriteLine("暂只支持纯中文姓名，请重新输入");
                    continue;
                }
                else if (!score.ContainsKey(key))
                {
                    if (key.Length >= 7)
                    {
                        Console.WriteLine("姓名较长，将部分省略");
                    }
                    int score = ReadScore();
                    GradeHashtable.score.Add(key, score);
                    return;
                }
                else
                {
                    Console.WriteLine($"{key}已存在于列表中，请重试！");
                    continue;
                }
            }
            while (true);
        }
    }

    class Program
    {
        static void Main()
        {
            GradeHashtable.Initialize();
            Menu.StartMenu();
            Exit();
        }

        public static void Exit()
        {
            Console.WriteLine("感谢使用，正在退出……");
            Thread.Sleep(600);
            Environment.Exit(0);
        }
    }
}
