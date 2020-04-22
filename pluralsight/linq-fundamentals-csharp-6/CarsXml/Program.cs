using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarsXml
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateXml();
            QueryXml();

        }
        private static void QueryXml()
        {
            var document = XDocument.Load("fuel4.xml");

            var query = from element in document.Element("Cars").Elements("Car")
                        where element.Attribute("Manufacturer").Value == "BMW"
                        select element.Attribute("Name").Value;

            foreach (var name in query)
            {
                Console.WriteLine(name);
            }
        }

        private static void CreateXml()
        {
            var records = ProcessCars("fuel.csv");

            //***************************************************************
            /*
             <?xml version="1.0" encoding="UTF-8"?>
                
                -<Cars>             
                
                     -<Car>
                     
                     <Name>4C</Name>
                     
                     <Combined>28</Combined>
                     
                     </Car> 
            */

            var document1 = new XDocument();
            var cars1 = new XElement("Cars");

            foreach (var record in records)
            {
                var car = new XElement("Car");
                var name = new XElement("Name", record.Name);
                var combined = new XElement("Combined", record.Combined);

                car.Add(name);
                car.Add(combined);

                cars1.Add(car);
            }

            document1.Add(cars1);
            document1.Save("fuel1.xml");

            //***************************************************************
            /*
                -<Cars>
                
                <Car Combined="28" Name="4C"/>             
             */
            var document2 = new XDocument();
            var cars2 = new XElement("Cars");

            foreach (var record in records)
            {
                var car = new XElement("Car");
                var name = new XAttribute("Name", record.Name);
                var combined = new XAttribute("Combined", record.Combined);

                car.Add(name);
                car.Add(combined);

                cars2.Add(car);
            }

            document2.Add(cars2);
            document2.Save("fuel2.xml");

            //***************************************************************
            /*
                -<Cars>
                
                <Car Combined="28" Name="4C"/>             
             */
            var document3 = new XDocument();
            var cars3 = new XElement("Cars");

            foreach (var record in records)
            {
                var combined = new XAttribute("Combined", record.Combined);
                var name = new XAttribute("Name", record.Name);
                var car = new XElement("Car", name, combined,
                    new XAttribute("Manufacturer", record.Manufacturer));

                cars3.Add(car);
            }

            document3.Add(cars3);
            document3.Save("fuel3.xml");

            //***************************************************************
            /*
                -<Cars>
                
                <Car Combined="28" Name="4C"/>             
             */
            var document4 = new XDocument();
            var cars4 = new XElement("Cars");

            var elements = from record in records
                           select new XElement("Car",
                           new XAttribute("Name", record.Name),
                           new XAttribute("Combined", record.Combined),
                            new XAttribute("Manufacturer", record.Manufacturer));

            cars4.Add(elements);
            document4.Add(cars4);
            document4.Save("fuel4.xml");
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

        private static List<Manufacturer> ProcessManufacturers(string path)
        {
            var query =
                   File.ReadAllLines(path)
                       .Where(l => l.Length > 1)
                       .Select(l =>
                       {
                           var columns = l.Split(',');
                           return new Manufacturer
                           {
                               Name = columns[0],
                               Headquarters = columns[1],
                               Year = int.Parse(columns[2])
                           };
                       });
            return query.ToList();
        }
    }

    public class CarStatistics
    {
        public CarStatistics()
        {
            Max = Int32.MinValue;
            Min = Int32.MaxValue;
        }
        
        public CarStatistics Accumulate(Car car)
        {
            Count += 1;
            Total += car.Combined;
            Max = Math.Max(Max, car.Combined);
            Min = Math.Min(Min, car.Combined);
            return this;
        }

        public CarStatistics Compute()
        {
            Average = Total / Count;
            return this;
        }

        public int Max { get; set; }
        public int Min { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }
        public double Average { get; set; }

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
