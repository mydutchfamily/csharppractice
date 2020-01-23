using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {

        static void OnGradeAdded(object sender, EventArgs e){
                System.Console.WriteLine("A grade was added");
        }
        static void Main(string[] args)
        {
            var book = new InMemoryBook("My grade book");
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;
            book.GradeAdded += OnGradeAdded;

            EnterGrade(book);

            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);

            book.ShowStat();
        }

        private static void EnterGrade(IBook book)
        {
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
                catch (ArgumentException e)
                {
                    System.Console.WriteLine(e.Message);
                    //throw; 
                }
                catch (FormatException e)
                {
                    System.Console.WriteLine(e.Message);
                    //throw; 
                }
                finally
                {
                    System.Console.WriteLine("****");
                }
            } while (true);
        }
    }
}
