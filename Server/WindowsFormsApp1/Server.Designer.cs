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
            this.checkedListBox6 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox5 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox4 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox3 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.state_size_label = new System.Windows.Forms.Label();
            this.state_joint_angularvelocity_label = new System.Windows.Forms.Label();
            this.state_joint_velocity_label = new System.Windows.Forms.Label();
            this.state_angularvelocity_label = new System.Windows.Forms.Label();
            this.state_velocity_label = new System.Windows.Forms.Label();
            this.state_rotation_label = new System.Windows.Forms.Label();
            this.state_position_label = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
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
            this.state_groupBox.Controls.Add(this.checkedListBox6);
            this.state_groupBox.Controls.Add(this.checkedListBox5);
            this.state_groupBox.Controls.Add(this.checkedListBox4);
            this.state_groupBox.Controls.Add(this.checkedListBox3);
            this.state_groupBox.Controls.Add(this.checkedListBox2);
            this.state_groupBox.Controls.Add(this.state_size_label);
            this.state_groupBox.Controls.Add(this.state_joint_angularvelocity_label);
            this.state_groupBox.Controls.Add(this.state_joint_velocity_label);
            this.state_groupBox.Controls.Add(this.state_angularvelocity_label);
            this.state_groupBox.Controls.Add(this.state_velocity_label);
            this.state_groupBox.Controls.Add(this.state_rotation_label);
            this.state_groupBox.Controls.Add(this.state_position_label);
            this.state_groupBox.Controls.Add(this.checkedListBox1);
            this.state_groupBox.Location = new System.Drawing.Point(6, 20);
            this.state_groupBox.Name = "state_groupBox";
            this.state_groupBox.Size = new System.Drawing.Size(295, 186);
            this.state_groupBox.TabIndex = 0;
            this.state_groupBox.TabStop = false;
            this.state_groupBox.Text = "State Space";
            // 
            // checkedListBox6
            // 
            this.checkedListBox6.CheckOnClick = true;
            this.checkedListBox6.ColumnWidth = 50;
            this.checkedListBox6.FormattingEnabled = true;
            this.checkedListBox6.Items.AddRange(new object[] {
            "x",
            "y",
            "z"});
            this.checkedListBox6.Location = new System.Drawing.Point(132, 158);
            this.checkedListBox6.MultiColumn = true;
            this.checkedListBox6.Name = "checkedListBox6";
            this.checkedListBox6.Size = new System.Drawing.Size(157, 20);
            this.checkedListBox6.TabIndex = 17;
            this.checkedListBox6.UseTabStops = false;
            this.checkedListBox6.SelectedIndexChanged += new System.EventHandler(this.UpdateCheckedStateCount);
            // 
            // checkedListBox5
            // 
            this.checkedListBox5.CheckOnClick = true;
            this.checkedListBox5.ColumnWidth = 50;
            this.checkedListBox5.FormattingEnabled = true;
            this.checkedListBox5.Items.AddRange(new object[] {
            "x",
            "y",
            "z"});
            this.checkedListBox5.Location = new System.Drawing.Point(132, 130);
            this.checkedListBox5.MultiColumn = true;
            this.checkedListBox5.Name = "checkedListBox5";
            this.checkedListBox5.Size = new System.Drawing.Size(157, 20);
            this.checkedListBox5.TabIndex = 16;
            this.checkedListBox5.UseTabStops = false;
            this.checkedListBox5.SelectedIndexChanged += new System.EventHandler(this.UpdateCheckedStateCount);
            // 
            // checkedListBox4
            // 
            this.checkedListBox4.CheckOnClick = true;
            this.checkedListBox4.ColumnWidth = 50;
            this.checkedListBox4.FormattingEnabled = true;
            this.checkedListBox4.Items.AddRange(new object[] {
            "x",
            "y",
            "z"});
            this.checkedListBox4.Location = new System.Drawing.Point(132, 102);
            this.checkedListBox4.MultiColumn = true;
            this.checkedListBox4.Name = "checkedListBox4";
            this.checkedListBox4.Size = new System.Drawing.Size(157, 20);
            this.checkedListBox4.TabIndex = 15;
            this.checkedListBox4.UseTabStops = false;
            this.checkedListBox4.SelectedIndexChanged += new System.EventHandler(this.UpdateCheckedStateCount);
            // 
            // checkedListBox3
            // 
            this.checkedListBox3.CheckOnClick = true;
            this.checkedListBox3.ColumnWidth = 50;
            this.checkedListBox3.FormattingEnabled = true;
            this.checkedListBox3.Items.AddRange(new object[] {
            "x",
            "y",
            "z"});
            this.checkedListBox3.Location = new System.Drawing.Point(132, 74);
            this.checkedListBox3.MultiColumn = true;
            this.checkedListBox3.Name = "checkedListBox3";
            this.checkedListBox3.Size = new System.Drawing.Size(157, 20);
            this.checkedListBox3.TabIndex = 14;
            this.checkedListBox3.UseTabStops = false;
            this.checkedListBox3.SelectedIndexChanged += new System.EventHandler(this.UpdateCheckedStateCount);
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.CheckOnClick = true;
            this.checkedListBox2.ColumnWidth = 50;
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Items.AddRange(new object[] {
            "x",
            "y",
            "z"});
            this.checkedListBox2.Location = new System.Drawing.Point(132, 46);
            this.checkedListBox2.MultiColumn = true;
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(157, 20);
            this.checkedListBox2.TabIndex = 13;
            this.checkedListBox2.UseTabStops = false;
            this.checkedListBox2.SelectedIndexChanged += new System.EventHandler(this.UpdateCheckedStateCount);
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
            // state_joint_velocity_label
            // 
            this.state_joint_velocity_label.AutoSize = true;
            this.state_joint_velocity_label.Location = new System.Drawing.Point(8, 134);
            this.state_joint_velocity_label.Margin = new System.Windows.Forms.Padding(5, 5, 5, 11);
            this.state_joint_velocity_label.Name = "state_joint_velocity_label";
            this.state_joint_velocity_label.Size = new System.Drawing.Size(77, 12);
            this.state_joint_velocity_label.TabIndex = 5;
            this.state_joint_velocity_label.Text = "joint_velocity";
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
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.ColumnWidth = 50;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "x",
            "y",
            "z"});
            this.checkedListBox1.Location = new System.Drawing.Point(132, 18);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(157, 20);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.UseTabStops = false;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.UpdateCheckedStateCount);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 351);
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

        }

        #endregion

        private System.Windows.Forms.Button send_button;
        private System.Windows.Forms.TextBox send_textBox;
        private System.Windows.Forms.Label leg_count_label;
        private System.Windows.Forms.GroupBox domain_groupBox;
        private System.Windows.Forms.GroupBox state_groupBox;
        private System.Windows.Forms.Label state_size_label;
        private System.Windows.Forms.Label state_joint_angularvelocity_label;
        private System.Windows.Forms.Label state_joint_velocity_label;
        private System.Windows.Forms.Label state_angularvelocity_label;
        private System.Windows.Forms.Label state_velocity_label;
        private System.Windows.Forms.Label state_rotation_label;
        private System.Windows.Forms.Label state_position_label;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox6;
        private System.Windows.Forms.CheckedListBox checkedListBox5;
        private System.Windows.Forms.CheckedListBox checkedListBox4;
        private System.Windows.Forms.CheckedListBox checkedListBox3;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
    }
}

