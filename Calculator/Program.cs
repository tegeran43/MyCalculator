using System;
using CalculatorClass;

namespace CalculatorConsole
{
    class Program
    {
        private static Calculator calculator;
        static void Main()
        {
            var input = Console.ReadLine();
            //var calculator = new Calculator();
            var result = calculator.Calculate(input);

            Console.WriteLine(result);
            Console.ReadKey();

        }
    }
}
