using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace ThreadsInvoke
{

    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer;
        public class Passenger
        {
            public Passenger(string name, int baggage, int numFlight)
            {
                Name = name;
                Baggage = baggage;
                NumFlight = numFlight;
            }

            public string Name { get; set; }
            public int Baggage { get; set; }
            public int NumFlight { get; set; }

        }
        List<Passenger> passes;
        public Form1()
        {
            InitializeComponent();
            
            listView1.Items.Clear();
           passes = new List<Passenger>()
            {
             new Passenger("Иванов Иван", 2, 123),
             new Passenger("Петров Петр", 1, 456),
             new Passenger("Сидоров Сидор", 3, 789),
             new Passenger("Козлов Константин", 2, 123),
             new Passenger("Андреев Андрей", 1, 456),
             new Passenger("Григорьев Григорий", 3, 789),
             new Passenger("Федоров Федор", 2, 123),
             new Passenger("Николаев Николай", 1, 456),
             new Passenger("Егоров Егор", 3, 789),
             new Passenger("Дмитриев Дмитрий", 2, 123)
            };

            
            
        }
        public void Tick(object sender, EventArgs e)
        {
            Text = DateTime.Now.ToLongTimeString();
        }
        private void запуститьПотокиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            int weigh = 0;
            new Thread(() =>
            {
                Action act = () =>
                {
                    foreach (Passenger passenger in passes)
                    {
                        if ( textBox1.Text != ""&& passenger.NumFlight == int.Parse(textBox1.Text))
                        {
                            listView1.Items.Add(passenger.Name);
                            weigh += passenger.Baggage;
                        }
                    }
                    listView1.Items.Add($"Общее кол-во багажа {weigh}");
                };
                Action act2 = () =>
                {
                    timer = new System.Windows.Forms.Timer();
                    timer.Interval = 1000;
                    timer.Start();
                    timer.Tick += new EventHandler(Tick);

                };
                Invoke(act);
                Invoke(act2);

            }).Start();
        }
    }
}



