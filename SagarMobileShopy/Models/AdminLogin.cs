using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SagarMobileShopy.Models
{
    public class AdminLogin
    {
        [Key]
        public int A_Id { get; set; }

        [Required(ErrorMessage ="User Name is Required !")]
        [Display(Name ="UserName")]
        public string A_UserName { get; set; }


        [Required(ErrorMessage = "Password is Required !")]
        [DataType(DataType.Password)]        
        [Display(Name = "Password")]        
        public string A_Password { get; set; }
        
    }
}