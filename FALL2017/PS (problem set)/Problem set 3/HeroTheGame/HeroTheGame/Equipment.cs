using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroTheGame
{
    class WeaponSpecialization
    {
        public static int Hash = 0;
        public static int Stab = 1;
        public static int Сut = 2;
        public static int Kibble = 3;
    }

    class WoodenSword
    {
        public int Damage = 1;
        public int Specialization = WeaponSpecialization.Сut;
    }

    class Arrow
    {

    }

    class Crossbow
    {

    }
}