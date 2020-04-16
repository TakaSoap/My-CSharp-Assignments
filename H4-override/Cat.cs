using System;
/*
 * 2、创建类Cat，继承于Animal ----- √
 * 成员变量：color；函数PrintSelf：打印name和color ----- √
 */
namespace H4_override
{
    class Cat : Animal
    //创建类Cat，继承于Animal
    {
        private string color;
        //成员变量：color
        internal string Color
        {
            get
            {
                return color;
            }
        }
        private ConsoleColor consoleColor;
        internal Cat(string name, string color) : base(name)
        {
            this.color = color;
            consoleColor = color
                == "GoldEnrod" ? ConsoleColor.DarkYellow : color == "LemonChiffon" ? ConsoleColor.Yellow : ConsoleColor.Gray;
        }
        internal override void PrintSelf()
        {
            base.PrintSelf();
            Console.ForegroundColor = consoleColor;
            Console.WriteLine("\t" + color);
        }
        //函数PrintSelf：打印name和color
    }
}
