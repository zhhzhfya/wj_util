//using Renci.SshNet;
//using Renci.SshNet.Common;
//using Renci.SshNet.Sftp;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Data;
//using System.IO;
//using System.Linq;
//using System.Text;

//namespace wj_util
//{
//    class Class1
//    {

//        protected void btnExcelImport_Click(object sender, EventArgs e)
//        {
//            if (this.LogisticsUpload.HasFile)//判断是否存在上传文件
//            {
//                string filename = this.LogisticsUpload.PostedFile.FileName;
//                string extension = (new FileInfo(filename)).Extension;
//                string newfilename = System.DateTime.Now.ToString("yyyyMMddHHmmss") + extension;

//                //判断是否存在上传路径，如果不存在，则创建
//                if (!Directory.Exists(Server.MapPath("../Upload/Logistics")))
//                {
//                    Directory.CreateDirectory(Server.MapPath("../Upload/Logistics"));
//                }
//                string path = Server.MapPath("../Upload/Logistics/");
//                this.LogisticsUpload.PostedFile.SaveAs(path + newfilename);//这一步实现上传文件

//                //插入数据库表
//                LogisticsLog logmodel = new LogisticsLog();
//                logmodel.FileName = filename;
//                logmodel.SavePath = path;
//                logmodel.CreateTime = DateTime.Now;
//                logmodel.CreaterId = base.CurrentUser.UserID.ToString();

//                logmodel.AgentId = this.AgentDropDownList.SelectedItem.Value.ToInt();
//                logmodel.AgentName = this.AgentDropDownList.SelectedItem.Text.ToString();
//                logmodel.Status = Convert.ToInt32(Core.EnumDefine.LogisticsStatus.wait);

//                //通过sftp方式上传到服务器
//                string sftppath = "/" + filename;//sftp根目录加上存入文件名
//                string localpath = path + newfilename;//本地文件
//                Framework.Common.SFTPOperation sftp = new Framework.Common.SFTPOperation(Config.ConfigSettings.Instance.SAP_SFTP_SERVER, int.Parse(Config.ConfigSettings.Instance.SAP_SFTP_PORT), Config.ConfigSettings.Instance.SAP_SFTP_ACCOUNT, Config.ConfigSettings.Instance.SAP_SFTP_PASSWORD);
//                sftp.Connect();
//                sftp.Put(localpath, sftppath);
//                sftp.Disconnect();

//                LogisticsBusinessService log = new LogisticsBusinessService();
//                if (log.Add(logmodel))
//                {
//                    //Response.Write("<script>window.open('StockBatchList.aspx','_self')</script>");
//                    this.AlertMessage("上传成功！");

//                    Response.Redirect("LogisticsList.aspx");
//                }
//                else
//                {
//                    this.AlertMessage("上传失败！");
//                }
//            }
//        }

//        // sftp操作类，用到的方法已经标黄，直接看，主要是put方法

//        public class SFTPOperation
//        {
//            #region 字段或属性
//            /// <summary>
//            /// sftp连接
//            /// </summary>
//            private SftpClient sftp;
//            /// <summary>
//            /// SFTP连接状态
//            /// </summary>
//            public bool Connected { get { return sftp.IsConnected; } }
//            /// <summary>
//            /// 主机地址
//            /// </summary>
//            private const string HOST = "192.168.0.80";//192.168.0.80 //140.231.210.125
//            /// <summary>
//            /// 端口
//            /// </summary>
//            private const int PORT = 22;
//            /// <summary>
//            /// 用户名
//            /// </summary>
//            private const string USERNAME = "siemens_sftp";//siemens_sftp //sie_icit
//            /// <summary>
//            /// 密码
//            /// </summary>
//            private const string PASSWORD = "password01!";//password01! //Icitsftp20140826+-

//            #endregion

//            #region 构造

