using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using wj_util.events;
using wj_util.utils;

namespace wj_util.model
{
    class TemplateMgr
    {

        // 100个数组，方便实现redo/undo
        public IList<JObject> jsons = new List<JObject>();
        public TreeView treeView { get; set; }

        public static String out_path { get; set; }

        public static bool working = false;

        public TemplateMgr()
        {
            // 订阅服务配置改变的事件
            EventBusHelper.getBus().Subscribe<EventAdd<TreeNode>>(evt =>
            {
                nodeAdd(evt.treeNode, evt.text);
            });

            EventBusHelper.getBus().Subscribe<EventModify<TreeNode>>(evt =>
            {
                nodeModify(evt.treeNode, evt.config);
            });

            EventBusHelper.getBus().Subscribe<EventDelete<TreeNode>>(evt =>
            {
                nodeDel(evt.treeNode);
            });
        }

        private void nodeDel(TreeNode selectedNode)
        {
            if (selectedNode.Level == 1)
            {
                string key = selectedNode.Text;
                foreach (JObject j in jsons)
                {
                    if (j["text"].ToString().Equals(key))
                    {
                        // 删除json
                        jsons.Remove(j);
                        // 删除文件
                        FileHelper.DeleteFile(j["path"] + "\\" + j["text"] + ".json");
                        break;
                    }
                }
                selectedNode.Remove();
            }
            if (selectedNode.Level == 2)
            {
                // 删除field 、保存文件
                foreach (JObject j in jsons)
                {
                    if (j["text"].ToString().Equals(selectedNode.Parent.Text))
                    {
                        JArray childs = (JArray)j["childs"];
                        for (int i = 0; i < childs.Count; i++)
                        {
                            JObject c = (JObject)childs[i];
                            if (c["text"].ToString().Equals(selectedNode.Text))
                            {
                                // 删除掉某个field
                                childs.Remove(c);
                                // 保存json
                                string file = j["path"].ToString() + selectedNode.Parent.Text + ".json";
                                FileHelper.Write(file, j.ToString(), true);
                                // 提示信息
                                EventUtil.send("保存文件：" + file);
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void nodeAdd(TreeNode selectedNode, String text)
        {
            if (selectedNode.Level == 0)
            {
                TreeNode tn = selectedNode.Nodes.Add(text, text, 1, 1);
                JObject j = new JObject();
                j["text"] = text;
                j["path"] = System.AppDomain.CurrentDomain.BaseDirectory;
                j["childs"] = new JArray();
                jsons.Add(j);
                tn.Tag = j;
                selectedNode.Expand();
            }
            // 添加field
            if (selectedNode.Level == 1)
            {
                TreeNode tn = selectedNode.Nodes.Add(text, text, selectedNode.Level + 1, selectedNode.Level + 1);
                selectedNode.Expand();
                JObject j = (JObject)selectedNode.Tag;
                JObject leaf = new JObject();
                leaf["text"] = text;
                tn.Tag = leaf;
                JArray childs = (JArray)j["childs"];
                childs.Add(leaf);
            }

        }
        public void nodeModify(TreeNode selectedFieldNode, JObject json)
        {
            if (selectedFieldNode.Level == 2)
            {
                selectedFieldNode.Tag = json;
                JObject j = (JObject)selectedFieldNode.Parent.Tag;
                JArray childs = (JArray)j["childs"];

                for (int i = 0; i < childs.Count; i++)
                {
                    JObject c = (JObject)childs[i];
                    if (c["text"].ToString().Equals(selectedFieldNode.Text))
                    {
                        childs[i] = json;
                        break;
                    }
                }
                // 保存json
                string file = j["path"].ToString() + selectedFieldNode.Parent.Text + ".json";
                FileHelper.Write(file, j.ToString(), true);
                EventUtil.send("保存文件：" + file);
            }
        }

        public void readTemplateFile(string[] files)
        {
            for (int i = 0; i < files.Length; i++)
            {
                if (!files[i].ToLower().EndsWith(".json"))
                {
                    continue;
                }
                try
                {
                    string json = FileHelper.Read(files[i], Encoding.UTF8);
                    JObject j = JObject.Parse(json);
                    // 把模板路径放到json里
                    j["path"] = files[i].Substring(0, files[i].LastIndexOf("\\") + 1);
                    // 解析json格式，构建treenode添加到treeview1
                    if (j["text"] != null && !treeView.Nodes[0].Nodes.ContainsKey(j["text"].ToString()))
                    {
                        TreeNode node1 = treeView.Nodes[0].Nodes.Add(j["text"].ToString(), j["text"].ToString(), 1, 1);
                        node1.Tag = j;
                        JArray childs = (JArray)j["childs"];
                        foreach (JObject chl in childs)
                        {
                            TreeNode leaf = node1.Nodes.Add(chl["text"].ToString(), chl["text"].ToString(), 2, 2);
                            leaf.Tag = chl;
                        }
                        jsons.Add(j);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
            treeView.Nodes[0].Expand();
        }

        public void startWork()
        {
            working = true;
            // 起线程池，就行生成模拟数据
            foreach (JObject json in jsons)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(genData), json);
                Console.WriteLine("start" + json["text"]);
            }
        }

        /// <summary>
        /// type,gen_type,ini_value,len
        /// </summary>
        /// <param name="state"></param>
        static void genData(object state)
        {
            JObject json = (JObject)state;
            int i = 0;
            StringBuilder sb = new StringBuilder();
            JArray childs = (JArray)json["childs"];
            while (working)
            {
                foreach (JObject chl in childs)
                {
                    object v = null;// type,gen_type,ini_value,len
                    if (chl["type"]!=null)
                    {
                        switch (chl["type"].ToString())
                        {
                            case "文本":
                                v = genStr(chl);
                                break;
                            case "数字":
                                v = genInt(chl);
                                break;
                            case "日期":
                                v = genDate(chl);
                                break;
                            case "Bool":
                                v = genBool(chl);
                                break;
                            case "手机号":
                                v = genPhone(chl);
                                break;
                            default:
                                break;
                        }
                    }
                    sb.Append(v).Append(",");
                }
                sb.Length = sb.Length - 1;
                i++;
                sb.Append("\r\n");
                if (i >= ran.Next(1000, 3000))
                {
                    string file = out_path + "\\" + json["text"] + "\\" + DateUtil.GetTimeStamp()+ ".csv";
                    FileHelper.Write(file, sb.ToString());
                    sb.Length = 0;
                    i = 0;
                }

            }
            Console.WriteLine("end" + json["text"]);
        }

        private static object genStr(JObject chl)
        {
            object v = null;
            if (chl["ini_value"] != null && !String.IsNullOrEmpty(chl["ini_value"].ToString()))
            {
                v = chl["ini_value"].ToString();
            }
            if (chl["gen_type"] != null && !String.IsNullOrEmpty(chl["gen_type"].ToString()))
            {
                if (chl["gen_type"].ToString().Equals("随机"))
                {
                    v = Guid.NewGuid().ToString("N");  
                }
                if (chl["gen_type"].ToString().Equals("固定"))
                {
                    if (v == null)
                    {
                        v = Guid.NewGuid().ToString("N");
                    }
                }
            }
            return v;
        }

        static Random ran = new Random();
        private static object genInt(JObject chl)
        {
            object v = null;
            Random ran = new Random();
            v = ran.Next();
            return v;
        }
        private static object genDate(JObject chl)
        {
            object v = null;
            v = DateUtil.GetDateTime();
            return v;
        }
        private static object genBool(JObject chl)
        {
            object v = null;

            return v;
        }
        private static object genPhone(JObject chl)
        {
            object v = null;
            v = getRandomTel();
            return v;
        }

        private static string[] telStarts = "134,135,136,137,138,139,150,151,152,157,158,159,130,131,132,155,156,133,153,180,181,182,183,185,186,176,187,188,189,177,178".Split(',');


        /// <summary>
        /// 随机生成电话号码
        /// </summary>
        /// <returns></returns>
        public static string getRandomTel()
        {
            int n = ran.Next(10, 1000);
            int index = ran.Next(0, telStarts.Length - 1);
            string first = telStarts[index];
            string second = (ran.Next(100, 888) + 10000).ToString().Substring(1);
            string thrid = (ran.Next(1, 9100) + 10000).ToString().Substring(1);
            return first + second + thrid;
        }
    }
}
