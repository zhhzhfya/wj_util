using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wj_util.hessian
{
    interface ISqlService
    {
        List<object[]> query(string sql, int offset, int pagesize);
    }
}
