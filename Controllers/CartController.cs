using LAgarden_CNPM.Common;
using LAgarden_CNPM.Models;
using MyClass.DAO;
using MyClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace LAgarden_CNPM.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        
        public ActionResult AddItem(int idma,int quantity)
        {
            if (Session[CommonConstants.USER_SESSION] == null)
            {
                return RedirectToAction("Login", "User");
            }
            var ctma = new CTMONANDAO().ViewDetail(idma);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.CTMA.IDMA == idma))
                {
                    foreach (var item in list)
                    {
                        if (item.CTMA.IDMA == idma)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.CTMA = ctma;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                //tạo mới
                var item = new CartItem();
                item.CTMA = ctma;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //gán
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {

                var jsonItem = jsonCart.SingleOrDefault(x => x.CTMA.IDMA == item.CTMA.IDMA);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.CTMA.IDMA == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult ThanhToan()
        {
            if (Session[CommonConstants.USER_SESSION] == null)
            {
                return RedirectToAction("Home","Site");
            }
            var sessionCart = (List<CartItem>)Session[CartSession];
            decimal TongTien = 0;
            foreach (var item in sessionCart)
            {
                TongTien += item.CTMA.Gia * item.Quantity;
            }
            ViewBag.TongTien = TongTien;
            ViewBag.MatHang = sessionCart;
            return View();
        }
        [HttpPost]
        public ActionResult ThanhToan(ThanhToanModel thanhtoan)
        {
            var userLogin= (UserLogin)Session[CommonConstants.USER_SESSION];
            var userTK = new UserDAO().GetByID(userLogin.UserName);
            var sessionCart = (List<CartItem>)Session[CartSession];
            var hoadon = new HoaDon();
            decimal TongTien = 0;
            foreach (var item in sessionCart)
            {
                TongTien += item.CTMA.Gia * item.Quantity;
            }
            if ( string.IsNullOrEmpty(thanhtoan.NameRecieve))
            {
                hoadon.NameRecieve = userTK.FullName;
            }
            else
            {
                hoadon.NameRecieve = thanhtoan.NameRecieve;
            }
            hoadon.TongTien = TongTien;
            hoadon.username = userLogin.UserName;
            if (string.IsNullOrEmpty(thanhtoan.AddressRecive))
            {
                hoadon.AddressRecive = userTK.Address;
            }
            else
            {
                hoadon.AddressRecive = thanhtoan.AddressRecive;
            }
            if (string.IsNullOrEmpty(thanhtoan.EmailRecieve))
            {
                hoadon.EmailRecieve = userTK.Email;
            }
            else
            {
                hoadon.EmailRecieve = thanhtoan.EmailRecieve;

            }
            if(string.IsNullOrEmpty(thanhtoan.PhoneRecive))
            {
                hoadon.Phone = userTK.Phone;
            }
            else
            {
                hoadon.Phone = thanhtoan.PhoneRecive;
            }
            string subject = "Thư cảm ơn";
            string body = System.IO.File.ReadAllText(Server.MapPath("~/Public/Html/1/index.html"));
            body = body.Replace("{{name}}", hoadon.NameRecieve);
            body = body.Replace("{{address}}", hoadon.AddressRecive);
            WebMail.Send(hoadon.EmailRecieve, subject, body, null, null, null, true, null, null, null, null, null, null);
            ViewBag.MatHang = sessionCart;
            decimal tienInRa = 0;
            foreach (var item in sessionCart)
            {
                tienInRa += item.CTMA.Gia * item.Quantity;
            }
            ViewBag.TongTien = tienInRa;
            hoadon.NgayLap = DateTime.Now;
            var result = new ThanhToanDAO().InsertHoaDon(hoadon);
            if (result > 0)
            {
                Session[CartSession] = null;
                ViewBag.Success = "Thanh toán thành công";
            }
            else
            {
                ModelState.AddModelError("", "Thanh toán không thành công vì thiếu thông tin!.");
            }
            return View();
        }
    }
}