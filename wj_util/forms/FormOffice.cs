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
    public partial class FormOffice : Form
    {
        string file;


        public FormOffice(String filename) 
        {
            this.file = filename;
            InitializeComponent();
            this.axFramerControl1.Open(file);
        }

        private void FormOffice_Load(object sender, EventArgs e)
        {
            
        }
    }
}
