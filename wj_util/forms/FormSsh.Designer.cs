namespace WjUtil.forms
{
    partial class FormSsh
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
            this.comboBox_clients = new System.Windows.Forms.ComboBox();
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.textBox_command = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBox_clients
            // 
            this.comboBox_clients.FormattingEnabled = true;
            this.comboBox_clients.Location = new System.Drawing.Point(3, 4);
            this.comboBox_clients.Name = "comboBox_clients";
            this.comboBox_clients.Size = new System.Drawing.Size(121, 20);
            this.comboBox_clients.TabIndex = 5;
            this.comboBox_clients.SelectedIndexChanged += new System.EventHandler(this.comboBox_clients_SelectedIndexChanged);
            this.comboBox_clients.Click += new System.EventHandler(this.comboBox_clients_Click);
            // 
            // textBox_result
            // 
            this.textBox_result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_result.Location = new System.Drawing.Point(3, 31);
            this.textBox_result.Multiline = true;
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_result.Size = new System.Drawing.Size(794, 600);
            this.textBox_result.TabIndex = 3;
            this.textBox_result.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_result_KeyDown);
            // 
            // textBox_command
            // 
            this.textBox_command.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_command.Location = new System.Drawing.Point(130, 4);
            this.textBox_command.Name = "textBox_command";
            this.textBox_command.Size = new System.Drawing.Size(443, 21);
            this.textBox_command.TabIndex = 4;
            this.textBox_command.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox4_KeyDown);
            // 
            // FormSsh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 633);
            this.Controls.Add(this.comboBox_clients);
            this.Controls.Add(this.textBox_result);
            this.Controls.Add(this.textBox_command);
            this.Name = "FormSsh";
            this.Text = "FormSsh";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_clients;
        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.TextBox textBox_command;
    }
}