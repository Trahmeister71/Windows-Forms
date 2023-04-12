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

namespace Accounts
{
    public partial class Form1 : Form
    {
        int count;
        public Form1()
        {
            InitializeComponent();
            StreamReader reader = new StreamReader("text.txt");
            string str = reader.ReadToEnd();
            count = str.Length;
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value += count;
        }
    }
}
