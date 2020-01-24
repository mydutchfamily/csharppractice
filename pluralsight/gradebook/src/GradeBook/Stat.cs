using System;
using System.Collections.Generic;

namespace GradeBook{

public class Stat{
    public double Average;
    public double High;
    public double Low;

    public double result;
    public char Grade;

    private List<double> grades;

        public Stat()
        {
        }

        public Stat(List<double> grades){
        this.grades = grades;
    }

    public void Calc(){
            var result = 0.0;
            var highGrade = double.MinValue;
            var lowestGrade = double.MaxValue;

            foreach (double number in grades)
            {
                result += number;
                highGrade = Math.Max(number, highGrade);
                lowestGrade = Math.Min(number, lowestGrade);
            }

            this.Average = result / grades.Count;
            this.High = highGrade;
            this.Low = lowestGrade;

            switch (this.Average)
            {
                case var d when d >= 90.0:
                    this.Grade = 'A';
                    break;

                case var d when d >= 80.0:
                    this.Grade = 'B';
                    break;

                case var d when d >= 70.0:
                    this.Grade = 'C';
                    break;

                case var d when d >= 60.0:
                    this.Grade = 'E';
                    break;

                default:
                    this.Grade = 'F';
                    break;

            }

    }
}
}