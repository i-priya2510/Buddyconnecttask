using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class ViewModel1
    {
        public Customer CustomerName { get; set; }
        public PurchaseOrder POID { get; set; }
        public Product ProductName { get; set; }
        public PurchaseOrderDetail Price { get; set; }
    }
}