using FoodEquals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparers
{
    public class FoodNameEqualityComparer : EqualityComparer<FoodItem> {

        private static readonly FoodNameEqualityComparer _instance = new FoodNameEqualityComparer();

        public static FoodNameEqualityComparer Instance { get { return _instance; } }

        private FoodNameEqualityComparer() { }

        public override bool Equals(FoodItem x, FoodItem y)
        {
            return x.Name == y.Name;
        }

        public override int GetHashCode(FoodItem obj)
        {
            return obj.Name.GetHashCode();// ^ obj.Group.GetHashCode(); - field not used in Equals should not be used in hash code
        }
    }

    

}
