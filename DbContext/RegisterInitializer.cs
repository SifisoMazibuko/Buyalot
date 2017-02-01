using Buyalot.DbConnection;
using Buyalot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buyalot.Initializer
{
    public class RegisterInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var customer = new List<CustomerModel> {
            
                    new CustomerModel{firstName = "Sifiso", lastName = "Mazibuko", phone = "0721548566", email = "sifiso@reverside.co.za", password = "12345", confirmPassword = "12345", state = "Active"}
            };
            customer.ForEach(c => context.CustomerModelSet.Add(c));
            context.SaveChanges();
        }
    }
}