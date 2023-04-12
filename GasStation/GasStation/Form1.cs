using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasStation
{
    public partial class Form1 : Form
    {
        public static Form1 form1;
        public static double allday = 0;
        public int sum = 0;
        public double rez;
        public Form1()
        {
            InitializeComponent();
            form1 = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox14.Text = String.Format("{0:F2}", rez + sum);
            rez = 0; sum = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            if (form.DialogResult == DialogResult.OK)
            {
                rez = form.GetRez();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();
            if (form.DialogResult == DialogResult.OK)
            {
                sum = form.GetSum();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void cбросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allday -= rez + sum;
            rez = 0; sum = 0;
            textBox14.Text = null;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("Прибыль за день {0:F2} UAH ", allday), "День закончился");
            Application.Exit();
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("Прибыль за день {0:F2} UAH", allday), "День закончился");
            Application.Exit();
        }

        private void расчитатьКлиентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allday += rez + sum;
            textBox14.Text = String.Format("{0:F2}", rez + sum);
            rez = 0; sum = 0;
        }

    }
}
