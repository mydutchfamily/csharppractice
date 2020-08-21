using FoodEquals;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr5 = { "apple", "orange", "pineapple" };
            string[] arr6 = { "apple", "pear", "Pineapple" };// arrays structurally equal

            var arrayComp = (IStructuralComparable)arr5;// interface implemented explicitly, so need to be casted
            int structComp = arrayComp.CompareTo(arr6, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine(structComp);

            Console.WriteLine("*********************************************");

            string[] arr3 = { "apple", "orange", "pineapple" };
            string[] arr4 = { "apple", "orange", "Pineapple" };// arrays structurally equal

            var arrayEq = (IStructuralEquatable)arr3;// interface implemented explicitly, so need to be casted
            bool structEqual = arrayEq.Equals(arr4, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine(structEqual);

            Console.WriteLine("*********************************************");

            string[] arr1 = { "apple", "orange", "pineapple" };
            string[] arr2 = { "apple", "orange", "pineapple" };// arrays structurally equal

            Console.WriteLine(arr1 == arr2);
            Console.WriteLine(arr1.Equals(arr2));

            Console.WriteLine("*********************************************");

            FoodItem beetroot = new FoodItem("beetroot", FoodGroup.Vegetables);
            FoodItem pickledBeetroot = new FoodItem("beetroot", FoodGroup.Sweets);

            var eqComparer = FoodNameEqualityComparer.Instance;
            bool equals = eqComparer.Equals(beetroot, pickledBeetroot);

            Console.WriteLine("Equals?" + equals.ToString());
            Console.WriteLine(eqComparer.GetHashCode(beetroot));
            Console.WriteLine(eqComparer.GetHashCode(pickledBeetroot));


            Console.WriteLine("*********************************************");

            var names1 = new HashSet<string>(StringComparer.CurrentCultureIgnoreCase) { "apple", "pear", "pineapple", "Apple" };

            foreach (var item in names1)
            {
                Console.WriteLine(item);
            }


            var names = new HashSet<string>() { "apple", "pear", "pineapple", "Apple"};

            foreach (var item in names)
            {
                Console.WriteLine(item);// with 2 apples
            }

            Console.WriteLine("*********************************************");

            var foodItems2 = new HashSet<FoodItem>(EqualityComparer<FoodItem>.Default);
            foodItems2.Add(new FoodItem("apple", FoodGroup.Fruit));
            foodItems2.Add(new FoodItem("pear", FoodGroup.Fruit));
            foodItems2.Add(new FoodItem("pineapple", FoodGroup.Fruit));
            foodItems2.Add(new FoodItem("Apple", FoodGroup.Fruit));

            foreach (var item in foodItems2)
            {
                Console.WriteLine(item);// no second Apple
            }

            Console.WriteLine("*********************************************");

            var foodItems1 = new HashSet<FoodItem>(FoodItemEqualityComparer.Instance);
            foodItems1.Add(new FoodItem("apple", FoodGroup.Fruit));
            foodItems1.Add(new FoodItem("pear", FoodGroup.Fruit));
            foodItems1.Add(new FoodItem("pineapple", FoodGroup.Fruit));
            foodItems1.Add(new FoodItem("Apple", FoodGroup.Fruit));

            foreach (var item in foodItems1)
            {
                Console.WriteLine(item);// no second Apple
            }

            Console.WriteLine("*********************************************");

            var foodItems = new HashSet<FoodItem>();
            foodItems.Add(new FoodItem("apple", FoodGroup.Fruit));
            foodItems.Add(new FoodItem("pear",FoodGroup.Fruit));
            foodItems.Add(new FoodItem("pineapple",FoodGroup.Fruit));
            foodItems.Add(new FoodItem("Apple",FoodGroup.Fruit));

            foreach (var item in foodItems)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("*********************************************");

            Food[] list1 = {
                new Food("apple", FoodGroup.Fruit),
                new Food("pear", FoodGroup.Fruit),
                new CookedFood("baked", "apple", FoodGroup.Fruit)// only name used for comparison
            };

            SortAndShowList(list1);

            Food[] list2 = {
                new CookedFood("baked", "apple", FoodGroup.Fruit),
                new Food("pear", FoodGroup.Fruit),
                new Food("apple", FoodGroup.Fruit)
            };

            SortAndShowList(list2);

            Console.WriteLine("*********************************************");

            Food[] list = {
                new Food("orange", FoodGroup.Fruit),
                new Food("banana", FoodGroup.Fruit),
                new Food("pear", FoodGroup.Fruit),
                new Food("apple", FoodGroup.Fruit)
            };


            Array.Sort(list, FoodNameComparer.Instance);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("*********************************************");



            Array.Sort(list, new FoodNameIComparer());

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        static void SortAndShowList(Food[] arr)
        {
            Array.Sort(arr, FoodNameComparer.Instance);

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
