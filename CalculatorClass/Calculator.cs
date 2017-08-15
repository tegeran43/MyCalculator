using System;

namespace CalculatorClass
{
    public class Calculator
    {
        
        private readonly char[] _characterSet = {'-', '+', '*', '/'};
        private readonly char[] _digitSet = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',', '.' };

        public string Calculate(string input)
        {
            var operators = input.Split(_digitSet, StringSplitOptions.RemoveEmptyEntries);
            var numbers = input.Split(_characterSet, StringSplitOptions.RemoveEmptyEntries);

            var statements = FillingString(numbers, operators).MultDiv().AddSubtr();

            return OutputResult(statements);
        }
        
        //заполнение массива строк[] по порядку, как в вводимом выражении
        private string[] FillingString(string[] numbers, string[] operators)
        {
            var statements = new string[numbers.Length + operators.Length];
            for (int i = 0, j = 1, k = 0; i < statements.Length; i += 2, j += 2, k++)
            {
                statements[i] = numbers[k];

                if (k < operators.Length)
                {
                    statements[j] = operators[k];
                }
            }

            return statements;
        }

        private  string OutputResult(string[] simpleStatement)
        {
            return simpleStatement[simpleStatement.Length - 1];
        }
    }
}
