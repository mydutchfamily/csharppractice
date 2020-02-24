using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneT1
{
    interface IPhone
    {
        List<IComponent> PhoneComponents { get; set;}

        string FormFactor { get;}

        string Operator { get; set;}

        string GetDescription();

    }
}
