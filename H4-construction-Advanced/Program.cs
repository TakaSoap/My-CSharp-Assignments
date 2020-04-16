using System;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace H4_construction_Advanced
{
    internal class Boyfriend
    {
        internal int number;
        internal string name;
        internal DateTime metDate;
        internal DateTime loveDate;
        internal int loveDuration;

        internal Boyfriend(string name, DateTime metDate, DateTime loveDate)
        {
            this.name = name;
            this.metDate = metDate;
            this.loveDate = loveDate;
            this.loveDuration = DateTime.Now.Subtract(loveDate).Days;
        }
    }

    internal static class Program
    {
        static readonly List<Boyfriend> boyfriends = new List<Boyfriend>();
        static readonly CultureInfo culture = new CultureInfo("zh-CN");

        internal static void StartMenu()
        {

            do
            {
                Console.Clear();

                Console.WriteLine("━━━━━━━━ 男友管理程序 ━━━━━━━━");

                PrintTable();

                Console.WriteLine("\n请通过输入对应数字选择功能");
                Console.WriteLine("1. 新增一位男友");
                Console.WriteLine("2. 修改一位男友的信息");
                Console.WriteLine("3. 删除一位男友");
                Console.WriteLine("4. 退出程序\n");

                switch (Selecting())
                {
                    case '1':
                        AddBoyfriend();
                        break;
                    case '2':
                        EditBoyfriend();
                        break;
                    case '3':
                        RemoveBoyfriend();
                        break;
                    case '4':
                        Exit();
                        break;
                    default:
                        continue;
                }
            } while (true);
        }

        private static void RemoveBoyfriend()
        {
            if (boyfriends.Count == 0)
            {
                Console.WriteLine("暂未存入男友，按任意键返回");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("请输入要删除的男友的序号（留空返回）：");
            while (true)
            {
                int number = ReadNumber();
                if (number == -1)
                    return;
                try
                {
                    boyfriends.RemoveAt(number - 1);
                }
                catch
                {
                    Console.WriteLine("输入错误，请重新输入：");
                    continue;
                }
                break;
            }
        }

        static int ReadNumber()
        {
            //异常处理
            while (true)
            {
                try
                {
                    string numberString = Console.ReadLine();
                    if (string.IsNullOrEmpty(numberString))
                        return -1;

                    int number = Convert.ToInt32(numberString);

                    if (number <= 0 || number > boyfriends.Count)
                    {
                        Console.WriteLine("输入有误，请重新输入：");
                        continue;
                    }
                    return number;
                }
                catch
                {
                    Console.WriteLine("输入有误，请重新输入：");
                    continue;
                }
            }
        }

        private static void EditBoyfriend()
        {
            if (boyfriends.Count == 0)
            {
                Console.WriteLine("暂未存入男友，按任意键返回");
                Console.ReadKey();
                return;
            }

            int number;

            Console.WriteLine("请输入要修改的男友的序号（留空返回）：");

            number = ReadNumber();
            if (number == -1)
                return;

            string name;

            Console.WriteLine("请修改这位男友的姓名（留空跳过）：");
            while (true)
            {
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    break;
                }
                else if (Encoding.Default.GetBytes(name).Length > 10)
                {
                    Console.WriteLine("姓名过长，请重新输入：");
                    continue;
                }
                break;
            }

            if (!string.IsNullOrEmpty(name))
                boyfriends[number - 1].name = name;

            Console.WriteLine("请修改相识日期（留空跳过）：");
            DateTime metDate = InputDateTime(1);

            if (metDate != DateTime.MaxValue)
                boyfriends[number - 1].metDate = metDate;

            Console.WriteLine("请修改相爱日期（留空跳过）：");
            DateTime loveDate;
            while (true)
            {
                loveDate = InputDateTime(1);
                if (loveDate.Subtract(boyfriends[number - 1].metDate).Days < 0 && loveDate != DateTime.MaxValue)
                {
                    Console.WriteLine("还不认识对方的时候恐怕还不能和他相爱，再输入一次呗：");
                    continue;
                }
                else
                    break;
            }
            
            if (loveDate != DateTime.MaxValue)
                boyfriends[number - 1].loveDate = loveDate;

            boyfriends[number - 1].loveDuration =
                DateTime.Now.Subtract(boyfriends[number - 1].loveDate).Days;

        }

        private static void AddBoyfriend()
        {
            string name;
            Console.WriteLine("请输入这位男友的姓名（留空返回）：");
            while (true)
            {
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    return;
                }
                else if (Encoding.Default.GetBytes(name).Length > 10)
                {
                    Console.WriteLine("姓名过长，请重新输入：");
                    continue;
                }
                break;
            }
            Console.WriteLine("请输入相识日期：");
            DateTime metDate = InputDateTime(0);
            Console.WriteLine("请输入相爱日期：");
            DateTime loveDate;
            while (true)
            {
                loveDate = InputDateTime(0);
                if (loveDate.Subtract(metDate).Days < 0)
                {
                    Console.WriteLine("还不认识对方的时候恐怕还不能和他相爱，再输入一次呗：");
                    continue;
                }
                else
                    break;
            }
            Boyfriend boyfriend = new Boyfriend(name, metDate, loveDate);
            boyfriends.Add(boyfriend);
            boyfriend.number = boyfriends.Count;
        }

        private static DateTime InputDateTime(int args)
        {
            DateTime date = DateTime.MaxValue;

            while (true)
            {
                string dateString = Console.ReadLine();
                if (string.IsNullOrEmpty(dateString) && args == 1)
                    return date;
                try
                {
                    date = DateTime.ParseExact(dateString, "yyyyMMdd", culture);
                    if (DateTime.Now.Subtract(date).Days < 1)
                    {
                        Console.WriteLine("未来可期，但请勿自欺，请重新输入：");
                        continue;
                    }
                }
                catch
                {
                    try
                    {
                        date = DateTime.Parse(dateString, culture);
                        if (DateTime.Now.Subtract(date).Days < 1)
                        {
                            Console.WriteLine("未来可期，但请勿自欺，请重新输入：");
                            continue;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("输入错误，参考格式范例：\n20180101 2018.1.1 2018-1-1 2018年1月1日 18/1/1 以此类推\n请重新输入：");
                        continue;
                    }
                }
                return date;
            }

        }

        private static void PrintTable()
        {
            Console.WriteLine($"{"序号",-4}{"姓名",-9}{"相识日期",-6}{"相爱日期",-6}{"恋爱天数"}");
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━");
            if (boyfriends.Count == 0)
            {
                Console.WriteLine("      暂未存入任何男友信息，请添加男友！");
            }
            else
            {
                foreach (Boyfriend boyfriend in boyfriends)
                {
                    string name =
                        boyfriend.name +
                        new string(' ', 10 - Encoding.Default.GetBytes(boyfriend.name).Length);

                    Console.WriteLine($"{boyfriends.IndexOf(boyfriend) + 1,4}" + "  " +
                        $"{name}" + " " + $"{boyfriend.metDate,-10:d}" +
                        $"{boyfriend.loveDate,-10:d}{boyfriend.loveDuration,8}");
                }
            }
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━"); ;
        }

        private static int Selecting()
        {
            ConsoleKeyInfo info = Console.ReadKey(true);
            return info.KeyChar;
        }

        internal static void Exit()
        {
            Console.WriteLine("祝你感情顺利，正在退出……");
            Thread.Sleep(600);
            Environment.Exit(0);
        }
        static void Main()
        {
            StartMenu();
            Exit();
        }
    }
}