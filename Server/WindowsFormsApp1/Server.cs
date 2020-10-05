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

            checkedListBoxes.Add(state_position_checkedListBox);
            checkedListBoxes.Add(state_rotation_checkedListBox);
            checkedListBoxes.Add(state_velocity_checkedListBox);
            checkedListBoxes.Add(state_angularvelocity_checkedListBox);
            checkedListBoxes.Add(state_joint_angle_checkedListBox);
            checkedListBoxes.Add(state_joint_angularvelocity_checkedListBox);
            checkedListBoxes.Add(state_joint_collisionSensor_checkedListBox);

            stateLabels.Add(state_position_label);
            stateLabels.Add(state_rotation_label);
            stateLabels.Add(state_velocity_label);
            stateLabels.Add(state_angularvelocity_label);
            stateLabels.Add(state_joint_angle_label);
            stateLabels.Add(state_joint_angularvelocity_label);
            stateLabels.Add(state_joint_collisionSensor_label);
        }

        private List<Label> stateLabels = new List<Label>();
        private List<CheckedListBox> checkedListBoxes = new List<CheckedListBox>();
        private void button1_Click(object sender, EventArgs e)
        {
            //int width = 10;
            string sendString = "LegCount:" + send_textBox.Text;

            string stateString = "$StateType,";
            for (int i = 0; i < checkedListBoxes.Count; i++)
            {
                for (int j = 0; j < checkedListBoxes[i].Items.Count; j++)
                {
                    if (checkedListBoxes[i].GetItemChecked(j))
                    {
                        stateString += stateLabels[i].Text + ":";
                        stateString += j + ",";
                    }
                }
            }
            sendString += stateString;

            string GoalString = string.Format("$Agent:{0},Goal:{1}", textBoxAgent.Text, textBoxGoal.Text);
            sendString += GoalString;

            sendData = Encoding.Default.GetBytes(sendString);
            udpServer.Send(sendData, sendData.Length, remoteEP);
        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            udpServer.Close();
        }

        private void UpdateCheckedStateCount(object sender, EventArgs e)
        {
            state_size_label.Text = string.Format("space size : {0}", GetCheckedStateCount());
        }

        private int GetCheckedStateCount()
        {
            int count = 0;
            for (int i = 0; i < checkedListBoxes.Count; i++)
            {
                int plusCount = 1;
                if (checkedListBoxes[i].Name.Contains("joint_"))
                {
                    int.TryParse(send_textBox.Text, out plusCount);
                    if(!checkedListBoxes[i].Name.Contains("collisionSensor"))
                        plusCount *= 2;
                }

                for (int j = 0; j < checkedListBoxes[i].Items.Count; j++)
                {
                    if (checkedListBoxes[i].GetItemChecked(j))
                        count += plusCount;
                }
            }

            return count;
        }

        //정수만 입력
        private void Only_Digit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
                e.Handled = !char.IsDigit(e.KeyChar);
        }
    }
}
