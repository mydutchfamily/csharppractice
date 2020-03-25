using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneClT2
{
    interface IKeyboard: IComponent
    {
        List<string> Languages { get;}
        List<IComponent> KeyboardComponents { get;}
    }
}
