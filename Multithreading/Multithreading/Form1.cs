using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multithreading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Clear();
            string[] disks = Directory.GetLogicalDrives();
            foreach (string disksPath in disks)
                comboBox1.Items.Add(disksPath);
            comboBox1.SelectedItem = comboBox1.Items[0];

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            listView1.Items.Clear();

            List<string[]> list = SearchFiles(comboBox1.SelectedItem.ToString(), textBox1.Text);
            foreach (var l in list)
            {
                listView1.Items.Add(new ListViewItem(l));
                count++;
            }
            label4.Text = $"Резульатта поиска: количество наайденных фалйов - {count}";
        }

        public List<string[]> SearchFiles(string path, string mask)
        {
            List<string[]> list = new List<string[]>();
            FileInfo fileinfo;
            try
            {
                if (checkBox1.Checked)
                {
                    foreach (string file in Directory.EnumerateFiles(path, mask, SearchOption.AllDirectories))
                    {
                        try
                        {
                            if (textBox2.Text != "")
                            {
                                using (StreamReader streamReader = new StreamReader(file))
                                {
                                    string line = streamReader.ReadToEnd();

                                    if (!line.Contains(textBox2.Text))
                                        continue;

                                }
                            }
                            fileinfo = new FileInfo(file);
                            list.Add(new[] { fileinfo.Name, fileinfo.FullName, fileinfo.Length.ToString()+" байт",
                        fileinfo.LastWriteTime.ToString() });

                        }
                        catch (UnauthorizedAccessException ex) { }

                    }
                }
                else
                {
                    foreach (string file in Directory.EnumerateFiles(path, mask))
                    {
                        try
                        {
                            if (textBox2.Text != "")
                            {
                                using (StreamReader streamReader = new StreamReader(file))
                                {
                                    string line = streamReader.ReadToEnd();

                                    if (!line.Contains(textBox2.Text))
                                        continue;

                                }
                            }
                            fileinfo = new FileInfo(file);
                            list.Add(new[] { fileinfo.Name, fileinfo.FullName, fileinfo.Length.ToString()+" байт",
                            fileinfo.LastWriteTime.ToString() });

                        }
                        catch (UnauthorizedAccessException ex) { }

                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {

            }
            return list;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            listView1.Items.Clear();
        }
    }
}
