using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            string name = "NIKITA";
            count += name.Length;
            MessageBox.Show(name);
            name = "LCIHKUN";
            count += name.Length;
            MessageBox.Show(name);
            name = "Viktorovich";
            count+=name.Length;
            string res= Convert.ToString(count/3);
            MessageBox.Show(name);
            MessageBox.Show("Количество символов", res, MessageBoxButtons.OK);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count=0;
            Random rand = new Random();
            bool flag = true;
            while (flag)
            {
                count++;
                int num=rand.Next(0,2001);
                DialogResult res = MessageBox.Show($"Это число - {num}?","Случайное число",MessageBoxButtons.YesNo);
                if(res == DialogResult.Yes)
                {
                    DialogResult rez = MessageBox.Show("Хотите еще?", "Игра", MessageBoxButtons.RetryCancel);
                    
                    if (rez == DialogResult.Cancel)
                    {
                        flag = false;
                        MessageBox.Show($"Количество попыток {count}","Игра окончена");
                        
                    }
                    count = 0;
                }

            }
        }
    }
}
