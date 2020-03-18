using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhoneT1.Interfaces;
using MobilePhoneT1.Implementation;

namespace MobilePhoneT1
{
    class Program
    {
        static void Main(string[] args)
        {
            IPhone phone = new Phone("Bar", "BP20200225");

            phone.SimCard = "Sim";

            Console.WriteLine(phone);

            IPhone gamePhone = new GamePhone("Bar", "BP20200318");

            Console.WriteLine(gamePhone);
        }
    }
}
