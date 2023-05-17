using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkProgrammming
{
    public partial class Form1 : Form
    {
        Thread thread;
        public Form1()
        {
            InitializeComponent();
            
        }
        void ThreadFuncReceive()
        {
            try
            {
                while (true)
                {
                    //connection to the local host
                    UdpClient uClient = new UdpClient(int.Parse(textBox3.Text));
                    IPEndPoint ipEnd = null;
                    //receiving datagramm
                    byte[] responce = uClient.Receive(ref ipEnd);
                    //conversion to a string
                    string strResult = Encoding.Unicode.GetString(responce);
                    //output to the screen
                    listView1.Items.Add(strResult);
                    listView1.Items[listView1.Items.Count - 1].ForeColor = Color.Green;
                    uClient.Close();
                }
            }
            catch (SocketException sockEx)
            {
                Console.WriteLine("Socket exception: " + sockEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.Message);
            }
        }

        void SendData(string datagramm)
        {
            UdpClient uClient = new UdpClient();
            //connecting to a remote host
            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse(textBox1.Text), int.Parse(textBox2.Text));
            try
            {
                byte[] bytes = Encoding.Unicode.GetBytes(datagramm);
                uClient.Send(bytes, bytes.Length, ipEnd);
            }
            catch (SocketException sockEx)
            {
                Console.WriteLine("Socket exception: " + sockEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.Message);
            }
            finally
            {
                //close the UdpClient class instance
                uClient.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(ThreadFuncReceive));
            thread.IsBackground = true;
            thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendData(textBox4.Text);
            listView1.Items.Add(textBox4.Text);
            listView1.Items[listView1.Items.Count - 1].ForeColor = Color.Red;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
