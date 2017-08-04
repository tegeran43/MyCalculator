using System;
namespace CalculatorClass
{
    public class Calculator
    {
        public string ParseInput(string input)
        {
            return input;
        }

        //заполнение массива строк[] по порядку, как в вводимом выражении
        public string[] FillingString(string[] statements, string[] numbers, string[] operators)
        {
            int iteration = 0;
            for (int i = 0, j = 1, k = 0; i < statements.Length; i += 2, j += 2, k++)
            {
                statements[i] = numbers[k];
                if (iteration < operators.Length) statements[j] = operators[k];
                iteration++;
            }
            return statements;
        }

        //Выполняет действия "*,/", другие не учитываются
        public string[] MultDiv(string[] statements)
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
        public string[] AddSubtr(string[] simpleStatement)
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

        public string OutputResult(string[] simpleStatement)
        {
            return simpleStatement[simpleStatement.Length - 1];
        }




    }
}
