using LAgarden_CNPM.Common;
using MyClass.DAO;
using MyClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace LAgardenCNPM.Controllers
{
    public class SiteController : Controller
    {
        // GET: Site
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Order(int page = 1, int pageSize=3)
        {
            //          var model = new DSMonAnv2().getList();
            int totalRecord = 0;
            var model = new DSMonAnv2().getListPage(ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }

        public ActionResult DanhMucOrder(int DanhMucID, int page = 1, int pageSize = 5)
        {
            var danhmuc = new DanhMucDAO().ViewDetail(DanhMucID);
            ViewBag.DanhMuc = danhmuc;
            int totalRecord = 0;
            var model = new DSMonAnv2().ListByDanhMucID(DanhMucID, ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            int maxPage = 10;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }
        public ActionResult Table()
        {
            var img = new ImageDatbanDAO().getList();
            return View(img);

        }

        [HttpPost]
        public JsonResult SendTable(string name, string phone, string email, DateTime? date, TimeSpan? time,string slnl, string slte, string ghichu)
        {
            if (Session[CommonConstants.USER_SESSION] != null)
            {

                var session = (UserLogin)Session[CommonConstants.USER_SESSION];
                var userTK = new UserDAO().GetByID(session.UserName);
                var datban = new DatBan();
                if (string.IsNullOrEmpty(name))
                {
                    datban.FullName = userTK.FullName;
                }
                else
                {
                    datban.FullName = name;
                }
                if (string.IsNullOrEmpty(phone))
                {
                    datban.Phone = userTK.Phone;
                }
                else
                {
                    datban.Phone = phone;
                }
                if (string.IsNullOrEmpty(email))
                {
                    datban.Email = userTK.Email;
                }
                else
                {
                    datban.Email = email;
                }
               
                datban.NgayDB = date;
                datban.GioDB = time;
                datban.SLNguoiLon = slnl;
                datban.SLTreEm = slte;
                datban.GhiChu = ghichu;
                datban.username = session.UserName;
                if (datban.FullName != "" && datban.Email != "" && datban.Phone != "")
                {
                    var id = new TableDAO().InsertTable(datban);

                    if (id > 0)
                    {
                        return Json(new
                        {
                            status = true
                        });
                        //send mail
                    }

                    else
                        return Json(new
                        {
                            status = false
                        });
                }

                return Json(new { message = "Thiếu thông tin, vui lòng kiểm tra lại" });
            }
            return Json(new { message = "Vui lòng đăng nhập tài khoản" });
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult TinTuc()
        {
            return View();
        }
        public ActionResult Information()
        {
            return View();
        }
        public ActionResult CTSP(int IDMA)
        {
            var CTMA = new DSMonAnv2().ViewDetail(IDMA);
            ViewBag.DanhMuc = new DSMONANDAO().ViewDetail(CTMA.DanhMucID);
            return View(CTMA);
        }

        public ActionResult DanhMucSP()
        {
            var model = new DanhMucDAO().getListSort();
            return PartialView(model);
        }
        public ActionResult Hotro()
        {
            return View();
        }
        public ActionResult DatBan()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Send(string name, string email, string content)
        {
            if (Session[CommonConstants.USER_SESSION] != null)
            {
                var session = (UserLogin)Session[CommonConstants.USER_SESSION];
                var feedback = new LIENHE();
                feedback.TenKH = name;
                feedback.Email = email;
                feedback.ChiTiet = content;
                
                if (feedback.TenKH != "" && feedback.Email != "" && feedback.ChiTiet!="")
                {
                    var id = new HoTroDAO().InsertFeedBack(feedback);
                    string subject = "Thư hỗ trợ";
                    string body = System.IO.File.ReadAllText(Server.MapPath("~/Public/Html/2/index.html"));
                    body = body.Replace("{{taikhoan}}", session.UserName);
                    body = body.Replace("{{email}}", email);
                    WebMail.Send(email, subject, body, null, null, null, true, null, null, null, null, null, null);
                    if (id > 0)
                    {
                        return Json(new
                        {
                            status = true
                        });
                        //send mail
                    }

                    else
                        return Json(new
                        {
                            status = false
                        });
                }
                return Json(new { message = "Chưa nhập tên, địa chỉ Email hoặc nội dung" });
            }
            return Json(new { message = "Vui lòng đăng nhập tài khoản" });
        }
    }

}