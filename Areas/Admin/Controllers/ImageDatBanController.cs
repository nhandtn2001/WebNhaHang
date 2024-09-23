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
    public class ImageDatBanController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: Admin/ImageDatBan
        public async Task<ActionResult> Index(int page = 1, int pageSize = 5)
        {
            var dao = new ImageDatbanDAO();
            var model = dao.getListPage(page, pageSize);
            return View(model);
        }

        // GET: Admin/ImageDatBan/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageDatBan imageDatBan = await db.ImageDatBans.FindAsync(id);
            if (imageDatBan == null)
            {
                return HttpNotFound();
            }
            return View(imageDatBan);
        }

        // GET: Admin/ImageDatBan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ImageDatBan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,imgsource")] ImageDatBan imageDatBan)
        {
            if (ModelState.IsValid)
            {
                db.ImageDatBans.Add(imageDatBan);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(imageDatBan);
        }

        // GET: Admin/ImageDatBan/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageDatBan imageDatBan = await db.ImageDatBans.FindAsync(id);
            if (imageDatBan == null)
            {
                return HttpNotFound();
            }
            return View(imageDatBan);
        }

        // POST: Admin/ImageDatBan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,imgsource")] ImageDatBan imageDatBan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imageDatBan).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(imageDatBan);
        }

        // GET: Admin/ImageDatBan/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageDatBan imageDatBan = await db.ImageDatBans.FindAsync(id);
            if (imageDatBan == null)
            {
                return HttpNotFound();
            }
            return View(imageDatBan);
        }

        // POST: Admin/ImageDatBan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ImageDatBan imageDatBan = await db.ImageDatBans.FindAsync(id);
            db.ImageDatBans.Remove(imageDatBan);
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
