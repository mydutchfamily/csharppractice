using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhoneClT2.Enums;
using MobilePhoneClT2.Interfaces.Markers;

namespace MobilePhoneClT2.Implementation
{
    public class Memory:IComponent
    {
        private Dictionary<string, object> memory;

        public Memory(string serialNumber)
        {
            memory = new Dictionary<string, object>();
            SerialNumber = serialNumber;
        }

        public ComponentTypes ComponentType
        {
            get;
        } = ComponentTypes.Memory;

        public string SerialNumber
        {
            get; private set;
        }

        public void Add<T>(ICollection<T> collectionToAdd) where T : class, IMemory
        {
            memory.Add(typeof(T).Name, collectionToAdd);
        }

        public void Add<T>(params T[] itemsToAdd) where T : class, IMemory
        {
            object obj;
            if (memory.TryGetValue(typeof(T).Name, out obj))
            {
                var castedObj = (ICollection<T>)obj;
                foreach (var item in itemsToAdd)
                {
                    castedObj.Add(item);
                }                
            }
            else
                throw new Exception("Memory is not allocated for " + typeof(T).Name);
        }

        public ICollection<T> Get<T>() where T : class, IMemory
        {
            object obj;
            if (memory.TryGetValue(typeof(T).Name, out obj))
                return (ICollection<T>)obj;
            else
                return null;
        }
        public override string ToString()
        {
            return $"{nameof(Memory)} with serial number {SerialNumber}";
        }
    }
}
