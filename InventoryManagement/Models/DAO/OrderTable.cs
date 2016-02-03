using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.Expressions;

namespace InventoryManagement.Models.DAO
{
    public class OrderTable
    {
        public int Id { set; get; }
        public string InvoiceNumber { set; get; }
        public int CustomerId { set; get; }
        public string ShipTo { set; get; }
        public int ProductCategoryId { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public double TotalAmount { set; get; }
        public DateTime PurchaseDate { set; get; }
        public DateTime ShipingDate { set; get; }
        public double Discount { set; get; }
        public double Tax { set; get; }
        public double TaxType1 { set; get; }
        public double TaxType2 { set; get; }
        public virtual Customer ACustomer { set; get; }
        public virtual ProductCategory AProductCategory { set; get; }
    }
}