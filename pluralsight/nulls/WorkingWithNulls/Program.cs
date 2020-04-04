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

            Console.WriteLine("**********************************************");

            PlayerCharacter sarah = new PlayerCharacter(new DiamondSkinDefence()) { Name = "Sarah"};
            PlayerCharacter amrit = new PlayerCharacter(new IronBonesDefence()) { Name = "Amrit" };
            PlayerCharacter gentry = new PlayerCharacter((ISpecialDefence)null) { Name = "Gentry" };

            sarah.Hit1(10);
            amrit.Hit1(10);
            gentry.Hit1(10);

            Console.WriteLine("**********************************************");

            PlayerCharacter nullgentry = new PlayerCharacter(new NullDefence()) { Name = "NullGentry" };

            nullgentry.Hit2(10);

            Console.WriteLine("**********************************************");

            PlayerCharacter absgentry = new PlayerCharacter(new AbstractDefence()) { Name = "AbsGentry" };

            absgentry.Hit3(10);

            Console.WriteLine("**********************************************");

            PlayerCharacter singletongentry = new PlayerCharacter(SpecialDefence.Null) { Name = "SingletonGentry" };

            singletongentry.Hit3(10);
        }
    }
}
