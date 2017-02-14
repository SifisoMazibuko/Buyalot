using Buyalot.DbConnection;
using Buyalot.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Buyalot.Initializer
{
    public class RegisterInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
           // context.AdminModelSet.AddOrUpdate(
           // p => p.adminName,
           // new AdminModel { adminName = "Sifiso" },
           // new AdminModel { email = "admin@buyalot.co.za" },
           // new AdminModel { password = "buyalot@1" }
           //);
           // context.AdminModelSet.AddOrUpdate();
           // context.SaveChanges();

           // var customer = new List<CustomerModel> {
            
           //         new CustomerModel{firstName = "Sifiso", lastName = "Mazibuko", phone = "0721548566", email = "sifiso@reverside.co.za", password = "12345", confirmPassword = "12345", state = "Active"}
           // };
           // customer.ForEach(c => context.CustomerModelSet.Add(c));
           // context.SaveChanges();
        }
    }
}