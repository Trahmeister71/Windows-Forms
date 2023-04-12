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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form3.form3.txbx1.Text = textBox4.Text;
                Form3.form3.txbx2.Text = textBox5.Text;
                Form3.form3.txbx3.Text = textBox6.Text;
                Form3.form3.txbx4.Text = textBox7.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сначала откройте мини-кафе");
            }
        }
    }
}
