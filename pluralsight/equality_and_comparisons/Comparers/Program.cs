﻿using FoodEquals;
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
    }
}
