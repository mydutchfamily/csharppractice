using FoodEquals;
using System;
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
