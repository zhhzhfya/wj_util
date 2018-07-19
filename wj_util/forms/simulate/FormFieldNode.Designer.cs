namespace WjUtil.forms
{
    partial class FormFieldNode
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
            this.radioButton_seq = new System.Windows.Forms.RadioButton();
            this.groupBox_type = new System.Windows.Forms.GroupBox();
            this.radioButton_bool = new System.Windows.Forms.RadioButton();
            this.radioButton_date = new System.Windows.Forms.RadioButton();
            this.radioButton_num = new System.Windows.Forms.RadioButton();
            this.radioButton_text = new System.Windows.Forms.RadioButton();
            this.textBox_ini_value = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton_random = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox_gen_type = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_len = new System.Windows.Forms.NumericUpDown();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox_type.SuspendLayout();
            this.groupBox_gen_type.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_len)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButton_seq
            // 
            this.radioButton_seq.AutoSize = true;
            this.radioButton_seq.Location = new System.Drawing.Point(6, 20);
            this.radioButton_seq.Name = "radioButton_seq";
            this.radioButton_seq.Size = new System.Drawing.Size(47, 16);
            this.radioButton_seq.TabIndex = 0;
            this.radioButton_seq.TabStop = true;
            this.radioButton_seq.Text = "递增";
            this.radioButton_seq.UseVisualStyleBackColor = true;
            // 
            // groupBox_type
            // 
            this.groupBox_type.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_type.Controls.Add(this.radioButton1);
            this.groupBox_type.Controls.Add(this.radioButton_bool);
            this.groupBox_type.Controls.Add(this.radioButton_date);
            this.groupBox_type.Controls.Add(this.radioButton_num);
            this.groupBox_type.Controls.Add(this.radioButton_text);
            this.groupBox_type.Location = new System.Drawing.Point(6, 1);
            this.groupBox_type.Name = "groupBox_type";
            this.groupBox_type.Size = new System.Drawing.Size(517, 53);
            this.groupBox_type.TabIndex = 13;
            this.groupBox_type.TabStop = false;
            // 
            // radioButton_bool
            // 
            this.radioButton_bool.AutoSize = true;
            this.radioButton_bool.Location = new System.Drawing.Point(169, 20);
            this.radioButton_bool.Name = "radioButton_bool";
            this.radioButton_bool.Size = new System.Drawing.Size(47, 16);
            this.radioButton_bool.TabIndex = 3;
            this.radioButton_bool.TabStop = true;
            this.radioButton_bool.Text = "Bool";
            this.radioButton_bool.UseVisualStyleBackColor = true;
            // 
            // radioButton_date
            // 
            this.radioButton_date.AutoSize = true;
            this.radioButton_date.Location = new System.Drawing.Point(116, 20);
            this.radioButton_date.Name = "radioButton_date";
            this.radioButton_date.Size = new System.Drawing.Size(47, 16);
            this.radioButton_date.TabIndex = 2;
            this.radioButton_date.TabStop = true;
            this.radioButton_date.Text = "日期";
            this.radioButton_date.UseVisualStyleBackColor = true;
            // 
            // radioButton_num
            // 
            this.radioButton_num.AutoSize = true;
            this.radioButton_num.Location = new System.Drawing.Point(63, 20);
            this.radioButton_num.Name = "radioButton_num";
            this.radioButton_num.Size = new System.Drawing.Size(47, 16);
            this.radioButton_num.TabIndex = 1;
            this.radioButton_num.TabStop = true;
            this.radioButton_num.Text = "数字";
            this.radioButton_num.UseVisualStyleBackColor = true;
            // 
            // radioButton_text
            // 
            this.radioButton_text.AutoSize = true;
            this.radioButton_text.Checked = true;
            this.radioButton_text.Location = new System.Drawing.Point(10, 20);
            this.radioButton_text.Name = "radioButton_text";
            this.radioButton_text.Size = new System.Drawing.Size(47, 16);
            this.radioButton_text.TabIndex = 0;
            this.radioButton_text.TabStop = true;
            this.radioButton_text.Text = "文本";
            this.radioButton_text.UseVisualStyleBackColor = true;
            // 
            // textBox_ini_value
            // 
            this.textBox_ini_value.Location = new System.Drawing.Point(53, 57);
            this.textBox_ini_value.Name = "textBox_ini_value";
            this.textBox_ini_value.Size = new System.Drawing.Size(191, 21);
            this.textBox_ini_value.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "初始值";
            // 
            // radioButton_random
            // 
            this.radioButton_random.AutoSize = true;
            this.radioButton_random.Location = new System.Drawing.Point(59, 20);
            this.radioButton_random.Name = "radioButton_random";
            this.radioButton_random.Size = new System.Drawing.Size(47, 16);
            this.radioButton_random.TabIndex = 1;
            this.radioButton_random.TabStop = true;
            this.radioButton_random.Text = "随机";
            this.radioButton_random.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(4, 137);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "确定";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox_gen_type
            // 
            this.groupBox_gen_type.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_gen_type.Controls.Add(this.radioButton_random);
            this.groupBox_gen_type.Controls.Add(this.radioButton3);
            this.groupBox_gen_type.Controls.Add(this.radioButton_seq);
            this.groupBox_gen_type.Location = new System.Drawing.Point(4, 84);
            this.groupBox_gen_type.Name = "groupBox_gen_type";
            this.groupBox_gen_type.Size = new System.Drawing.Size(519, 47);
            this.groupBox_gen_type.TabIndex = 10;
            this.groupBox_gen_type.TabStop = false;
            this.groupBox_gen_type.Text = "生成方式";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(112, 20);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(47, 16);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "固定";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "长度";
            // 
            // numericUpDown_len
            // 
            this.numericUpDown_len.Location = new System.Drawing.Point(285, 57);
            this.numericUpDown_len.Name = "numericUpDown_len";
            this.numericUpDown_len.Size = new System.Drawing.Size(51, 21);
            this.numericUpDown_len.TabIndex = 14;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(222, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 16);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "手机号";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // FormFieldNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 246);
            this.Controls.Add(this.groupBox_type);
            this.Controls.Add(this.textBox_ini_value);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox_gen_type);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown_len);
            this.Name = "FormFieldNode";
            this.Text = "FormFieldNode";
            this.groupBox_type.ResumeLayout(false);
            this.groupBox_type.PerformLayout();
            this.groupBox_gen_type.ResumeLayout(false);
            this.groupBox_gen_type.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_len)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton_seq;
        private System.Windows.Forms.GroupBox groupBox_type;
        private System.Windows.Forms.RadioButton radioButton_bool;
        private System.Windows.Forms.RadioButton radioButton_date;
        private System.Windows.Forms.RadioButton radioButton_num;
        private System.Windows.Forms.RadioButton radioButton_text;
        private System.Windows.Forms.TextBox textBox_ini_value;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton_random;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox_gen_type;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_len;
        private System.Windows.Forms.RadioButton radioButton1;

    }
}