//            /// <summary>
//            /// 构造
//            /// </summary>
//            public SFTPOperation()
//            {
//                var keyboardAuthMethod = new KeyboardInteractiveAuthenticationMethod(USERNAME);
//                keyboardAuthMethod.AuthenticationPrompt += delegate(Object senderObject, AuthenticationPromptEventArgs eventArgs)
//                {
//                    foreach (var prompt in eventArgs.Prompts)
//                    {
//                        if (prompt.Request.Equals("Password: ",
//                        StringComparison.InvariantCultureIgnoreCase))
//                        {
//                            prompt.Response = PASSWORD;
//                        }
//                    }
//                };
//                var passwordAuthMethod = new PasswordAuthenticationMethod(USERNAME, PASSWORD);
//                var connInfo = new ConnectionInfo(HOST, USERNAME, new AuthenticationMethod[] {
//                                                            passwordAuthMethod,
//                                                            keyboardAuthMethod 
//                                                            });
//                sftp = new SftpClient(connInfo);
//                //sftp = new SftpClient(HOST, PORT, USERNAME, PASSWORD);
//            }
//            /// <summary>
//            /// 构造
//            /// </summary>
//            /// <param name="host">主机</param>
//            /// <param name="port">端口</param>
//            /// <param name="user">用户名</param>
//            /// <param name="pwd">密码</param>
//            public SFTPOperation(string host, int port, string user, string pwd)
//            {
//                var keyboardAuthMethod = new KeyboardInteractiveAuthenticationMethod(user);
//                keyboardAuthMethod.AuthenticationPrompt += delegate(Object senderObject, AuthenticationPromptEventArgs eventArgs)
//                {
//                    foreach (var prompt in eventArgs.Prompts)
//                    {
//                        if (prompt.Request.Equals("Password: ",
//                        StringComparison.InvariantCultureIgnoreCase))
//                        {
//                            prompt.Response = pwd;
//                        }
//                    }
//                };
//                var passwordAuthMethod = new PasswordAuthenticationMethod(user, pwd);
//                var connInfo = new ConnectionInfo(host, user, new AuthenticationMethod[] {
//                                                                                            passwordAuthMethod,
//                                                                                            keyboardAuthMethod 
//                                                                                            });
//                sftp = new SftpClient(connInfo);
//                //sftp = new SftpClient(host, port, user, pwd);
//            }
//            #endregion

//            #region 连接SFTP
//            /// <summary>
//            /// 连接SFTP
//            /// </summary>
//            /// <returns>true成功</returns>
//            public bool Connect()
//            {
//                try
//                {
//                    if (!Connected)
//                    {
//                        sftp.Connect();
//                    }
//                    return true;
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(string.Format("连接SFTP失败，原因：{0}", ex.Message));
//                }
//            }
//            #endregion

//            #region 断开SFTP
//            /// <summary>
//            /// 断开SFTP
//            /// </summary> 
//            public void Disconnect()
//            {
//                try
//                {
//                    if (sftp != null && Connected)
//                    {
//                        sftp.Disconnect();
//                    }
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(string.Format("断开SFTP失败，原因：{0}", ex.Message));
//                }
//            }
//            #endregion

//            #region SFTP上传文件
//            /// <summary>
//            /// SFTP上传文件
//            /// </summary>
//            /// <param name="localPath">本地路径</param>
//            /// <param name="remotePath">远程路径</param>
//            public void Put(string localPath, string remotePath)
//            {
//                try
//                {
//                    using (var file = File.OpenRead(localPath))
//                    {
//                        sftp.UploadFile(file, remotePath);
//                    }
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(string.Format("SFTP文件上传失败，原因：{0}", ex.Message));
//                }
//            }
//            /// <summary>
//            /// SFTP上传文件
//            /// </summary>
//            /// <param name="stream">文件流</param>
//            /// <param name="remotePath">远程路径</param>
//            public void Put(Stream stream, string remotePath)
//            {
//                try
//                {
//                    Connect();
//                    sftp.UploadFile(stream, remotePath);
//                    Disconnect();
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(string.Format("SFTP文件上传失败，原因：{0}", ex.Message));
//                }
//            }
//            #endregion

//            #region SFTP获取文件
//            /// <summary>
//            /// SFTP获取文件
//            /// </summary>
//            /// <param name="remotePath">远程路径</param>
//            /// <param name="localPath">本地路径</param>
//            public void Get(string remotePath, string localPath)
//            {
//                try
//                {
//                    var byt = sftp.ReadAllBytes(remotePath);

