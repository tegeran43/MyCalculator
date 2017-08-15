using System;
using System.Linq;
using System.Windows.Forms;
using CalculatorClass;

namespace WindowsFormCalculator
{
    public partial class WinCalculator : Form
    {
        private readonly Calculator _calculator;

        public WinCalculator()
        {
            InitializeComponent();
            _calculator = new Calculator();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            switch (btn.Text)
            {
                case "C":
                    {
                        display.Clear();
                        break;
                    }

                case "<-":
                    {
                        if (display.Text != "")
                        {
                            display.Text = display.Text.Remove(display.Text.Length - 1, 1);
                        }
                        break;
                    }

                default:
                    {
                        if (!string.IsNullOrEmpty(display.Text))
                        {
                            var lastDigit = display.Text.Substring(display.Text.Length - 1, 1);

                            if (!char.IsDigit(btn.Text[0]) && !char.IsDigit(lastDigit[0]))
                            {
                                //display tetxt remove last symbol 
                                display.Text = display.Text.Remove(display.Text.Length - 1, 1);
                            }

                        }

                        display.Text += btn.Text;

                        break;
                    }
            }
        }

        private void BtnResultClick(object sender, EventArgs e)
        {
            display.Text = _calculator.Calculate(display.Text);
        }

        private void Display_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}