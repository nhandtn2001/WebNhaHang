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
    public class CHITIETHDController : BaseController
    {
        private MyDBContext db = new MyDBContext();

        // GET: Admin/CHITIETHD
        public ActionResult Index()
        {
            return View(db.CHITIETHDs.ToList());
        }

        // GET: Admin/CHITIETHD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETHD cHITIETHD = db.CHITIETHDs.Find(id);
            if (cHITIETHD == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETHD);
        }

        // GET: Admin/CHITIETHD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CHITIETHD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,ChiTietHD1,TongHD,IDNV,TenNV,TenKH")] CHITIETHD cHITIETHD)
        {
            if (ModelState.IsValid)
            {
                db.CHITIETHDs.Add(cHITIETHD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cHITIETHD);
        }

        // GET: Admin/CHITIETHD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETHD cHITIETHD = db.CHITIETHDs.Find(id);
            if (cHITIETHD == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETHD);
        }

        // POST: Admin/CHITIETHD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,ChiTietHD1,TongHD,IDNV,TenNV,TenKH")] CHITIETHD cHITIETHD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHITIETHD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cHITIETHD);
        }

        // GET: Admin/CHITIETHD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETHD cHITIETHD = db.CHITIETHDs.Find(id);
            if (cHITIETHD == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETHD);
        }

        // POST: Admin/CHITIETHD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHITIETHD cHITIETHD = db.CHITIETHDs.Find(id);
            db.CHITIETHDs.Remove(cHITIETHD);
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
