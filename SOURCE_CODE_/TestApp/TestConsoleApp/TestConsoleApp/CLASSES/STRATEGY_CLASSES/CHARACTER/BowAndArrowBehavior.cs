using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestConsoleApp
{
    public class BowAndArrowBehavior:WeaponBehavior
    {
        public void useWeapon()
        {
            Console.WriteLine("I've Bow and Arrow");
        }
    }
}