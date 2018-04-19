using framework.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wj_util.hessian;

namespace WjUtil.forms
{
    public partial class FormSqlQuery : Form
    {
        public FormSqlQuery()
        {
            InitializeComponent();
            this.grid1.BorderStyle = BorderStyle.FixedSingle;
            this.grid1.FixedRows = 1;
        }

        private void FormSqlQuery_Load(object sender, EventArgs e)
        {
            // 查询历史的hessian连接
            if (!LocalDBBusiness.GetInstance().CheckTableExist("CO_URL_LOGS"))
            {
                SQLiteCommand command = new SQLiteCommand("CREATE TABLE CO_URL_LOGS(URL VARCHAR(30), SUPER_PASS VARCHAR(20), FLAG INT)");
                LocalDBSQLiteHelper.GetInstance().ExecuteNonQuery(command);
            }
            else
            {
                // 如果存在则把历史数据加载到combox里
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM CO_URL_LOGS");
                DataSet ds = LocalDBSQLiteHelper.GetInstance().ExecuteDataSet(command);
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["FLAG"].ToString().Equals("1"))
                    {
                        this.toolStripComboBox1.Items.Add(dr["URL"].ToString());
                    }
                    else if (dr["FLAG"].ToString().Equals("2"))
                    {
                        this.toolStripComboBox1.Items.Add(dr["URL"].ToString());
                    }
                }
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //this.toolStripButton_run.Enabled = false;
            query();
            //this.toolStripButton_run.Enabled = true;
        }

        private void query()
        {
            this.grid1.Columns.Clear();
            this.grid1.Rows.Clear();

            HessianHelper.url = this.toolStripTextBox_url.Text;
            string sql = this.textBox_sql.Text;
            List<object[]> list = HessianHelper.query(sql, 0, 1000);
            
            for (int i = 0; i < list.Count; i++)
            {
                this.grid1.Rows.Insert(i);
                if (i == 0)
                {
                    this.grid1.ColumnsCount = list[i].Length;
                    for (int j = 0; j < list[i].Length; j++)
                    {
                        this.grid1[i, j] = new SourceGrid.Cells.ColumnHeader(list[i][j].ToString());
                    }
                }
                else
                {
                    for (int j = 0; j < list[i].Length; j++)
                    {
                        this.grid1[i, j] = new SourceGrid.Cells.Cell(list[i][j], typeof(string));
                    }
                }
            }

            this.grid1.AutoSizeCells();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click_2(object sender, EventArgs e)
        {

        }

        private void FormSqlQuery_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox_sql_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.Enter))
            {
                query();
            }
            if (Keys.F8 == e.KeyCode)
            {
                query();
            }
        }
    }
}
