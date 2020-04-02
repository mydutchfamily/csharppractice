using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithNulls
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerCharacter[] players = null;

            string name = players?[0]?.Name;// null conditional operator

            PlayerCharacter player1 = null;

            name = player1?.Name;// null conditional operator


            PlayerCharacter player2 = new PlayerCharacter();
            player2.Name = "  ";

            PlayerDisplayer.Write(player2);
        }
    }
}
