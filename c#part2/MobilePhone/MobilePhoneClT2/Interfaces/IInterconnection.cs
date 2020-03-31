﻿using MobilePhoneClT2.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneClT2.Interfaces
{
    public interface IInterconnection: IComponent
    {
        Boolean DoAction(object data = null);
        Plugins PluginToUse { get; set; }

        List<Plugins> SupportedPlugins { get; }
    }
}