using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viktorina
{
    public partial class Form1 : Form
    {
        int i= 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                progressBar1.PerformStep();
            }
            
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
                progressBar1.Visible = true; 
            else
                progressBar1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            button1.Enabled = false;            
            timer1.Start();
            groupBox8.Visible = true;
            label3.Visible = true;
            label3.BackColor = Color.Yellow;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
                progressBar1.PerformStep();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i == 5)
            {
                timer1.Stop();
                label3.BackColor = Color.Red;
                groupBox8.Enabled = false;
            }
            label3.Text = i.ToString();
            i++;
            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked)
                progressBar1.PerformStep();
            
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked)
                progressBar1.PerformStep();
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton11.Checked)
                progressBar1.PerformStep();
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton14.Checked)
                progressBar1.PerformStep();
        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton18.Checked)
                progressBar1.PerformStep();
        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton19.Checked)
                progressBar1.PerformStep();
        }

        private void radioButton23_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton23.Checked)
                progressBar1.PerformStep();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked && checkBox5.Checked && !checkBox6.Checked)
                progressBar1.PerformStep();
        }
    }
}
