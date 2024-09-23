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
    public class DSMONANController : BaseController
    {
        private MyDBContext db = new MyDBContext();

        private DSMONANDAO dsmonanDao = new DSMONANDAO();
        // GET: Admin/DSMONAN
        public ActionResult Index()
        {
            return View(dsmonanDao.getList());
        }

        // GET: Admin/DSMONAN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DSMONAN dSMONAN = db.DSMONANs.Find(id);
            if (dSMONAN == null)
            {
                return HttpNotFound();
            }
            return View(dSMONAN);
        }

        // GET: Admin/DSMONAN/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DSMONAN/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenMonAn,Gia,Slug,Status,Title,DanhMucID")] DSMONAN dSMONAN)
        {
            if (ModelState.IsValid)
            {
                db.DSMONANs.Add(dSMONAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dSMONAN);
        }

        // GET: Admin/DSMONAN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DSMONAN dSMONAN = db.DSMONANs.Find(id);
            if (dSMONAN == null)
            {
                return HttpNotFound();
            }
            return View(dSMONAN);
        }

        // POST: Admin/DSMONAN/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDMA,TenMonAn,Gia,Slug,Status,Title,DanhMucID")] DSMONAN dSMONAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dSMONAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dSMONAN);
        }

        // GET: Admin/DSMONAN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DSMONAN dSMONAN = db.DSMONANs.Find(id);
            if (dSMONAN == null)
            {
                return HttpNotFound();
            }
            return View(dSMONAN);
        }

        // POST: Admin/DSMONAN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DSMONAN dSMONAN = db.DSMONANs.Find(id);
            db.DSMONANs.Remove(dSMONAN);
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
