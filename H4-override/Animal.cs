using System;
/*
 * 1、创建类Animal ----- √
 * 成员变量：name；虚函数PrintSelf ----- √
 */
namespace H4_override
{
    class Animal
    //创建类Animal
    {
        private string name;
        //成员变量：name
        internal string Name
        {
            get
            {
                return name;
            }
        }
        internal Animal(string name)
        {
            this.name = name;
        }
        internal virtual void PrintSelf()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(name);
        }
        //虚函数PrintSelf
    }
}
