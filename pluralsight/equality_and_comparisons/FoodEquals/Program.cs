using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodEquals
{
    class Program
    {
        static void Main(string[] args)
        {

            FoodItem bananai1 = new FoodItem("banana", FoodGroup.Fruit);
            FoodItem bananai2 = new FoodItem("banana", FoodGroup.Fruit);
            FoodItem chocolatei = new FoodItem("chocolate", FoodGroup.Sweets);

            Console.WriteLine("banana1 == banana2: " + (bananai1 == bananai2));
            Console.WriteLine("banana2 == chocolate: " + (bananai2 == chocolatei));
            Console.WriteLine("banana1 == chocolate: " + (bananai1 == chocolatei));

            Console.WriteLine("********************************************");

            string str1 = "Click me";
            string str2 = string.Copy(str1);
            DiaplayWhwtherArgsEqual(str1, str2);

            Console.WriteLine("********************************************");

            Tuple<int, int> tuple1 = Tuple.Create(1, 3);
            Tuple<int, int> tuple2 = Tuple.Create(1,3);

            Console.WriteLine("Reference " + ReferenceEquals(tuple1, tuple2));
            Console.WriteLine("operator " + (tuple1 == tuple2));// not overloaded for tuples = will compare references 
            Console.WriteLine("method " + tuple1.Equals(tuple2));

            Console.WriteLine("********************************************");

             str1 = "Click me";
             str2 = string.Copy(str1);

            Console.WriteLine("Reference " + ReferenceEquals(str1, str2));
            Console.WriteLine("operator " + AreStringEqualOp(str1, str2));
            Console.WriteLine("method " + AreStringEqualsMethod(str1, str2));

            Console.WriteLine("********************************************");

            Button button1 = new Button();
            button1.Text = "Click me";
            Button button2 = new Button();
            button2.Text = "Click me";

            Console.WriteLine("operator " + AreButtonEqualOp(button1, button2));
            Console.WriteLine("method " + AreButtonEqualsMethod(button1, button2));


            Console.WriteLine("********************************************");

            Console.WriteLine("operator " + AreIntsEqualOp(3, 3));
            Console.WriteLine("method " + AreIntsEqualsMethod(3, 3));

            Console.WriteLine("********************************************");

            Food banana = new Food("banana");
            Food banana2 = new Food("banana");

            Food chocolate = new Food("chocolate");

            Console.WriteLine(banana.Equals(chocolate));
            Console.WriteLine(banana.Equals(banana2));// virtual object.Equals()
            Console.WriteLine(object.Equals(banana, banana2));// static object.Equals() - if one of the objects is null
            Console.WriteLine(object.ReferenceEquals(banana, banana2));// ALWAYS check reference to same instance

            Console.WriteLine("********************************************");

            FoodStruct bananas = new FoodStruct("banana");
            FoodStruct bananas2 = new FoodStruct("banana");

            Console.WriteLine(bananas.Equals(bananas2));
            //Console.WriteLine(bananas == bananas2);// operator == should be overloaded

            Console.ReadLine();
        }

        private static void DiaplayWhwtherArgsEqual<T>(T x, T y) where T: class
        {
            Console.WriteLine("Equals?: " + (x == y));// == will be lost for concrete class and general implementation used - ref comp
        }

        private static bool AreStringEqualsMethod(string str1, string str2)
        {
            return str1.Equals(str2);//  callvirt   instance bool [mscorlib]System.String::Equals(string)
        }

        private static bool AreStringEqualOp(string str1, string str2)
        {
            return str1 == str2;// call       bool [mscorlib]System.String::op_Equality(string,string)
            //op_Equality is overload of == operator
        }

        static bool AreIntsEqualOp(int x, int y) {
            return x==y;// compare values in one command - ceq
        }

        static bool AreIntsEqualsMethod(int x, int y)
        {
            return x.Equals(y);// call       instance bool [mscorlib]System.Int32::Equals(int32)
        }

        static bool AreButtonEqualOp(Button x, Button y)
        {
            return x == y;// compare values in one command - ceq
        }

        static bool AreButtonEqualsMethod(Button x, Button y)
        {
            return x.Equals(y);// callvirt   instance bool [mscorlib]System.Object::Equals(object)
        }
    }
}
