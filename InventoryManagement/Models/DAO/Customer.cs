using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models.DAO
{
    public class Customer
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string PhoneNumebr { set; get; }
        public string MobileNumber { set; get; }
        public string PurchaseAmount { set; get; }
        public string Address { set; get; }
        public DateTime DateOfBirth { set; get; }
        public string Email { set; get; }
        public int CustomerCategoryId { set; get; }
        public double Discount { set; get; }
        public virtual CustomerCategory ACustomerCategory { set; get; }
        

    }
}