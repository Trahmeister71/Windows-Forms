using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasStation
{
    public partial class Form3 : Form
    {
        //public Form ParentForm { get; set; }
        int sum = 0;
        public static Form3 form3 { get; set; }
        public TextBox txbx1,txbx2,txbx3,txbx4;
        public Form3()
        {
            InitializeComponent();
            form3 = this;
            txbx1 = textBox4;
            txbx2 = textBox5;
            txbx3 = textBox6;
            txbx4 = textBox7;
        }
        public int GetSum() { return sum; } 
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {

                maskedTextBox4.Enabled = true;
            }
            else
            {
                maskedTextBox4.Enabled = false;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                maskedTextBox1.Enabled = true;
            else maskedTextBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.form1.sum = sum;
            Close();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                maskedTextBox2.Enabled = true;
            else maskedTextBox2.Enabled = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                maskedTextBox3.Enabled = true;
            else maskedTextBox3.Enabled = false;
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            sum = 0;
            if (checkBox1.Checked && maskedTextBox1.Text != "")
            {
                sum += Convert.ToInt32(textBox4.Text) * Convert.ToInt32(maskedTextBox1.Text);
            }
            if (checkBox2.Checked && maskedTextBox2.Text != "")
            {
                sum += Convert.ToInt32(textBox5.Text) * Convert.ToInt32(maskedTextBox2.Text);
            }
            if (checkBox3.Checked && maskedTextBox3.Text != "")
            {
                sum += Convert.ToInt32(textBox6.Text) * Convert.ToInt32(maskedTextBox3.Text);
            }
            if (checkBox4.Checked && maskedTextBox4.Text != "")
            {
                sum += Convert.ToInt32(textBox7.Text) * Convert.ToInt32(maskedTextBox4.Text);
            }
            textBox13.Text = sum.ToString();
            
        }
    }
}
