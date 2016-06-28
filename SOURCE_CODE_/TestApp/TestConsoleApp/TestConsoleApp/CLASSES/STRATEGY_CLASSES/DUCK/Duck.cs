using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    public interface FlyBehavior
    {
        void fly();
    }
    public interface QuackBehavior
    {
        void quack();
    }
    
    public abstract class Duck
    {
        protected FlyBehavior flyBehavior;
        protected QuackBehavior quackBehavior;

        public Duck() {}
        public abstract void display();
        public void performFly()
        {
            flyBehavior.fly();
        }
        public void performQuack()
        {
            quackBehavior.quack();
        }
        public void swim()
        {
            Console.WriteLine("All ducks can swim");
        }

        public void setFlyBehavior(FlyBehavior fb) {
            flyBehavior = fb;
        }
        public void setQuackBehavior(QuackBehavior qb)
        {
            quackBehavior = qb;
        }
    }
    public class MallardDuck : Duck
    {
        public MallardDuck()
        {
            quackBehavior = new Quack();
            flyBehavior = new FlyWithWings(); 
        }
        public override void display()
        {
            Console.WriteLine("I'm realy Mallard duck");
        }
    }
    public class AnotherDuck : Duck
    {
        public AnotherDuck()
        {
            quackBehavior = new MuteQuack();
            flyBehavior = new FlyNoWay();
        }
        public override void display()
        {
            Console.WriteLine("I'm realy Mallard duck");
        }
    }
    public class ModelDuck : Duck
    {
       public ModelDuck() {
            flyBehavior = new FlyNoWay();
            quackBehavior = new Quack();
        }
        public override void display()
        {
            Console.WriteLine("I'm model duck");
        }
    }
    

    public class FlyWithWings:FlyBehavior
    {
        public void fly()
        {
            Console.WriteLine("I'm flying!!!");
        }

    }
    public class FlyNoWay : FlyBehavior
    {
        public void fly()
        {
            Console.WriteLine("I can't flying!!!");
        }

    }
    public class FlyRocketPowered : FlyBehavior {
        public void fly()
        {
            Console.WriteLine("I'm flying with a rocket");
        }
    }

    public class Quack : QuackBehavior {
        public void quack()
        {
            Console.WriteLine("Quack"); 
        }
    }
    public class MuteQuack : QuackBehavior
    {
        public void quack()
        {
            Console.WriteLine("<<<SILENT>>>");
        }
    }
    public class Squeak : QuackBehavior
    {
        public void quack()
        {
            Console.WriteLine("---Squeak---");
        }
    }
}
