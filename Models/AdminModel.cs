using Buyalot.DbConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Buyalot.Models
{
    [Table("Admin")]
    public class AdminModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int adminID { get; set; }
        public string adminName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        public bool isValid(string adminName, string email, string password)
        {
            DataContext context = new DataContext();
            var u = (from s in context.AdminModelSet
                     where s.adminName == adminName && s.email == email && s.password == password
                     select s).ToList();
            if (u.Count > 0)
                return true;
            else
                return false;
        }
    }
}