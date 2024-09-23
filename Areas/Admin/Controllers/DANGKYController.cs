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
    public class DANGKYController : BaseController
    {
        private MyDBContext db = new MyDBContext();

        // GET: Admin/DANGKY
        public ActionResult Index()
        {
            return View(db.DANGKies.ToList());
        }

        // GET: Admin/DANGKY/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANGKY dANGKY = db.DANGKies.Find(id);
            if (dANGKY == null)
            {
                return HttpNotFound();
            }
            return View(dANGKY);
        }

        // GET: Admin/DANGKY/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DANGKY/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenDangNhap,MatKhau,EmailDK,DiaChiDK,TenDayDu,CauHoiBaoMat,NgaySinh,GioiTinhDK,MaQuyen")] DANGKY dANGKY)
        {
            if (ModelState.IsValid)
            {
                db.DANGKies.Add(dANGKY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dANGKY);
        }

        // GET: Admin/DANGKY/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANGKY dANGKY = db.DANGKies.Find(id);
            if (dANGKY == null)
            {
                return HttpNotFound();
            }
            return View(dANGKY);
        }

        // POST: Admin/DANGKY/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenDangNhap,MatKhau,EmailDK,DiaChiDK,TenDayDu,CauHoiBaoMat,NgaySinh,GioiTinhDK,MaQuyen")] DANGKY dANGKY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dANGKY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dANGKY);
        }

        // GET: Admin/DANGKY/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANGKY dANGKY = db.DANGKies.Find(id);
            if (dANGKY == null)
            {
                return HttpNotFound();
            }
            return View(dANGKY);
        }

        // POST: Admin/DANGKY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DANGKY dANGKY = db.DANGKies.Find(id);
            db.DANGKies.Remove(dANGKY);
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
