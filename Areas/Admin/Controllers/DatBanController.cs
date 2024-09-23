using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyClass.DAO;
using MyClass.Model;

namespace LAgardenCNPM.Areas.Admin.Controllers
{
    public class DatBanController : BaseController
    {
        private MyDBContext db = new MyDBContext();

        // GET: Admin/DatBan
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var dao = new TableDAO();
            var model = dao.getListPage(page, pageSize);
            return View(model);
        }

        // GET: Admin/DatBan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatBan datBan = db.DatBans.Find(id);
            if (datBan == null)
            {
                return HttpNotFound();
            }
            return View(datBan);
        }

        // GET: Admin/DatBan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DatBan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DatBanID,NgayDB,GioDB,FullName,Email,Phone,SLNguoiLon,SLTreEm,GhiChu")] DatBan datBan)
        {
            if (ModelState.IsValid)
            {
                db.DatBans.Add(datBan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(datBan);
        }

        // GET: Admin/DatBan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatBan datBan = db.DatBans.Find(id);
            if (datBan == null)
            {
                return HttpNotFound();
            }
            return View(datBan);
        }

        // POST: Admin/DatBan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DatBanID,NgayDB,GioDB,FullName,Email,Phone,SLNguoiLon,SLTreEm,GhiChu")] DatBan datBan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datBan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(datBan);
        }

        // GET: Admin/DatBan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatBan datBan = db.DatBans.Find(id);
            if (datBan == null)
            {
                return HttpNotFound();
            }
            return View(datBan);
        }

        // POST: Admin/DatBan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatBan datBan = db.DatBans.Find(id);
            db.DatBans.Remove(datBan);
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
