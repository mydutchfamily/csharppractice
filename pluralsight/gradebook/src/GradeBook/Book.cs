using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {
        public Book()
        {
            grades = new List<double>();
        }

        List<double> grades;
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }
    }
}