//                    File.WriteAllBytes(localPath, byt);
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(string.Format("SFTP文件获取失败，原因：{0}", ex.Message));
//                }

//            }

//            public void DownloadFile()
//            {
//                //sftp.DownloadFile()
//            }

//            #endregion

//            #region 删除SFTP文件
//            /// <summary>
//            /// 删除SFTP文件 
//            /// </summary>
//            /// <param name="remotePath">远程路径</param>
//            public void Delete(string remotePath)
//            {
//                try
//                {
//                    sftp.Delete(remotePath);
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(string.Format("SFTP文件删除失败，原因：{0}", ex.Message));
//                }
//            }
//            /// <summary>
//            /// 删除SFTP文件
//            /// </summary>
//            /// <param name="remoteFile">远程路径</param>
//            public void DeleteFile(string remoteFile)
//            {
//                try
//                {
//                    Connect();
//                    sftp.DeleteFile(remoteFile);
//                    Disconnect();
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(string.Format("SFTP文件删除失败，原因：{0}", ex.Message));
//                }
//            }
//            #endregion

//            #region 获取SFTP文件列表
//            /// <summary>
//            /// 获取SFTP文件列表
//            /// </summary>
//            /// <param name="remotePath">远程目录</param>
//            /// <param name="fileSuffix">文件后缀</param>
//            /// <returns></returns>
//            public ArrayList GetFileList(string remotePath, string fileSuffix)
//            {
//                try
//                {
//                    fileSuffix = fileSuffix.ToUpper();
//                    var files = sftp.ListDirectory(remotePath);
//                    var objList = new ArrayList();
//                    foreach (var file in files)
//                    {
//                        if (file.IsDirectory) continue;
//                        string name = file.Name.ToUpper();
//                        if (name.Length > (fileSuffix.Length + 1) && fileSuffix == name.Substring(name.Length - fileSuffix.Length))
//                        {
//                            objList.Add(file.FullName);
//                        }
//                    }
//                    return objList;
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(string.Format("SFTP文件列表获取失败，原因：{0}", ex.Message));
//                }
//            }
//            #endregion

//            #region 移动SFTP文件
//            /// <summary>
//            /// 移动SFTP文件
//            /// </summary>
//            /// <param name="oldRemotePath">旧远程路径</param>
//            /// <param name="newRemotePath">新远程路径</param>
//            public void Move(string oldRemotePath, string newRemotePath)
//            {
//                string fileName = string.Empty;
//                try
//                {
//                    newRemotePath = !sftp.WorkingDirectory.Equals("/") ? sftp.WorkingDirectory + newRemotePath : newRemotePath;
//                    CreateDirectory(newRemotePath, false);
//                    fileName = oldRemotePath.LastIndexOf('/') != -1 ? oldRemotePath.Substring(oldRemotePath.LastIndexOf('/') + 1) : oldRemotePath;

//                    SftpFile file = sftp.ListDirectory(newRemotePath).SingleOrDefault(l => l.Name == fileName);

//                    if (file != null)
//                        fileName = fileName.Substring(0, fileName.LastIndexOf(".")) + DateTime.Now.ToString("_yyyyMMddHHmmss") + "." + fileName.Substring(fileName.LastIndexOf(".") + 1);
//                    sftp.RenameFile(oldRemotePath, newRemotePath + "/" + fileName);
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(string.Format("SFTP文件移动失败，原因：{0}", ex.Message));
//                }
//            }
//            #endregion

//            #region 创建目录
//            /// <summary>
//            /// 创建目录
//            /// </summary>
//            /// <param name="remotePath">远程目录</param>
//            /// <param name="isDisconnect">是否关闭连接</param>
//            private void CreateDirectory(string remotePath, bool isDisconnect)
//            {
//                try
//                {
//                    string[] paths = remotePath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
//                    string curPath = "/";
//                    for (int i = 0; i < paths.Length; i++)
//                    {
//                        curPath += paths[i];
//                        if (!sftp.Exists(curPath))
//                        {
//                            sftp.CreateDirectory(curPath);
//                        }
//                        if (i < paths.Length - 1)
//                            curPath += "/";
//                    }
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(string.Format("创建目录失败，原因：{0}", ex.Message));
//                }
//            }
//            #endregion

