using CommonUtil;
using InvokerHelper;
using Redbus;
using Redbus.Interfaces;
using Renci.SshNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using wj_util;
using wj_util.events;
using WjUtil.forms;
using wj_util.utils;

namespace wj_util
{
    /// <summary>
    /// 委托：服务连接信息改变
    /// </summary>
    public delegate void ChangeServersEventHandler();
    public partial class FormRuleUtil : Form
    {
        public FormRuleUtil()
        {
            InitializeComponent();
        }

        const int CLOSE_SIZE = 15;
        //tabPage标签图片   
        //Bitmap image = new Bitmap("E:\\close.png");

        private void FormRuleUtil_Load(object sender, EventArgs e)
        {
            //this.tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            //this.tabControl1.Padding = new System.Drawing.Point(15, 3);
            //this.tabControl1.DrawItem += new DrawItemEventHandler(this.MainTabControl_DrawItem);
            //this.tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainTabControl_MouseDown);
            addTabForm("WjUtil.forms", "FormExcel", "FormExcel", "Excel");
            addTabForm("WjUtil.forms", "FormBitCal", "FormBitCal", "字符计算");
            addTabForm("WjUtil.forms", "FormSimulation", "FormSimulation", "模拟数据生成器");
            addTabForm("WjUtil.forms", "FormSqlQuery", "FormSqlQuery", "Sql查询");
            addTabForm("WjUtil.forms", "FormStringUtils", "FormStringUtils", "字符工具");
            addTabForm("WjUtil.forms", "FormService", "FormService", "服务配置");
            //addTabForm("WjUtil.forms", "FormDwEvt", "FormDwEvt", "电围模拟数据");

            this.tabControl1.SelectedIndex = 0;

            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            notifyIcon1.Visible = false;
            notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.SizeChanged += new System.EventHandler(this.FormRuleUtil_SizeChanged);

            // 订阅服务配置改变的事件
            EventBusHelper.getBus().Subscribe<EventMessage<List<String>>>(msg =>
            {
                foreach (string str in msg.messages)
	            {
                    this.toolStripStatusLabel_msg.Text = str;
	            }
            });
        }

