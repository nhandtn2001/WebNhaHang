using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyClass.Model;

namespace LAgardenCNPM.Areas.Admin.Controllers
{
    public class LINKController : BaseController
    {
        private MyDBContext db = new MyDBContext();

        // GET: Admin/LINK
        public ActionResult Index()
        {
            return View(db.LINKs.ToList());
        }

        // GET: Admin/LINK/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LINK lINK = db.LINKs.Find(id);
            if (lINK == null)
            {
                return HttpNotFound();
            }
            return View(lINK);
        }

        // GET: Admin/LINK/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LINK/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDMA,Slug,TypeLink,TableId")] LINK lINK)
        {
            if (ModelState.IsValid)
            {
                db.LINKs.Add(lINK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lINK);
        }

        // GET: Admin/LINK/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LINK lINK = db.LINKs.Find(id);
            if (lINK == null)
            {
                return HttpNotFound();
            }
            return View(lINK);
        }

        // POST: Admin/LINK/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDMA,Slug,TypeLink,TableId")] LINK lINK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lINK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lINK);
        }

        // GET: Admin/LINK/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LINK lINK = db.LINKs.Find(id);
            if (lINK == null)
            {
                return HttpNotFound();
            }
            return View(lINK);
        }

        // POST: Admin/LINK/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LINK lINK = db.LINKs.Find(id);
            db.LINKs.Remove(lINK);
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
