using System;

namespace Zip
{
    class Program
    {
        static void Main(string[] args)
        {
            var john = new Customer(750, 1, 4, 29);
            var calculator = new CreditCalculator.CreditCalculator();
            Console.WriteLine(calculator.CalculateCredit(john));
            Console.ReadKey();
        }
    }
}
