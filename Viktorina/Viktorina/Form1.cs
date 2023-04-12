using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viktorina
{
    public partial class Form1 : Form
    {
        int i= 2;
        int b = 0;
        bool ans1 = true;
        bool ans2 = true;
        bool ans3 = true;
        bool ans4 = true;
        bool ans5 = true;
        bool ans6 = true;
        bool ans7 = true;
        bool ans8 = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked && ans1)
            {
                progressBar1.PerformStep();
                label1.Visible = true;
                label1.BackColor = Color.Green;
                label1.Text = "Верно";
            }
            else if (ans1)
            {
                label1.Visible = true;
                label1.BackColor = Color.Red;
                label1.Text = "Неверно";
            }
            ans1 = false;
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
            if (radioButton5.Checked && ans2)
            {
                progressBar1.PerformStep();
                label2.Visible = true;
                label2.BackColor = Color.Green;
                label2.Text = "Верно";
            }
            else if (ans2)
            {
                label2.Visible = true;
                label2.BackColor = Color.Red;
                label2.Text = "Неверно";
            }
            ans2 = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = i.ToString();
            if (i == 5)
            {
                timer1.Stop();
                label3.BackColor = Color.Red;
                groupBox8.Enabled = false;
                int res = progressBar1.Value;
                DialogResult resdlg =MessageBox.Show($"Вы прошли тест на {res}%","Результат",MessageBoxButtons.RetryCancel,MessageBoxIcon.Information);
                if (resdlg == DialogResult.Cancel)
                {
                    StreamWriter writer = new StreamWriter("Test.txt", false);
                    writer.WriteLine($"TEST: {res}%");
                    writer.Close();
                    Application.Exit();
                }
                else
                    Application.Restart();
            }
            
            i++;
            

        }
        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked && ans3)
            {
                progressBar1.PerformStep();
                label5.Visible = true;
                label5.BackColor = Color.Green;
                label5.Text = "Верно";
            }
            else if (ans3)
            {
                label5.Visible = true;
                label5.BackColor = Color.Red;
                label5.Text = "Неверно";
            }
            ans3 = false;
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton11.Checked && ans4)
            {
                progressBar1.PerformStep();
                label6.Visible = true;
                label6.BackColor = Color.Green;
                label6.Text = "Верно";
            }
            else if (ans4)
            {
                label6.Visible = true;
                label6.BackColor = Color.Red;
                label6.Text = "Неверно";
            }
            ans4 = false;
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton14.Checked && ans5)
            {
                progressBar1.PerformStep();
                label7.Visible = true;
                label7.BackColor = Color.Green;
                label7.Text = "Верно";
            }
            else if (ans5)
            {
                label7.Visible = true;
                label7.BackColor = Color.Red;
                label7.Text = "Неверно";
            }
            ans5 = false;
        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton18.Checked && ans6)
            {
                progressBar1.PerformStep();
                label8.Visible = true;
                label8.BackColor = Color.Green;
                label8.Text = "Верно";
            }
            else if (ans6)
            {
                label8.Visible = true;
                label8.BackColor = Color.Red;
                label8.Text = "Неверно";
            }
            ans6 = false;
        }
        
        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
            if (b == 2)
            {
                if (radioButton19.Checked && ans7)
                {
                    progressBar1.PerformStep();
                    label9.Visible = true;
                    label9.BackColor = Color.Green;
                    label9.Text = "Верно";
                }
                else if (ans7)
                {
                    label9.Visible = true;
                    label9.BackColor = Color.Red;
                    label9.Text = "Неверно";
                }
                ans7 = false;
            }
            b++;
        }

        private void radioButton23_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton23.Checked && ans8)
            {
                progressBar1.PerformStep();
                label11.Visible = true;
                label11.BackColor = Color.Green;
                label11.Text = "Верно";
            }
            else if(ans8)
            {
                label11.Visible = true;
                label11.BackColor = Color.Red;
                label11.Text = "Неверно";
            }
            ans8 = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked)
            {
                progressBar1.PerformStep();
                label4.Visible = true;
                label4.BackColor = Color.Green;
                label4.Text = "Верно";
            }
            else 
            {
                label4.Visible = true;
                label4.BackColor = Color.Red;
                label4.Text = "Неверно";
            }
            button2.Enabled = false;
            groupBox9.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox4.Checked && checkBox5.Checked && !checkBox6.Checked)
            {
                progressBar1.PerformStep();
                label10.Visible = true;
                label10.BackColor = Color.Green;
                label10.Text = "Верно";
            }
            else
            {
                label10.Visible = true;
                label10.BackColor = Color.Red;
                label10.Text = "Неверно";
            }
            button3.Enabled = false;
            groupBox10.Enabled = false;
        }
    }
}
