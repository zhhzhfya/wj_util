namespace WjUtil.forms
{
    partial class FormStringUtils
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
            this.checkBox_xg_to2 = new System.Windows.Forms.CheckBox();
            this.checkBox_replaceStrs = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtBox_del_end_chr = new System.Windows.Forms.TextBox();
            this.textBox_replaceStrs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox2_trim = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox_concat = new System.Windows.Forms.CheckBox();
            this.checkBox_mpp_sql = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_in = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox_xg_to2
            // 
            this.checkBox_xg_to2.AutoSize = true;
            this.checkBox_xg_to2.Location = new System.Drawing.Point(179, 55);
            this.checkBox_xg_to2.Name = "checkBox_xg_to2";
            this.checkBox_xg_to2.Size = new System.Drawing.Size(78, 16);
            this.checkBox_xg_to2.TabIndex = 19;
            this.checkBox_xg_to2.Text = "替换\\为\\\\";
            this.checkBox_xg_to2.UseVisualStyleBackColor = true;
            this.checkBox_xg_to2.CheckedChanged += new System.EventHandler(this.checkBox_xg_to2_CheckedChanged);
            // 
            // checkBox_replaceStrs
            // 
            this.checkBox_replaceStrs.AutoSize = true;
            this.checkBox_replaceStrs.Location = new System.Drawing.Point(280, 55);
            this.checkBox_replaceStrs.Name = "checkBox_replaceStrs";
            this.checkBox_replaceStrs.Size = new System.Drawing.Size(96, 16);
            this.checkBox_replaceStrs.TabIndex = 18;
            this.checkBox_replaceStrs.Text = "替换字符为空";
            this.checkBox_replaceStrs.UseVisualStyleBackColor = true;
            this.checkBox_replaceStrs.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_2);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(8, 98);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox3);
            this.splitContainer1.Size = new System.Drawing.Size(1068, 665);
            this.splitContainer1.SplitterDistance = 261;
            this.splitContainer1.TabIndex = 10;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(1068, 261);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // textBox3
            // 
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox3.Location = new System.Drawing.Point(0, 0);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox3.Size = new System.Drawing.Size(1068, 400);
            this.textBox3.TabIndex = 0;
            this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyDown);
            // 
            // txtBox_del_end_chr
            // 
            this.txtBox_del_end_chr.Location = new System.Drawing.Point(316, 18);
            this.txtBox_del_end_chr.Name = "txtBox_del_end_chr";
            this.txtBox_del_end_chr.Size = new System.Drawing.Size(55, 21);
            this.txtBox_del_end_chr.TabIndex = 17;
            this.txtBox_del_end_chr.Text = ",";
            this.txtBox_del_end_chr.TextChanged += new System.EventHandler(this.txtBox_del_end_chr_TextChanged);
            // 
            // textBox_replaceStrs
            // 
            this.textBox_replaceStrs.Location = new System.Drawing.Point(382, 53);
            this.textBox_replaceStrs.Name = "textBox_replaceStrs";
            this.textBox_replaceStrs.Size = new System.Drawing.Size(214, 21);
            this.textBox_replaceStrs.TabIndex = 12;
            this.textBox_replaceStrs.Text = "STRING,DATE,NUMBER,INT,BOOLEAN";
            this.textBox_replaceStrs.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "删除结尾符号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "结尾字符：";
            // 
            // checkBox2_trim
            // 
            this.checkBox2_trim.AutoSize = true;
            this.checkBox2_trim.Checked = true;
            this.checkBox2_trim.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2_trim.Location = new System.Drawing.Point(11, 55);
            this.checkBox2_trim.Name = "checkBox2_trim";
            this.checkBox2_trim.Size = new System.Drawing.Size(60, 16);
            this.checkBox2_trim.TabIndex = 15;
            this.checkBox2_trim.Text = "行trim";
            this.checkBox2_trim.UseVisualStyleBackColor = true;
            this.checkBox2_trim.CheckedChanged += new System.EventHandler(this.checkBox2_trim_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(77, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(72, 21);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "\',\'";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // checkBox_concat
            // 
            this.checkBox_concat.AutoSize = true;
            this.checkBox_concat.Checked = true;
            this.checkBox_concat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_concat.Location = new System.Drawing.Point(155, 20);
            this.checkBox_concat.Name = "checkBox_concat";
            this.checkBox_concat.Size = new System.Drawing.Size(72, 16);
            this.checkBox_concat.TabIndex = 14;
            this.checkBox_concat.Text = "合并一行";
            this.checkBox_concat.UseVisualStyleBackColor = true;
            // 
            // checkBox_mpp_sql
            // 
            this.checkBox_mpp_sql.AutoSize = true;
            this.checkBox_mpp_sql.Location = new System.Drawing.Point(69, 55);
            this.checkBox_mpp_sql.Name = "checkBox_mpp_sql";
            this.checkBox_mpp_sql.Size = new System.Drawing.Size(96, 16);
            this.checkBox_mpp_sql.TabIndex = 20;
            this.checkBox_mpp_sql.Text = "替换字符为空";
            this.checkBox_mpp_sql.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkBox_in);
            this.groupBox1.Controls.Add(this.checkBox_mpp_sql);
            this.groupBox1.Controls.Add(this.checkBox_xg_to2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBox_replaceStrs);
            this.groupBox1.Controls.Add(this.checkBox_concat);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.txtBox_del_end_chr);
            this.groupBox1.Controls.Add(this.checkBox2_trim);
            this.groupBox1.Controls.Add(this.textBox_replaceStrs);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1068, 81);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "过滤条件";
            // 
            // checkBox_in
            // 
            this.checkBox_in.AutoSize = true;
            this.checkBox_in.Checked = true;
            this.checkBox_in.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_in.Location = new System.Drawing.Point(382, 20);
            this.checkBox_in.Name = "checkBox_in";
            this.checkBox_in.Size = new System.Drawing.Size(78, 16);
            this.checkBox_in.TabIndex = 21;
            this.checkBox_in.Text = "IN Format";
            this.checkBox_in.UseVisualStyleBackColor = true;
            // 
            // FormStringUtils
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 769);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormStringUtils";
            this.Text = "FormStringUtils";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_xg_to2;
        private System.Windows.Forms.CheckBox checkBox_replaceStrs;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtBox_del_end_chr;
        private System.Windows.Forms.TextBox textBox_replaceStrs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox2_trim;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox_concat;
        private System.Windows.Forms.CheckBox checkBox_mpp_sql;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_in;

    }
}