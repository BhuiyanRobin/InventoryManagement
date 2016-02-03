using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using InventoryManagement.Models.DAO;

namespace InventoryManagement.Models.DAL
{
    public class Gateway:DbContext
    {
        public Gateway(): base("connection")
        {
            
        }
        public DbSet<ProductCategory> ProductCategories { set; get; }
        public DbSet<RetailStore> RetailStores { set; get; }
        public DbSet<CustomerCategory> CustomerCategories { set; get; }
        public DbSet<Customer> Customer { set; get; }
        public DbSet<OrderTable> Order { set; get; } 
        public DbSet<Product> Products { set; get; } 

        
    }
}