using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using InventoryManagement.Models.DAO;
using InventoryManagement.Models.DAL;

namespace InventoryManagement.Controllers
{
    public class ProductController : Controller
    {
        private Gateway db = new Gateway();

        // GET: /Product/
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.AProductCategory);
            return View(products.ToList());
        }

        // GET: /Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: /Product/Create
        public ActionResult Create()
        {
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "Id", "CategoryName");
            return View();
        }

        // POST: /Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ProductCategoryId,Name,Code,UnitPrice,Quantity,PurchasePrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "Id", "CategoryName", product.ProductCategoryId);
            return View(product);
        }

        // GET: /Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "Id", "CategoryName", product.ProductCategoryId);
            return View(product);
        }

        // POST: /Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ProductCategoryId,Name,Code,UnitPrice,Quantity")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "Id", "CategoryName", product.ProductCategoryId);
            return View(product);
        }

        // GET: /Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: /Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult UpdateQuantity()
        {
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "Id", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult UpdateQuantity(int? id, int? productCategoryId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product aProduct = db.Products.FirstOrDefault(x => x.ProductCategoryId == productCategoryId && x.Id == id);
            if (aProduct == null)
            {
                return HttpNotFound();
            }
            return View(aProduct);
        }


        public ActionResult Update(int productCategoryId, int productId, int quantity)
        {
            if (quantity == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           Product aProduct= db.Products.FirstOrDefault(x => x.ProductCategoryId == productCategoryId && x.Id == productId);
            aProduct.Quantity += quantity;
            db.Entry(aProduct).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Added Quantity",JsonRequestBehavior.AllowGet);
        }

        public ActionResult CheckProduct()
        {
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "Id", "CategoryName");
            return View();
        }

        public ActionResult CheckProductInHand(int productCategoryId, int productId)
        {
            ProductCategory aProductCategory = db.ProductCategories.FirstOrDefault(x => x.Id == productCategoryId);
            Product aProduct =db.Products.FirstOrDefault(x => x.Id == productId && x.ProductCategoryId == productCategoryId);

            Products aProducts=new Products();
            aProducts.ProductCategory = aProductCategory.CategoryName;
            aProducts.ProductName = aProduct.Name;
            aProducts.ProductQuantity = aProduct.Quantity;
            return Json(aProducts, JsonRequestBehavior.AllowGet);
        }

        public ActionResult All()
        {
            List<Product> products = db.Products.ToList();
            List<AllProducts>allProductses=new List<AllProducts>();
            foreach (Product product in products)
            {
                AllProducts allProducts=new AllProducts();
                allProducts.ProductCategory = db.ProductCategories.FirstOrDefault(x => x.Id ==product.ProductCategoryId).CategoryName;
                allProducts.ProductName = product.Name;
                allProducts.ProductQuantity = product.Quantity;
                allProductses.Add(allProducts);
            }
            return Json(allProductses, JsonRequestBehavior.AllowGet);
        }
    }

    internal class Products
    {
        public string ProductName { set; get; }
        public string ProductCategory { set; get; }
        public int ProductQuantity { set; get; }
    }

    internal class AllProducts
    {
        public string ProductName { set; get; }
        public string ProductCategory { set; get; }
        public int ProductQuantity { set; get; }
    } 
    
}
