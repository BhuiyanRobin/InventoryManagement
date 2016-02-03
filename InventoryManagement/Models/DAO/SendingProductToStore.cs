using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models.DAO
{
    public class SendingProductToStore
    {
        public int Id{set; get;}
        public string InvoiceNumber { set; get; }
        public virtual ProductCategory AProductCategory { set; get; }
        public string ProductName { set; get; }
        public double UnitPrice { set; get; }
        public int UnitSupply { set; get; }
        public double Discount { set; get; }
        public double TotalPrice { set; get; }
        public DateTime SendingDate { set; get; }
        public RetailStore ARetailStore { set; get; }
        
    }
}