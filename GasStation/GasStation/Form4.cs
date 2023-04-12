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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                Form5 form5 = new Form5();
                form5.ShowDialog();
                this.Close();

            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль", "Вход", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

    }
}
