using MobilePhoneClT2.Enums;
using System.Collections.Generic;

namespace MobilePhoneT1.Interfaces
{
    interface IPhone:IComponent
    {
        List<IComponent> PhoneComponents { get;}

        FormFactor FormFactor { get;}

        string SimCard { get; set;}

    }
}
