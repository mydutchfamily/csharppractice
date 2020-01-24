using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{

    public class DiskBook : Book
    {

        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                //because of "using" no need to execute - writer.Close();

                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Stat GetStat()
        {

            var grades = new List<double>();
            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    line = reader.ReadLine();
                    grades.Add(number);
                }
            }
            var result = new Stat(grades);
            result.Calc();
            return result;
        }

        public void ShowStat()
        {
            var stat = GetStat();

            Console.WriteLine($"The average grade is :{stat.Average:N1}");
            Console.WriteLine($"The min grade is :{stat.Low}");
            Console.WriteLine($"The max grade is :{stat.High}");
            Console.WriteLine($"The letter of grade is :{stat.Grade}");
        }
    }

}