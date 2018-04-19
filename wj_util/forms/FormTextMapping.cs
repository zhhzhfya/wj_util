using System;
using System.Collections;
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
    public partial class FormTextMapping : Form
    {
        public FormTextMapping()
        {
            InitializeComponent();
        }

        private void textBox_c1_TextChanged(object sender, EventArgs e)
        {
            genDataFieldsMapText();
        }

        private void textBox_c2_TextChanged(object sender, EventArgs e)
        {
            genDataFieldsMapText();
        }
        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            genDataFieldsMapText();
        }

        private void textBox_hbase_sql_TextChanged(object sender, EventArgs e)
        {
            genDataFieldsMapText();
        }

        private void textBox_sql2_TextChanged(object sender, EventArgs e)
        {
            genDataFieldsMapText();
        }

        private void textBox_sql3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }


        private void genDataFieldsMapText()
        {
            if (string.IsNullOrEmpty(this.textBox_sql1.Text) || string.IsNullOrEmpty(this.textBox_sql2.Text) || !this.checkBox_auto_gen.Checked)
            {
                return;
            }
            string[] strs1 = Regex.Split(this.textBox_sql1.Text, "\r\n", RegexOptions.IgnoreCase);
            Hashtable ht1 = new Hashtable();
            Hashtable ht2 = new Hashtable();
            // 第一数据集的那列 对应 第二数据集的那列？
            int c1 = Int32.Parse(this.textBox_c1.Text);
            int c2 = Int32.Parse(this.textBox_c2.Text);
            StringBuilder sb = new StringBuilder();
            foreach (var line in strs1)
            {
                string[] values = Regex.Split(line, "\t", RegexOptions.IgnoreCase);
                if (c1 < values.Length && !string.IsNullOrEmpty(values[c1]) && !ht1.ContainsKey(values[c1]))
                {
                    ht1.Add(values[c1], values);
                }
            }
            this.textBox_console.Text = ht1.ToString();
            string[] strs2 = Regex.Split(this.textBox_sql2.Text, "\r\n", RegexOptions.IgnoreCase);

            for (int i = 0; i < strs2.Length; i++)
            {
                string[] values = Regex.Split(strs2[i], "\t", RegexOptions.IgnoreCase);
                string rule = this.textBox_result_rule.Text;
                for (int j = 0; j < values.Length; j++)
                {
                    if (rule.Contains("2." + j))
                    {
                        if (j < values.Length && !string.IsNullOrEmpty(values[j]))
                        {
                            rule = rule.Replace("2." + j, values[j]);
                        }
                    }
                }
                if (c2 < values.Length && !string.IsNullOrEmpty(values[c2]) && ht1.ContainsKey(values[c2]))
                {
                    string[] strs = (string[])ht1[values[c2]];
                    for (int k = 0; k < strs.Length; k++)
                    {
                        if (rule.Contains("1." + k))
                        {
                            if (k < strs.Length && !string.IsNullOrEmpty(strs[k]))
                            {
                                rule = rule.Replace("1." + k, strs[k]);
                            }
                        }
                    }
                }
                if (!rule.Equals(this.textBox_result_rule.Text))
                {
                    sb.Append(rule).Append("\r\n");
                }
            }
            this.textBox_sql3.Text = sb.ToString();
        }
    }
}
