using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WjUtil.forms
{
    public partial class FormStringUtils : Form
    {
        public FormStringUtils()
        {
            InitializeComponent();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            makeRuleString();
        }

        private void makeRuleString()
        {
            string txt = this.textBox2.Text;
            string endChar = this.textBox1.Text;
            char[] chars = endChar.ToCharArray();
            string sp = endChar.Substring(0, chars.Length/2);
            if (String.IsNullOrEmpty(endChar))
            {
                MessageBox.Show("结尾字符不能为空");
                this.textBox1.Text = ";";
            }
            string[] txtArray = Regex.Split(txt, "\r\n", RegexOptions.IgnoreCase);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < txtArray.Length; i++)
            {
                string line = txtArray[i];
                // trim the source str
                if (this.checkBox2_trim.Checked)
                {
                    line = line.Trim();
                }
                // 删除结尾字符
                if (!String.IsNullOrEmpty(this.txtBox_del_end_chr.Text) && line.EndsWith(this.txtBox_del_end_chr.Text))
                {
                    line = line.Substring(0, line.Length - this.txtBox_del_end_chr.TextLength);
                }
                // 替换特殊字符
                if (this.checkBox_replaceStrs.Checked)
                {
                    string[] repStrs = this.textBox_replaceStrs.Text.Split(',');
                    for (int j = 0; j < repStrs.Length; j++)
                    {
                        line = line.Replace(repStrs[j], "");
                    }
                }
                if (this.checkBox_mpp_sql.Checked)
                {
                    line = line.Replace("STRING", "text");
                }

                // 再trim一次
                if (this.checkBox2_trim.Checked)
                {
                    line = line.Trim();
                }
                // 指定了结尾字符？
                if (!String.IsNullOrEmpty(endChar))
                {
                    line = line + endChar;
                }

                if (this.checkBox_xg_to2.Checked)
                {
                    line = line.Replace("\\", "\\\\");
                }

                // 拼成一行？                
                if (!this.checkBox_concat.Checked)
                {
                    line = line + "\r\n";
                }


                sb.Append(line);
            }
            if (!this.checkBox_concat.Checked)
            {
                sb.Length = sb.Length - 2;
            }
            if (!String.IsNullOrEmpty(endChar))
            {
                sb.Length = sb.Length - endChar.Length;
            }

            if (this.checkBox_in.Checked)
            {
                if (sb.ToString().EndsWith(endChar))
                {
                    sb.Length = sb.Length - endChar.Length;
                }
                
                sb.Insert(0, sp).Insert(0, " in (").Append(sp).Append(")");
            }

            this.textBox3.Text = sb.ToString();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            makeRuleString();
        }

        private void checkBox2_trim_CheckedChanged(object sender, EventArgs e)
        {
            makeRuleString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            makeRuleString();
        }

        private void txtBox_del_end_chr_TextChanged(object sender, EventArgs e)
        {
            makeRuleString();
        }

        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {
            makeRuleString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            makeRuleString();
        }
        private void checkBox_xg_to2_CheckedChanged(object sender, EventArgs e)
        {
            makeRuleString();
        }
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }
    }
}
