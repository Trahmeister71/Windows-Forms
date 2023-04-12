using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ListBoxAnketa
{
    public partial class Form1 : Form
    {
        
        [Serializable]
        public class Person
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public Person() { }
            public Person(string n, string s, string em ,string p)
            {
                Name = n;
                Surname = s;
                Email = em;
                Phone = p;
            }
            public override string ToString()
            {
                return Name+ " "+ Surname;
            }

        }
        public Form1()
        {
            InitializeComponent();
            XmlSerializer xmlSerializer1 = new XmlSerializer(typeof(List<Person>));
            using (FileStream fs = new FileStream("person.xml", FileMode.Open))
            {
                List<Person> newpeople = xmlSerializer1.Deserialize(fs) as List<Person>;
                if (newpeople != null)
                {
                    foreach (Person person in newpeople)
                        listBox1.Items.Add(person);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(maskedTextBox1.Text!= String.Empty && maskedTextBox2.Text != String.Empty && maskedTextBox3.Text != String.Empty && maskedTextBox4.Text != String.Empty&& maskedTextBox4.Text.Length==14)
            {
                Person person =new Person(maskedTextBox1.Text, maskedTextBox2.Text, maskedTextBox3.Text, maskedTextBox4.Text);
                listBox1.Items.Add(person);
                maskedTextBox1.Text = null; maskedTextBox2.Text = null; maskedTextBox3.Text = null; maskedTextBox4.Text = null;

            }
            else
            {
                MessageBox.Show("Заполните пустые поля","Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Person obj = (Person)listBox1.SelectedItem;
                listBox1.Items.Remove(listBox1.SelectedItem);
                maskedTextBox1.Text = obj.Name; maskedTextBox2.Text = obj.Surname; maskedTextBox3.Text = obj.Email; maskedTextBox4.Text = obj.Phone;
                button1.Enabled = false;
                button4.Enabled = true;
            }
            else
            {
                MessageBox.Show("Выберите элемент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            while (true)
            {
                if (maskedTextBox1.Text != String.Empty && maskedTextBox2.Text != String.Empty && maskedTextBox3.Text != String.Empty && maskedTextBox4.Text != String.Empty)
                {
                    Person person = new Person(maskedTextBox1.Text, maskedTextBox2.Text, maskedTextBox3.Text, maskedTextBox4.Text);
                    listBox1.Items.Add(person);
                    maskedTextBox1.Text = null; maskedTextBox2.Text = null; maskedTextBox3.Text = null; maskedTextBox4.Text = null;
                    break;
                }
                else
                {
                    MessageBox.Show("Заполните пустые поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            button1.Enabled = true;
            button4.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<Person> list = new List<Person>();
            foreach (Person person in listBox1.Items)
                list.Add(person);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
            using (FileStream fs = new FileStream("person.xml", FileMode.Create))
            {               
                xmlSerializer.Serialize(fs, list);
            }
        }

        private void maskedTextBox3_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9._]+@[a-zA-Z0-9]+\.[a-zA-Z]{2,4}$");

            if (!regex.IsMatch(maskedTextBox3.Text))
            {
                maskedTextBox3.Text = String.Empty;
            }
        }
    }
}