//            #region 获取目录列表
//            /// <summary>
//            /// 获取目录列表
//            /// </summary>
//            /// <param name="remotePath">远程目录路径</param>
//            /// <returns></returns>
//            public ArrayList GetDirectoryList(string remotePath)
//            {
//                try
//                {
//                    var files = sftp.ListDirectory(remotePath);
//                    var objList = new ArrayList();
//                    foreach (var file in files)
//                    {
//                        if (!file.IsDirectory) continue;
//                        if (!file.Name.Equals(".") && !file.Name.Equals(".."))
//                            objList.Add(file.FullName);
//                    }
//                    return objList;
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(string.Format("SFTP目录列表获取失败，原因：{0}", ex.Message));
//                }
//            }
//            #endregion

//            #region 删除远程目录
//            /// <summary>
//            /// 删除远程目录（包含目录内文件、子目录）
//            /// </summary>
//            /// <param name="remoteDirectory">远程目录</param>
//            public void DeleteDirectory(string remoteDirectory)
//            {
//                try
//                {
//                    //delete files
//                    var files = sftp.ListDirectory(remoteDirectory);
//                    foreach (var file in files)
//                    {
//                        if (!file.IsDirectory)
//                            sftp.DeleteFile(file.FullName);
//                        else
//                        {
//                            if (!file.Name.Equals(".") && !file.Name.Equals(".."))
//                            {
//                                DeleteDirectory(file.FullName);
//                            }
//                        }
//                    }
//                    sftp.DeleteDirectory(remoteDirectory);
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(string.Format("SFTP目录删除失败，原因：{0}", ex.Message));
//                }
//            }
//            #endregion

//            #region 获取SFTP数据表格
//            /// <summary>
//            /// 获取SFTP数据表格
//            /// </summary>
//            /// <param name="remotePath">远程路径</param>
//            /// <returns>DataTable</returns>
//            public DataTable GetDataTable(string remotePath)
//            {
//                StreamReader sr = null;
//                try
//                {
//                    DataTable dt = new DataTable();
//                    Connect();
//                    sr = sftp.OpenText(remotePath);

//                    //记录每次读取的一行记录
//                    string strLine = "";
//                    //记录每行记录中的各字段内容
//                    string[] aryLine;
//                    //标示列数
//                    int columnCount = 0;
//                    //标示是否是读取的第一行
//                    bool IsFirst = true;

//                    //逐行读取CSV中的数据
//                    while ((strLine = sr.ReadLine()) != null)
//                    {
//                        aryLine = strLine.Trim().Split('\t'); //把读取到的内容分割
//                        if (IsFirst == true)
//                        {
//                            IsFirst = false;
//                            columnCount = aryLine.Length;
//                            //创建列
//                            for (int i = 0; i < columnCount; i++)
//                            {
//                                if (!dt.Columns.Contains(aryLine[i]))
//                                {
//                                    DataColumn dc = new DataColumn(aryLine[i]);
//                                    dt.Columns.Add(dc);
//                                }
//                                else
//                                    columnCount--;
//                            }
//                        }
//                        else
//                        {
//                            DataRow dr = dt.NewRow(); //创建行
//                            for (int j = 0; j < dt.Columns.Count; j++)
//                            {
//                                dr[j] = aryLine.Length > j ? aryLine[j] : "";
//                            }
//                            dt.Rows.Add(dr);
//                        }
//                    }
//                    return dt;
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(string.Format("SFTP文件转换失败，原因：{0}", ex.Message));
//                }
//                finally
//                {
//                    sr.Dispose();
//                    sr.Close();
//                    Disconnect();
//                }
//            }
//            #endregion

//            #region CSV => DataTable filetype
//            public DataTable GetDataTable(string remotePath, string filetype)
//            {
//                StreamReader sr = null;
//                try
//                {
//                    DataTable dt = new DataTable();
//                    sr = sftp.OpenText(remotePath);

//                    //记录每次读取的一行记录
//                    string strLine = "";
//                    //记录每行记录中的各字段内容
//                    string[] aryLine;
//                    //标示列数
//                    int columnCount = 0;
//                    //标示是否是读取的第一行
//                    bool IsFirst = true;

