using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneT1
{
    class Program
    {
        static void Main(string[] args)
        {
            IPhone phone = PhoneBuilder.BuildSimplePhone();

            phone.Operator = "Sim";

            Console.WriteLine(phone.GetDescription());
        }
    }
}
