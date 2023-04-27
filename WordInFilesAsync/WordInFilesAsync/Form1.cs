using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordInFilesAsync
{
    public partial class Form1 : Form
    {
        int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        { 
            count = 0;
            try
            {
                string word = textBox2.Text;
                string path = textBox1.Text;
                string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    await Task.Run(() =>
                    {
                        using (StreamReader sr = new StreamReader(file))
                        {
                            string text = sr.ReadToEnd();
                            int value = Regex.Matches(text, textBox2.Text, RegexOptions.IgnoreCase).Count;
                            count += value;

                        }
                    });

                }
                listBox1.Items.Add($"Путь к директории {path}");
                listBox1.Items.Add($"Слово {word}");
                listBox1.Items.Add($"Количество слов в директории {count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"^[A-Za-z]:\\(?:[^\\]+\\)*[^\\]*$");
            if (!regex.IsMatch(textBox1.Text))
                textBox1.Text = "";
        }
    }
}
