using System;
/*
 * 1.创建类Biology ----- √
 * 私有成员变量：name；一个有参数的构造函数 ----- √
 * 保护成员方法(printName)：打印name ----- √
 * 2.创建类Cat，继承于Biology ----- √
 * 私有成员变量：food(食物)；两个构造函数 ----- √
 * 公有成员方法(show)：打印name和food ----- √
 * 3.创建类Tree，继承于Biology ----- √
 * 私有成员变量：age(树龄)；两个构造函数 ----- √
 * 公有成员方法(show)：打印name和age ----- √
 * 4.在主函数中新建对象cat，tree，并调用相应方法 ----- √
 */
namespace H4_inherit
{
    class Biology  //创建类Biology
    {
        private string name;  //私有成员变量：name
        public Biology(string name)  //一个有参数的构造函数
        {
            this.name = name;
        }
        protected void printName()
        {
            Console.WriteLine($"{name}");
        }
    }
    class Cat : Biology  //创建类Cat，继承于Biology
    {
        private string name;
        private string food;  //私有成员变量：food(食物)
        public Cat(string name) : base(name)
        {
            this.name = name;  //两个构造函数 - 第一个
        }
        public Cat(string name, string food) : base(name)
        {
            this.name = name;  //两个构造函数 - 第二个
            this.food = food;
        }
        public void Show()  //公有成员方法(show)：打印name和food
                            //首字母大写符合规范，老师认可改写法不扣分
        {
            Console.WriteLine("━━━━━━━━━━━");
            Console.WriteLine("Name\t\tFood");
            Console.WriteLine($"{name}\t\t{food}");
            Console.WriteLine("━━━━━━━━━━━");
        }
    }
    class Tree : Biology  //创建类Tree，继承于Biology
    {
        private string name;
        private int age;
        public Tree(string name) : base(name)
        {
            this.name = name;  //两个构造函数 - 第一个
        }
        public Tree(string name, int age) : base(name)
        {
            this.name = name;  //两个构造函数 - 第二个
            this.age = age;
        }
        public void Show()  //公有成员方法(show)：打印name和age
                            //首字母大写符合规范，老师认可改写法不扣分
        {
            Console.WriteLine("Name\t\tAge");
            Console.WriteLine($"{name}\t{age}");
            Console.WriteLine("━━━━━━━━━━━");
        }
    }
    class Program
    {
        static void Main()  //在主函数中新建对象cat，tree
        {
            Cat cat = new Cat("Tom", "Tuna");
            cat.Show();  //并调用相应方法

            Tree tree = new Tree("Delonix regia", 7);
            tree.Show();  //并调用相应方法

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
