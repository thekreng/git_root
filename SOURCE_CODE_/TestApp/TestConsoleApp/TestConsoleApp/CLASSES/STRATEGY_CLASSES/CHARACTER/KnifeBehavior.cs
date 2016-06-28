using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestConsoleApp
{
    public class KnifeBehavior:WeaponBehavior
    {
        public void useWeapon()
        {
            Console.WriteLine("I've knife");
        }
    }
}