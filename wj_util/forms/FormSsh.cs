using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using wj_util;
using wj_util.events;

namespace WjUtil.forms
{
    public partial class FormSsh : Form
    {
        private static SshClient client;
        private static ShellStream stream;
        private static StreamReader reader;
        private static StreamWriter writer;
        public FormSsh()
        {
            InitializeComponent();
            // 订阅服务配置改变的事件
            EventBusHelper.getBus().Subscribe<ServerChangeEvent<List<String>>>(s =>
            {
                reAddServerCheckboxs();
            });
            reAddServerCheckboxs();
        }

        private void reAddServerCheckboxs()
        {
            List<Control> list = FormServerInfo.getSftpCheckBoxs();
            this.comboBox_clients.Items.Clear();
            foreach (var c in list)
            {
                this.comboBox_clients.Items.Add(c.Text);
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (e.KeyValue == 13)
            {
                if (client == null)
                {
                    MessageBox.Show("请选择一个连接");
                    return;
                }
                string cmdTxt = String.IsNullOrEmpty(this.textBox_command.Text) ? "\n" : this.textBox_command.Text;
                this.textBox_command.Text = "";
                string result = SendCommand(stream, cmdTxt);/// client.RunCommand(this.textBox_command.Text).Result.Replace("\n", "\r\n");
                sb.Append(result);
                //Console.WriteLine(sb.ToString());
                this.textBox_result.AppendText(sb.ToString());
                this.textBox_result.ScrollToCaret();
            }
        }

        private static string SendCommand(ShellStream stream, string customCMD)
        {
            writer.AutoFlush = true;
            writer.WriteLine(customCMD);
            while (!stream.DataAvailable)
                Thread.Sleep(10);
            return reader.ReadToEnd();
        }
        private void comboBox_clients_Click(object sender, EventArgs e)
        {
            this.comboBox_clients.DroppedDown = true;
        }

        private void comboBox_clients_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ip = (string)this.comboBox_clients.SelectedItem;
            client = FormServerInfo.getSshClient(ip);
            if (!client.IsConnected)
            {
                client.Connect();
            }
            stream = client.CreateShellStream("terminalName1", 80, 24, 800, 600, 1024);
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
        }

        private void textBox_result_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }
    }
}
