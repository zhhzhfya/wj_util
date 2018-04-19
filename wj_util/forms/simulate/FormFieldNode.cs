using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wj_util.events;

namespace WjUtil.forms
{
    public partial class FormFieldNode : Form
    {
        JObject json;
        TreeNode selectedNode;
        public FormFieldNode()
        {
            InitializeComponent();
        }

        public void setData(TreeNode selectedNode, JObject json)
        {
            this.json = json;
            this.selectedNode = selectedNode;

            foreach (Control c in this.groupBox_type.Controls)
            {
                if (c is RadioButton && json["type"] != null && ((RadioButton)c).Text.Equals(json["type"].ToString()))
                {
                    ((RadioButton)c).Checked = true;
                }
            }
            foreach (Control c in this.groupBox_gen_type.Controls)
            {
                if (c is RadioButton && json["gen_type"] != null && ((RadioButton)c).Text.Equals(json["gen_type"].ToString()))
                {
                    ((RadioButton)c).Checked = true;
                }
            }
            if (json["ini_value"] != null && !String.IsNullOrEmpty(json["ini_value"].ToString()))
            {
                this.textBox_ini_value.Text = json["ini_value"].ToString();
            }
            if (json["len"] != null && !String.IsNullOrEmpty(json["len"].ToString()))
            {
                this.numericUpDown_len.Value = Convert.ToInt32(json["len"].ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            JObject json = getFieldConfig();
            EventBusHelper.getBus().Publish(new EventModify<TreeNode>(selectedNode, getFieldConfig()));
        }


        /// <summary>
        /// type,gen_type,ini_value,len
        /// </summary>
        /// <returns></returns>
        private JObject getFieldConfig()
        {
            // 提取这个字段的配置，然后设置到json里
            JObject json = new JObject();
            foreach (Control c in this.groupBox_type.Controls)
            {
                if (c is RadioButton && ((RadioButton)c).Checked)
                {
                    json["type"] = ((RadioButton)c).Text;
                }
            }
            foreach (Control c in this.groupBox_gen_type.Controls)
            {
                if (c is RadioButton && ((RadioButton)c).Checked)
                {
                    json["gen_type"] = ((RadioButton)c).Text;
                }
            }
            if (!String.IsNullOrEmpty(this.textBox_ini_value.Text))
            {
                json["ini_value"] = this.textBox_ini_value.Text;
            }
            if (this.numericUpDown_len.Value > 0)
            {
                json["len"] = this.numericUpDown_len.Value;
            }
            json["text"] = this.json["text"];
            return json;
        }
    }
}
