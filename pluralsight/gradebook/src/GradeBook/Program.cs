using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("My grade book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);

            var grades = new List<double>() { 12.7, 10.3, 6.11 };
            var result = 0.0;
            var highGrade = double.MinValue;
            var lowestGrade = double.MaxValue;

            foreach (double number in grades)
            {
                result += number;
                highGrade = Math.Max(number, highGrade);
                lowestGrade = Math.Min(number, lowestGrade);
            }

            var avarage = result / grades.Count;

            Console.WriteLine($"The average grade is :{avarage:N1}");
            Console.WriteLine($"The min grade is :{lowestGrade}");
            Console.WriteLine($"The max grade is :{highGrade}");
            Console.WriteLine($"The sum of grade is :{result}");
        }
    }
}
