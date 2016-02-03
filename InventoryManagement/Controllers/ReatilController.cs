using System.Linq;
using System.Net;
using System.Web.Mvc;
using InventoryManagement.Models.DAO;
using InventoryManagement.Models.DAL;
using System.Data.Entity;

namespace InventoryManagement.Controllers
{
    public class ReatilController : Controller
    {
        private Gateway db = new Gateway();

        // GET: /Reatil/
        public ActionResult Index()
        {
            return View(db.RetailStores.ToList());
        }

        // GET: /Reatil/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RetailStore retailstore = db.RetailStores.Find(id);
            if (retailstore == null)
            {
                return HttpNotFound();
            }
            return View(retailstore);
        }

        // GET: /Reatil/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Reatil/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,StoreName,StoreCode,Address,ZipCode,PostalCode")] RetailStore retailstore)
        {
            if (ModelState.IsValid)
            {
                db.RetailStores.Add(retailstore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(retailstore);
        }

        // GET: /Reatil/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RetailStore retailstore = db.RetailStores.Find(id);
            if (retailstore == null)
            {
                return HttpNotFound();
            }
            return View(retailstore);
        }

        // POST: /Reatil/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,StoreName,StoreCode,Address,ZipCode,PostalCode")] RetailStore retailstore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(retailstore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(retailstore);
        }

        // GET: /Reatil/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RetailStore retailstore = db.RetailStores.Find(id);
            if (retailstore == null)
            {
                return HttpNotFound();
            }
            return View(retailstore);
        }

        // POST: /Reatil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RetailStore retailstore = db.RetailStores.Find(id);
            db.RetailStores.Remove(retailstore);
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
