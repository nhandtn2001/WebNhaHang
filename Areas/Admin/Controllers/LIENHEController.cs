using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyClass.Model;
using MyClass.DAO;
using MyClass;
namespace LAgardenCNPM.Areas.Admin.Controllers
{
    public class LIENHEController : BaseController
    {
        private MyDBContext db = new MyDBContext();
        private HoTroDAO hotroDao = new HoTroDAO();
        // GET: Admin/LIENHE
        public ActionResult Index(int page=1, int pageSize=5)
        {
            var model = hotroDao.getListPage(page, pageSize);
            return View(model);
        }

        // GET: Admin/LIENHE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIENHE lIENHE = db.LIENHEs.Find(id);
            if (lIENHE == null)
            {
                return HttpNotFound();
            }
            return View(lIENHE);
        }

        // GET: Admin/LIENHE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LIENHE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,TenKH,Email,SDT,ChiTiet,status")] LIENHE lIENHE)
        {
            if (ModelState.IsValid)
            {
                db.LIENHEs.Add(lIENHE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lIENHE);
        }

        // GET: Admin/LIENHE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIENHE lIENHE = db.LIENHEs.Find(id);
            if (lIENHE == null)
            {
                return HttpNotFound();
            }
            return View(lIENHE);
        }

        // POST: Admin/LIENHE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,TenKH,Email,SDT,ChiTiet,status")] LIENHE lIENHE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lIENHE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lIENHE);
        }

        // GET: Admin/LIENHE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIENHE lIENHE = db.LIENHEs.Find(id);
            if (lIENHE == null)
            {
                return HttpNotFound();
            }
            return View(lIENHE);
        }

        // POST: Admin/LIENHE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LIENHE lIENHE = db.LIENHEs.Find(id);
            db.LIENHEs.Remove(lIENHE);
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
