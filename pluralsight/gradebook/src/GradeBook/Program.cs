using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("My grade book");
            var grade = 0.0;
            var input = "";
            Console.WriteLine("Enter grade(s) from 0 to 100 or else for exit: ");
            do
            {
                input = Console.ReadLine();
                try
                {
                    if (double.TryParse(input, out grade))
                    {
                        book.AddGrade(grade);
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);
                    //throw; 
                }
            } while (true);

            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);

            book.ShowStat();
        }
    }
}
