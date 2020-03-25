using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneT2
{
    struct Resolution
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
