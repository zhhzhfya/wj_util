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
    public delegate void OkDelegate(string text);  
    public partial class FormInput : Form
    {
        public event OkDelegate OkEvent;
        public FormInput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.textBox1.Text))
            {
                MessageBox.Show("请输入一个不为空的值");
                return;
            }
            OkEvent(this.textBox1.Text);
            this.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormInput_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !String.IsNullOrEmpty(this.textBox1.Text))
            {
                OkEvent(this.textBox1.Text);
                this.Close();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
