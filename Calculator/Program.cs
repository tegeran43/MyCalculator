using System;
using CalculatorClass;

namespace CalculatorConsole
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var calculator = new Calculator();
            var result = calculator.Calculate(input);

            Console.WriteLine(result);
            Console.ReadKey();

        }
    }
}
