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
using LAgardenCNPM.Common;
using MyClass.DAO;

namespace LAgardenCNPM.Areas.Admin.Controllers
{
    public class TAIKHOANController : BaseController
    {
        private MyDBContext db = new MyDBContext();
        UserDAO dao = new UserDAO();
        // GET: Admin/TAIKHOAN
        public async Task<ActionResult> Index(int page = 1, int pageSize = 5)  
        {

            var model = dao.getListPage(page, pageSize);
            return View(model);
        }

        // GET: Admin/TAIKHOAN/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIKHOAN tAIKHOAN = await db.TAIKHOANs.FindAsync(id);
            if (tAIKHOAN == null)
            {
                return HttpNotFound();
            }
            return View(tAIKHOAN);
        }

        // GET: Admin/TAIKHOAN/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TAIKHOAN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDKH,FullName,UserName,Password,Email,Phone,Address,ImgKH,Gender,Roles,CreateBy,CreateAt,UpdateBy,UpdateAt,Status")] TAIKHOAN tAIKHOAN)
        {
            if (ModelState.IsValid)
            {
                var x = Encryptor.MD5Hash(tAIKHOAN.Password);
                tAIKHOAN.Password = x;
                db.TAIKHOANs.Add(tAIKHOAN);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tAIKHOAN);
        }

        // GET: Admin/TAIKHOAN/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIKHOAN tAIKHOAN = await db.TAIKHOANs.FindAsync(id);
            if (tAIKHOAN == null)
            {
                return HttpNotFound();
            }
            return View(tAIKHOAN);
        }

        // POST: Admin/TAIKHOAN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDKH,FullName,UserName,Password,Email,Phone,Address,ImgKH,Gender,Roles,CreateBy,CreateAt,UpdateBy,UpdateAt,Status")] TAIKHOAN tAIKHOAN)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(tAIKHOAN.Password))
                {
                    TAIKHOAN tk = dao.GetByID(tAIKHOAN.UserName);
                    tAIKHOAN.Password = tk.Password;
                }
                else
                {
                    var x = Encryptor.MD5Hash(tAIKHOAN.Password);
                    tAIKHOAN.Password = x;
                }
                db.Entry(tAIKHOAN).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tAIKHOAN);
        }

        // GET: Admin/TAIKHOAN/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIKHOAN tAIKHOAN = await db.TAIKHOANs.FindAsync(id);
            if (tAIKHOAN == null)
            {
                return HttpNotFound();
            }
            return View(tAIKHOAN);
        }

        // POST: Admin/TAIKHOAN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TAIKHOAN tAIKHOAN = await db.TAIKHOANs.FindAsync(id);
            db.TAIKHOANs.Remove(tAIKHOAN);
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
