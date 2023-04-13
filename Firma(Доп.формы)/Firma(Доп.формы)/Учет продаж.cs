using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firma_Доп.формы_
{
    public partial class Form1 : Form
    {
        Product producttemp;
        public double all;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Редакция_товаров form = new Редакция_товаров();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                try
                {

                    producttemp = new Product();
                    producttemp = form.GetProduct();
                    if (producttemp.Name != "" && producttemp.Price != 0)
                    {
                        for(int i = 0; i < comboBox1.Items.Count; i++)
                        {
                            if(comboBox1.Items[i].ToString() == producttemp.Name)
                            {
                                Product temp = (Product)comboBox1.Items[i];
                                temp.Name = producttemp.Name;
                                temp.Price= producttemp.Price;
                                comboBox1.Items[i]=temp;
                                return;
                            }
                        }
                        comboBox1.Items.Add(producttemp);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product pr = (Product)comboBox1.SelectedItem;
            textBox1.Text = pr.Price.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Add((Product)comboBox1.SelectedItem);
                all = Convert.ToDouble(textBox2.Text);
                all += ((Product)comboBox1.SelectedItem).Price;
                textBox2.Text = all.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
