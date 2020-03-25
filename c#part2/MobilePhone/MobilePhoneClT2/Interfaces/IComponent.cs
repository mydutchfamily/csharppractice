using MobilePhoneClT2.Enums;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneClT2
{
    public interface IComponent
    {
        ComponentTypes ComponentType { get; }
        string SerialNumber { get; }
    }
}
