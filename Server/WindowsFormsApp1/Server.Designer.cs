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
            this.receive_data_label = new System.Windows.Forms.Label();
            this.send_textBox = new System.Windows.Forms.TextBox();
            this.leg_count_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // send_button
            // 
            this.send_button.Location = new System.Drawing.Point(92, 76);
            this.send_button.Name = "send_button";
            this.send_button.Size = new System.Drawing.Size(75, 23);
            this.send_button.TabIndex = 0;
            this.send_button.Text = "Send";
            this.send_button.UseVisualStyleBackColor = true;
            this.send_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // receive_data_label
            // 
            this.receive_data_label.AutoSize = true;
            this.receive_data_label.Location = new System.Drawing.Point(198, 9);
            this.receive_data_label.Name = "receive_data_label";
            this.receive_data_label.Size = new System.Drawing.Size(74, 12);
            this.receive_data_label.TabIndex = 1;
            this.receive_data_label.Text = "receive data";
            // 
            // send_textBox
            // 
            this.send_textBox.Location = new System.Drawing.Point(92, 6);
            this.send_textBox.Name = "send_textBox";
            this.send_textBox.Size = new System.Drawing.Size(100, 21);
            this.send_textBox.TabIndex = 2;
            this.send_textBox.Text = "6";
            // 
            // leg_count_label
            // 
            this.leg_count_label.AutoSize = true;
            this.leg_count_label.Location = new System.Drawing.Point(12, 9);
            this.leg_count_label.Name = "leg_count_label";
            this.leg_count_label.Size = new System.Drawing.Size(71, 12);
            this.leg_count_label.TabIndex = 3;
            this.leg_count_label.Text = "Leg Count :";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.leg_count_label);
            this.Controls.Add(this.send_textBox);
            this.Controls.Add(this.receive_data_label);
            this.Controls.Add(this.send_button);
            this.Name = "Server";
            this.Text = "Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Server_FormClosed);
            this.Load += new System.EventHandler(this.Server_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button send_button;
        private System.Windows.Forms.Label receive_data_label;
        private System.Windows.Forms.TextBox send_textBox;
        private System.Windows.Forms.Label leg_count_label;
    }
}

