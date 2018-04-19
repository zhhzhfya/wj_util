using hessiancsharp.client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wj_util.hessian
{
    class HessianHelper
    {
        public static string url = @"http://192.168.4.254:8080/wj/hessian";
        static CHessianProxyFactory factory;
        static HessianHelper()
        {
            factory = new CHessianProxyFactory();
        }

        public static List<object[]> query(string sql, int offset, int pagesize) 
        {
            ISqlService proxy = (ISqlService)factory.Create(typeof(ISqlService), url);
            List<object[]> list;
            try
            {
                list = proxy.query(sql, offset, pagesize);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                list = new List<object[]>();
            }
            return list;
        }
    }
}
