using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadsLab
{
    public partial class Form1 : Form
    {
        public class Bank
        {
            private int money;

            public int GetMoney()
            {
                return money;
            }

            public void SetMoney(int value)
            {
                money = value;
                new Thread(() =>
                {
                    using (StreamWriter file = new StreamWriter("info.txt", true))
                    {
                        file.WriteLine(money.ToString());
                        file.WriteLine(name.ToString());
                        file.WriteLine(percent.ToString());
                    }
                }).Start();
            }

            private string name;

            public string GetName()
            {
                return name;
            }

            public void SetName(string value)
            {
                name = value;
                new Thread(() =>
                {
                    using (StreamWriter file = new StreamWriter("info.txt", true))
                    {
                        file.WriteLine(money.ToString());
                        file.WriteLine(name.ToString());
                        file.WriteLine(percent.ToString());
                    }
                }).Start();
            }

            private int percent;

            public Bank(int money, string name, int percent)
            {
                this.money = money;
                this.name = name;
                this.percent = percent;
            }

            public int GetPercent()
            {
                return percent;
            }

            public void SetPercent(int value)
            {
                percent = value;
                new Thread(() =>
                {
                    using (StreamWriter file = new StreamWriter("info.txt", false))
                    {
                        file.WriteLine(money.ToString());
                        file.WriteLine(name.ToString());
                        file.WriteLine(percent.ToString());
                    }
                }).Start();
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void потокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                Print(new List<int>() { 1, 2, 3, 4, 5 });
            });
            thread.Start();
        }

        private void Print(List<int> arr)
        {
            foreach (int i in arr)
                listBox1.Items.Add(i.ToString());
        }
        Bank person;
        private void button1_Click(object sender, EventArgs e)
        {
            person = new Bank(int.Parse(textBox1.Text), textBox2.Text, int.Parse(textBox3.Text));
            button2.Enabled = true;
            button1.Enabled = false;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await Task.Run(() => { 
            person.SetMoney(int.Parse(textBox1.Text));
            person.SetName(textBox2.Text);
            person.SetPercent(int.Parse(textBox3.Text));
            });
        }
    }
}
