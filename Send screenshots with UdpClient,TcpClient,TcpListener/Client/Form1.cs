using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private async void btn_Send_Click(object sender, EventArgs e)
        {
            try
            {
                var tcpClient = new TcpClient();
                tcpClient.Connect("127.0.0.1", 45001);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Client error: " + ex.Message);
            }
            var client = new UdpClient(45678);
            var ep = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                var bytes = client.Receive(ref ep);
                var str = Encoding.Default.GetString(bytes);
                textBox.Text = str;

                Thread.Sleep(5000);
            }
        }
    }
}
