using wj_util;
using Renci.SshNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Redbus.Interfaces;
using Redbus;
using wj_util.events;

namespace wj_util
{
    public partial class FormServerInfo : Form
    {
        public static bool locks {get; set;}
        string rmIps { get; set; }
        string userName { get; set; }
        string passWord { get; set; }

        static Hashtable sftpTable = new Hashtable();
        static Hashtable sshTable = new Hashtable();

        public FormServerInfo()
        {
            InitializeComponent();
            if (locks)
            {
                this.button_ok.Enabled = false;
                this.button_test.Enabled = false;
                this.label_note.Text = "连接信息存在引用，不能修改";
            }
            // 加载保存的配置
            /// TODO
        }
        static Boolean test = false;
        private void button2_Click(object sender, EventArgs e)
        {
            preInitServers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!test)
            {
                preInitServers();
            }
            if (test)
            {
                List<String> l = new List<String>();
                EventBusHelper.getBus().Publish(new ServerChangeEvent<List<String>>(l));
                this.Dispose();
            }
        }

        private void preInitServers()
        {
            if (string.IsNullOrEmpty(this.textBox_rm_ips.Text) || string.IsNullOrEmpty(this.textBox_username.Text) || string.IsNullOrEmpty(this.textBox_password.Text))
            {
                MessageBox.Show("请输入服务器的配置");
                return;
            }
            if (initServers())
            {
                test = true;
                this.label_note.Text = "连接成功";
            }
        }

        private bool initServers()
        {
            rmIps = this.textBox_rm_ips.Text;
            userName = this.textBox_username.Text;
            passWord = this.textBox_password.Text;

            StringBuilder sb = new StringBuilder();
            string[] ips = Regex.Split(rmIps, ",", RegexOptions.IgnoreCase);
            foreach (var ip in ips)
            {
                ConnectionInfo connectionInfo = new ConnectionInfo(ip, userName, new PasswordAuthenticationMethod(userName, passWord));
                SftpClient sftp = new SftpClient(connectionInfo);
                try
                {
                    sftp.Connect();
                    
                    if (sftp.IsConnected)
                    {
                        if (sftpTable.ContainsKey(ip))
                        {
                            ((SftpClient)sftpTable[ip]).Disconnect();
                            sftpTable.Remove(ip);
                        }
                        sftpTable.Add(ip, sftp);
                    }
                }
                catch (Exception e)
                {
                    sb.Append(ip + "：服务器连接异常"+e.Message+"\r\n");
                }
                SshClient sshClient = new SshClient(connectionInfo);
                try
                {
                    sshClient.Connect();

                    if (sshClient.IsConnected)
                    {
                        if (sshTable.ContainsKey(ip))
                        {
                            ((SshClient)sshTable[ip]).Disconnect();
                            sshTable.Remove(ip);
                        }
                        sshTable.Add(ip, sshClient);
                    }
                }
                catch (Exception e)
                {
                    sb.Append(ip + "：服务器连接异常" + e.Message + "\r\n");
                }
            }
            if (sb.Length > 0)
            {
                this.label_note.Text = sb.ToString();
                return false;
            }
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sftpTable.Clear();
            this.Dispose();
        }

        public static SftpClient getSftpClient(string ip)
        {
            return (SftpClient)sftpTable[ip];
        }

        public static List<Control> getSftpCheckBoxs() 
        {
            List<Control> l = new List<Control>();
            foreach (var ip in sftpTable.Keys)
            {
                CheckBox cb = new CheckBox();
                cb.Text = "" + ip;
                cb.Tag = ip;
                cb.Margin = new Padding(0);
                l.Add(cb);
            }

            return l;
        }

        public static SshClient getSshClient(string ip)
        {
            return (SshClient)sshTable[ip];
        }

        public static Hashtable getSshTable() 
        {
            return sshTable;
        }
    }
}
