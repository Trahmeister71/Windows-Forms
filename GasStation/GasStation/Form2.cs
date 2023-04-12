using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasStation
{
    public partial class Form2 : Form
    {
        public static Form2 form2;
        public ComboBox comboBox2;
        public string mtb3 { get; set; } = "46,59";
        public string mtb2 { get; set; } = "46,73";
        public string mtb4 { get; set; } = "49,12";
        public string mtb1 { get; set; } = "46,62";
        double rez;
        public Form2()
        {
            InitializeComponent();
            comboBox2=comboBox1;
            form2 = this;
            comboBox1.SelectedItem = comboBox1.Items[2];
        }
        public double GetRez()
        {
            return rez;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox3.Text = "0";
                textBox2.Enabled = true;
                textBox3.Enabled = false;
                textBox12.Text = "";
                label7.Text = "К оплате";
                label10.Text = "UAH";
            }
            else
            {
                textBox2.Text = "0";
                textBox2.Enabled = false;
                textBox3.Enabled = true;

                textBox12.Text = "";
                label7.Text = "К выдаче";
                label10.Text = "L";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    double amount = Convert.ToDouble(textBox2.Text);
                    double price = Convert.ToDouble(textBox1.Text);
                    rez = amount * price;
                    textBox12.Text = rez.ToString();
                }
                else
                {
                    textBox12.Text = "";
                }
            }
            catch (Exception ex)
            {
                textBox2.Text = null;
                MessageBox.Show(ex.Message);
            }
        }
        public void changeMTB1(string s)
        {
            mtb1 = s;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text != "")
                {
                    double amount = Convert.ToDouble(textBox3.Text);
                    double price = Convert.ToDouble(textBox1.Text);
                    rez = amount / price;
                    textBox12.Text = String.Format("{0:F2}", rez);
                    rez = amount;
                }
                else
                {
                    textBox12.Text = "";
                }
            }
            catch (Exception ex)
            {
                textBox3.Text = null;
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = null;
            textBox3.Text = null;
            textBox12.Text = null;
            object obj = comboBox1.SelectedItem;
            string item = obj.ToString();
            switch (item)
            {
                case "Дизельное топливо":
                    textBox1.Text = mtb1.ToString();
                    break;
                case "A-92":
                    textBox1.Text = mtb2.ToString();
                    break;
                case "A-95":
                    textBox1.Text = mtb3.ToString();
                    break;
                case "A-95 Premium":
                    textBox1.Text = mtb4.ToString();
                    break;
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.form1.rez = Convert.ToDouble(textBox12.Text);
            Close();
        }
    }
}
