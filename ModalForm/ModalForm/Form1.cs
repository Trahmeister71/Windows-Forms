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
    public partial class Form1 : Form
    {
        Form2 form2;
        public Form1()
        {
            InitializeComponent();
        }
        public string SetText
        {
            set
            {
                textBox2.Text = value;
            }
        }
        public string GetText
        {
            get
            {
                if (!String.IsNullOrEmpty(textBox1.Text))
                    return textBox1.Text;
                throw new Exception();

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            form2 = new Form2();
            form2.ParentForm = this;
            form2.SetText = GetText;
            DialogResult rez= form2.ShowDialog();
            if(rez == DialogResult.OK)
            {
                SetText=form2.GetText;
            }
        }
    }
}
