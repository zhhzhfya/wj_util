namespace WjUtil.forms
{
    partial class FormSqlQuery
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
            this.textBox_sql = new System.Windows.Forms.TextBox();
            this.grid1 = new SourceGrid.Grid();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_run = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_beatiful = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_url = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_sql
            // 
            this.textBox_sql.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_sql.Location = new System.Drawing.Point(3, 28);
            this.textBox_sql.Multiline = true;
            this.textBox_sql.Name = "textBox_sql";
            this.textBox_sql.Size = new System.Drawing.Size(707, 119);
            this.textBox_sql.TabIndex = 0;
            this.textBox_sql.Text = "select * from wj_net limit 33";
            this.textBox_sql.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_sql_KeyDown);
            // 
            // grid1
            // 
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(2, 2);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(709, 309);
            this.grid1.TabIndex = 0;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_sql);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grid1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Size = new System.Drawing.Size(713, 467);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_run,
            this.toolStripSeparator1,
            this.toolStripButton_beatiful,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripLabel1,
            this.toolStripTextBox_url,
            this.toolStripComboBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(713, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_run
            // 
            this.toolStripButton_run.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_run.Image = global::WjUtil.Properties.Resources.server_go;
            this.toolStripButton_run.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_run.Name = "toolStripButton_run";
            this.toolStripButton_run.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_run.Text = "toolStripButton1";
            this.toolStripButton_run.ToolTipText = "执行脚本";
            this.toolStripButton_run.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_beatiful
            // 
            this.toolStripButton_beatiful.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_beatiful.Image = global::WjUtil.Properties.Resources.wand;
            this.toolStripButton_beatiful.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_beatiful.Name = "toolStripButton_beatiful";
            this.toolStripButton_beatiful.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_beatiful.Text = "toolStripButton1";
            this.toolStripButton_beatiful.ToolTipText = "美化sql";
            this.toolStripButton_beatiful.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::WjUtil.Properties.Resources.page_excel;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1_excel";
            this.toolStripButton1.ToolTipText = "导出Excel";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_2);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel1.Text = "地址";
            // 
            // toolStripTextBox_url
            // 
            this.toolStripTextBox_url.AutoCompleteCustomSource.AddRange(new string[] {
            "http://192.168.4.254:8080/wj/hessian",
            "http://192.168.4.254:8080/wj/hessian",
            "http://192.168.4.254:8080/wj/hessian",
            "http://192.168.4.254:8080/wj/hessian"});
            this.toolStripTextBox_url.Name = "toolStripTextBox_url";
            this.toolStripTextBox_url.Size = new System.Drawing.Size(300, 25);
            this.toolStripTextBox_url.Text = "http://192.168.4.254:8080/wj/hessian";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownWidth = 221;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "http://192.168.4.254:8080/wj/hessian",
            "http://192.168.4.254:8080/wj/hessian",
            "http://192.168.4.254:8080/wj/hessian",
            "http://192.168.4.254:8080/wj/hessian",
            "http://192.168.4.254:8080/wj/hessian"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(250, 25);
            // 
            // FormSqlQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 467);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormSqlQuery";
            this.Text = "FormSqlQuery";
            this.Load += new System.EventHandler(this.FormSqlQuery_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_sql;
        private SourceGrid.Grid grid1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_run;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_url;
        private System.Windows.Forms.ToolStripButton toolStripButton_beatiful;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
    }
}