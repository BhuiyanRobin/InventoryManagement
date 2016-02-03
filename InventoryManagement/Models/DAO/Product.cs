using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models.DAO
{
    public class Product
    {
        
        public int Id { set; get; }
        public int ProductCategoryId { set; get; }
        public String Name { set; get; }
        public string Code { set; get; }
        public double PurchasePrice { set; get; }
        public double UnitPrice { set; get; }
        public int Quantity { set; get; }
        public virtual ProductCategory AProductCategory { set; get; }
    }
}