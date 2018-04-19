using ExcelDataReader;
using ExcelExporter;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WjUtil.forms
{
    public partial class FormExcel : Form
    {
        DataSet ds;

        bool closing = false;
        public FormExcel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "Excel文件(*.xls,*.xls)|*.xls;*.xlsx";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] files = dialog.FileNames;
                foreach (string file in files)
	            {
                    this.label1.Text = "";
                    System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                    stopwatch.Start();
                    ds = ExcelToDataTable(file);
                    stopwatch.Stop();
                    if (ds.Tables.Count > 0)
                    {
                        this.label1.Text += "读取xls耗时：" + stopwatch.Elapsed.TotalSeconds;
                        stopwatch.Reset(); stopwatch.Start();
                        //dataTableToGrid(this.grid1, ds.Tables[0]);
                        dataTableToGridAsync(this.grid1, ds.Tables[0], 100);
                        stopwatch.Stop();
                        this.label1.Text += "加载到Grid耗时：" + stopwatch.Elapsed.TotalSeconds;
                    }
	            }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }


        public void dataTableToGrid(SourceGrid.Grid grid, DataTable dt)
        {
            grid.Columns.Clear();
            grid.Rows.Clear();
            grid.ColumnsCount = dt.Columns.Count;
            grid.Rows.Insert(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                grid[0, i] = new SourceGrid.Cells.ColumnHeader(dt.Columns[i].ToString());
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grid.Rows.Insert(i+1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    grid[i, j] = new SourceGrid.Cells.Cell(dt.Rows[i][j], typeof(string));
                }
            }

            grid.AutoSizeCells();
        }

        public void dataTableToGridAsync(SourceGrid.DataGrid grid, DataTable dt, int page)
        {
            DataTable _dt = new DataTable();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                _dt.Columns.Add(dt.Columns[i].ColumnName);
            }
            for (int i = 0; i < page; i++)
            {
                _dt.Rows.Add(dt.Rows[i].ItemArray);
            }

            grid.SelectionMode = SourceGrid.GridSelectionMode.Row;
            grid.Selection.EnableMultiSelection = true;
            grid.DataSource = new DevAge.ComponentModel.BoundDataView(_dt.DefaultView);
            grid.Columns.AutoSizeView();

            grid.ClipboardMode = SourceGrid.ClipboardMode.All;

            // HACK - disable checkinf of ilegal calls
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            // disable sorting before the data is loaded
            grid.DataSource.AllowSort = false;

            Thread oThread = new Thread(delegate()
            {
                grid.SuspendLayout();
                for (int i = page; i < dt.Rows.Count; i++)
                {
                    if (closing == true)
                        return;
                    _dt.Rows.Add(dt.Rows[i].ItemArray);
                }
                grid.ResumeLayout();
                grid.RecalcCustomScrollBars();
                grid.DataSource.AllowSort = true;
            });            
            oThread.Start();
        }


        /// <summary>
        /// 读取Excel文件到DataSet中
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static DataSet ExcelToDataTable(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // 2. Use the AsDataSet extension method
                    return reader.AsDataSet();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl files (*.xlsx)|*.xlsx";
            saveFileDialog.FilterIndex = 0; if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "Export Excel File To";
                string strName = saveFileDialog.FileName;
                if (File.Exists(strName))
                {
                    File.Delete(strName);
                }
                // 导出excel
                new ExcelExport().AddSheet(ds.Tables[0]).ExportTo(strName);
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Closing += delegate
            {
                closing = true;
            };
        }
    }
}
