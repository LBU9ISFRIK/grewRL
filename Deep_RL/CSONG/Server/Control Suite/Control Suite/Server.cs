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
        private Label lblCount = new Label();
        public Label label;
        public TextBox total_entities = new TextBox();
        public TextBox textBox;
        private ListBox lstBox = new ListBox();
        public List<Label> labels = new List<Label>();
        public int P_X = 1, P_Y = 1, P_Z = 1, V_X = 1, V_Y = 1, V_Z = 1;

        public Server()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.AutoScroll = true;
            

            udpServer = new UdpClient(port);
            remoteEP = new IPEndPoint(IPAddress.Parse(strIP), port);


            panel1.BackColor = Color.White;
            for (int i = 1; i <= int.Parse(t_e_count.Text); i++)
            {
                Label label_entity = new Label();
                Label label_pos_X = new Label();
                Label label_pos_Y = new Label();
                Label label_pos_Z = new Label();

                Label label_vel_X = new Label();
                Label label_vel_Y = new Label();
                Label label_vel_Z = new Label();
                int height = 2;
                int distance_1 = 100;
                label_entity.Text = "Entity  " + i.ToString();
                label_entity.Location = new Point(1, panel1.Controls.Count * height);
                //label_entity.BackColor = Color.Gray;
                label_entity.Size = new Size(55, 16);

                label_pos_X.Text = "Pos X";
                label_pos_X.Location = new Point(80, panel1.Controls.Count * height);
                //label_pos_X.BackColor = Color.Gray;
                label_pos_X.Size = new Size(40, 16);

                label_pos_Y.Text = "Pos Y";
                label_pos_Y.Location = new Point(175, panel1.Controls.Count * height);
                //label_pos_Y.BackColor = Color.Gray;
                label_pos_Y.Size = new Size(40, 16);

                label_pos_Z.Text = "Pos Z";
                label_pos_Z.Location = new Point(270, panel1.Controls.Count * height);
                //label_pos_Z.BackColor = Color.Gray;
                label_pos_Z.Size = new Size(40, 16);

                label_vel_X.Text = "Vel X";
                label_vel_X.Location = new Point(390, panel1.Controls.Count * height);
                //label_vel_X.BackColor = Color.Gray;
                label_vel_X.Size = new Size(40, 16);

                label_vel_Y.Text = "Vel Y";
                label_vel_Y.Location = new Point(480, panel1.Controls.Count * height);
                //label_vel_Y.BackColor = Color.Gray;
                label_vel_Y.Size = new Size(40, 16);

                label_vel_Z.Text = "Vel Z";
                label_vel_Z.Location = new Point(570, panel1.Controls.Count * height);
                //label_vel_Z.BackColor = Color.Gray;
                label_vel_Z.Size = new Size(40, 16);

                panel1.Controls.Add(label_entity);
                panel1.Controls.Add(label_pos_X);
                panel1.Controls.Add(label_pos_Y);
                panel1.Controls.Add(label_pos_Z);
                panel1.Controls.Add(label_vel_X);
                panel1.Controls.Add(label_vel_Y);
                panel1.Controls.Add(label_vel_Z);

                AddNewTextBox_pos_X();
                AddNewTextBox_pos_Y();
                AddNewTextBox_pos_Z();
                AddNewTextBox_vel_X();
                AddNewTextBox_vel_Y();
                AddNewTextBox_vel_Z();

            }





        }
        public int margen_top = 26;
        public int textbox_w = 45;
        public System.Windows.Forms.TextBox AddNewTextBox_pos_X()
        {
            System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
            panel1.Controls.Add(txt);
            txt.Top = -margen_top + P_X * margen_top;
            txt.Left = 125;
            txt.Size = new System.Drawing.Size(textbox_w, 20);
            txt.Text = "10";
            P_X = P_X + 1;

            return txt;
        }

        public System.Windows.Forms.TextBox AddNewTextBox_pos_Y()
        {
            System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
            panel1.Controls.Add(txt);
            txt.Top = -margen_top + P_Y * margen_top;
            txt.Left = 220;
            txt.Size = new System.Drawing.Size(textbox_w, 20);
            txt.Text = "20";
            P_Y = P_Y + 1;

            return txt;
        }
        public System.Windows.Forms.TextBox AddNewTextBox_pos_Z()
        {
            System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
            panel1.Controls.Add(txt);
            txt.Top = -margen_top + P_Z * margen_top;
            txt.Left = 315;
            txt.Size = new System.Drawing.Size(textbox_w, 20);
            txt.Text = "30";
            P_Z = P_Z + 1;

            return txt;
        }

        public System.Windows.Forms.TextBox AddNewTextBox_vel_X()
        {
            System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
            panel1.Controls.Add(txt);
            txt.Top = -margen_top + V_X * margen_top;
            txt.Left = 435;
            txt.Size = new System.Drawing.Size(textbox_w, 20);
            txt.Text = "0";
            V_X = V_X + 1;

            return txt;
        }

        public System.Windows.Forms.TextBox AddNewTextBox_vel_Y()
        {
            System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
            panel1.Controls.Add(txt);
            txt.Top = -margen_top + V_Y * margen_top;
            txt.Left = 525;
            txt.Size = new System.Drawing.Size(textbox_w, 20);
            txt.Text = "0";
            V_Y = V_Y + 1;

            return txt;
        }
        public System.Windows.Forms.TextBox AddNewTextBox_vel_Z()
        {
            System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
            panel1.Controls.Add(txt);
            txt.Top = -margen_top + V_Z * margen_top;
            txt.Left = 615;
            txt.Size = new System.Drawing.Size(textbox_w, 20);
            txt.Text = "0";
            V_Z = V_Z + 1;

            return txt;
        }


        private void button3_Click(object sender, EventArgs e)
        {

            string send = g_s_width.Text;
            send += "$"+g_s_height.Text;
            send += "$" + t_s_x.Text;
            send += "$" + t_s_y.Text;
            send += "$" + t_e_count.Text;
            List<string> model_path = new List<string>(e_3d_model.Text.Split('\\'));
            string sourcePath = string.Join("/", model_path.ToArray());
            send += "$" + sourcePath;

            //send += "$" + e1_pos_x.Text + "$" + e1_pos_y.Text + "$" + e1_pos_z.Text;  //obstacle_1 pos(x, y, z)
            //send += "$" + e1_vel_x.Text + "$" + e1_vel_y.Text + "$" + e1_vel_z.Text;  //obstacle_1 vel(x, y, z)

            //send += "$" + e2_pos_x.Text + "$" + e2_pos_y.Text + "$" + e2_pos_z.Text;  //obstacle_2 pos(x, y, z)
            //send += "$" + e2_vel_x.Text + "$" + e2_vel_y.Text + "$" + e2_vel_z.Text;  //obstacle_2 vel(x, y, z)

            //send += "$" + e3_pos_x.Text + "$" + e3_pos_y.Text + "$" + e3_pos_z.Text;  //obstacle_3 pos(x, y, z)
            //send += "$" + e3_vel_x.Text + "$" + e3_vel_y.Text + "$" + e3_vel_z.Text;  //obstacle_3 vel(x, y, z)

            

            switch (choose_goal.Text)
            {
                case "Num 1":
                    send += "$"+ "Num 1" + "$"+ goal_tem1.Text;
                    break;
                case "Num 2":
                    send += "$" + "Num 2" + "$" + goal_tem2.Text;
                    break;
                case "Num 3":
                    send += "$" + "Num 3" + "$" + goal_tem3.Text;
                    break;
                case "Num 4":
                    send += "$" + "Num 4" + "$" + goal_tem4.Text;
                    break;
                default:
                    send += "$" + "Num 1" + "$" + goal_tem1.Text;
                    break;
            }

            switch (choose_reward.Text)
            {
                case "Num 1":
                    send += "$" + "Num 1" + "$" + reward_1.Text;
                    break;
                case "Num 2":
                    send += "$" + "Num 2" + "$" + reward_2.Text;
                    break;
                case "Num 3":
                    send += "$" + "Num 3" + "$" + reward_3.Text;
                    break;
                case "Num 4":
                    send += "$" + "Num 4" + "$" + reward_4.Text;
                    break;
                default:
                    send += "$" + "Num 1" + "$" + reward_1.Text;
                    break;
            }


            data = Encoding.Default.GetBytes(send);
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
                e_3d_model.Text = ofd_tb24.FileName;
            }
        }

        OpenFileDialog ofd_tb25 = new OpenFileDialog();

        private void button6_Click(object sender, EventArgs e)
        {
            if (ofd_tb25.ShowDialog() == DialogResult.OK)
            {
                goal_tem1.Text = ofd_tb25.FileName;
            }
        }

        OpenFileDialog ofd_tb26 = new OpenFileDialog();

        private void button7_Click(object sender, EventArgs e)
        {
            if (ofd_tb26.ShowDialog() == DialogResult.OK)
            {
                goal_tem2.Text = ofd_tb26.FileName;
            }
        }

        OpenFileDialog ofd_tb27 = new OpenFileDialog();

        private void button8_Click(object sender, EventArgs e)
        {
            if (ofd_tb27.ShowDialog() == DialogResult.OK)
            {
                goal_tem3.Text = ofd_tb27.FileName;
            }
        }

        OpenFileDialog ofd_tb28 = new OpenFileDialog();

        private void button9_Click(object sender, EventArgs e)
        {
            if (ofd_tb28.ShowDialog() == DialogResult.OK)
            {
                goal_tem4.Text = ofd_tb28.FileName;
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
            //gobject.DrawLine(grayPen, 10, 25, 1440, 25);
            // Down Line
           // gobject.DrawLine(grayPen, 10, 500, 1440, 500);

        }

        private void g_s_width_TextChanged(object sender, EventArgs e)
        {

        }

        private void choose_goal_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip9_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripComboBox5_Click(object sender, EventArgs e)
        {

        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            g_s_width.Text = "10";
            g_s_height.Text = "10";
            t_s_x.Text = "1000";
            t_s_y.Text = "1000";
            t_e_count.Text = "3";
            e_3d_model.Text = @"C:\Unity\Unity_learning\whnp3v2jflkw-Tree\Tree\Tree.fbx"; 
            
            ////obstacle_1 pos(x, y, z)
            //e1_pos_x.Text = "10";
            //e1_pos_y.Text = "2"; 
            //e1_pos_z.Text = "0";

            ////obstacle_1 vel(x, y, z)
            //e1_vel_x.Text = "0";
            //e1_vel_y.Text = "0";
            //e1_vel_z.Text = "0";

            ////obstacle_2 pos(x, y, z)
            //e2_pos_x.Text = "20";
            //e2_pos_y.Text = "2";
            //e2_pos_z.Text = "10";

            ////obstacle_2 vel(x, y, z)
            //e2_vel_x.Text = "0";
            //e2_vel_y.Text = "0";
            //e2_vel_z.Text = "0";

            ////obstacle_3 pos(x, y, z)
            //e3_pos_x.Text = "30";
            //e3_pos_y.Text = "2";
            //e3_pos_z.Text = "20";

            ////obstacle_3 vel(x, y, z)
            //e3_vel_x.Text = "0";
            //e3_vel_y.Text = "0";
            //e3_vel_z.Text = "0";



            choose_goal.Text = "Num 1";

            choose_reward.Text = "Num 1";
            

        }

        private void t_e_count_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
