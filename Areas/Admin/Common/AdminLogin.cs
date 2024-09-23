using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAgarden_CNPM.Areas.Admin.Common
{
    public class AdminLogin
    {
        public long UserID { set; get; }
        public string UserName { set; get; }
        public string GroupID { set; get; }
    }
}