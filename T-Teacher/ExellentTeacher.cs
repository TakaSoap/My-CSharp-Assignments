using System;
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
    class ExellentTeacher : Teacher
    {
        //定义ExcellentTeacher类，该类继承自Teacher类
        public int Bonus { get; set; }
        public ExellentTeacher(string name, int teacherID, int wage, int bonus) : base(name, teacherID, wage)
        {
            Bonus = bonus;
        }
        //可以从父类中继承工号，姓名，工资信息，额外封装奖金信息
        public override void PrintInfor()
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}", TeacherID, Name, Wage, Bonus);
        }
        //重写PrintInfor函数，用于输出工号、姓名、工资、奖金
    }
}
