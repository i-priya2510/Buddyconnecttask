using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class ViewModel2
    {
        public Customer CustomerName { get; set; }
        public DateTime? Date { get; set; }
        public PurchaseOrder Amount { get; set; }
    }
}