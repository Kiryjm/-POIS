using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson3_Calculator
{
    public partial class MainF : Form
    {
        public MainF()
        {
            InitializeComponent();
        }

        long x = 0;
        char operation = ' ', ArOp = ' ';

        private void OneBtn_Click(object sender, EventArgs e)
        {
            if (operation == '0' || operation == 'C')
                if (textBox1.Text == "0")
                    textBox1.Text = "1";

                else textBox1.Text += "1";
            else
            {
                textBox1.Text = "1";
                operation = '0';
            }

        }

        private void TwoBtn_Click(object sender, EventArgs e)
        {
            if (operation == '0' || operation == 'C')
                if (textBox1.Text == "0")
                    textBox1.Text = "2";

                else textBox1.Text += "2";
            else 
            {
                textBox1.Text = "2";
                operation = '0';
            
            }
        }

        private void ThreeBtn_Click(object sender, EventArgs e)
        {
            if (operation == '0' || operation == 'C')
                if (textBox1.Text == "0")
                    textBox1.Text = "3";
                else textBox1.Text += "3";
            else 
            {
                textBox1.Text = "3";
                operation = '0';
            
            }
        }

        private void FourBtn_Click(object sender, EventArgs e)
        {
            if (operation == '0' || operation == 'C')
                if (textBox1.Text == "0")
                    textBox1.Text = "4";
                else textBox1.Text += "4";
            else 
            {
                textBox1.Text = "4";
                operation = '0';
            
            }
        }

        private void FiveBtn_Click(object sender, EventArgs e)
        {
            if (operation == '0' || operation == 'C')
                if (textBox1.Text == "0")
                    textBox1.Text = "5";
                else textBox1.Text += "5";
            else 
            {
                textBox1.Text = "5";
                operation = '0';

            }
        }

        private void SixBtn_Click(object sender, EventArgs e)
        {
            if (operation == '0' || operation == 'C')
                if (textBox1.Text == "0")
                    textBox1.Text = "6";
                else textBox1.Text += "6";
            else 
            {
                textBox1.Text = "6";
                operation = '0';
            
            }
        }

        private void SevenBtn_Click(object sender, EventArgs e)
        {
            if (operation == '0' || operation == 'C')
                if (textBox1.Text == "0")
                    textBox1.Text = "7";
                else textBox1.Text += "7";
            else 
            {
                textBox1.Text = "7";
                operation = '0';
            
            }
        }

        private void EightBtn_Click(object sender, EventArgs e)
        {
            if (operation == '0' || operation == 'C')
                if (textBox1.Text == "0")
                    textBox1.Text = "8";
                else textBox1.Text += "8";
            else 
            {
                textBox1.Text = "8";
                operation = '0';
            
            }
        }

        private void NineBtn_Click(object sender, EventArgs e)
        {
            if (operation == '0' || operation == 'C')
                if (textBox1.Text == "0")
                    textBox1.Text = "9";
                else textBox1.Text += "9";
            else 
            {
                textBox1.Text = "9";
                operation = '0';
            
            }
        }

        private void ZeroBtn_Click(object sender, EventArgs e)
        {
	    if (operation == '0' || operation == 'C')
                if (textBox1.Text == "0")
                    textBox1.Text = "0";
                else textBox1.Text += "0";
	    else 
	    {
                textBox1.Text = "0";
                operation = '0';

	    }

        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            operation = 'C';
            ArOp = ' ';
        }

        private void BackspaceBtn_Click(object sender, EventArgs e)
        {
            if (operation == '0' || operation == 'C')
            {
                if (textBox1.Text.Length > 1)
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);

                else if (textBox1.Text != "0")
                    textBox1.Text = "0";
                operation = 'C';
            }
            
        }

        

        private void PlusBtn_Click(object sender, EventArgs e)
        {
            x = Convert.ToInt64(textBox1.Text);
            operation = '+';
            ArOp = '+';

        }

        private void ResultBtn_Click(object sender, EventArgs e)
        {
            long y = Convert.ToInt64(textBox1.Text);

            switch (ArOp) 
            {
                case '+': 
                    textBox1.Text = Convert.ToString(x + y);
                    if (operation != '=')
                        x = y;
                    operation = '=';
                    break;

                case '-':
                    textBox1.Text = Convert.ToString(x - y);
                    if (operation != '=')
                        x = y;
                    operation = '=';
                    break;

                case '*':
                    textBox1.Text = Convert.ToString(x * y);
                    if (operation != '=')
                        x = y;
                    operation = '=';
                    break;

                case '/':
                    textBox1.Text = Convert.ToString(x / y);
                    if (operation != '=')
                        x = y;
                    operation = '=';
                    break;
            
            }
        }

        private void MInusBtn_Click(object sender, EventArgs e)
        {
            x = Convert.ToInt64(textBox1.Text);
            operation = '+';
            ArOp = '-';
        }

        private void MultBtn_Click(object sender, EventArgs e)
        {
            x = Convert.ToInt64(textBox1.Text);
            operation = '+';
            ArOp = '*';
        }

        private void DivBtn_Click(object sender, EventArgs e)
        {
            x = Convert.ToInt64(textBox1.Text);
            operation = '+';
            ArOp = '/';
        }
    }
}
