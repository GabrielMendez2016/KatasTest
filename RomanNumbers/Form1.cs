using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanNumbers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int number = Int32.Parse(this.textBox1.Text);
                if (number > 3000) //checking < 3000 constraint
                {
                    this.label1.Text = "Number must be less than 3000";
                    return;
                }

                this.label1.Text = RomanConverter.convertToRoman(number);

            }
            catch (Exception) 
            {
                this.label1.Text = "Number Format is Invalid";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.label1.Text = RomanConverter.convertToDigit(this.textBox2.Text.ToUpper()).ToString();
        }
    }
}
