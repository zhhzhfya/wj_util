namespace WjUtil.forms
{
    partial class FormKafka
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
            this.textBox_kafka_consumer = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_metadata_broker = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_zk_connect = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.button_producer = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button_consumer = new System.Windows.Forms.Button();
            this.textBox_group = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_topic = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_kafka_consumer
            // 
            this.textBox_kafka_consumer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_kafka_consumer.Location = new System.Drawing.Point(5, 149);
            this.textBox_kafka_consumer.Multiline = true;
            this.textBox_kafka_consumer.Name = "textBox_kafka_consumer";
            this.textBox_kafka_consumer.Size = new System.Drawing.Size(956, 518);
            this.textBox_kafka_consumer.TabIndex = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.textBox_metadata_broker);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.textBox_zk_connect);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.button_producer);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.textBox5);
            this.groupBox4.Controls.Add(this.button_consumer);
            this.groupBox4.Controls.Add(this.textBox_group);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.textBox_topic);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(5, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(955, 138);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            // 
            // textBox_metadata_broker
            // 
            this.textBox_metadata_broker.Location = new System.Drawing.Point(122, 47);
            this.textBox_metadata_broker.Name = "textBox_metadata_broker";
            this.textBox_metadata_broker.Size = new System.Drawing.Size(709, 21);
            this.textBox_metadata_broker.TabIndex = 11;
            this.textBox_metadata_broker.Text = "192.168.2.212:9092,192.168.2.213:9092,192.168.2.214:9092";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 50);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(101, 12);
            this.label16.TabIndex = 10;
            this.label16.Text = "metadata.broker:";
            // 
            // textBox_zk_connect
            // 
            this.textBox_zk_connect.Location = new System.Drawing.Point(122, 20);
            this.textBox_zk_connect.Name = "textBox_zk_connect";
            this.textBox_zk_connect.Size = new System.Drawing.Size(709, 21);
            this.textBox_zk_connect.TabIndex = 9;
            this.textBox_zk_connect.Text = "192.168.2.212:2181,192.168.2.213:2181,192.168.2.214:2181";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 12);
            this.label15.TabIndex = 8;
            this.label15.Text = "zookeeper.connect:";
            // 
            // button_producer
            // 
            this.button_producer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_producer.Location = new System.Drawing.Point(874, 99);
            this.button_producer.Name = "button_producer";
            this.button_producer.Size = new System.Drawing.Size(75, 23);
            this.button_producer.TabIndex = 7;
            this.button_producer.Text = "发送";
            this.button_producer.UseVisualStyleBackColor = true;
            this.button_producer.Click += new System.EventHandler(this.button_producer_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(63, 104);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 6;
            this.label14.Text = "message:";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Location = new System.Drawing.Point(122, 101);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(746, 21);
            this.textBox5.TabIndex = 5;
            this.textBox5.Text = "123";
            // 
            // button_consumer
            // 
            this.button_consumer.Location = new System.Drawing.Point(473, 73);
            this.button_consumer.Name = "button_consumer";
            this.button_consumer.Size = new System.Drawing.Size(75, 23);
            this.button_consumer.TabIndex = 4;
            this.button_consumer.Text = "接收";
            this.button_consumer.UseVisualStyleBackColor = true;
            this.button_consumer.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_group
            // 
            this.textBox_group.Location = new System.Drawing.Point(367, 74);
            this.textBox_group.Name = "textBox_group";
            this.textBox_group.Size = new System.Drawing.Size(100, 21);
            this.textBox_group.TabIndex = 3;
            this.textBox_group.Text = "test";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(320, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "group:";
            // 
            // textBox_topic
            // 
            this.textBox_topic.Location = new System.Drawing.Point(122, 74);
            this.textBox_topic.Name = "textBox_topic";
            this.textBox_topic.Size = new System.Drawing.Size(192, 21);
            this.textBox_topic.TabIndex = 1;
            this.textBox_topic.Text = "wj_net";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(75, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "topic:";
            // 
            // FormKafka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 671);
            this.Controls.Add(this.textBox_kafka_consumer);
            this.Controls.Add(this.groupBox4);
            this.Name = "FormKafka";
            this.Text = "FormKafka";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_kafka_consumer;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox_metadata_broker;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox_zk_connect;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button_producer;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button_consumer;
        private System.Windows.Forms.TextBox textBox_group;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_topic;
        private System.Windows.Forms.Label label9;
    }
}