using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models.DAO
{
    public class CustomerCategory
    {

        public int Id { set; get; }
        public string CategoryName { set; get; }
        public string Code { set; get; }
        public double Discount { set; get; }
        public double PurchaseVloumeTo { set; get; }
        public double PurchaseVolumeForm { set; get; }
    }
}