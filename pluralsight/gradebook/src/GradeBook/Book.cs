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

        public void AddLetterGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }
        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                System.Console.WriteLine("Invalid grade");

            }

        }

        public void ShowStat()
        {
            var stat = GetStat();

            Console.WriteLine($"The average grade is :{stat.Average:N1}");
            Console.WriteLine($"The min grade is :{stat.Low}");
            Console.WriteLine($"The max grade is :{stat.High}");
            Console.WriteLine($"The letter of grade is :{stat.Grade}");
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

            switch (stat.Average)
            {
                case var d when d >= 90.0:
                    stat.Grade = 'A';
                    break;

                case var d when d >= 80.0:
                    stat.Grade = 'B';
                    break;

                case var d when d >= 70.0:
                    stat.Grade = 'C';
                    break;

                case var d when d >= 60.0:
                    stat.Grade = 'E';
                    break;

                default:
                    stat.Grade = 'F';
                    break;

            }

            return stat;
        }
    }
}