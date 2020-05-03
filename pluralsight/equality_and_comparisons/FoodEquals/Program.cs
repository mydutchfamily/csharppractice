using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEquals
{
    class Program
    {
        static void Main(string[] args)
        {
            Food banana = new Food("banana");
            Food banana2 = new Food("banana");

            Food chocolate = new Food("chocolate");

            Console.WriteLine(banana.Equals(chocolate));
            Console.WriteLine(banana.Equals(banana2));// virtual object.Equals()
            Console.WriteLine(object.Equals(banana, banana2));// static object.Equals() - if one of the objects is null
            Console.WriteLine(object.ReferenceEquals(banana, banana2));// ALWAYS check reference to same instance

            Console.WriteLine("********************************************");

            FoodStruct bananas = new FoodStruct("banana");
            FoodStruct bananas2 = new FoodStruct("banana");

            Console.WriteLine(bananas.Equals(bananas2));

            Console.ReadLine();
        }
    }
}
