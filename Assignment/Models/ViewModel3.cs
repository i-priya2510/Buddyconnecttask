using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class ViewModel3
    {
        public DateTime? Date { get; set; }
        public Product ProductName { get; set; }
        public PurchaseOrderDetail Quantity { get; set; }
    }
}