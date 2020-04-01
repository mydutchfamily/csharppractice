using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithNulls
{
    class PlayerDisplayer
    {
        public static void Write(PlayerCharacter player)
        {
            if (string.IsNullOrWhiteSpace(player.Name)) {
                Console.WriteLine("Player name is null or all whitespace");
            }else
            {
                Console.WriteLine(player.Name);
            }

            if (player.DaysSinceLastLogin == -1)
            {
                Console.WriteLine($"No value for {nameof(player.DaysSinceLastLogin)}");
            }
            else { Console.WriteLine(player.DaysSinceLastLogin); }

            if (player.DateOfBirth == null)
            {
                Console.WriteLine($"No value for {nameof(player.DateOfBirth)}");
            }
            else { Console.WriteLine(player.DateOfBirth); }

            if (player.Age == null)
            {
                Console.WriteLine($"No value for {nameof(player.Age)}");
            }
            else { Console.WriteLine(player.Age); }

            if (player.IsNew == null)
            {
                Console.WriteLine("Player status is unknown");
            }
            else if (player.IsNew == true) { Console.WriteLine("Player is new"); }
            else { Console.WriteLine("Player is experienced."); }

        }
    }
}
