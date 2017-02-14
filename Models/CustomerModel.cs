using Buyalot.DbConnection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Buyalot.Models
{
    [Table("Customer")]
    public class CustomerModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int customerID { get; set; }

        [Required(ErrorMessage = "First Name required")]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "Last Name required")]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Phone")]
        public string phone { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        //[Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        public string confirmPassword { get; set; }
        
        public string state { get; set; }

        public bool isValid(string email, string password)
        {
            DataContext context = new DataContext();
            var u = (from s in context.CustomerModelSet
                     where  s.email == email && s.password == password
                     select s).ToList();
            if (u.Count > 0)
                return true;
            else
                return false;
        }


        public virtual ICollection<AddressModel> Addresses { get; set; }
        public virtual ICollection<BillingModel> Billings { get; set; }
        public virtual ICollection<OrderModel> Orders { get; set; }
        public virtual ICollection<PaymentModel> Payments { get; set; }
        
    }
}