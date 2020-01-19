using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {

        private List<double> grades;
        public string Name;

        public Book(string name)
        {
            this.Name = name;
            grades = new List<double>();
        }
        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else{
System.Console.WriteLine("Invalid grade");

            }

        }

        public void ShowStat()
        {
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


        public Stat GetStat()
        {
            var result = 0.0;
            Stat stat = new Stat();
            var highGrade = double.MinValue;
            var lowestGrade = double.MaxValue;

            foreach (double number in grades)
            {
                result += number;
                highGrade = Math.Max(number, highGrade);
                lowestGrade = Math.Min(number, lowestGrade);
            }

            stat.Average = result / grades.Count;
            stat.High = highGrade;
            stat.Low = lowestGrade;

            return stat;
        }
    }
}