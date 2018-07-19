namespace wj_util
{
    partial class FormServerInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_rm_ips = new System.Windows.Forms.TextBox();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_test = new System.Windows.Forms.Button();
            this.label_note = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox_pre_run_script = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(83, 68);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(212, 21);
            this.textBox_password.TabIndex = 16;
            this.textBox_password.Text = "123456";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 15;
            this.label10.Text = "密码：";
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(83, 41);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(212, 21);
            this.textBox_username.TabIndex = 14;
            this.textBox_username.Text = "root";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "用户：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "远程IPS：";
            // 
            // textBox_rm_ips
            // 
            this.textBox_rm_ips.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_rm_ips.Location = new System.Drawing.Point(83, 12);
            this.textBox_rm_ips.Name = "textBox_rm_ips";
            this.textBox_rm_ips.Size = new System.Drawing.Size(332, 21);
            this.textBox_rm_ips.TabIndex = 11;
            this.textBox_rm_ips.Text = "192.168.8.245";
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.Location = new System.Drawing.Point(259, 186);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 17;
            this.button_ok.Text = "确定";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_test
            // 
            this.button_test.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_test.Location = new System.Drawing.Point(178, 186);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(75, 23);
            this.button_test.TabIndex = 18;
            this.button_test.Text = "测试连接";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Click += new System.EventHandler(this.button2_Click);
            // 
            // label_note
            // 
            this.label_note.AutoSize = true;
            this.label_note.Location = new System.Drawing.Point(12, 191);
            this.label_note.Name = "label_note";
            this.label_note.Size = new System.Drawing.Size(23, 12);
            this.label_note.TabIndex = 19;
            this.label_note.Text = "...";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(340, 186);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 20;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox_pre_run_script
            // 
            this.textBox_pre_run_script.Location = new System.Drawing.Point(83, 95);
            this.textBox_pre_run_script.Multiline = true;
            this.textBox_pre_run_script.Name = "textBox_pre_run_script";
            this.textBox_pre_run_script.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_pre_run_script.Size = new System.Drawing.Size(332, 85);
            this.textBox_pre_run_script.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "执行脚本：";
            // 
            // FormServerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 221);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_pre_run_script);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label_note);
            this.Controls.Add(this.button_test);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_rm_ips);
            this.Name = "FormServerInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "服务器配置信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_rm_ips;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_test;
        private System.Windows.Forms.Label label_note;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox_pre_run_script;
        private System.Windows.Forms.Label label1;

    }
}