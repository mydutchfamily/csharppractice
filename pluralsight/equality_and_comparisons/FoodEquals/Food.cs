using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEquals
{
    public class Food
    {
        private string _name;
        public string Name { get { return _name; } }

        public Food(string name)
        {
            this._name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }

    public struct FoodStruct
    {
        private string _name;
        public string Name { get { return _name; } }

        public FoodStruct(string name)
        {
            this._name = name;
        }

        public override string ToString()
        {
            return _name;
        }

        //public static bool operator ==(FoodStruct x, FoodStruct y) {

        //}
    }

    public enum FoodGroup {Meat, Fruit, Vegetables, Sweets }

    public struct FoodItem: IEquatable<FoodItem>
    {
        private readonly string _name;
        private readonly FoodGroup _group;

        public string Name { get { return _name; } }

        public FoodGroup Group { get { return _group; } }

        public FoodItem(string name, FoodGroup group)
        {
            this._name = name;
            this._group = group;
        }

        public override string ToString()
        {
            return _name;
        }

        public bool Equals(FoodItem other)
        {
            return this._name == other._name && this._group == other._group;//== does value comp for string and enum
        }

        public override bool Equals(object obj)
        {
            if (obj is FoodItem)
                return Equals((FoodItem)obj);
            else return false;
        }

        public static bool operator == (FoodItem lhs, FoodItem rhs)
        {
            return lhs.Equals(rhs);// no need null checking for value types
        }

        public static bool operator !=(FoodItem lhs, FoodItem rhs)
        {
            return !lhs.Equals(rhs);
            //return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            return _name.GetHashCode() ^ _group.GetHashCode();// GetHashCode already impled for .NET types
        }
    }
}
