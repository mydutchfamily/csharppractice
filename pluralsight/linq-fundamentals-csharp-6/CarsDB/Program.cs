﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarsDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> add1 = (x, y) => x + y;
            Console.WriteLine(add1);

            Expression<Func<int, int, int>> add2 = (x, y) => x + y;
            Console.WriteLine(add2);
            Console.WriteLine(add2.Compile()(3,5));

            var add3 = add2.Compile();
            Console.WriteLine(add3(5,6));

            Console.WriteLine("*********************************************************");

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarDb>());// force framework recreate db if something has changed
            InsertData();
            QueryData();
        }

        private static void QueryData()
        {
            var db = new CarDb();
            //db.Database.Log = Console.WriteLine; // will print out all sql commands

            var query = from car in db.Cars
                        orderby car.Combined descending, car.Name ascending
                        select car;

            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Name}: {car.Combined}");
            }

            Console.WriteLine("************************************************");

            db.Database.Log = Console.WriteLine; // will print out all sql commands
            var query2 = db.Cars.Where(c => c.Manufacturer == "BMW")
                .OrderByDescending(c => c.Combined).ThenBy(c => c.Name)
                .Take(10);// will build query to take 10

            foreach (var car in query2)
            {
                Console.WriteLine($"{car.Name}: {car.Combined}");
            }

            Console.WriteLine("************************************************");

            db.Database.Log = Console.WriteLine; // will print out all sql commands
            var query3 = db.Cars.Where(c => c.Manufacturer == "BMW")
                .OrderByDescending(c => c.Combined).ThenBy(c => c.Name)
                .ToList()// because of this query all BMW into memory and only then take 10;
                .Take(10);

            foreach (var car in query3)
            {
                Console.WriteLine($"{car.Name}: {car.Combined}");
            }

        }

        private static void InsertData()
        {
            var cars = ProcessCars("fuel.csv");
            var db = new CarDb();// by default will try to connect to local db
            //db.Database.Log = Console.WriteLine; // will print out all sql commands

            if (!db.Cars.Any())
            {
                foreach (var car in cars)
                {
                    db.Cars.Add(car);
                }
                db.SaveChanges();               
            }
        }

        private static List<Car> ProcessCars(string path)
        {
            var query =

                File.ReadAllLines(path)
                    .Skip(1)// first line is header
                    .Where(l => l.Length > 1)// last line is empty
                    .ToCar();

            return query.ToList();
        }


    }
    public static class CarExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');

                yield return new Car// return new Car each time in loop iteration
                {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displacement = double.Parse(columns[3], System.Globalization.CultureInfo.InvariantCulture),
                    Cylinders = int.Parse(columns[4]),
                    City = int.Parse(columns[5]),
                    Highway = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7])
                };
            }
        }
    }
}
