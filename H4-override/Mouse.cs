using System;
/*
 * 3、创建类Mouse，继承于Animal ----- √
 * 成员变量：weight；函数PrintSelf：打印name和weight ----- √
 */
namespace H4_override
{
    class Mouse : Animal
    //创建类Mouse，继承于Animal
    {
        private int weight;
        //成员变量：weight
        internal int Weight
        {
            get
            {
                return weight;
            }
        }
        internal Mouse(string name, int weight) : base(name)
        {
            this.weight = weight;
        }
        internal override void PrintSelf()
        {
            base.PrintSelf();
            Console.WriteLine("\t" + weight + " grams");
        }
        //函数PrintSelf：打印name和weight
    }
}
