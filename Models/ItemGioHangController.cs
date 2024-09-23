using MyClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LAgardenCNPM;
namespace LAgarden_CNPM.Models
{
    [Serializable]

    public class ItemGioHang
    {
        public long IDMonAn { set; get; }
        public int SoLuong { set; get; }
    }
}