//                    //逐行读取CSV中的数据
//                    while ((strLine = sr.ReadLine()) != null)
//                    {
//                        aryLine = strLine.Trim().Split('\t'); //把读取到的内容分割
//                        if (IsFirst == true)
//                        {
//                            IsFirst = false;
//                            columnCount = aryLine.Length;
//                            //创建列
//                            for (int i = 0; i < columnCount; i++)
//                            {
//                                if (!dt.Columns.Contains(aryLine[i]))
//                                {
//                                    string columnName = GetColumnName(aryLine[i], filetype);

//                                    DataColumn dc = new DataColumn(columnName);
//                                    dt.Columns.Add(dc);
//                                }
//                                else
//                                    columnCount--;
//                            }
//                        }
//                        else
//                        {
//                            DataRow dr = dt.NewRow(); //创建行
//                            for (int j = 0; j < dt.Columns.Count; j++)
//                            {
//                                //去除前导0
//                                if (dt.Columns[j].ColumnName.Equals("KUNNR") || dt.Columns[j].ColumnName.Equals("MATNR") || dt.Columns[j].ColumnName.Equals("Invoice_Create_Date") || dt.Columns[j].ColumnName.Equals("Invoice_Create_Time") || dt.Columns[j].ColumnName.Equals("Invoice_Release_Date") || dt.Columns[j].ColumnName.Equals("Invoice_Release_Time"))
//                                    dr[j] = aryLine.Length > j ? aryLine[j].TrimStart('0') : "";
//                                //decimal 类型转换
//                                else if (dt.Columns[j].ColumnName.Equals("Grossweight") || dt.Columns[j].ColumnName.Equals("NetWeight") || dt.Columns[j].ColumnName.Equals("ProductListPrice"))
//                                {
//                                    dr[j] = aryLine[j].ToDecimal();
//                                }
//                                //int 类型转换
//                                else if (dt.Columns[j].ColumnName.Equals("Per") || dt.Columns[j].ColumnName.Equals("PlannedDeliveryTime") || dt.Columns[j].ColumnName.Equals("GRT"))
//                                {
//                                    dr[j] = aryLine[j].ToInt();
//                                }
//                                else
//                                    dr[j] = aryLine.Length > j ? aryLine[j] : "";

//                                if (aryLine.Length < columnCount && j == aryLine.Length - 1)
//                                    j = dt.Columns.Count;
//                            }
//                            dt.Rows.Add(dr);
//                        }
//                    }
//                    return dt;
//                }
//                catch (Exception ex)
//                {
//                    throw new Exception(string.Format("SFTP文件转换失败，原因：{0}", ex.Message));
//                }
//                finally
//                {
//                    sr.Dispose();
//                    sr.Close();
//                }
//            }

