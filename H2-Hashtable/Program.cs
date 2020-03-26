using System;
using System.Collections;
using System.Threading;

namespace H2_Hashtable
{
    class Menu
    {
        public static void StartMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\"Seasonal Flowers\" Management Program");
                FlowerHashtable.PrintTable();
                Console.WriteLine("\nPlease choose a function by its number.");
                Console.WriteLine("1. Edit a season");
                Console.WriteLine("2. Remove a flower");
                Console.WriteLine("3. Exit");
                switch (Selecting())
                {
                    case '1':
                        FlowerHashtable.ChangeFlower();
                        break;
                    case '2':
                        FlowerHashtable.RemoveFlower();
                        break;
                    case '3':
                        Program.Exit();
                        break;
                    default:
                        continue;
                }
            } 
            while (true);
        }
        private static int Selecting()
        {
            ConsoleKeyInfo info = Console.ReadKey(true);
            return info.KeyChar;
        }
    }
    static class FlowerHashtable
    {
        static readonly Hashtable Flowers = new Hashtable();
        public static void Initialize()
        {
            Flowers.Add("Spring", "Cherry Blossom");
            Flowers.Add("Summer", "Sunflower");
            Flowers.Add("Fall", "Chrysanthemum");
            Flowers.Add("Winter", "Plum Blossom");
        }
        public static void ChangeFlower()
        {
            do
            {
                Console.Write("\nPlease input the season you want to change the flower from:");
                string key = Console.ReadLine();
                if (Flowers.ContainsKey(key))
                {
                    Console.Write("Please input the name of the flower you want to change:");
                    string valueChangement = Console.ReadLine();
                    Flowers[key] = valueChangement;
                    return;
                }
                else
                {
                    Console.WriteLine("Input error. Please input the correct name.");
                    continue;
                }
            }
            while (true);
        }

        public static void RemoveFlower()
        {
            do
            {
                Console.Write("\nPlease input the season you want to remove the flower from:");
                string key = Console.ReadLine();
                if (Flowers.ContainsKey(key))
                {
                    try
                    {
                        Flowers.Remove(key);
                    }
                    catch
                    {
                        Console.WriteLine($"Remove failed. Please try again.");
                        return;
                    }
                    return;
                }
                else
                {
                    Console.WriteLine("Input error. Please input the correct name.");
                    continue;
                }
            }
            while (true);
        }

        public static void PrintTable()
        {
            Console.WriteLine("\n━━━━━━━━━━━━━");
            Console.WriteLine("Season\tFlower");
            Console.WriteLine("━━━━━━━━━━━━━");
            Console.WriteLine($"Spring\t{Flowers["Spring"]}");
            Console.WriteLine($"Summer\t{Flowers["Summer"]}");
            Console.WriteLine($"Fall\t{Flowers["Fall"]}");
            Console.WriteLine($"Winter\t{Flowers["Winter"]}");
            Console.WriteLine("━━━━━━━━━━━━━");
            /*
             * 本来想更优雅的用foreach来遍历，
             * 但是Hashtable自己本身的排序顺序很古怪。
             * 如果用ArrayList akey = new ArrayList(Flowers.Keys);
             * 再Flowers.Sort();
             * 则只能做到按首字母排序。
             * 目前好像没有更有效的自定义排序的方法，
             * 除非自己写比较器，这样代码就失去通用性了。
             * 那还不如如上直接用老方法硬拉。
             */
        }
    }
    class Program
    {
        static void Main()
        {
            FlowerHashtable.Initialize();
            Menu.StartMenu();
            Exit();
        }
        public static void Exit()
        {
            Console.WriteLine("Thanks for using this program. Exiting...");
            Thread.Sleep(600);
            Environment.Exit(0);
        }
    }
}
