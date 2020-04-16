using System;
/*
 * 1.新建类Cat ----- √
 * 一个构造函数，两个属性 ----- √
 * 定义一个索引器 ----- √
 * 至少一个非静态成员方法（不包括构造函数）----- √
 * 至少一个静态成员变量，一个静态成员方法 ----- √
 * 2.在主函数中新建Cat对象数组cats ----- √
 * 数组长度为5 ----- √
 * 调用非静态成员方法和静态成员方法 ----- √
 * 利用索引器访问数组中第0个元素的数据，并输出 ----- √
 * 排序（按某一属性值，降序），输出 ----- √
 */

namespace H4_static  //项目名称H4-static
{
    class Cat : IComparable  //新建类Cat
    {
        public Cat(string Name, int Age)  //一个构造函数
        {
            this.Name = Name;
            this.Age = Age;
        }
        public string Name { get; set; }  //两个属性 - 第一个属性（自动实现）
        public int Age { get; set; }  //两个属性 - 第二个属性（自动实现）
        public object this[int index]  //定义一个索引器
        {
            get
            {
                if (index == 0)
                    return Name;
                else if (index == 1)
                    return Age;
                else
                    return null;
            }
            set
            {
                if (index == 0)
                    Name = (string)value;
                else if (index == 1)
                    Age = (int)value;
            }
        }
        public void EditProfile()  //一个非静态成员方法
        {
            Console.WriteLine($"Edit {Name}'s name (keep empty to skip):");
            string newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName))
            {
                Name = newName;
            }
            Console.WriteLine($"Edit {Name}'s age (keep empty to skip):");
            int newAge = ReadNumber();
            if (newAge != -1)
            {
                Age = newAge;
            }
        }
        public static int catsCount = 0;  //一个静态成员变量
        //没说不能public，但是限制两个属性，所以这个变量就public吧
        static int ReadNumber()  //一个静态成员方法
        {
            //异常处理
            while (true)
            {
                try
                {
                    string newAgeString = Console.ReadLine();

                    if (string.IsNullOrEmpty(newAgeString))
                        return -1;

                    int newAge = Convert.ToInt32(newAgeString);

                    if (newAge <= 0 || newAge > 30)
                    {
                        Console.WriteLine("Input error, please retry:");
                        continue;
                    }
                    return newAge;
                }
                catch
                {
                    Console.WriteLine("Input error, please retry:");
                    continue;
                }
            }
        }
        public int CompareTo(object obj)  //实现IComparable接口
        {
            Cat cat = (Cat)obj;
            if (cat == null)
            {
                throw new ArgumentException("Program error. Object is not a \"Cat\"");
            }
            return cat.Age - Age;
        }

    }
    class Program
    {
        static void Main()
        {
            string[] catNames = { "Charlie", "Tom", "Max", "Chloe", "Oliver" };
            int[] age = { 1, 2, 3, 4, 5 };
            Cat[] cats = new Cat[5];  //在主函数中新建Cat对象数组cats，数组长度为5

            for (int i = 0; i < 5; i++)
            {
                cats[i] = new Cat(catNames[i], age[i]);
                Cat.catsCount++;
            }

            Random random = new Random();
            Console.WriteLine("Edit a randomly choosed cat.");
            cats[random.Next(1, 5)].EditProfile();
            //调用非静态成员方法和静态成员方法（静态成员方法被非静态成员方法调用）

            Console.WriteLine($"\nThe zeroth cat's name is {cats[0][0]}, and he/she is {cats[0][1]}.\n");
            //利用索引器访问数组中第0个元素的数据，并输出

            Array.Sort(cats);  //排序（按某一属性值，降序）//此处按"Age"降序

            PrintCats(cats);  //输出

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        static void PrintCats(Cat[] cats)
        {
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━");
            Console.WriteLine("Name\tAge");
            Console.WriteLine("───────────────────────");
            foreach (Cat cat in cats)
            {
                Console.WriteLine($"{cat.Name}\t{cat.Age}");
            }
            Console.WriteLine($"There are {Cat.catsCount} cats in total.");
            Console.WriteLine("Cats are listed in descending order by ages.");
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━");
        }
    }
}