//            private string GetColumnName(string columnName, string filetype)
//            {
//                string restr = columnName;
//                switch (filetype)
//                {
//                    case "SO_PO_DOWNLOAD":
//                        switch (columnName)
//                        {
//                            case "SO Number":
//                                restr = "VBELN";
//                                break;
//                            case "SO Cust. PO No.":
//                                restr = "BSTKD";
//                                break;
//                            case "Customer PO line item No":
//                                restr = "CustItemNo";
//                                break;
//                            case "ZBA3 DATE":
//                                restr = "ZBA3_DATE";
//                                break;
//                            case "ZBAV DATE":
//                                restr = "ZBAV_DATE";
//                                break;
//                            case "ZOP3 DATE":
//                                restr = "ZOP3_DATE";
//                                break;
//                            case "Credit Block":
//                                restr = "CMGST";
//                                break;
//                            case "Credit Block Description":
//                                restr = "CMGST_TEXT";
//                                break;
//                            case "Delivery number":
//                                restr = "DeliveryNumber";
//                                break;
//                            case "Delivery Created date":
//                                restr = "LFDAT";
//                                break;
//                            case "Delivery quantity":
//                                restr = "LFIMG";
//                                break;
//                            case "Vendor Name":
//                                restr = "NAME1";
//                                break;
//                            case "Delivery item":
//                                restr = "LIPS_POSNR";
//                                break;
//                            case "Material number":
//                                restr = "MATNR";
//                                break;
//                            case "SO Net Value Item":
//                                restr = "NETWR";
//                                break;
//                            case "SO Item":
//                                restr = "POSNR";
//                                break;
//                            case "SO Item Category":
//                                restr = "PSTYV";
//                                break;
//                            case "Billing number":
//                                restr = "InvoiceNo";
//                                break;
//                            case "Billing Item":
//                                restr = "InvoiceItemNo";
//                                break;
//                            case "MLFB":
//                                restr = "YYBCEZNDR";
//                                break;
//                            case "Options":
//                                restr = "Options";
//                                break;
//                            case "GR Quantity":
//                                restr = "WEMNG";
//                                break;
//                            case "GR Date":
//                                restr = "GR_date";
//                                break;
//                            case "EKES_EINDT_AB":
//                                restr = "EINDT_AB";
//                                break;
//                            case "EKES_EINDT_LA":
//                                restr = "EINDT_LA";
//                                break;
//                            case "PO item confirmed AB qty":
//                                restr = "MENGE_AB";
//                                break;
//                            case "PO item confirmed LA qty":
//                                restr = "MENGE_LA";
//                                break;
//                            case "PO Number":
//                                restr = "EBELN";
//                                break;
//                            case "PO Item":
//                                restr = "EBELP";
//                                break;
//                            case "Customer Number":
//                                restr = "KUNNR";
//                                break;
//                            case "Customer Name1":
//                                restr = "KNA1_NAME1";
//                                break;
//                            case "SO Date":
//                                restr = "AUDAT";
//                                break;
//                            case "PO date":
//                                restr = "BSTDK";
//                                break;
//                            case "Discount":
//                                restr = "Discount";
//                                break;
//                            case "Cumulative Order Quantity in Sales":
//                                restr = "ItemRequiredQuantity";
//                                break;
//                            case "Material Description":
//                                restr = "ARKTX";
//                                break;
//                            case "ZOP2 DATE":
//                                restr = "ZOP2_DATE";
//                                break;
//                            case "ZRDE DATE":
//                                restr = "ZRDE_DATE";
//                                break;
//                            case "ZLAV DATE":
//                                restr = "ZLAV_DATE";
//                                break;
//                            case "Employee ID":
//                                restr = "Employee_ID";
//                                break;
//                            case "Employee Name":
//                                restr = "Employee_Name";
//                                break;
//                            case "VBEZ":
//                                restr = "VBEZ";
//                                break;
//                            case "POM-item":
//                                restr = "POM_Item";
//                                break;
//                            case "ZMIN":
//                                restr = "ZMIN_Block";
//                                break;
//                            case "DLBL":
//                                restr = "Delivery_Block";
//                                break;
//                            case "Header status":
//                                restr = "Order_Status";
//                                break;
//                            case "Reason for rejection":
//                                restr = "Reason_For_Rejection";
//                                break;
//                            case "Invoice Qty":
//                                restr = "Invoice_Qty";
//                                break;
//                            case "Invoice creation date":
//                                restr = "Invoice_Create_Date";
//                                break;
//                            case "Invoice creation time":
//                                restr = "Invoice_Create_Time";
//                                break;
//                            case "Invoice release date":
//                                restr = "Invoice_Release_Date";
//                                break;
//                            case "Invoince release time":
//                                restr = "Invoice_Release_Time";
//                                break;
//                            case "email address":
//                                restr = "Email_Address";
//                                break;
//                            case "SO Time":
//                                restr = "SO_Time";
//                                break;
//                            case "SPR No":
//                                restr = "SPR_No";
//                                break;
//                            case "PGI Date":
//                                restr = "PGI_Date";
//                                break;
//                            case "PGI Time":
//                                restr = "PGI_Time";
//                                break;
//                            case "Customer required date":
//                                restr = "Customer_Required_Date";
//                                break;
//                            case "VBEZ-CODE":
//                                restr = "VBEZ_Code";
//                                break;
//                            default:
//                                restr = columnName;
//                                break;
//                        }
//                        break;
//                    case "MATERIAL_STOCK_DOWNLOAD":
//                        switch (columnName)
//                        {
//                            case "Base Unit":
//                                restr = "Base_Unit";
//                                break;
//                            case "Material Number":
//                                restr = "Material_Number";
//                                break;
//                            case "Plant":
//                                restr = "Plant";
//                                break;
//                            case "Storage Location":
//                                restr = "Storage_Location";
//                                break;
//                            case "Own and consignment stock":
//                                restr = "Unrestricted_Stock";
//                                break;
//                            default:
//                                restr = columnName;
//                                break;
//                        }
//                        break;
//                    case "MATERIAL_MASTER_DOWNLOAD":
//                        switch (columnName)
//                        {
//                            case "Base Unit":
//                                restr = "BaseUnit";
//                                break;
//                            case "Currency":
//                                restr = "Currency";
//                                break;
//                            case "Dist Channel":
//                                restr = "DistChannel";
//                                break;
//                            case "Gross weight":
//                                restr = "Grossweight";
//                                break;
//                            case "GRT":
//                                restr = "GRT";
//                                break;
//                            case "Item Category Group":
//                                restr = "ItemCategoryGroup";
//                                break;
//                            case "Material Description":
//                                restr = "MaterialDescription";
//                                break;
//                            case "Material Group":
//                                restr = "MaterialGroup";
//                                break;
//                            case "Material Number":
//                                restr = "MaterialNumber";
//                                break;
//                            case "Print":
//                                restr = "MLFB";
//                                break;
//                            case "Sort":
//                                restr = "MLFB_Sort";
//                                break;
//                            case "Net Weight":
//                                restr = "NetWeight";
//                                break;
//                            case "Options":
//                                restr = "Options";
//                                break;
//                            case "Per":
//                                restr = "Per";
//                                break;
//                            case "Planned Delivery Time":
//                                restr = "PlannedDeliveryTime";
//                                break;
//                            case "Plant":
//                                restr = "Plant";
//                                break;
//                            case "Product List Price":
//                                restr = "ProductListPrice";
//                                break;
//                            case "Profit Center":
//                                restr = "ProfitCenter";
//                                break;
//                            case "Sales Org":
//                                restr = "SalesOrg";
//                                break;
//                            case "Unit of Measure":
//                                restr = "UnitofMeasure";
//                                break;
//                            case "Vendor Name":
//                                restr = "VendorName";
//                                break;
//                            case "Vendor Number":
//                                restr = "VendorNumber";
//                                break;
//                            case "Weight UOM":
//                                restr = "WeightUOM";
//                                break;
//                            case "Min. dely qty"://Min.order qty
//                                restr = "Min_order_qty";
//                                break;
//                            case "Material Status":
//                                restr = "MaterialStatus";
//                                break;
//                            case "GBK":
//                                restr = "GBK";
//                                break;
//                            case "Product hierarchy":
//                                restr = "ProductHierarchy";
//                                break;
//                            default:
//                                restr = columnName;
//                                break;
//                        }
//                        break;
//                }

