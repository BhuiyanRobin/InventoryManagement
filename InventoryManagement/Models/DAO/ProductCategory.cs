using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Antlr.Runtime.Tree;

namespace InventoryManagement.Models.DAO
{
    public class ProductCategory
    {
        public int Id { set; get; }
        public string CategoryName { set; get; }
        public string CategoryCode { set; get; }
    }
}