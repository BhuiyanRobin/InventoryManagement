using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using InventoryManagement.Models.DAO;
using InventoryManagement.Models.DAL;

namespace InventoryManagement.Controllers
{
    public class CustomerCategoryController : Controller
    {
        private Gateway db = new Gateway();

        // GET: /CustomerCategory/
        public ActionResult Index()
        {
            return View(db.CustomerCategories.ToList());
        }

        // GET: /CustomerCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerCategory customercategory = db.CustomerCategories.Find(id);
            if (customercategory == null)
            {
                return HttpNotFound();
            }
            return View(customercategory);
        }

        // GET: /CustomerCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CustomerCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,CategoryName,Code,PurchaseVloumeTo,PurchaseVolumeForm")] CustomerCategory customercategory)
        {
            if (ModelState.IsValid)
            {
                db.CustomerCategories.Add(customercategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customercategory);
        }

        // GET: /CustomerCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerCategory customercategory = db.CustomerCategories.Find(id);
            if (customercategory == null)
            {
                return HttpNotFound();
            }
            return View(customercategory);
        }

        // POST: /CustomerCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,CategoryName,Code,PurchaseVloumeTo,PurchaseVolumeForm")] CustomerCategory customercategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customercategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customercategory);
        }

        // GET: /CustomerCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerCategory customercategory = db.CustomerCategories.Find(id);
            if (customercategory == null)
            {
                return HttpNotFound();
            }
            return View(customercategory);
        }

        // POST: /CustomerCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerCategory customercategory = db.CustomerCategories.Find(id);
            db.CustomerCategories.Remove(customercategory);
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
    }
}
