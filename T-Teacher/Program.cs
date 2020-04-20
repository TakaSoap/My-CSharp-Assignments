using System;
using System.Linq;
/*
 * 定义Teacher类，
 * 在该类中封装有工号，姓名，工资信息，
 * 可以使用索引器写该类中封装的这三个信息。
 * 定义函数PrintInfor，用于输出封装的三个信息。
 * 定义函数PrintNum，用于输出当前老师对象的数目。
 * 定义ExcellentTeacher类，该类继承自Teacher类，
 * 可以从父类中继承工号，姓名，工资信息，额外封装奖金信息。
 * 重写PrintInfor函数，用于输出工号、姓名、工资、奖金。
 * 主函数中，创建3个Teacher对象，3个ExcellentTeacher对象，放在数组中。
 * 调用PrintNum函数输出教师数。
 * 使用索引器，修改3个ExcellentTeacher对象的工资信息，每个人的工资额加上100。
 * 按照工资的降序排序6个对象，将排序前，和排序后的信息输出。
 */
namespace T_Teacher
{
    class Program
    {
        static void Main()
        {
            string[] names = { "Liam", "Evelyn", "Oliver", "Emilia", "Logan", "Violet" };
            int[] teacherIDs = { 101001, 101003, 101005, 102007, 102009, 102012 };
            int[] wages = { 20000, 21000, 22000, 23000, 24000, 25000 };
            int[] bonuses = { 5000, 8000, 9000 };

            Teacher[] teachers = new Teacher[names.Length];

            for (int i = 0; i < names.Length; i++)
            {
                teachers[i] = i < bonuses.Length ? new Teacher(names[i], teacherIDs[i], wages[i]) :
                    new ExellentTeacher(names[i], teacherIDs[i], wages[i], bonuses[i - bonuses.Length]);
            }
            //主函数中，创建3个Teacher对象，3个ExcellentTeacher对象，放在数组中

            PrintNum(teachers);
            //调用PrintNum函数输出教师数

            foreach (Teacher teacher in teachers)
            {
                if (teacher is ExellentTeacher)
                {
                    teacher[2] = teacher.Wage + 100;
                }
            }
            //使用索引器，修改3个ExcellentTeacher对象的工资信息，每个人的工资额加上100

            Console.WriteLine("Befroe sorting:");
            PrintTable(teachers);
            Array.Sort(teachers);
            Console.WriteLine("After sorting:");
            PrintTable(teachers);
            //按照工资的降序排序6个对象，将排序前，和排序后的信息输出

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }
        static void PrintTable(Teacher[] teachers)
        {
            const string thickBorder = "━━━━━━━━━━━━━━━━━━━";
            const string thinBorder = "───────────────────";

            Console.WriteLine(thickBorder);
            Console.WriteLine("ID\tName\tWage\tBonus(if have)");
            Console.WriteLine(thinBorder);

            foreach (Teacher teacher in teachers)
            {
                teacher.PrintInfor();
            }

            Console.WriteLine(thickBorder);
        }
        static void PrintNum(Teacher[] teachers)
        {
            //定义函数PrintNum，用于输出当前老师对象的数目
            Console.WriteLine(teachers.Length > 1 ? 
                             ("There are " + teachers.Count() + " teachers now.") :
                             teachers.Length == 1 ? "There is only one teacher now." :
                             "There is no teacher.");
        }
    }
}
