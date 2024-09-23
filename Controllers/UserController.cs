using LAgarden_CNPM.Models;
using MyClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClass.DAO;
using BotDetect.Web;
using BotDetect.Web.Mvc;
using LAgarden_CNPM.Common;
using LAgardenCNPM.Common;
using System.Data.Entity;
using CaptchaMvc.HtmlHelpers;

namespace LAgarden_CNPM.Controllers
{
    public class UserController : Controller
    {
        private MyDBContext db = new MyDBContext();
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result)
                {
                    var user = dao.GetByID(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.IDKH;
                    userSession.GroupID = "0";
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Home", "Site");
                }
                else
                {
                    ModelState.AddModelError("", "Sai tên tài khoản hoặc mật khẩu!");
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            Session[CommonConstants.USER_SESSION] = null;
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                if (dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else if (!this.IsCaptchaValid(""))
                {
                    ViewBag.errorCaptcha="Captcha không đúng";
                }
                else
                {
                    var taikhoan = new TAIKHOAN();
                    taikhoan.UserName = model.UserName;
                    taikhoan.FullName = model.Name;
                    var x = Encryptor.MD5Hash(model.Password);
                    taikhoan.Password = x;
                    taikhoan.Phone = model.Phone;
                    taikhoan.Email = model.Email;
                    taikhoan.Address = model.Address;
                    taikhoan.CreateAt = DateTime.Now;
                    taikhoan.Status = 0;
                    var result = dao.Insert(taikhoan);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công.");
                    }
                }
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");

        }
        public ActionResult MyInformation()
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            TAIKHOAN tk = new UserDAO().GetByID(session.UserName);
            InformationModel model = new InformationModel();
            model.UserName = tk.UserName;
            model.Phone = tk.Phone;
            model.Name = tk.FullName;
            model.Address = tk.Address;
            model.Email = tk.Email;
            return View(model);
        }
        [HttpPost]
        public ActionResult MyInformation(InformationModel model)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            var dao = new UserDAO();
            var user = dao.GetByID(session.UserName);
            int result;
            if (ModelState.IsValid)
            {
                if(user.Email == model.Email)
                {
                    user.FullName = model.Name;
                    user.Address = model.Address;
                    user.Phone = model.Phone;
                    
                }
                else
                {
                    if (dao.CheckEmail(model.Email) ==false)
                    {
                        user.FullName = model.Name;
                        user.Address = model.Address;
                        user.Phone = model.Phone;
                        user.Email = model.Email;
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email đã tồn tại");
                    }
                }
                result = dao.Update(user);
                if (result > 0)
                {
                    ViewBag.Success = "Cập nhật thành công";
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công.");
                }
            } 
            return View(model);
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            var dao = new UserDAO();
            var user = dao.GetByID(session.UserName);
            if (ModelState.IsValid)
            { 
                var x = Encryptor.MD5Hash(model.oldPassword);
                if (x.Equals(user.Password))
                {
                    user.Password = Encryptor.MD5Hash(model.Password);
                    var result = dao.Update(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Cập nhật mật khẩu thành công";
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật thất bại.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Mật khẩu cũ không đúng");
                }
            }
                return View(model);
        }

    }
}