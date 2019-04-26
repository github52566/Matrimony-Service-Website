using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Matrimonial_Website.Models
{
    public class Registration
    {
        public string u_id { get; set; }
        public string pass { get; set; }
        public string F_name { get; set; }
        public string L_name { get; set; }
        public string religion { get; set; }
        public string gender { get; set; }
    }
}