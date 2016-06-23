using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Duck mallard = new MallardDuck();
            Duck anotherDuck = new AnotherDuck();
            mallard.performQuack();
            mallard.performFly();
            anotherDuck.performQuack();
            anotherDuck.performFly();
            Console.Read();
        }
    }
}
