using System;

namespace DaysOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek = {
                "Monday",
                "Tuesday",
                "We*nesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
            foreach (string day in daysOfWeek)
            {
                System.Console.WriteLine(day);
            }

            daysOfWeek[2] = "Wednesday";

            foreach (string day in daysOfWeek)
            {
                System.Console.WriteLine(day);
            }

            System.Console.WriteLine("Which day of week to show? monday 1,...");
            int iDay = int.Parse(Console.ReadLine());

            string dayToShow = daysOfWeek[iDay - 1];
            System.Console.WriteLine($"That day is {dayToShow}");
        }
    }
}
