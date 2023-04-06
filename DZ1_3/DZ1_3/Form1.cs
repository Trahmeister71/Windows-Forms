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

namespace DZ1_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = $"X: {e.X.ToString()}\tY: {e.Y.ToString()}";
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                Text = "Ширина = "+ Screen.GetWorkingArea(this).Width.ToString()+ " Высота = "+
                    Screen.GetWorkingArea(this).Height.ToString();
                Thread.Sleep(1000);      
            }
            if(e.Button == MouseButtons.Left)
            {
                if (e.X < Width -10 && e.X > 10 && e.Y < Height - 10 && e.Y > 10)
                    MessageBox.Show("Курсор в прямоугольнике");
                else if (e.X == Width - 10 || e.X == 10 || e.Y == Height - 10 || e.Y == 10)
                    MessageBox.Show("Курсор на границе прямоугольника");
                else
                    MessageBox.Show("Курсор вне прямоугольника");
            }
            
        }
    }
}
