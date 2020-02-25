using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneT1
{
    public interface IComponent
    {
        string ComponentType { get; }
        string SerialNumber { get; }
        string GetDescription();
    }
}
