using FoodEquals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparers
{
    class FoodNameIComparer : IComparer<Food>
    {
        public int Compare(Food x, Food y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            return string.Compare(x.Name, y.Name, StringComparison.CurrentCulture);
        }
    }

    class FoodNameComparer : Comparer<Food>
    {
        private static FoodNameComparer _instance = new FoodNameComparer();

        public static FoodNameComparer Instance { get { return _instance; } }// one instance is enough

        private FoodNameComparer() { }// hide constructor;
        public override int Compare(Food x, Food y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            int nameOrder = string.Compare(x.Name, y.Name, StringComparison.CurrentCulture);

            if (nameOrder != 0)
                return nameOrder;// names are different

            // names are the same, order by groups
            return string.Compare(x.Group.ToString(), y.Group.ToString(), StringComparison.CurrentCulture);
            // but we still missing fields from child class CookedFood - cookingMethod 
        }
    }
}
