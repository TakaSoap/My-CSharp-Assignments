using System;
using System.Collections;
/*
 * 控制台项目H4-override ----- √
 * 1、创建类Animal ----- √
 * 成员变量：name；虚函数PrintSelf ----- √
 * 2、创建类Cat，继承于Animal ----- √
 * 成员变量：color；函数PrintSelf：打印name和color ----- √
 * 3、创建类Mouse，继承于Animal ----- √
 * 成员变量：weight；函数PrintSelf：打印name和weight ----- √
 * 4、主函数中新建hashtable ----- √
 * 在hashtable中添加2只Cat对象，3只Mouse对象；hashtable的索引为动物的名字 ----- √
 * 使用循环语句打印输出hashtable中所存放的对象信息。 ----- √
 */
namespace H4_override
{
    class Program
    {
        static void Main()
        {
            Console.Title = "H4-override";
            Console.SetWindowSize(28, 12);

            string[] names = { "Charlie", "Tom", "Max", "Chloe", "Oliver" };
            string[] colors = { "GoldEnrod", "LemonChiffon" };
            int[] weights = { 233, 252, 251 };

            Hashtable animals = new Hashtable();
            //主函数中新建hashtable

            for (int i = 0; i < names.Length; i++)
                animals.Add(names[i], i < 2 ? new Cat(names[i], colors[i]) : new Mouse(names[i], weights[i - 2]) as Animal);
            //在hashtable中添加2只Cat对象，3只Mouse对象；hashtable的索引为动物的名字

            PrintInformation(animals);
            //使用循环语句打印输出hashtable中所存放的对象信息。

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }
        static void PrintInformation(Hashtable animals)
        {
            const string thickBorder = "━━━━━━━━━━━";
            const string thinBorder = "───────────";

            Console.WriteLine(thickBorder);
            Console.WriteLine("Name\tColor/Weight");
            Console.WriteLine(thinBorder);

            foreach (Animal animal in animals.Values)
                animal.PrintSelf();
            //使用循环语句打印输出hashtable中所存放的对象信息。
            //foreach也是循环语句。

            Console.WriteLine(thickBorder);
        }
    }
}
