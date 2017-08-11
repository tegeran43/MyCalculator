using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += ",";
        }

        char operation; // Знак
        string firstNumber; // Первое число
        string secondNumber; // Второе число
        bool member = false; // Для выполнения действия, если не нажали "="

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            member = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (member)
            {
                Solution();
            }
            operation = '+';
            firstNumber = textBox1.Text;
            textBox1.Text += "+";
            member = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (member)
            {
                Solution();
            }
            operation = '*';
            firstNumber = textBox1.Text;
            textBox1.Text += "*";
            member = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (member)
            {
                Solution();
            }
            operation = '-';
            firstNumber = textBox1.Text;
            textBox1.Text += "-";
            member = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (member)
            {
                Solution();
            }
            operation = '/';
            firstNumber = textBox1.Text;
            textBox1.Text += "/";
            member = true;
        }

        public void Solution()
        {
            
            for (int i = firstNumber.Length + 1; i < textBox1.Text.Length; i++)
            {
                secondNumber += textBox1.Text[i];   
            }
            if (operation == '+') { textBox1.Text = Convert.ToString(Convert.ToDouble(firstNumber) + Convert.ToDouble(secondNumber)); }
            if (operation == '-') { textBox1.Text = Convert.ToString(Convert.ToDouble(firstNumber) - Convert.ToDouble(secondNumber)); }
            if (operation == '*') { textBox1.Text = Convert.ToString(Convert.ToDouble(firstNumber) * Convert.ToDouble(secondNumber)); }
            if (operation == '/') { textBox1.Text = Convert.ToString(Convert.ToDouble(firstNumber) / Convert.ToDouble(secondNumber)); }
            secondNumber = null;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Solution();
            member = false;
        }
    }
}
