﻿using MobilePhoneClT2.Enums;
using MobilePhoneClT2.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MobilePhoneClT2.AbstractClass
{
    public abstract class InterconnectionCommon : IInterconnection
    {
        protected Plugins vPluginToUse;
        protected List<Plugins> vSupportedPlugins;
        protected static object syncRoot = new object();

        public abstract ComponentTypes ComponentType { get; }
        public string SerialNumber { get; }

        public InterconnectionCommon(string serialNumber)
        {
            SerialNumber = serialNumber;
        }
        public virtual async Task DoAction(int? executeTimes = null)
        {
            await Task.Run(()=> { Action?.Invoke(0); });
        }
        public Plugins PluginToUse
        {
            get
            {
                return vPluginToUse;
            }

            set
            {
                if (vSupportedPlugins.Contains(value))
                { vPluginToUse = value; }
                else
                {
                    throw new NotImplementedException("Not supported type of connection");
                }
            }
        }

        public List<Plugins> SupportedPlugins
        {
            get
            {
                return vSupportedPlugins.GetRange(0, vSupportedPlugins.Count);
            }
        }

        public Action<int> Action {get; set;}
    }
}
