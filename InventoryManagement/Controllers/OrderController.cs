using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using InventoryManagement.Models.DAO;
using InventoryManagement.Models.DAL;

namespace InventoryManagement.Controllers
{
    public class OrderController : Controller
    {
        private Gateway db = new Gateway();

        // GET: /Order/
        public ActionResult Index()
        {
            var order = db.Order.Include(o => o.ACustomer).Include(o => o.AProductCategory);
            return View(order.ToList());
        }

        // GET: /Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderTable ordertable = db.Order.Find(id);
            if (ordertable == null)
            {
                return HttpNotFound();
            }
            return View(ordertable);
        }

        // GET: /Order/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customer, "Id", "Name");
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "Id", "CategoryName");
            return View();
        }

        // POST: /Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,InvoiceNumber,CustomerId,ShipTo,ProductCategoryId,Quantity,TotalAmount,PurchaseDate,ShipingDate,Discount,Tax,TaxType1,TaxType2")] OrderTable ordertable)
        {
            if (ModelState.IsValid)
            {
                db.Order.Add(ordertable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customer, "Id", "Name", ordertable.CustomerId);
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "Id", "CategoryName", ordertable.ProductCategoryId);
            return View(ordertable);
        }

        // GET: /Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderTable ordertable = db.Order.Find(id);
            if (ordertable == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customer, "Id", "Name", ordertable.CustomerId);
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "Id", "CategoryName", ordertable.ProductCategoryId);
            return View(ordertable);
        }

        // POST: /Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,InvoiceNumber,CustomerId,ShipTo,ProductCategoryId,Quantity,TotalAmount,PurchaseDate,ShipingDate,Discount,Tax,TaxType1,TaxType2")] OrderTable ordertable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordertable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customer, "Id", "Name", ordertable.CustomerId);
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "Id", "CategoryName", ordertable.ProductCategoryId);
            return View(ordertable);
        }

        // GET: /Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderTable ordertable = db.Order.Find(id);
            if (ordertable == null)
            {
                return HttpNotFound();
            }
            return View(ordertable);
        }

        // POST: /Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderTable ordertable = db.Order.Find(id);
            db.Order.Remove(ordertable);
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

        public ActionResult AllProduct(int productCategoryId)
        {
            var allProducts = db.Products.Where(x => x.ProductCategoryId == productCategoryId).ToList();
            return Json(allProducts, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchProduct(int id)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            return Json(product, JsonRequestBehavior.AllowGet);
        }
        public ActionResult OrderInfo(OrderTable order)
        {
            
            order.PurchaseDate = DateTime.Today;
            order.ShipingDate = DateTime.Today;
          
            db.Order.Add(order);
            Product aProduct = db.Products.FirstOrDefault(x => x.Id == order.ProductId && x.ProductCategoryId == order.ProductCategoryId);
            aProduct.Quantity = aProduct.Quantity-order.Quantity;
            db.Entry(aProduct).State = EntityState.Modified;
            db.SaveChanges();
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}
