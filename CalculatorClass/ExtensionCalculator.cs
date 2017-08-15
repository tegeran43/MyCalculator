using System;

namespace CalculatorClass
{
    public static class ExtensionCalculator
    {
        public static void Hello() { }

        //Выполняет действия "*, /", другие не учитываются
        public static string[] MultDiv(this string[] statements)
        {
            int countnull = 0;
            for (int i = 1; i < statements.Length - 1; i++)
            {
                if (statements[i] == "*")
                {
                    statements[i + 1] = Convert.ToString(Convert.ToDouble(statements[i - 1]) * Convert.ToDouble(statements[i + 1]));
                    statements[i - 1] = null;
                    statements[i] = null;
                    countnull += 2;
                }
                if (statements[i] == "/")
                {
                    statements[i + 1] = Convert.ToString(Convert.ToDouble(statements[i - 1]) / Convert.ToDouble(statements[i + 1]));
                    statements[i - 1] = null;
                    statements[i] = null;
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
        public static string[] AddSubtr(this string[] simpleStatement)
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
    }
}