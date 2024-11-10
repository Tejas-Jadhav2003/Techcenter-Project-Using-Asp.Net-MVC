using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sagar.mobile.shopy.business.Models
{
    public class Bill
    {
        public int billId { get; set; }
        public string billNo { get; set; }
        public string customerName { get; set; }
        public string address { get; set; }
        public float subTotal { get; set; }
        public float gst { get; set; }
        public float total { get; set; }
        public DateTime date { get; set; }
        public List<ProductBill> productBills { get; set; }
    }

    public class ProductBill
    {
        public int productBillId { get; set; }
        public float price { get; set; }
        public int qty { get; set; }
        public float warrenty { get; set; }
        public float total { get; set; }
        public int billId { get; set; }
        public int purchaseId { get; set; }
      
    }

}
