using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using wj_util.events;
using wj_util.model;
using wj_util.utils;

namespace WjUtil.forms
{
    public partial class FormSimulation : Form
    {

        public TreeNode activeNode = null;

        static TemplateMgr templateMgr = new TemplateMgr();

        public string temp_path = "";
        // 2个变量，用于展示模板节点、叶子节点数据
        FormFieldNode formField;
        FormTemplateNode formTemplateNode;

        public FormSimulation()
        {
            InitializeComponent();
            templateMgr.treeView = this.treeView1;
            TemplateMgr.out_path = this.txtPath.Text;
            treeView1.HideSelection = false;
            //自已绘制  
            this.treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;
            this.treeView1.DrawNode += new DrawTreeNodeEventHandler(treeView1_DrawNode);  
        }
        //temp_path = System.AppDomain.CurrentDomain.BaseDirectory;

        //在绘制节点事件中，按自已想的绘制  
        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true; //我这里用默认颜色即可，只需要在TreeView失去焦点时选中节点仍然突显  
            return;
            //or  自定义颜色  
            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                //演示为绿底白字  
                e.Graphics.FillRectangle(Brushes.DarkBlue, e.Node.Bounds);

                Font nodeFont = e.Node.NodeFont;
                if (nodeFont == null) nodeFont = ((TreeView)sender).Font;
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White, Rectangle.Inflate(e.Bounds, 2, 0));
            }
            else
            {
                e.DrawDefault = true;
            }

            if ((e.State & TreeNodeStates.Focused) != 0)
            {
                using (Pen focusPen = new Pen(Color.Black))
                {
                    focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    Rectangle focusBounds = e.Node.Bounds;
                    focusBounds.Size = new Size(focusBounds.Width - 1,
                    focusBounds.Height - 1);
                    e.Graphics.DrawRectangle(focusPen, focusBounds);
                }
            }

        }  

        private void 添加字段ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        void form2_OkEvent(string text)
        {
            TreeNode tn;
            int i;
            if (treeView1.SelectedNode != null)
            {
                tn = treeView1.SelectedNode.Nodes.Add(text);
                i = treeView1.SelectedNode.Level + 1;
            }
            else
            {
                tn = treeView1.Nodes.Add(text);
                i = 0;
            }
            tn.ImageIndex = i;
            tn.SelectedImageIndex = i;
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //|| e.Node.Parent == null 
            e.Node.SelectedImageIndex = e.Node.ImageIndex;

            if (e.Button == MouseButtons.Left && e.Node != null)
            {
                nodeLeftClick(e);
            }
            if (e.Button == MouseButtons.Right && e.Node != null)
            {
                nodeRightClick(e);
            }
        }

        private void nodeLeftClick(TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 2)
            {
                //this.textBox_ini_value.Text = e.Node.Text;
                //e.Node.BeginEdit();
            }
        }




        private void nodeRightClick(TreeNodeMouseClickEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
            this.contextMenuStrip1 = new ContextMenuStrip();
            if (e.Node.Level <= 1)
            {
                ToolStripMenuItem itemAdd = new ToolStripMenuItem("添加节点");
                itemAdd.Click += new EventHandler(itemAdd_click);
                contextMenuStrip1.Items.Add(itemAdd);
            }
            if (e.Node.Level >= 1)
            {
                ToolStripMenuItem itemDel = new ToolStripMenuItem("删除");
                itemDel.Click += new EventHandler(itemDel_click);
                contextMenuStrip1.Items.Add(itemDel);
            }
            contextMenuStrip1.Show(treeView1, e.X, e.Y);
        }

        void itemDel_click(object sender, EventArgs e)
        {
            // 删除某个节点
            EventBusHelper.getBus().Publish(new EventDelete<TreeNode>(treeView1.SelectedNode));
        }

        void itemAdd_click(object sender, EventArgs e)
        {
            FormInput fi = new FormInput();
            fi.OkEvent += new OkDelegate(itemAdd_OkEvent);
            fi.ShowDialog();
        }

        void itemAdd_OkEvent(string text)
        {
            EventBusHelper.getBus().Publish(new EventAdd<TreeNode>(treeView1.SelectedNode, text));
        }

        private void FormSimulation_Load(object sender, EventArgs e)
        {
            TreeNode tn = this.treeView1.Nodes.Add("root", "数据模板", 0, 0);
            tn.ImageIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.txtPath.Text = path.SelectedPath;
            TemplateMgr.out_path = path.SelectedPath;
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level >= 1)
            {

            }
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && treeView1.SelectedNode != null && treeView1.SelectedNode.Level <= 1)
            {
                FormInput fi = new FormInput();
                fi.OkEvent += new OkDelegate(itemAdd_OkEvent);
                fi.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 检查路径
            if (!Directory.Exists(this.txtPath.Text))
            {
                MessageBox.Show("保存路径错误");
                return;
            }
            if (treeView1.Nodes[0].Nodes.Count == 0)
            {
                MessageBox.Show("请添加模板");
                return;
            }
            if (TemplateMgr.working)
	        {
                TemplateMgr.working = false;
	        }
            else
            {
                templateMgr.startWork();
            }
            this.button1.Text = TemplateMgr.working ? "停止" : "开始生成";
        }


        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "json文件(*.json)|*.json";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] files = dialog.FileNames;
                templateMgr.readTemplateFile(files);
            }
        }



        public JObject loopJson(TreeNode node)
        {
            JObject boot = new JObject();
            TreeNodeCollection nodes = node.Nodes;
            if (nodes.Count > 0)
            {
                JArray js = new JArray();
                foreach (TreeNode chl in nodes)
                {
                    JObject json = loopJson(chl);
                    js.Add(json);
                }
                boot["childs"] = js;
            }
            boot["text"] = node.Text;
            return boot;
        }

        public void createJson()
        {
            TreeNodeCollection nodes = this.treeView1.Nodes;
            Hashtable ht = new Hashtable();
            JObject _json = loopJson(nodes[0]);
            JArray childs = (JArray)_json["childs"];
            foreach (JObject json in childs)
            {
                // getFieldConfig();
                ht.Add(json["text"].ToString(), json);
            }

            temp_path = String.IsNullOrEmpty(temp_path) ? System.AppDomain.CurrentDomain.BaseDirectory : temp_path;
            if (String.IsNullOrEmpty(temp_path) || activeNode == null || ht[activeNode.Text] == null)
            {
                return;
            }

            //保存到本地文件
            JObject j = (JObject)ht[activeNode.Text];
            string file = temp_path + activeNode.Text + ".json";
            FileHelper.Write(file, j.ToString(), true);
            EventUtil.send("保存文件：" + file);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.panel1.Controls.Clear();
            JObject json = (JObject)e.Node.Tag;
            if (e.Node.Level == 2)
            {
                activeNode = e.Node.Parent;
                if (formTemplateNode != null)
                {
                    formTemplateNode.Hide();
                }
                if (formField == null)
                {
                    formField = new FormFieldNode();
                    formField.TopLevel = false;
                    formField.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    formField.Dock = DockStyle.Fill;
                    formField.ControlBox = false;
                    formField.AutoScroll = true;

                    this.panel1.Controls.Add(formField);
                }
                formField.setData(e.Node, json);
                formField.Show();
            }
            if (e.Node.Level == 1) 
            {
                if (formField != null)
                {
                    formField.Hide();
                }
                if (formTemplateNode == null)
                {
                    formTemplateNode = new FormTemplateNode();
                    formTemplateNode.TopLevel = false;
                    formTemplateNode.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    formTemplateNode.Dock = DockStyle.Fill;
                    formTemplateNode.ControlBox = false;
                    formTemplateNode.AutoScroll = true;
                
                    this.panel1.Controls.Add(formTemplateNode);
                }
                formTemplateNode.setData(e.Node, json);
                formTemplateNode.Show();
            }
        }


        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (String.IsNullOrEmpty(e.Node.Text))
            {
                e.CancelEdit = true;
            }
            else
            {
                // 进行重新修改名称、重新修改文件
                if (e.Node.Level == 1)
                {
                    string file = temp_path + e.Node.Text + ".json";
                    FileHelper.DeleteFile(file);
                    activeNode = e.Node;
                    new Thread(createJson).Start();
                }
            }
            //Console.WriteLine(pre_label + "------>" + e.Label);
        }

        private void treeView1_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node.Level <= 1)
            {
                e.CancelEdit = true;
            }
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode moveNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            //根据鼠标坐标确定要移动到的目标节点
            Point pt = ((TreeView)(sender)).PointToClient(new Point(e.X, e.Y));
            TreeNode targeNode = this.treeView1.GetNodeAt(pt);
            //如果目标节点无子节点则添加为同级节点,反之添加到下级节点的未端
            TreeNode NewMoveNode = (TreeNode)moveNode.Clone();
            if (targeNode.Nodes.Count == 0)
            {
                targeNode.Parent.Nodes.Insert(targeNode.Index, NewMoveNode);
            }
            else
            {
                targeNode.Nodes.Insert(targeNode.Nodes.Count, NewMoveNode);
            }
            //更新当前拖动的节点选择
            treeView1.SelectedNode = NewMoveNode;
            //展开目标节点,便于显示拖放效果
            targeNode.Expand();
            //移除拖放的节点
            moveNode.Remove();
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode"))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void FormSimulation_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void FormSimulation_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            templateMgr.readTemplateFile(files);
        }
    }
}
