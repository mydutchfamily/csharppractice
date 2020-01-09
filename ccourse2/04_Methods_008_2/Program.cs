using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Methods_008_2
{

    class Client
    {
        double debt;
        double[] payments;
        int paymentIndex = 0;

        public Client(double debt, double[] payments)
        {
            this.debt = debt;
            this.payments = payments;
        }

        public double Debt { get => debt; set => debt = value; }
        public double[] Payments { get => payments; set => payments = value; }

        public void PrintDebtStatus()
        {
            Console.WriteLine("Debt is: {0}", debt);
            Console.Write("Payments:");
            double sum = 0;
            foreach (var item in payments)
            {
                Console.Write(" " + item);
                sum += item;
            }
            Console.WriteLine("\nSum of pay outs: {0}", sum);
            Console.WriteLine("Debt left: {0}", (debt - sum));
        }

        public void PayOuts(double payment)
        {
            payments[paymentIndex] = payment;
            paymentIndex++;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client(1000, new double[] { 0, 0, 0, 0, 0, 0, 0 });
            client.PrintDebtStatus();
            client.PayOuts(400);
            client.PayOuts(200);
            client.PrintDebtStatus();
            Console.ReadKey();
        }
    }
}
