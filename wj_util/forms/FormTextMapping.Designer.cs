namespace WjUtil.forms
{
    partial class FormTextMapping
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
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.textBox_sql1 = new System.Windows.Forms.TextBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.textBox_sql2 = new System.Windows.Forms.TextBox();
            this.textBox_sql3 = new System.Windows.Forms.TextBox();
            this.textBox_console = new System.Windows.Forms.TextBox();
            this.checkBox_auto_gen = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_result_rule = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_c2 = new System.Windows.Forms.TextBox();
            this.textBox_c1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer4
            // 
            this.splitContainer4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer4.Location = new System.Drawing.Point(2, 34);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.textBox_console);
            this.splitContainer4.Size = new System.Drawing.Size(880, 667);
            this.splitContainer4.SplitterDistance = 479;
            this.splitContainer4.TabIndex = 18;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.textBox_sql1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(880, 479);
            this.splitContainer2.SplitterDistance = 246;
            this.splitContainer2.TabIndex = 1;
            // 
            // textBox_sql1
            // 
            this.textBox_sql1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_sql1.Location = new System.Drawing.Point(0, 0);
            this.textBox_sql1.Multiline = true;
            this.textBox_sql1.Name = "textBox_sql1";
            this.textBox_sql1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_sql1.Size = new System.Drawing.Size(246, 479);
            this.textBox_sql1.TabIndex = 0;
            this.textBox_sql1.TextChanged += new System.EventHandler(this.textBox_hbase_sql_TextChanged);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.textBox_sql2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.textBox_sql3);
            this.splitContainer3.Size = new System.Drawing.Size(630, 479);
            this.splitContainer3.SplitterDistance = 315;
            this.splitContainer3.TabIndex = 0;
            // 
            // textBox_sql2
            // 
            this.textBox_sql2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_sql2.Location = new System.Drawing.Point(0, 0);
            this.textBox_sql2.Multiline = true;
            this.textBox_sql2.Name = "textBox_sql2";
            this.textBox_sql2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_sql2.Size = new System.Drawing.Size(315, 479);
            this.textBox_sql2.TabIndex = 1;
            this.textBox_sql2.TextChanged += new System.EventHandler(this.textBox_sql2_TextChanged);
            // 
            // textBox_sql3
            // 
            this.textBox_sql3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_sql3.Location = new System.Drawing.Point(0, 0);
            this.textBox_sql3.Multiline = true;
            this.textBox_sql3.Name = "textBox_sql3";
            this.textBox_sql3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_sql3.Size = new System.Drawing.Size(311, 479);
            this.textBox_sql3.TabIndex = 1;
            this.textBox_sql3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_sql3_KeyDown);
            // 
            // textBox_console
            // 
            this.textBox_console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_console.Location = new System.Drawing.Point(0, 0);
            this.textBox_console.Multiline = true;
            this.textBox_console.Name = "textBox_console";
            this.textBox_console.Size = new System.Drawing.Size(880, 184);
            this.textBox_console.TabIndex = 0;
            // 
            // checkBox_auto_gen
            // 
            this.checkBox_auto_gen.AutoSize = true;
            this.checkBox_auto_gen.Checked = true;
            this.checkBox_auto_gen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_auto_gen.Location = new System.Drawing.Point(616, 9);
            this.checkBox_auto_gen.Name = "checkBox_auto_gen";
            this.checkBox_auto_gen.Size = new System.Drawing.Size(72, 16);
            this.checkBox_auto_gen.TabIndex = 17;
            this.checkBox_auto_gen.Text = "自动生成";
            this.checkBox_auto_gen.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(234, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "输出：";
            // 
            // textBox_result_rule
            // 
            this.textBox_result_rule.Location = new System.Drawing.Point(281, 7);
            this.textBox_result_rule.Name = "textBox_result_rule";
            this.textBox_result_rule.Size = new System.Drawing.Size(334, 21);
            this.textBox_result_rule.TabIndex = 15;
            this.textBox_result_rule.Text = "2.3\t1.2,";
            this.textBox_result_rule.TextChanged += new System.EventHandler(this.textBox4_TextChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "文本列？->文本列？";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "->";
            // 
            // textBox_c2
            // 
            this.textBox_c2.Location = new System.Drawing.Point(202, 7);
            this.textBox_c2.Name = "textBox_c2";
            this.textBox_c2.Size = new System.Drawing.Size(24, 21);
            this.textBox_c2.TabIndex = 12;
            this.textBox_c2.Text = "5";
            this.textBox_c2.TextChanged += new System.EventHandler(this.textBox_c2_TextChanged);
            // 
            // textBox_c1
            // 
            this.textBox_c1.Location = new System.Drawing.Point(144, 7);
            this.textBox_c1.Name = "textBox_c1";
            this.textBox_c1.Size = new System.Drawing.Size(29, 21);
            this.textBox_c1.TabIndex = 11;
            this.textBox_c1.Text = "0";
            this.textBox_c1.TextChanged += new System.EventHandler(this.textBox_c1_TextChanged);
            // 
            // FormTextMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 702);
            this.Controls.Add(this.splitContainer4);
            this.Controls.Add(this.checkBox_auto_gen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_result_rule);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_c2);
            this.Controls.Add(this.textBox_c1);
            this.Name = "FormTextMapping";
            this.Text = "FormTextMapping";
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox textBox_sql1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TextBox textBox_sql2;
        private System.Windows.Forms.TextBox textBox_sql3;
        private System.Windows.Forms.TextBox textBox_console;
        private System.Windows.Forms.CheckBox checkBox_auto_gen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_result_rule;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_c2;
        private System.Windows.Forms.TextBox textBox_c1;
    }
}