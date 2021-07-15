using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Query1()
        {
            dbLPstoresEntities pentity = new dbLPstoresEntities();
                List<Product> product = pentity.Products.ToList();
                List<Customer> customer = pentity.Customers.ToList();
                List<PurchaseOrder> purchaseOrder = pentity.PurchaseOrders.ToList();
                List<PurchaseOrderDetail> purchaseOrderDetail = pentity.PurchaseOrderDetails.ToList();
                var obj = from C in pentity.Customers
                          join PO in pentity.PurchaseOrders
                          on C.CustomerID equals PO.CustomerID
                          join POD in pentity.PurchaseOrderDetails
                          on PO.POID equals POD.POID
                          join P in pentity.Products
                          on POD.ProductID equals P.ProductID
                          select new ViewModel1
                          {
                              CustomerName = C,
                              POID = PO,
                              ProductName = P,
                              Price = POD
                          };
                return View(obj);
            
        }
        public ActionResult Query2()
        {
            dbLPstoresEntities pentity = new dbLPstoresEntities();
            List<Customer> customers = pentity.Customers.ToList();
            List<PurchaseOrder> purchaseOrder = pentity.PurchaseOrders.ToList();
            var obj = from po in purchaseOrder
                     join c in customers on po.CustomerID equals c.CustomerID
                     orderby po.Date
                     select new ViewModel2
                     {
                         CustomerName = c,
                         Date = po.Date,
                         Amount = po
                     };
            return View(obj);

        }
        public ActionResult Query3()
        {
            dbLPstoresEntities pentity = new dbLPstoresEntities();
            List<Product> products = pentity.Products.ToList();
            List<PurchaseOrder> purchaseOrder = pentity.PurchaseOrders.ToList();
            List<PurchaseOrderDetail> purchaseOrderDetail = pentity.PurchaseOrderDetails.ToList();
            var IE = from p in products
                     join pod in purchaseOrderDetail on p.ProductID equals pod.ProductID
                     join po in purchaseOrder on pod.POID equals po.POID
                     orderby po.Date
                     select new ViewModel3
                     {
                         Date = po.Date,
                         ProductName = p,
                         Quantity = pod
                     };
            return View(IE);
        }
        public ActionResult Query4()
        {
            dbLPstoresEntities pentity = new dbLPstoresEntities();
            List<PurchaseOrder> purchaseOrder = pentity.PurchaseOrders.ToList();
            List<PurchaseOrderDetail> purchaseOrderDetail = pentity.PurchaseOrderDetails.ToList();
            var IE1 = from po in purchaseOrder
                      join pod in purchaseOrderDetail on po.POID equals pod.POID
                      group new { po, pod } by new { po.Date } into G
                      let firstproductgroup = G.FirstOrDefault()
                      let DOP = firstproductgroup.po
                      let POID = firstproductgroup.pod
                      let maxprice = G.Max(m => m.pod.Price)
                      select new ViewModel4
                      {
                          Date = DOP.Date,
                          POID = POID,
                          Price = maxprice
                      };
            return View(IE1);
        }
    }
}