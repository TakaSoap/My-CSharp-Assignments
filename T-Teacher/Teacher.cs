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
    class Teacher : IComparable
    {
        //定义Teacher类
        public Teacher(string name, int teacherID, int wage)
        {
            Name = name;
            TeacherID = teacherID;
            Wage = wage;
        }
        public string Name { get; set; }
        public int TeacherID { get; set; }
        public int Wage { get; set; }
        //在该类中封装有工号，姓名，工资信息
        //public属性的自动实现，封装了三个信息
        public object this[int index]
        {
            get
            {
                return
                    index == 0 ? TeacherID :
                    index == 1 ? Name :
                    index == 2 ? Wage : null as object;
            }
            set
            {
                if (index == 0)
                    Name = (string)value;
                else if (index == 1)
                    TeacherID = (int)value;
                else if (index == 2)
                    Wage = (int)value;
                //可以使用索引器写该类中封装的这三个信息
            }
        }
        public virtual void PrintInfor()
        {
            //定义函数PrintInfor，用于输出封装的三个信息
            Console.WriteLine("{0}\t{1}\t{2}", TeacherID, Name, Wage);
        }

        public int CompareTo(object obj)
        {
            Teacher teacher = obj as Teacher;
            return teacher.Wage - Wage;
        }
    }
}
