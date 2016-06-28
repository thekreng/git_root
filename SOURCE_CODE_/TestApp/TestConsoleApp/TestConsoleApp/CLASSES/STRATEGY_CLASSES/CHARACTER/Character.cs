using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestConsoleApp
{
    public abstract class Character
    {
        public Character()
        {
            this.weaponBehavior = new DefaultBehavior();
        }
        protected WeaponBehavior weaponBehavior;
        public  void fight()
        {
            weaponBehavior.useWeapon();
        }

        public void setWeapon(WeaponBehavior wb)
        {
            this.weaponBehavior = wb;
        }
    }
}