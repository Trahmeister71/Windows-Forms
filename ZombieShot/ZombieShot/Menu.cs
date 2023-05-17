using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZombieShot
{
    public partial class Menu : Form
    {
        public static Menu menu { get; set; }

        List<string> menus = new List<string>
        {
           "Complexity: Easy","Complexity: Medium","Complexity: Hard"
        };
        int i = 1;
        public Menu()
        {
            InitializeComponent();
            menu = this;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (i == 2)
            { button2.Text = menus[0]; i = -1; }
            button2.Text = menus[i+1];
            i++;
            Database.Complex = button2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Visible = false;

        }
    }
}
