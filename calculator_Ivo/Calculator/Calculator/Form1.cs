using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double result = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        string calculation = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_click(object sender, EventArgs e)
        {
            if (textBox_Result.Text.Equals("0") || (isOperationPerformed))
            {
                textBox_Result.Clear();
            }
            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!textBox_Result.Text.Contains("."))
                {
                    textBox_Result.Text = textBox_Result.Text + button.Text;
                }
            }
            else
                textBox_Result.Text = textBox_Result.Text + button.Text;

        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (result != 0)
            {
                button23.PerformClick();
                operationPerformed = button.Text;
                result = double.Parse(textBox_Result.Text);
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                result = double.Parse(textBox_Result.Text);
                isOperationPerformed = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            result = 0;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    textBox_Result.Text = (result + Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "-":
                    textBox_Result.Text = (result - Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "*":
                    textBox_Result.Text = (result * Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "/":
                    textBox_Result.Text = (result / Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "√":
                    double d = Double.Parse(textBox_Result.Text);
                    textBox_Result.Text = (Math.Sqrt(d).ToString());
                    break;
                default:
                    break;
            }
            listBox1.Items.Insert(0, Convert.ToDecimal(textBox_Result.Text));
        }
        private void button24_Click_1(object sender, EventArgs e)
        {

            if (listBox1.Items.Count == 0)
            {
                listBox1.Items.Add(Decimal.Parse(textBox_Result.Text));
            }
            else
            {
                decimal b = (decimal)listBox1.Items[0] + Decimal.Parse(textBox_Result.Text);
                listBox1.Items[0] = b;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            decimal b = (decimal)listBox1.Items[0] - Decimal.Parse(textBox_Result.Text);
            listBox1.Items[0] = b;
        }

        

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0) textBox_Result.Text = listBox1.Items[0].ToString();
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Insert(0, Convert.ToDecimal(textBox_Result.Text));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                listBox1.Items.Clear();
            }
        }

        private void te(object sender, EventArgs e)
        {

        }

        private void label1_Clic(object sender, EventArgs e)
        {

        }
    }
    public class Operations : Form1
    {
        private List<decimal> list;
        public List<decimal> getList()
        {
            return list;
        }
        public void MemoryPlus(decimal a)
        {
            list.Add(a);
        }
        public void MemoryMinus(decimal a)
        {
            list.Add(a);
        }
        public void MemoryRecall()
        {
            textBox_Result.Text = list[list.Count - 1].ToString();
        }

        public void MemoryClear()
        {
            list.Clear();
        }
    }
}
