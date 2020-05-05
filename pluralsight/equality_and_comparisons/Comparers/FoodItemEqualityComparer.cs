using FoodEquals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparers
{
    class FoodItemEqualityComparer : EqualityComparer<FoodItem>
    {
        private static readonly FoodItemEqualityComparer _instance = new FoodItemEqualityComparer();

        public static FoodItemEqualityComparer Instance { get { return _instance; } }

        private FoodItemEqualityComparer() { }// get singletone
        public override bool Equals(FoodItem x, FoodItem y)
        {
            // null check need to be added for sealed class
            return x.Name.ToUpperInvariant() == y.Name.ToUpperInvariant()
                && x.Group == y.Group;
        }

        public override int GetHashCode(FoodItem obj)
        {
            return obj.Name.ToUpperInvariant().GetHashCode() ^ obj.Group.GetHashCode();
        }
    }
}
