using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApp1
{
    public partial class Server : Form
    {
        string strIP = "127.0.0.1";
        int port = 8000;

        UdpClient udpServer;
        IPEndPoint remoteEP;

        byte[] sendData;

        public Server()
        {
            InitializeComponent();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            udpServer = new UdpClient(port);
            remoteEP = new IPEndPoint(IPAddress.Parse(strIP), port);

            //데이터 받기
            //int length = socket.Receive(rBuffer, 0, rBuffer.Length, SocketFlags.None);

            //디코딩
            //string result = Encoding.UTF8.GetString(rBuffer);

            //label1.Text = "전송된 데이터 : ";
            //label1.Text += result + "\n";
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //int width = 10;
            string sendString = "LegCount:" + send_textBox.Text;
            sendString += "$StateType:position,torso_velocity";

            sendData = Encoding.Default.GetBytes(sendString);
            udpServer.Send(sendData, sendData.Length, remoteEP);
        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            udpServer.Close();
        }
    }
}
