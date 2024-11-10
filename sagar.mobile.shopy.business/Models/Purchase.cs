using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sagar.mobile.shopy.business.Models
{
    public class Purchase
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage ="Company Name Is Required!")]
        public string company_name { get; set; }

        [Display(Name = "Model Name")]
        [Required(ErrorMessage = "Model Name Is Required!")]
        public string model_no { get; set; }

        [Display(Name = "IMEI No")]
        [Required(ErrorMessage = "IMEI No Is Required!")]

        public string imei_no { get; set; }

        [Display(Name = "Features")]
        [Required(ErrorMessage = "Features Is Required!")]     
        public string features { get; set; }

        [Display(Name = "Warranty")]
        [Required(ErrorMessage = "Warranty Is Required!")]
        public int warranty { get; set; }

        [Display(Name = "Qty")]
        [Required(ErrorMessage = "Qty Is Required!")]
        public int qty { get; set; }

        [Display(Name = "Purchase Price")]
        [Required(ErrorMessage = "Purchase Price Is Required!")]
        public float purchase_price { get; set; }

        [Display(Name = "Sale Price")]
        [Required(ErrorMessage = "Sale Price Is Required!")]
        public float sale_price { get; set; }

        [Display(Name = "Total")]
        [Required(ErrorMessage = "Total Is Required!")]
        public float total { get; set; }

    }

}

   