using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModalForm
{
    public partial class Form2 : Form
    {
        public Form ParentForm { get; set; } 
        public Form2()
        {
            InitializeComponent();
        }
        public string SetText
        {
            set
            {
                textBox1.Text = value;
            }
        }
        public string GetText
        {
            get
            {
                if (!String.IsNullOrEmpty(textBox2.Text))
                    return textBox2.Text;
                throw new Exception();

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
