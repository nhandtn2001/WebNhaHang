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
    public class CTMONANController : BaseController
    {
        private MyDBContext db = new MyDBContext();
        private CTMONANDAO ctmonanDao = new CTMONANDAO();
        // GET: Admin/CTMONAN
        public ActionResult Index(int page = 1 ,int pageSize=5)
        {
            var model = ctmonanDao.getListPage(page, pageSize);
            return View(model);
        }

        // GET: Admin/CTMONAN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTMONAN cTMONAN = db.CTMONANs.Find(id);
            if (cTMONAN == null)
            {
                return HttpNotFound();
            }
            return View(cTMONAN);
        }

        // GET: Admin/CTMONAN/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CTMONAN/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDMA,DanhMucID,TenMonAn,SoLuong,ChiTietMA,Gia,GiaSale,ImgMA,slug,title")] CTMONAN cTMONAN)
        {
            if (ModelState.IsValid)
            {
                db.CTMONANs.Add(cTMONAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cTMONAN);
        }

        // GET: Admin/CTMONAN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTMONAN cTMONAN = db.CTMONANs.Find(id);
            if (cTMONAN == null)
            {
                return HttpNotFound();
            }
            return View(cTMONAN);
        }

        // POST: Admin/CTMONAN/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDMA,DanhMucID,TenMonAn,SoLuong,ChiTietMA,Gia,GiaSale,ImgMA,slug,title")] CTMONAN cTMONAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTMONAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cTMONAN);
        }

        // GET: Admin/CTMONAN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTMONAN cTMONAN = db.CTMONANs.Find(id);
            if (cTMONAN == null)
            {
                return HttpNotFound();
            }
            return View(cTMONAN);
        }

        // POST: Admin/CTMONAN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CTMONAN cTMONAN = db.CTMONANs.Find(id);
            db.CTMONANs.Remove(cTMONAN);
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
