using System.Collections.Generic;

namespace MobilePhoneT1.Interfaces
{
    interface IPhone:IComponent
    {
        List<IComponent> PhoneComponents { get; set;}

        string FormFactor { get;}

        string Operator { get; set;}

    }
}
