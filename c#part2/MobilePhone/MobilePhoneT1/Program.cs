using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhoneT1.Interfaces;

namespace MobilePhoneT1
{
    class Program
    {
        static void Main(string[] args)
        {
            IPhone phone = PhoneBuilder.BuildSimplePhone("BP20200225");

            phone.Operator = "Sim";

            Console.WriteLine(phone.GetDescription());
        }
    }
}
