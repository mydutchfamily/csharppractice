using System;
using System.Collections.Generic;

namespace GradeBook
{

    public delegate void GradeAddedDelegate(object sender, EventArgs args);


    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Stat GetStat();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }
        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);
        public abstract Stat GetStat();
    }

    public class InMemoryBook : Book
    {
        private List<double> grades;
        public override event GradeAddedDelegate GradeAdded;
        private string name1;
        public string Name1
        {
            get
            {
                return name1;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name1 = value;
                }
            }
        }

        public const string category = "Science";

        public InMemoryBook(string name) : base(name)
        {
            this.Name = name;
            grades = new List<double>();
        }

        public void AddGrade(char letter)
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
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                //System.Console.WriteLine("Invalid grade");
                throw new ArgumentException($"Invalid {nameof(grade)}");

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

        public override Stat GetStat()
        {
            Stat stat = new Stat(grades);
            stat.Calc();
            return stat;
        }
    }
}