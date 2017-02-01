﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Buyalot.Models
{
    public class PaymentModel
    {
        public int paymentID { get; set; }
        public int customerID { get; set; }
        public int orderID { get; set; }
        public DateTime paymentDate { get; set; }
        public string paymentType { get; set; }
        public decimal totalPrice { get; set; }
    }
}