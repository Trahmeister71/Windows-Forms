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
    public partial class Редакция_товаров : Form
    {
        public Product product;
        public Редакция_товаров()
        {
            InitializeComponent();
        }
        public Product GetProduct()
        {
            return product;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                product = new Product();
                product.Name = textBox1.Text;
                product.Price = Convert.ToDouble(textBox2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
