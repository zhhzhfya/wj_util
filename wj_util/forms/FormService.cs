using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WjUtil.forms
{
    public partial class FormService : Form
    {
        public FormService()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }


        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateProtocol();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String s = System.AppDomain.CurrentDomain.BaseDirectory + "\r\n";
            // 获取程序的基目录。  
            s += System.AppDomain.CurrentDomain.BaseDirectory + "\r\n";

            // 获取模块的完整路径。 
            s += System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName + "\r\n";

            // 获取和设置当前目录(该进程从中启动的目录)的完全限定目录。 System.Environment.CurrentDirectory

            // 获取应用程序的当前工作目录。 
            s += System.IO.Directory.GetCurrentDirectory() + "\r\n";

            // 获取和设置包括该应用程序的目录的名称。 
            s += System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\r\n";

            // 获取启动了应用程序的可执行文件的路径。
            s += System.Windows.Forms.Application.StartupPath + "\r\n";

            // 获取启动了应用程序的可执行文件的路径及文件名。 
            s += System.Windows.Forms.Application.ExecutablePath + "\r\n";
            MessageBox.Show(s);
        }

        /// <summary>  
        /// 注册表名称，注意不能有特殊符号，包括下划线
        /// <a href="phs://str">打开程序并传递字符串str作为参数</a>  
        /// </summary>  
        private const string RegName = "phs";
        public void UpdateProtocol()
        {
            try
            {
                if (Registry.ClassesRoot.OpenSubKey(RegName) != null)
                {
                    RegistryKey rg = Registry.ClassesRoot.OpenSubKey(RegName + "\\shell\\open\\command", true);
                    string
                        oldUrl = rg.GetValue("").ToString(),
                        newUrl = string.Format("\"{0}\" \"%1\"", Application.ExecutablePath);


                    if (!oldUrl.Equals(newUrl, StringComparison.CurrentCultureIgnoreCase))
                    {
                        rg.SetValue("", newUrl);
                    }
                }
                else
                {
                    RegistryKey first = Registry.ClassesRoot.CreateSubKey(RegName);
                    first.SetValue("", RegName + " Protocol");
                    first.SetValue("URL Protocol", "");
                    RegistryKey
                        shell = first.CreateSubKey("shell"),
                        open = shell.CreateSubKey("open"),
                        cmd = open.CreateSubKey("command");
                    cmd.SetValue("", string.Format("\"{0}\" \"%1\"", Application.ExecutablePath));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("修改注册表信息失败，请尝试：使用将程序加入安全软件白名单、使用管理员方式启动", ex);
            }
        }

        private void axFramerControl1_OnFileCommand(object sender, AxDSOFramer._DFramerCtlEvents_OnFileCommandEvent e)
        {

        }

        private void FormService_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormOffice f = new FormOffice("e:\\a.xlsx");
            f.Show();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            FormOffice f = new FormOffice("e:\\b.xlsx");
            f.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            app.Visible = true;
            app.Documents.Add("D://Test.docx");
        }  
    }
}
