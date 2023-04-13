using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAbControl
{
    public partial class Form1 : Form
    {
        int countcorrect=0;
        RadioButton radioButton3_2;
        RadioButton radioButton2_3;
        RadioButton radioButton1_1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GroupBox groupBox1 = new GroupBox();
            groupBox1.Text = "4)Столица Малайзии";
            groupBox1.Location = new Point(10, 10);
            groupBox1.Size = new Size(200, 100);

            // создание RadioButton-ов для первого GroupBox
            radioButton1_1 = new RadioButton();
            radioButton1_1.Text = "Куала-лумпур";
            radioButton1_1.Location = new Point(20, 20);
            radioButton1_1.Size = new Size(150, 20);

            RadioButton radioButton1_2 = new RadioButton();
            radioButton1_2.Text = "Бангладеш";
            radioButton1_2.Location = new Point(20, 40);
            radioButton1_2.Size = new Size(150, 20);

            RadioButton radioButton1_3 = new RadioButton();
            radioButton1_3.Text = "Лаос";
            radioButton1_3.Location = new Point(20, 60);
            radioButton1_3.Size = new Size(150, 20);

            // добавление RadioButton-ов в первый GroupBox
            groupBox1.Controls.Add(radioButton1_1);
            groupBox1.Controls.Add(radioButton1_2);
            groupBox1.Controls.Add(radioButton1_3);

            // создание второго GroupBox
            GroupBox groupBox2 = new GroupBox();
            groupBox2.Text = "5)Сколько людей убила испанка";
            groupBox2.Location = new Point(10, 120);
            groupBox2.Size = new Size(200, 100);

            // создание RadioButton-ов для второго GroupBox
            RadioButton radioButton2_1 = new RadioButton();
            radioButton2_1.Text = "9 млн";
            radioButton2_1.Location = new Point(20, 20);
            radioButton2_1.Size = new Size(150, 20);

            RadioButton radioButton2_2 = new RadioButton();
            radioButton2_2.Text = "17 млн";
            radioButton2_2.Location = new Point(20, 40);
            radioButton2_2.Size = new Size(150, 20);

            radioButton2_3 = new RadioButton();
            radioButton2_3.Text = "12,5 млн";
            radioButton2_3.Location = new Point(20, 60);
            radioButton2_3.Size = new Size(150, 20);

            // добавление RadioButton-ов во второй GroupBox
            groupBox2.Controls.Add(radioButton2_1);
            groupBox2.Controls.Add(radioButton2_2);
            groupBox2.Controls.Add(radioButton2_3);

            // создание третьего GroupBox
            GroupBox groupBox3 = new GroupBox();
            groupBox3.Text = "Кто написал TheFacebook";
            groupBox3.Location = new Point(235, 10);
            groupBox3.Size = new Size(200, 100);

            // создание RadioButton-ов для третьего GroupBox
            RadioButton radioButton3_1 = new RadioButton();
            radioButton3_1.Text = "Стив Джобс";
            radioButton3_1.Location = new Point(20, 20);
            radioButton3_1.Size = new Size(150, 20);

            radioButton3_2 = new RadioButton();
            radioButton3_2.Text = "Марк Цукерберг";
            radioButton3_2.Location = new Point(20, 40);
            radioButton3_2.Size = new Size(150, 20);

            RadioButton radioButton3_3 = new RadioButton();
            radioButton3_3.Text = "Билл Гейтс";
            radioButton3_3.Location = new Point(20, 60);
            radioButton3_3.Size = new Size(150, 20);

            groupBox3.Controls.Add(radioButton3_1);
            groupBox3.Controls.Add(radioButton3_2);
            groupBox3.Controls.Add(radioButton3_3);

            TabPage tabpage2 = new TabPage("2");
            tabpage2.Controls.Add(groupBox1);
            tabpage2.Controls.Add(groupBox2);
            tabpage2.Controls.Add(groupBox3);
            tabControl1.TabPages.Add(tabpage2);
        }
        private void button2_Click(object sender, EventArgs e)
        {            
            if (radioButton3.Checked)
                countcorrect++;
            if (radioButton5.Checked)
                countcorrect++;
            if (radioButton9.Checked)
                countcorrect++;
            if (radioButton1_1.Checked)
                countcorrect++;
            if (radioButton2_3.Checked)
                countcorrect++;
            if (radioButton3_2.Checked)
                countcorrect++;
            MessageBox.Show($"Правильные ответы: {countcorrect}");
            countcorrect = 0;
        }
    }
}