        private void FormRuleUtil_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)//最小化
            {
                this.ShowInTaskbar = false;
                this.notifyIcon1.Visible = true;
            }
        }
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;  
  
            //点鼠标右键,return  
            if (Mouse_e.Button == MouseButtons.Left)  
            {
                showMainForm();
            }
        }

        private void showMainForm()
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.Activate();
            this.notifyIcon1.Visible = false;
            this.ShowInTaskbar = true;
        }

        //绘制“Ｘ”号即关闭按钮   
        //private void MainTabControl_DrawItem(object sender, DrawItemEventArgs e)
        //{
        //    try
        //    {
        //        Rectangle myTabRect = this.tabControl1.GetTabRect(e.Index);

        //        //先添加TabPage属性      
        //        e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, this.Font, SystemBrushes.ControlText, myTabRect.X + 2, myTabRect.Y + 2);
        //        //再画一个矩形框   
        //        using (Pen p = new Pen(Color.White))
        //        {
        //            myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 3), 2);
        //            myTabRect.Width = CLOSE_SIZE;
        //            myTabRect.Height = CLOSE_SIZE;
        //            e.Graphics.DrawRectangle(p, myTabRect);
        //        }

        //        //填充矩形框   
        //        Color recColor = e.State == DrawItemState.Selected ? Color.White : Color.White;
        //        using (Brush b = new SolidBrush(recColor))
        //        {
        //            e.Graphics.FillRectangle(b, myTabRect);
        //        }

        //        //画关闭符号   
        //        using (Pen objpen = new Pen(Color.Black))
        //        {
        //            ////=============================================   
        //            //自己画X   
        //            ////=============================================   
        //            //使用图片   
        //            Bitmap bt = new Bitmap(image);
        //            Point p5 = new Point(myTabRect.X, 4);
        //            e.Graphics.DrawImage(bt, p5);
        //            //e.Graphics.DrawString(this.MainTabControl.TabPages[e.Index].Text, this.Font, objpen.Brush, p5);   
        //            //Bitmap bt2 = new Bitmap(image);
        //            //Point p52 = new Point(myTabRect.X + 10, 4);
        //            //e.Graphics.DrawImage(bt2, p52);
        //        }
        //        e.Graphics.Dispose();
        //    }
        //    catch (Exception)
        //    { }
        //}

        //关闭按钮功能   
        //private void MainTabControl_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        int x = e.X, y = e.Y;
        //        //计算关闭区域      
        //        Rectangle myTabRect = this.tabControl1.GetTabRect(this.tabControl1.SelectedIndex);

        //        myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 3), 2);
        //        myTabRect.Width = CLOSE_SIZE;
        //        myTabRect.Height = CLOSE_SIZE;

        //        //如果鼠标在区域内就关闭选项卡      
        //        bool isClose = x > myTabRect.X && x < myTabRect.Right && y > myTabRect.Y && y < myTabRect.Bottom;
        //        if (isClose == true)
        //        {
        //            this.tabControl1.TabPages.Remove(this.tabControl1.SelectedTab);
        //        }
        //    }
        //}
      
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showFormServerInfo();
        }

        private void showFormServerInfo()
        {
            FormServerInfo f = new FormServerInfo();
            f.Show();
        }

       
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            showFormServerInfo();
        }


        private void addTabForm(string nameSpace, string formClass, string name, string text)
        {
            foreach (TabPage tp in this.tabControl1.TabPages)
            {
                if (tp.Name == name)
                {
                    this.tabControl1.SelectedTab = tp;
                    return;
                }
            }
            Form form = CreateInstance<Form>(nameSpace, formClass, null);
            form.TopLevel = false;
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.ControlBox = false;
            form.AutoScroll = true;
            form.Show();
            TabPage page = new TabPage();
            page.Name = name;
            page.Text = text;
            page.Controls.Add(form);
            this.tabControl1.Controls.Add(page);
            this.tabControl1.SelectedTab = page;
        }


        /// <summary>
        /// 创建对象实例
        /// </summary>
        /// <typeparam name="T">要创建对象的类型</typeparam>
        /// <param name="nameSpace">类型所在命名空间</param>
        /// <param name="className">类型名</param>
        /// <param name="parameters">构造函数参数</param>
        /// <returns></returns>
        public static T CreateInstance<T>(string nameSpace, string className, object[] parameters)
        {
            try
            {
                string fullName = nameSpace + "." + className;//命名空间.类型名
                object ect = Assembly.GetExecutingAssembly().CreateInstance(fullName, true, System.Reflection.BindingFlags.Default, null, parameters, null, null);//加载程序集，创建程序集里面的 命名空间.类型名 实例
                return (T)ect;//类型转换并返回
            }
            catch
            {
                //发生异常，返回类型的默认值
                return default(T);
            }
        }

        private void 字符工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addTabForm("WjUtil.forms", "FormStringUtils", "FormStringUtils", "字符工具");
        }

        private void sSHToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addTabForm("WjUtil.forms", "FormSsh", "FormSsh", "SSH客户端");
        }

        private void 文本映射ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addTabForm("WjUtil.forms", "FormTextMapping", "FormTextMapping", "文本映射");
        }

        private void 定时上传ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addTabForm("WjUtil.forms", "FormSshUploader", "FormSshUploader", "定时上传");
        }

        private void 批量查杀ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addTabForm("WjUtil.forms", "FormKiller", "FormKiller", "批量查杀");
        }

        private void kafka工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addTabForm("WjUtil.forms", "FormKafka", "FormKafka", "Kafka工具");
        }

        private void zookeeper工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addTabForm("WjUtil.forms", "FormZookeeper", "FormZookeeper", "Zookeeper工具");
        }

        private void 模拟数据生成器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addTabForm("WjUtil.forms", "FormSimulation", "FormSimulation", "模拟数据生成器");
        }

        private void 机器学习ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addTabForm("WjUtil.forms", "FormLearn", "FormLearn", "机器学习");
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showMainForm();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sQL查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addTabForm("WjUtil.forms", "FormSqlQuery", "FormSqlQuery", "Sql查询");
        }

        private void 服务配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addTabForm("WjUtil.forms", "FormService", "FormService", "服务配置");
        }

        private void grid1000000测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmSample53
            addTabForm("WjUtil.forms", "frmSample53", "frmSample53", "1000000数据SourceGrid测试");
        }

        private void 字节计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addTabForm("WjUtil.forms", "FormBitCal", "FormBitCal", "字符计算");
            
        }

        private void 电围模拟数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addTabForm("WjUtil.forms", "FormDwEvt", "FormDwEvt", "电围模拟数据");
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addTabForm("WjUtil.forms", "FormExcel", "FormExcel", "Excel");
        }

    }
}
