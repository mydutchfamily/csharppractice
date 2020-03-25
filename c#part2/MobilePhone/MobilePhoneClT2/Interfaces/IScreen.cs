using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneClT2
{
    public struct Resolution
    {
        public int x;
        public int y;
    }

    interface IScreen: IComponent
    {
        string Type { get; }

        Resolution Resolution { get;}
    }
}
