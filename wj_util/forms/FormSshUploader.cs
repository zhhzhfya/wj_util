using InvokerHelper;
using Redbus;
using Redbus.Interfaces;
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
    public partial class FormSshUploader : Form
    {
        IEventBus eventBus = new EventBus();
        public FormSshUploader()
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
            this.flowPanelServers.Controls.Clear();
            foreach (var c in list)
            {
                this.flowPanelServers.Controls.Add(c);
            }
        }

        Thread t = null;
        Boolean loop = false;
        private void button2_Click(object sender, EventArgs e)
        {
            if (FormServerInfo.getSftpCheckBoxs().Count == 0)
            {
                MessageBox.Show("请设置连接信息");
                return;
            }
            if (!loop)
            {
                loop = true;
                t = new Thread(new ThreadStart(loopUploadFile));
                t.Start();
                this.button_timer_start.Text = "停止";
            }
            else
            {
                loop = false;
                this.button_timer_start.Text = "正在停止...";
                this.button_timer_start.Enabled = false;
            }
        }

        public void loopUploadFile()
        {
            while (loop)
            {
                FormServerInfo.locks = true;
                doUploadFile();
                if (!loop)
                {
                    break;
                }
                Thread.Sleep(Convert.ToInt32(this.numericUpDown1.Value));
            }
            InvokeHelper.Set(this.button_timer_start, "Enabled", true);
            InvokeHelper.Set(this.button_timer_start, "Text", "开始");
            InvokeHelper.Set(this.progressBar1, "Value", 0);
            FormServerInfo.locks = false;
        }

        public void doUploadFile()
        {
            if (string.IsNullOrEmpty(this.textBox_rm_dir.Text))
            {
                MessageBox.Show("请输入远程文件夹");
                return;
            }
            if (string.IsNullOrEmpty(this.textBox_local_dir.Text))
            {
                MessageBox.Show("请输入本地文件夹");
                return;
            }
            string local_dir = this.textBox_local_dir.Text;
            string rm_dir = this.textBox_rm_dir.Text;
            DirectoryInfo dir = new DirectoryInfo(local_dir);
            SftpClient sftp = null;
            int links = 0;
            for (int i = 0; i < this.flowPanelServers.Controls.Count; i++)
            {
                CheckBox cb = (CheckBox)this.flowPanelServers.Controls[i];
                if (cb.Checked)
                {
                    sftp = FormServerInfo.getSftpClient((string)cb.Tag);
                }
                if (sftp == null)
                {
                    continue;
                }
                if (!sftp.IsConnected)
                {
                    sftp.Connect();
                }
                InvokeHelper.Set(this.progressBar1, "Value", 0);
                InvokeHelper.Set(this.progressBar1, "Maximum", dir.GetFiles().Count());
                int c = 1;
                sftp.ChangeDirectory(rm_dir);
                System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
                long timeStamp = (long)(DateTime.Now - startTime).TotalMilliseconds; // 相差毫秒数
                foreach (FileInfo f in dir.GetFiles("*.*")) //查找文件
                {
                    using (var fileStream = new FileStream(f.FullName, FileMode.Open))
                    {
                        sftp.BufferSize = 4 * 1024; // bypass Payload error large
                        string path = f.Directory.FullName + Path.DirectorySeparatorChar + timeStamp + "_" + f.Name + ".tmp";
                        sftp.UploadFile(fileStream, Path.GetFileName(path));
                        sftp.RenameFile(rm_dir + "/" + timeStamp + "_" + f.Name + ".tmp", rm_dir + "/" + timeStamp + "_" + f.Name);
                        InvokeHelper.Set(this.progressBar1, "Value", c++);
                        InvokeHelper.Invoke(this.textBox_log, "AppendText", new object[] { DateTime.Now.ToLocalTime() + " 上传：" + f.FullName + "\r\n" });
                        InvokeHelper.Invoke(this.textBox_log, "ScrollToCaret", new object[] { });
                        //Console.WriteLine("上传："+f.FullName);
                        if (!loop)
                        {
                            break;
                        }
                    }
                }
                links++;
                if (!loop)
                {
                    break;
                }
            }
            if (links == 0)
            {
                loop = false;
                MessageBox.Show("没有可用的连接");
            }
        }

        private void button2_Click_clean(object sender, EventArgs e)
        {
            InvokeHelper.Set(this.textBox_log, "Text", "");
        }
    }
}
