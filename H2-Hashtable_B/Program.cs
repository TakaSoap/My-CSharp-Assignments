using System;
using System.Collections;
using System.Threading;

namespace H2_Hashtable
{
    static class FlowerHashtable
    {
        static readonly Hashtable Flowers = new Hashtable();
        public static void Initialize()
        {
            Flowers.Add("Spring", "Cherry Blossom");
            Flowers.Add("Summer", "Sunflower");
            Flowers.Add("Fall", "Chrysanthemum");
            Flowers.Add("Winter", "Plum Blossom");
            Console.WriteLine("Before editing:");
        }
        public static void Change()
        {
            Flowers.Remove("Winter");
            Flowers["Fall"] = "Osmanthus";
            Console.WriteLine("After editing:");
        }

        public static void PrintTable()
        {
            Console.WriteLine("\n━━━━━━━━━━━━━");
            Console.WriteLine("Season\tFlower");
            Console.WriteLine("━━━━━━━━━━━━━");
            Console.WriteLine($"Spring\t{Flowers["Spring"]}");
            Console.WriteLine($"Summer\t{Flowers["Summer"]}");
            Console.WriteLine($"Fall\t{Flowers["Fall"]}");
            if(Flowers.ContainsKey("Winter"))
            {
                Console.WriteLine($"Winter\t{Flowers["Winter"]}");
            }
            Console.WriteLine("━━━━━━━━━━━━━\n");
        }
    }
    class Program
    {
        static void Main()
        {
            FlowerHashtable.Initialize();
            FlowerHashtable.PrintTable();
            FlowerHashtable.Change();
            FlowerHashtable.PrintTable();

            Exit();
        }
        public static void Exit()
        {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
            Environment.Exit(0);
        }
    }
}
