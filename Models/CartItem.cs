using MyClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAgarden_CNPM.Models
{
    [Serializable]
    public class CartItem
    {
        public CTMONAN CTMA { set; get; }
        public int Quantity { set; get; }
    }
}