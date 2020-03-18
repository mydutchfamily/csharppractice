using System.Collections.Generic;

namespace MobilePhoneT1.Interfaces
{
    interface IPhone:IComponent
    {
        List<IComponent> PhoneComponents { get;}

        string FormFactor { get;}

        string SimCard { get; set;}

    }
}
