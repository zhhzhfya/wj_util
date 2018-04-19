//using System;

//using System.Collections.Generic;
//using System.Text;
//using System.Windows.Forms;
//using Excel;
 
//namespace wj_util.utils
//{
//    class clsExportToExcel
//    {
//        private SourceGrid.Grid grid1;
//        public clsExportToExcel(SourceGrid.Grid oGrid)
//        {
//            grid1 = oGrid;
//        }
        
//        public void ExportToExcel(string cTitle)
//        {
//            string cFileName = GetFileName(cTitle);
//            if (cFileName == "") return;
//            if (!CheckGrid()) return;
//            Excel.Application xlApp = new Excel.Application();
//            if (xlApp == null)
//            {
//                MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel", "提示");
//                return;
//            }
 
//            Excel.Workbooks workbooks = xlApp.Workbooks;
//            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
//            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
//            Excel.Range range;
//            long iRowsCount = grid1.RowsCount;
//            long iColumnsCount = grid1.ColumnsCount;
//            worksheet.Cells[1, 1] = "";
 
//            //************写入数据****************
//            int iStartRow = 1;
//            //写入标题
//            if (cTitle != "")
//            {
//                range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, grid1.ColumnsCount]);
//                range.MergeCells = true;
//                range.Value2 = cTitle;
//                range.HorizontalAlignment = XlVAlign.xlVAlignCenter;
//                range.RowHeight = 40;
//                iStartRow = 2;
//            }
//            //写入表体数据
//            int iRowIndex;
//            int iColIndex;
//            float iColWidth = 13.25F;
//            for (int iRow = 0; iRow < grid1.RowsCount; iRow++)
//            {
//                for (int iCol = 0; iCol < grid1 .ColumnsCount; iCol++)
//                {
//                    grid1[iRow, iCol].Tag = null;
//                }
//            }
//            for (int iRow = 0; iRow < grid1 .RowsCount ; iRow++)
//            {
//                for (int iCol = 0; iCol < grid1 .ColumnsCount ; iCol++)
//                {
//                    int iRowSpan = grid1[iRow, iCol].RowSpan;
//                    int iColSpan = grid1[iRow, iCol].ColumnSpan;
//                    iRowIndex = iRow + iStartRow;
//                    iColIndex = iCol + 1;
//                    if (iRowSpan > 1)
//                    {
//                        if (grid1[iRow, iCol].Tag == null)
//                        {
//                            range = worksheet.get_Range(worksheet.Cells[iRowIndex, iColIndex], worksheet.Cells[iRowIndex + iRowSpan - 1, iColIndex]);
//                            range.MergeCells = true;
//                            range.Value2 = "'" + (grid1[iRow, iCol].Value == null ? "" : grid1[iRow, iCol].Value.ToString());
//                            range.HorizontalAlignment = XlVAlign.xlVAlignCenter;
//                            range.ColumnWidth = iColWidth;
//                            for (int i = 0; i < iRowSpan; i++)
//                            {
//                                grid1[iRow + i, iCol].Tag = true;
//                            }
//                        }
//                    }
//                    else if (iColSpan > 1)
//                    {
//                        if (grid1[iRow, iCol].Tag == null)
//                        {
//                            range = worksheet.get_Range(worksheet.Cells[iRowIndex, iColIndex], worksheet.Cells[iRowIndex, iColIndex + iColSpan - 1]);
//                            range.MergeCells = true;
//                            range.Value2 = "'" + (grid1[iRow, iCol].Value == null ? "" : grid1[iRow, iCol].Value.ToString());
//                            range.HorizontalAlignment = XlVAlign.xlVAlignCenter;
//                            range.ColumnWidth = iColWidth;
//                            for (int i = 0; i < iColSpan; i++)
//                            {
//                                grid1[iRow, iCol + i].Tag = true;
//                            }
//                        }
//                    }
//                    else
//                    {
//                        range = worksheet.get_Range(worksheet.Cells[iRowIndex, iColIndex], worksheet.Cells[iRowIndex, iColIndex]);
//                        range.Value2 = "'" + (grid1[iRow, iCol].Value == null ? "" : grid1[iRow, iCol].Value.ToString());
//                        range.HorizontalAlignment = XlVAlign.xlVAlignCenter;
//                        range.ColumnWidth = iColWidth;
//                    }
//                }
//            }
//            range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[iRowsCount + 2, iColumnsCount]);
//            range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
//            range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;
//            range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous;
//            range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = Excel.XlBorderWeight.xlThin;
//            if (cFileName != "")
//            {
//                try
//                {
//                    workbook.Saved = true;
//                    workbook.SaveCopyAs(cFileName); ;
//                }
//                catch (Exception ex)
//                {
//                    mProgressBar.Close();
//                    MessageBox.Show("导出文件时出错,文件可能正被打开！/n" + ex.Message);
//                }
//            }
//            xlApp.Quit();
//            GC.Collect();//强行销毁
//            MessageBox.Show("导出成功", "提示");
//        }
//        private string GetFileName(string cTitle)
//        {
//            string cSaveFileName = "";
//            SaveFileDialog saveDialog = new SaveFileDialog();
//            saveDialog.DefaultExt = "xls";
//            saveDialog.Filter = "Excel文件|*.xls";
//            saveDialog.FileName = DateTime.Today.ToString("yyyy-MM-dd") + " " + cTitle;
//            if (saveDialog.ShowDialog() != DialogResult.Cancel)
//            {
//                cSaveFileName = saveDialog.FileName;
//            }
//            return cSaveFileName;
//        }
 
       
//        private bool CheckGrid()
//        {
//            if (grid1 == null)
//            {
//                MessageBox.Show("没有数据可导", "提示");
//                return false;
//            }
//            if (grid1.ColumnsCount <= 0)
//            {
//                MessageBox.Show("没有数据可导", "提示");
//                return false;
//            }
//            if (grid1.RowsCount <= 0)
//            {
//                MessageBox.Show("没有数据可导", "提示");
//                return false;
//            }
//            return true;
//        }
//    }
//}