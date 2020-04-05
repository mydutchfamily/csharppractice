using System;
using System.Collections.Generic;

namespace CS8NullBasics
{
    class Program
    {

        public static void LogNonNullable1<T>(T value){ 
        
        }

        public static void LogNonNullable2<T>(T value) where T : class?
        {

        }

        public static void LogNonNullable3<T>(T value) where T : class
        {

        }
        static void Main(string[] args)
        {
            //#nullable enable // could be specified ANY where in the file, to show warning
            string message = null;
            Console.WriteLine(message);

            string? message3 = null; // now it is possible to use null
            Console.WriteLine(message3);

            //#nullable disable//  optional part

            string message2 = null; // will be covered by tag <Nullable>enable</Nullable> in *.csproj file, seems does not work with #nullable
            Console.WriteLine(message2);

            Console.WriteLine("Press enter to end.");

            Console.WriteLine("*************************************************************");

            Message message4 = new Message();

            Console.WriteLine(message4.Text);
            Console.WriteLine(message4.From1);
            Console.WriteLine(message4.ToUpperFrom1());

            Console.WriteLine("*************************************************************");

            Message message5 = new Message() { Text = "Hello there", From1 = null };
            try
            {
                Console.WriteLine(message5.Text);
                Console.WriteLine(message5.From1);
                Console.WriteLine(message5.ToUpperFrom1());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.WriteLine("*************************************************************");

            Message message6 = new Message() { Text = "Hello there", From2 = null };

            Console.WriteLine(message6.Text);
            Console.WriteLine(message6.From2);
            Console.WriteLine(message6.ToUpperFrom1());

            Console.WriteLine("*************************************************************");

            Message message7 = new Message() { Text = "Hello there", From3 = null };

            Console.WriteLine(message7.Text);
            Console.WriteLine(message7.From3 ?? "no from");
            //Console.WriteLine(message7.From3!.Length);
            Console.WriteLine(message7.ToUpperFrom1());

            Console.WriteLine("*************************************************************");

            Message message8 = new Message() { Text = "Hello there", From3 = null };

            MessagePopulator.Populate3(message8);

            Console.WriteLine(message8.Text);
            Console.WriteLine(message8.From3);
            Console.WriteLine(message8.From3!.Length);// "!" null-forgiving operator, will suppress warning, but NOT fix null poiter reference exception!!!!
            Console.WriteLine(message8.ToUpperFrom1());

            Console.WriteLine("*************************************************************");

            Message? nullMessage = null;

            Message nonNullMessage = new Message();

            List<Message> m1 = new List<Message>();

            m1.Add(nullMessage);// warning
            m1.Add(nonNullMessage);// ok

            List<Message?> m2 = new List<Message?>();

            m2.Add(nullMessage);// ok
            m2.Add(nonNullMessage);// ok

            Console.WriteLine("*************************************************************");

            LogNonNullable1(nullMessage); //ok
            LogNonNullable1(nonNullMessage); //ok

            DateTime? nullDate = null;// not a class

            LogNonNullable1(nullDate);

            Console.WriteLine("*************************************************************");

            LogNonNullable2(nullMessage); //ok
            LogNonNullable2(nonNullMessage); //ok
            //LogNonNullable2(nullDate);// error: nullDate is not a reference type - class

            Console.WriteLine("*************************************************************");

            LogNonNullable3(nullMessage); // warning
            LogNonNullable3(nonNullMessage); //ok
            //LogNonNullable3(nullDate);// error: nullDate is not a reference type - class
        }
    }
}
