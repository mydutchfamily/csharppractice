using MobilePhoneClT2.Enums;
using MobilePhoneClT2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneClT2.AbstractClass
{
    public abstract class InterconnectionCommon : IInterconnection
    {
        protected Plugins vPluginToUse;
        protected List<Plugins> vSupportedPlugins;

        public abstract ComponentTypes ComponentType { get; }
        public abstract string SerialNumber { get; }
        public abstract Boolean DoAction(object data = null);
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

    }
}
