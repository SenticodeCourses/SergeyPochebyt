using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SergCo.Calculator.WindowsFormsApp
{
    public partial class Calculator : Form
    {
        private double number1, number2;
        private int count;
        private bool sing =true;

        public Calculator()
        {
            InitializeComponent();
            
        }

        private void Calculate()
        {
            switch (count)
            {
                case 1:
                    number2 = number1 + Convert.ToDouble(textBox1.Text);
                    textBox1.Text = number2.ToString();
                    break;
                case 2:
                    number2 = number1 - Convert.ToDouble(textBox1.Text);
                    textBox1.Text = number2.ToString();
                    break;
                case 3:
                    number2 = number1 * Convert.ToDouble(textBox1.Text);
                    textBox1.Text = number2.ToString();
                    break;
                case 4:
                    number2 = number1 / Convert.ToDouble(textBox1.Text);
                    textBox1.Text = number2.ToString();
                    break;
                default:
                    break;

            }

        }


        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 1;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 0;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 2;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 3;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 4;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 5;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 6;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 7;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 8;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 9;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                number1 = Convert.ToDouble(textBox1.Text);
                textBox1.Clear();
                count = 1;
                sing = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                number1 = Convert.ToDouble(textBox1.Text);
                textBox1.Clear();
                count = 2;
                sing = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                number1 = Convert.ToDouble(textBox1.Text);
                textBox1.Clear();
                count = 3;
                sing = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                number1 = Convert.ToDouble(textBox1.Text);
                textBox1.Clear();
                count = 4;
                sing = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Calculate();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (sing == true)
            {
                textBox1.Text = "-" + textBox1.Text;
                sing = false;
            }
            else
            {
                textBox1.Text = textBox1.Text.Replace("-", "");
                sing = true;
            }

        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(","))
            {
                
                if (textBox1.Text == "")
                {
                    textBox1.Text = "0" + textBox1.Text;
                }

                if (textBox1.Text == "-")
                {
                    textBox1.Text = textBox1.Text + "0";
                }
                
                textBox1.Text = textBox1.Text + ",";
            }
        }
    }
}
