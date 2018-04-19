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
    public partial class FormBitCal : Form
    {
        public FormBitCal()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            setInt(sender);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            setInt(sender);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            setInt(sender);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            setInt(sender);
        }

        private void setInt(object sender)
        {
            this.numericUpDown1.Value = Convert.ToInt32(((RadioButton)sender).Tag);
        }
    }
}
