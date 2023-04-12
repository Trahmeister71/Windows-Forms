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

namespace FileSearcher_folderBrowserDialog_
{
    public partial class Form1 : Form
    {
        string pathToFolder = "D:\\Documents\\Downloads\\";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            listBox1.Items.Clear();
            string[] astrFiles = Directory.GetFiles(pathToFolder);            
            foreach (string file in astrFiles)
            {
                if (file.EndsWith(textBox1.Text))
                { 
                    listBox1.Items.Add(file);
                    count++; 
                }
            }
            listBox1.Items.Add("Всего файлов: " + count);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                pathToFolder = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
