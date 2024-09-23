using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LAgarden_CNPM.Models
{
    public class ThanhToanModel
    {
        [Key]
        public int ID { get; set; }
        public string NameRecieve { get; set; }
        public string PhoneRecive { get; set; }
        public string AddressRecive { get; set; }
        
        public string EmailRecieve { get; set; }
    }
}