//                return restr;
//            }
//            #endregion

//            #region CSV => DataTable by filetype new
//            /// <summary>
//            /// CSV 提取数据到 DataTable
//            /// </summary>
//            /// <param name="remotePath">远程路径</param>
//            /// <param name="filetype">文件类别（订单/库存/物料）</param>
//            /// <returns></returns>
//            public DataTable GetDataTable_New(string remotePath, string filetype)
//            {
//                using (StreamReader sr = sftp.OpenText(remotePath))
//                {
//                    DataTable dt = new DataTable();
//                    //记录每次读取的一行记录
//                    string strLine = "";
//                    //记录每行记录中的各字段内容
//                    string[] aryLine;
//                    //标示是否是读取的第一行
//                    bool IsFirst = true;

//                    //逐行读取CSV中的数据
//                    while ((strLine = sr.ReadLine()) != null)
//                    {
//                        aryLine = strLine.Trim().Split('\t'); //把读取到的内容分割
//                        if (IsFirst == true)
//                        {
//                            //创建列
//                            IsFirst = false;
//                            for (int i = 0; i < aryLine.Length; i++)
//                            {
//                                string columnName = GetColumnName_New(aryLine[i], filetype);
//                                if (!dt.Columns.Contains(columnName))
//                                    dt.Columns.Add(new DataColumn(columnName));
//                            }
//                        }
//                        else
//                        {
//                            //创建行
//                            DataRow dr = dt.NewRow();
//                            for (int j = 0; j < dt.Columns.Count; j++)
//                                dr[j] = aryLine.Length > j && !string.IsNullOrEmpty(aryLine[j]) ? aryLine[j] : "";
//                            dt.Rows.Add(dr);
//                        }
//                    }
//                    return dt;
//                }
//            }

