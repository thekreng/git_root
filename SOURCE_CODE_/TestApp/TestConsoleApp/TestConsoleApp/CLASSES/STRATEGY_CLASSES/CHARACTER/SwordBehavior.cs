using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestConsoleApp
{
    public class SwordBehavior : WeaponBehavior
    {
        public void useWeapon()
        {
            Console.WriteLine("I've SWORD");
        }
    }
}