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

namespace Control_Suite
{
    public partial class Server : Form
    {

        string strIP = "127.0.0.1";
        int port = 8000;

        UdpClient udpServer;
        IPEndPoint remoteEP;

        byte[] data;

        public Server()
        {
            InitializeComponent();
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            data = Encoding.Default.GetBytes(textBox1.Text);
            udpServer.Send(data, data.Length, remoteEP);
        }



        private void button1_Click(object sender, EventArgs e)
        {
           
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
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

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        OpenFileDialog ofd_tb24 = new OpenFileDialog();

        private void button5_Click(object sender, EventArgs e)
        {
            
            if (ofd_tb24.ShowDialog() == DialogResult.OK)
            {
                textBox24.Text = ofd_tb24.FileName;
            }
        }

        OpenFileDialog ofd_tb25 = new OpenFileDialog();

        private void button6_Click(object sender, EventArgs e)
        {
            if (ofd_tb25.ShowDialog() == DialogResult.OK)
            {
                textBox25.Text = ofd_tb25.FileName;
            }
        }

        OpenFileDialog ofd_tb26 = new OpenFileDialog();

        private void button7_Click(object sender, EventArgs e)
        {
            if (ofd_tb26.ShowDialog() == DialogResult.OK)
            {
                textBox26.Text = ofd_tb26.FileName;
            }
        }

        OpenFileDialog ofd_tb27 = new OpenFileDialog();

        private void button8_Click(object sender, EventArgs e)
        {
            if (ofd_tb27.ShowDialog() == DialogResult.OK)
            {
                textBox27.Text = ofd_tb27.FileName;
            }
        }

        OpenFileDialog ofd_tb28 = new OpenFileDialog();

        private void button9_Click(object sender, EventArgs e)
        {
            if (ofd_tb28.ShowDialog() == DialogResult.OK)
            {
                textBox28.Text = ofd_tb28.FileName;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics gobject = CreateGraphics();
            Brush gray = new SolidBrush(Color.Gray);
            Pen grayPen = new Pen(gray, 2);

            // Top line
            gobject.DrawLine(grayPen, 10, 25, 1440, 25);
            // Down Line
            gobject.DrawLine(grayPen, 10, 500, 1440, 500);

        }
    }
}
