using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasStation
{
    public partial class Form6 : Form
    {
        public Form ParentForm { get; set; }
        public Form6()
        {
            InitializeComponent();
        }
        public string GetOil() => comboBox1.SelectedItem.ToString();
        public string Price() => textBox2.ToString();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                object obj = comboBox1.SelectedItem;
                string item = obj.ToString();
                switch (item)
                {
                    case "Дизельное топливо":
                        Form2.form2.changeMTB1(textBox2.Text);
                        //Form2.form2.mtb1 =textBox2.Text;
                        break;
                    case "A-92":
                        Form2.form2.mtb2 = textBox2.Text;
                        break;
                    case "A-95":
                        Form2.form2.mtb3 = textBox2.Text;
                        break;
                    case "A-95 Premium":
                        Form2.form2.mtb4 = textBox2.Text;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Сначала откройте автозаправку"); 
            }
            Close();
        }
    }
}
