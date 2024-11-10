using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace SagarMobileShopy.Models
{
    public class Registration
    {
        [Key]
        public int Cust_Id { get; set; }

        [Required(ErrorMessage ="Name is required !")]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Not a valid First Name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Contact number is required !")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Contact { get; set; }

        [Required(ErrorMessage ="Email ID is required !")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string EmailId { get; set; }

        [Required(ErrorMessage ="Password is required !")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password required !")]
        [DataType(DataType.Password)]
        [NotMapped]
        [CompareAttribute("Password", ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Date")]
        public DateTime Cust_RegisteredDate { get; set; }
       
    }
}