using System;
using System.Windows.Forms;

namespace GiffyCalc
{
    public partial class Form1 : Form
    {
        private readonly Calculator calculator;

        public Form1()
        {
            InitializeComponent();
            calculator = new Calculator();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var values = GetInputValues();
            txtResult.Text = calculator.Add(values.X, values.Y).ToString();
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            var values = GetInputValues();
            txtResult.Text = calculator.Multiply(values.X, values.Y).ToString();
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            var values = GetInputValues();
            txtResult.Text = calculator.Subtract(values.X, values.Y).ToString();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
        }





        private InputValues GetInputValues()
        {
            var x = Convert.ToInt32(txtNumber1.Text);
            var y = Convert.ToInt32(txtNumber2.Text);
            return new InputValues(x, y);
        }

        private class InputValues
        {
            public int X;
            public int Y;

            public InputValues(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }

    
}
