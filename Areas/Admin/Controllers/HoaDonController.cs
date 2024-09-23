using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyClass.Model;
using MyClass.DAO;

namespace LAgardenCNPM.Areas.Admin.Controllers
{
    public class HoaDonController : BaseController
    {
        private MyDBContext db = new MyDBContext();

        // GET: Admin/HoaDon
        public async Task<ActionResult> Index(int page = 1, int pageSize = 5)
        {
            var dao = new HoaDonDAO();
            var model = dao.getListPage(page, pageSize);
            return View(model);
        }

        // GET: Admin/HoaDon/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = await db.HoaDon.FindAsync(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: Admin/HoaDon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/HoaDon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,username,NameRecieve,AddressRecive,Phone,EmailRecieve,TongTien,NgayLap")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDon.Add(hoaDon);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(hoaDon);
        }

        // GET: Admin/HoaDon/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = await db.HoaDon.FindAsync(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: Admin/HoaDon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,username,NameRecieve,AddressRecive,Phone,EmailRecieve,TongTien,NgayLap")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(hoaDon);
        }

        // GET: Admin/HoaDon/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = await db.HoaDon.FindAsync(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: Admin/HoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HoaDon hoaDon = await db.HoaDon.FindAsync(id);
            db.HoaDon.Remove(hoaDon);
            await db.SaveChangesAsync();
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
