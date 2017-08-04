using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorClass;

namespace CalculatorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();

            var input = Console.ReadLine().Replace('.', ',');
            string[] numbers = input.Split(new char[] { '-', '+', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);
            string[] operators = input.Split(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);

            //массив строк,в котором будет разбитая строка input
            string[] statements = new string[numbers.Length + operators.Length];

            calculator.FillingString(statements, numbers, operators);

            calculator.MultDiv(statements);

            calculator.AddSubtr(simpleStatement);


            Console.ReadKey();


            //Console.WriteLine(input + "=" + n[n.Length - 1]);
        }
    }
}