//            /// <summary>
//            /// 映射字段名
//            /// </summary>
//            /// <param name="columnName">DT 列名</param>
//            /// <param name="filetype">文件类别</param>
//            /// <returns></returns>
//            private string GetColumnName_New(string columnName, string filetype)
//            {
//                string order = System.Configuration.ConfigurationManager.AppSettings["Order"];
//                string stock = System.Configuration.ConfigurationManager.AppSettings["Stock"];
//                string master = System.Configuration.ConfigurationManager.AppSettings["Master"];

//                string restr = columnName;
//                if (filetype.Equals(order))
//                {
//                    switch (columnName)
//                    {
//                        //未完成
//                        default:
//                            restr = columnName;
//                            break;
//                    }
//                }
//                if (filetype.Equals(stock))
//                {
//                    switch (columnName)
//                    {
//                        case "Material Number":
//                            restr = "MaterialNumber";
//                            break;
//                        case "Own and consignment stock":
//                            restr = "StockQuantity";
//                            break;
//                        default:
//                            restr = columnName;
//                            break;
//                    }
//                }
//                if (filetype.Equals(master))
//                {
//                    switch (columnName)
//                    {
//                        case "Material Number":
//                            restr = "MaterialNumber";
//                            break;
//                        case "Print":
//                            restr = "MLFB_Print";
//                            break;
//                        case "Sort":
//                            restr = "MLFB_Sort";
//                            break;
//                        case "Material Description":
//                            restr = "MaterialDescription";
//                            break;
//                        case "Material Group":
//                            restr = "MaterialGroup";
//                            break;
//                        case "Item Category Group":
//                            restr = "ItemCategoryGroup";
//                            break;
//                        case "Base Unit":
//                            restr = "BaseUnit";
//                            break;
//                        case "Currency":
//                            restr = "Currency";
//                            break;
//                        case "Dist Channel":
//                            restr = "DistChannel";
//                            break;
//                        case "Gross weight":
//                            restr = "GrossWeight";
//                            break;
//                        case "Net Weight":
//                            restr = "NetWeight";
//                            break;
//                        case "GRT":
//                            restr = "GRT";
//                            break;
//                        case "Options":
//                            restr = "Options";
//                            break;
//                        case "Per":
//                            restr = "Per";
//                            break;
//                        case "Planned Delivery Time":
//                            restr = "PlannedDeliveryTime";
//                            break;
//                        case "Plant":
//                            restr = "Plant";
//                            break;
//                        case "Product List Price":
//                            restr = "ListPrice";
//                            break;
//                        case "Profit Center":
//                            restr = "ProfitCenter";
//                            break;
//                        case "Sales Org":
//                            restr = "SalesOrg";
//                            break;
//                        case "Unit of Measure":
//                            restr = "UnitOfMeasure";
//                            break;
//                        case "Weight UOM":
//                            restr = "WeightUOM";
//                            break;
//                        case "Vendor Name":
//                            restr = "VendorName";
//                            break;
//                        case "Vendor Number":
//                            restr = "VendorNumber";
//                            break;
//                        case "Min. dely qty":
//                            restr = "Min_Dely_Qty";
//                            break;
//                        case "Material Status":
//                            restr = "MaterialStatus";
//                            break;
//                        case "GBK":
//                            restr = "GBK";
//                            break;
//                        case "Product hierarchy":
//                            restr = "ProductHierarchy";
//                            break;
//                        default:
//                            restr = columnName;
//                            break;
//                    }
//                }
//                return restr;
//            }
//            #endregion
//        }




//    }
//}
