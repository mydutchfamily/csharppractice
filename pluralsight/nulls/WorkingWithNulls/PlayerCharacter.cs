using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithNulls
{
    class PlayerCharacter
    {

        public PlayerCharacter() {
            DaysSinceLastLogin = -1; // magic number
        }
        public string Name{ get; set; }
        public int DaysSinceLastLogin { get; set; }

        public Nullable<DateTime> DateOfBirth{ get; set; } // Nullable<T>

        public int? Age { get; set; } // type?

        public bool? IsNew { get; set; }
    }
}
