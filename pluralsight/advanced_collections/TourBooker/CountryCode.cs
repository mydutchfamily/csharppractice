using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourBooker
{
    public class CountryCode
    {
        public string Value { get; }
        public CountryCode(string value)
        {
            Value = value;
        }
        public override string ToString() => Value;

        public override bool Equals(object other)
        {
            if(other is CountryCode)
                return StringComparer.OrdinalIgnoreCase.Equals(this.Value, ((CountryCode)other).Value);
            return false;
        }

        public static bool operator ==(CountryCode lhs, CountryCode rhs) {
            if (lhs != null)
                return lhs.Equals(rhs);
            else return rhs == null;
        }

        public static bool operator !=(CountryCode lhs, CountryCode rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode() {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(this.Value);
        }

    }
}
