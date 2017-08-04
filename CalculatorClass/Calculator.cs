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

            //statements = MultDiv(statements);
            //statements = AddSubtr(statements);

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

        //Выполняет действия "*,/", другие не учитываются
        private string[] MultDiv(string[] statements)
        {
            int countnull = 0;
            for (int i = 1; i < statements.Length - 1; i++)
            {
                if (statements[i] == "*")
                {
                    statements[i - 1] = Convert.ToString(Convert.ToDouble(statements[i - 1]) * Convert.ToDouble(statements[i + 1]));
                    statements[i] = null;
                    statements[i + 1] = null;
                    countnull += 2;
                }
                if (statements[i] == "/")
                {
                    statements[i - 1] = Convert.ToString(Convert.ToDouble(statements[i - 1]) / Convert.ToDouble(statements[i + 1]));
                    statements[i] = null;
                    statements[i + 1] = null;
                    countnull += 2;
                }
            }
            //создаём массив без символов null
            string[] simpleStatement = new string[statements.Length - countnull];
            //заполняем массив символами
            for (int i = 0, j = 0; i < statements.Length; i++)
            {
                if (statements[i] != null)
                {
                    simpleStatement[j] = statements[i];
                    j++;
                }
            }
            return simpleStatement;
        }

        //Вычисляет простое выражение(при вхоящих знаках "+,-") из входящего массива строк
        private string[] AddSubtr(string[] simpleStatement)
        {
            for (int i = 1; i < simpleStatement.Length - 1; i++)
            {
                if (simpleStatement[i] == "+")
                {
                    simpleStatement[i + 1] = Convert.ToString(Convert.ToDouble(simpleStatement[i - 1]) + Convert.ToDouble(simpleStatement[i + 1]));
                    simpleStatement[i - 1] = null;
                    simpleStatement[i] = null;
                }
                if (simpleStatement[i] == "-")
                {
                    simpleStatement[i + 1] = Convert.ToString(Convert.ToDouble(simpleStatement[i - 1]) - Convert.ToDouble(simpleStatement[i + 1]));
                    simpleStatement[i - 1] = null;
                    simpleStatement[i] = null;
                }
            }
            return simpleStatement;
        }

        private string OutputResult(string[] simpleStatement)
        {
            return simpleStatement[simpleStatement.Length - 1];
        }
    }
}
