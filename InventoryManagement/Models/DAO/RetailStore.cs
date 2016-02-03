using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models.DAO
{
    public class RetailStore
    {
        public int Id { set; get; }
        public string StoreName { set; get; }
        public string StoreCode { set; get; }
        public string Address { set; get; }
        public string ZipCode { set; get; }
        public string PostalCode { set; get; }
    }
}