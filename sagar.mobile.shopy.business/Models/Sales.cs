using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sagar.mobile.shopy.business.Models
{
    public class Sales
    {
        public string imei_no { get; set; }
        public string company_name { get; set; }
        public string model_name { get; set; }
        public int warranty { get; set; }
        public int qty { get; set; }
        public float total { get; set; }
        public DateTime date { get; set; }
    }
}
