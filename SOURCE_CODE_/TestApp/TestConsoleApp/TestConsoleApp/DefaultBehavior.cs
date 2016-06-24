using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestConsoleApp
{
    public class DefaultBehavior:WeaponBehavior
    {
        public void useWeapon()
        {
            Console.WriteLine("I have nothing!!!");
        }
    }
}