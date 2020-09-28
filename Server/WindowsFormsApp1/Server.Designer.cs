namespace WindowsFormsApp1
{
    partial class Server
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.send_button = new System.Windows.Forms.Button();
            this.send_textBox = new System.Windows.Forms.TextBox();
            this.leg_count_label = new System.Windows.Forms.Label();
            this.domain_groupBox = new System.Windows.Forms.GroupBox();
            this.state_groupBox = new System.Windows.Forms.GroupBox();
            this.state_joint_collisionSensor_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.state_joint_collisionSensor_label = new System.Windows.Forms.Label();
            this.state_joint_angularvelocity_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.state_joint_angle_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.state_angularvelocity_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.state_velocity_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.state_rotation_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.state_size_label = new System.Windows.Forms.Label();
            this.state_joint_angularvelocity_label = new System.Windows.Forms.Label();
            this.state_joint_angle_label = new System.Windows.Forms.Label();
            this.state_angularvelocity_label = new System.Windows.Forms.Label();
            this.state_velocity_label = new System.Windows.Forms.Label();
            this.state_rotation_label = new System.Windows.Forms.Label();
            this.state_position_label = new System.Windows.Forms.Label();
            this.state_position_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.textBoxAgent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxGoal = new System.Windows.Forms.TextBox();
            this.domain_groupBox.SuspendLayout();
            this.state_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // send_button
            // 
            this.send_button.Location = new System.Drawing.Point(106, 312);
            this.send_button.Name = "send_button";
            this.send_button.Size = new System.Drawing.Size(130, 32);
            this.send_button.TabIndex = 0;
            this.send_button.Text = "Apply Changes";
            this.send_button.UseVisualStyleBackColor = true;
            this.send_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // send_textBox
            // 
            this.send_textBox.Location = new System.Drawing.Point(94, 265);
            this.send_textBox.Name = "send_textBox";
            this.send_textBox.Size = new System.Drawing.Size(100, 21);
            this.send_textBox.TabIndex = 2;
            this.send_textBox.Text = "6";
            this.send_textBox.TextChanged += new System.EventHandler(this.UpdateCheckedStateCount);
            this.send_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Only_Digit_KeyPress);
            // 
            // leg_count_label
            // 
            this.leg_count_label.AutoSize = true;
            this.leg_count_label.Location = new System.Drawing.Point(14, 268);
            this.leg_count_label.Name = "leg_count_label";
            this.leg_count_label.Size = new System.Drawing.Size(71, 12);
            this.leg_count_label.TabIndex = 3;
            this.leg_count_label.Text = "Leg Count :";
            // 
            // domain_groupBox
            // 
            this.domain_groupBox.CausesValidation = false;
            this.domain_groupBox.Controls.Add(this.state_groupBox);
            this.domain_groupBox.Controls.Add(this.leg_count_label);
            this.domain_groupBox.Controls.Add(this.send_textBox);
            this.domain_groupBox.Location = new System.Drawing.Point(12, 12);
            this.domain_groupBox.Name = "domain_groupBox";
            this.domain_groupBox.Size = new System.Drawing.Size(309, 294);
            this.domain_groupBox.TabIndex = 4;
            this.domain_groupBox.TabStop = false;
            this.domain_groupBox.Text = "Domain Editor";
            // 
            // state_groupBox
            // 
            this.state_groupBox.CausesValidation = false;
            this.state_groupBox.Controls.Add(this.state_joint_collisionSensor_checkedListBox);
            this.state_groupBox.Controls.Add(this.state_joint_collisionSensor_label);
            this.state_groupBox.Controls.Add(this.state_joint_angularvelocity_checkedListBox);
            this.state_groupBox.Controls.Add(this.state_joint_angle_checkedListBox);
            this.state_groupBox.Controls.Add(this.state_angularvelocity_checkedListBox);
            this.state_groupBox.Controls.Add(this.state_velocity_checkedListBox);
            this.state_groupBox.Controls.Add(this.state_rotation_checkedListBox);
            this.state_groupBox.Controls.Add(this.state_size_label);
            this.state_groupBox.Controls.Add(this.state_joint_angularvelocity_label);
            this.state_groupBox.Controls.Add(this.state_joint_angle_label);
            this.state_groupBox.Controls.Add(this.state_angularvelocity_label);
            this.state_groupBox.Controls.Add(this.state_velocity_label);
            this.state_groupBox.Controls.Add(this.state_rotation_label);
            this.state_groupBox.Controls.Add(this.state_position_label);
            this.state_groupBox.Controls.Add(this.state_position_checkedListBox);
            this.state_groupBox.Location = new System.Drawing.Point(6, 20);
            this.state_groupBox.Name = "state_groupBox";
            this.state_groupBox.Size = new System.Drawing.Size(295, 239);
            this.state_groupBox.TabIndex = 0;
            this.state_groupBox.TabStop = false;
            this.state_groupBox.Text = "State Space";
            // 
            // state_joint_collisionSensor_checkedListBox
            // 
            this.state_joint_collisionSensor_checkedListBox.CheckOnClick = true;
            this.state_joint_collisionSensor_checkedListBox.FormattingEnabled = true;
            this.state_joint_collisionSensor_checkedListBox.Items.AddRange(new object[] {
            " "});
            this.state_joint_collisionSensor_checkedListBox.Location = new System.Drawing.Point(132, 186);
            this.state_joint_collisionSensor_checkedListBox.Name = "state_joint_collisionSensor_checkedListBox";
            this.state_joint_collisionSensor_checkedListBox.Size = new System.Drawing.Size(157, 20);
            this.state_joint_collisionSensor_checkedListBox.TabIndex = 19;
            this.state_joint_collisionSensor_checkedListBox.UseTabStops = false;
            this.state_joint_collisionSensor_checkedListBox.SelectedIndexChanged += new System.EventHandler(this.UpdateCheckedStateCount);
            // 
            // state_joint_collisionSensor_label
            // 
            this.state_joint_collisionSensor_label.AutoSize = true;
            this.state_joint_collisionSensor_label.Location = new System.Drawing.Point(8, 190);
            this.state_joint_collisionSensor_label.Margin = new System.Windows.Forms.Padding(5, 5, 5, 11);
            this.state_joint_collisionSensor_label.Name = "state_joint_collisionSensor_label";
            this.state_joint_collisionSensor_label.Size = new System.Drawing.Size(121, 12);
            this.state_joint_collisionSensor_label.TabIndex = 18;
            this.state_joint_collisionSensor_label.Text = "joint_collisionSensor";
            // 
            // state_joint_angularvelocity_checkedListBox
            // 
            this.state_joint_angularvelocity_checkedListBox.CheckOnClick = true;
            this.state_joint_angularvelocity_checkedListBox.FormattingEnabled = true;
            this.state_joint_angularvelocity_checkedListBox.Items.AddRange(new object[] {
            " "});
            this.state_joint_angularvelocity_checkedListBox.Location = new System.Drawing.Point(132, 158);
            this.state_joint_angularvelocity_checkedListBox.Name = "state_joint_angularvelocity_checkedListBox";
            this.state_joint_angularvelocity_checkedListBox.Size = new System.Drawing.Size(157, 20);
            this.state_joint_angularvelocity_checkedListBox.TabIndex = 17;
            this.state_joint_angularvelocity_checkedListBox.UseTabStops = false;
            this.state_joint_angularvelocity_checkedListBox.SelectedIndexChanged += new System.EventHandler(this.UpdateCheckedStateCount);
            // 
            // state_joint_angle_checkedListBox
            // 
            this.state_joint_angle_checkedListBox.CheckOnClick = true;
            this.state_joint_angle_checkedListBox.FormattingEnabled = true;
            this.state_joint_angle_checkedListBox.Items.AddRange(new object[] {
            " "});
            this.state_joint_angle_checkedListBox.Location = new System.Drawing.Point(132, 130);
            this.state_joint_angle_checkedListBox.Name = "state_joint_angle_checkedListBox";
            this.state_joint_angle_checkedListBox.Size = new System.Drawing.Size(157, 20);
            this.state_joint_angle_checkedListBox.TabIndex = 16;
            this.state_joint_angle_checkedListBox.UseTabStops = false;
            this.state_joint_angle_checkedListBox.SelectedIndexChanged += new System.EventHandler(this.UpdateCheckedStateCount);
            // 
            // state_angularvelocity_checkedListBox
            // 
            this.state_angularvelocity_checkedListBox.CheckOnClick = true;
            this.state_angularvelocity_checkedListBox.ColumnWidth = 50;
            this.state_angularvelocity_checkedListBox.FormattingEnabled = true;
            this.state_angularvelocity_checkedListBox.Items.AddRange(new object[] {
            "x",
            "y",
            "z"});
            this.state_angularvelocity_checkedListBox.Location = new System.Drawing.Point(132, 102);
            this.state_angularvelocity_checkedListBox.MultiColumn = true;
            this.state_angularvelocity_checkedListBox.Name = "state_angularvelocity_checkedListBox";
            this.state_angularvelocity_checkedListBox.Size = new System.Drawing.Size(157, 20);
            this.state_angularvelocity_checkedListBox.TabIndex = 15;
            this.state_angularvelocity_checkedListBox.UseTabStops = false;
            this.state_angularvelocity_checkedListBox.SelectedIndexChanged += new System.EventHandler(this.UpdateCheckedStateCount);
            // 
            // state_velocity_checkedListBox
            // 
            this.state_velocity_checkedListBox.CheckOnClick = true;
            this.state_velocity_checkedListBox.ColumnWidth = 50;
            this.state_velocity_checkedListBox.FormattingEnabled = true;
            this.state_velocity_checkedListBox.Items.AddRange(new object[] {
            "x",
            "y",
            "z"});
            this.state_velocity_checkedListBox.Location = new System.Drawing.Point(132, 74);
            this.state_velocity_checkedListBox.MultiColumn = true;
            this.state_velocity_checkedListBox.Name = "state_velocity_checkedListBox";
            this.state_velocity_checkedListBox.Size = new System.Drawing.Size(157, 20);
            this.state_velocity_checkedListBox.TabIndex = 14;
            this.state_velocity_checkedListBox.UseTabStops = false;
            this.state_velocity_checkedListBox.SelectedIndexChanged += new System.EventHandler(this.UpdateCheckedStateCount);
            // 
            // state_rotation_checkedListBox
            // 
            this.state_rotation_checkedListBox.CheckOnClick = true;
            this.state_rotation_checkedListBox.ColumnWidth = 50;
            this.state_rotation_checkedListBox.FormattingEnabled = true;
            this.state_rotation_checkedListBox.Items.AddRange(new object[] {
            "x",
            "y",
            "z"});
            this.state_rotation_checkedListBox.Location = new System.Drawing.Point(132, 46);
            this.state_rotation_checkedListBox.MultiColumn = true;
            this.state_rotation_checkedListBox.Name = "state_rotation_checkedListBox";
            this.state_rotation_checkedListBox.Size = new System.Drawing.Size(157, 20);
            this.state_rotation_checkedListBox.TabIndex = 13;
            this.state_rotation_checkedListBox.UseTabStops = false;
            this.state_rotation_checkedListBox.SelectedIndexChanged += new System.EventHandler(this.UpdateCheckedStateCount);
            // 
            // state_size_label
            // 
            this.state_size_label.AutoSize = true;
            this.state_size_label.Location = new System.Drawing.Point(191, 0);
            this.state_size_label.Name = "state_size_label";
            this.state_size_label.Size = new System.Drawing.Size(86, 12);
            this.state_size_label.TabIndex = 12;
            this.state_size_label.Text = "space size : 0";
            // 
            // state_joint_angularvelocity_label
            // 
            this.state_joint_angularvelocity_label.AutoSize = true;
            this.state_joint_angularvelocity_label.Location = new System.Drawing.Point(8, 162);
            this.state_joint_angularvelocity_label.Margin = new System.Windows.Forms.Padding(5, 5, 5, 11);
            this.state_joint_angularvelocity_label.Name = "state_joint_angularvelocity_label";
            this.state_joint_angularvelocity_label.Size = new System.Drawing.Size(121, 12);
            this.state_joint_angularvelocity_label.TabIndex = 6;
            this.state_joint_angularvelocity_label.Text = "joint_angularVelocity";
            // 
            // state_joint_angle_label
            // 
            this.state_joint_angle_label.AutoSize = true;
            this.state_joint_angle_label.Location = new System.Drawing.Point(8, 134);
            this.state_joint_angle_label.Margin = new System.Windows.Forms.Padding(5, 5, 5, 11);
            this.state_joint_angle_label.Name = "state_joint_angle_label";
            this.state_joint_angle_label.Size = new System.Drawing.Size(65, 12);
            this.state_joint_angle_label.TabIndex = 5;
            this.state_joint_angle_label.Text = "joint_angle";
            // 
            // state_angularvelocity_label
            // 
            this.state_angularvelocity_label.AutoSize = true;
            this.state_angularvelocity_label.Location = new System.Drawing.Point(8, 106);
            this.state_angularvelocity_label.Margin = new System.Windows.Forms.Padding(5, 5, 5, 11);
            this.state_angularvelocity_label.Name = "state_angularvelocity_label";
            this.state_angularvelocity_label.Size = new System.Drawing.Size(92, 12);
            this.state_angularvelocity_label.TabIndex = 4;
            this.state_angularvelocity_label.Text = "angularVelocity";
            // 
            // state_velocity_label
            // 
            this.state_velocity_label.AutoSize = true;
            this.state_velocity_label.Location = new System.Drawing.Point(8, 78);
            this.state_velocity_label.Margin = new System.Windows.Forms.Padding(5, 5, 5, 11);
            this.state_velocity_label.Name = "state_velocity_label";
            this.state_velocity_label.Size = new System.Drawing.Size(48, 12);
            this.state_velocity_label.TabIndex = 3;
            this.state_velocity_label.Text = "velocity";
            // 
            // state_rotation_label
            // 
            this.state_rotation_label.AutoSize = true;
            this.state_rotation_label.Location = new System.Drawing.Point(8, 50);
            this.state_rotation_label.Margin = new System.Windows.Forms.Padding(5, 5, 5, 11);
            this.state_rotation_label.Name = "state_rotation_label";
            this.state_rotation_label.Size = new System.Drawing.Size(46, 12);
            this.state_rotation_label.TabIndex = 2;
            this.state_rotation_label.Text = "rotation";
            // 
            // state_position_label
            // 
            this.state_position_label.AutoSize = true;
            this.state_position_label.Location = new System.Drawing.Point(8, 22);
            this.state_position_label.Margin = new System.Windows.Forms.Padding(5, 5, 5, 11);
            this.state_position_label.Name = "state_position_label";
            this.state_position_label.Size = new System.Drawing.Size(49, 12);
            this.state_position_label.TabIndex = 1;
            this.state_position_label.Text = "position";
            // 
            // state_position_checkedListBox
            // 
            this.state_position_checkedListBox.CheckOnClick = true;
            this.state_position_checkedListBox.ColumnWidth = 50;
            this.state_position_checkedListBox.FormattingEnabled = true;
            this.state_position_checkedListBox.Items.AddRange(new object[] {
            "x",
            "y",
            "z"});
            this.state_position_checkedListBox.Location = new System.Drawing.Point(132, 18);
            this.state_position_checkedListBox.MultiColumn = true;
            this.state_position_checkedListBox.Name = "state_position_checkedListBox";
            this.state_position_checkedListBox.Size = new System.Drawing.Size(157, 20);
            this.state_position_checkedListBox.TabIndex = 0;
            this.state_position_checkedListBox.UseTabStops = false;
            this.state_position_checkedListBox.SelectedIndexChanged += new System.EventHandler(this.UpdateCheckedStateCount);
            // 
            // textBoxAgent
            // 
            this.textBoxAgent.Location = new System.Drawing.Point(384, 51);
            this.textBoxAgent.Name = "textBoxAgent";
            this.textBoxAgent.Size = new System.Drawing.Size(100, 21);
            this.textBoxAgent.TabIndex = 5;
            this.textBoxAgent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Only_Digit_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(341, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Agent";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(514, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Goal";
            // 
            // textBoxGoal
            // 
            this.textBoxGoal.Location = new System.Drawing.Point(557, 51);
            this.textBoxGoal.Name = "textBoxGoal";
            this.textBoxGoal.Size = new System.Drawing.Size(100, 21);
            this.textBoxGoal.TabIndex = 7;
            this.textBoxGoal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Only_Digit_KeyPress);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 351);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxGoal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxAgent);
            this.Controls.Add(this.domain_groupBox);
            this.Controls.Add(this.send_button);
            this.Name = "Server";
            this.Text = "Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Server_FormClosed);
            this.Load += new System.EventHandler(this.Server_Load);
            this.domain_groupBox.ResumeLayout(false);
            this.domain_groupBox.PerformLayout();
            this.state_groupBox.ResumeLayout(false);
            this.state_groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button send_button;
        private System.Windows.Forms.TextBox send_textBox;
        private System.Windows.Forms.Label leg_count_label;
        private System.Windows.Forms.GroupBox domain_groupBox;
        private System.Windows.Forms.GroupBox state_groupBox;
        private System.Windows.Forms.Label state_size_label;
        private System.Windows.Forms.Label state_joint_angularvelocity_label;
        private System.Windows.Forms.Label state_joint_angle_label;
        private System.Windows.Forms.Label state_angularvelocity_label;
        private System.Windows.Forms.Label state_velocity_label;
        private System.Windows.Forms.Label state_rotation_label;
        private System.Windows.Forms.Label state_position_label;
        private System.Windows.Forms.CheckedListBox state_position_checkedListBox;
        private System.Windows.Forms.CheckedListBox state_joint_angularvelocity_checkedListBox;
        private System.Windows.Forms.CheckedListBox state_joint_angle_checkedListBox;
        private System.Windows.Forms.CheckedListBox state_angularvelocity_checkedListBox;
        private System.Windows.Forms.CheckedListBox state_velocity_checkedListBox;
        private System.Windows.Forms.CheckedListBox state_rotation_checkedListBox;
        private System.Windows.Forms.CheckedListBox state_joint_collisionSensor_checkedListBox;
        private System.Windows.Forms.Label state_joint_collisionSensor_label;
        private System.Windows.Forms.TextBox textBoxAgent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxGoal;
    }
}

