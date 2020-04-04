using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithNulls
{
    class PlayerCharacter
    {
        private readonly ISpecialDefence _specialDefence;
        private readonly SpecialDefence _absspecialDefence;

        public PlayerCharacter(ISpecialDefence specialDefence) {
            _specialDefence = specialDefence;
        }

        public PlayerCharacter(SpecialDefence specialDefence)
        {
            _absspecialDefence = specialDefence;
        }
        public PlayerCharacter() {
            DaysSinceLastLogin = -1; // magic number
        }
        public string Name{ get; set; }
        public int DaysSinceLastLogin { get; set; }

        public Nullable<DateTime> DateOfBirth{ get; set; } // Nullable<T>

        public int? Age { get; set; } // type?

        public bool? IsNew { get; set; }

        public int Health { get; set; } = 100;

        public void Hit1(int damage)
        {
            int damageReduction = 0;

            if (_specialDefence != null)
            {
                damageReduction = _specialDefence.CalculateDamageReduction(damage);
            }

            int totalDamageTaken = damage - damageReduction;

            Health -= totalDamageTaken;

            Console.WriteLine($"{Name}'s health has been reduced by {totalDamageTaken} to {Health}.");

        }

        public void Hit2(int damage)
        {
            int totalDamageTaken = damage - _specialDefence.CalculateDamageReduction(damage);

            Health -= totalDamageTaken;

            Console.WriteLine($"{Name}'s health has been reduced by {totalDamageTaken} to {Health}.");

        }

        public void Hit3(int damage)
        {
            int totalDamageTaken = damage - _absspecialDefence.CalculateDamageReduction(damage);

            Health -= totalDamageTaken;

            Console.WriteLine($"{Name}'s health has been reduced by {totalDamageTaken} to {Health}.");

        }
    }
}
