using LAgardenCNPM.Areas.Admin.Models;
using MyClass.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LAgarden_CNPM.Areas.Admin.Common;
using LAgardenCNPM.Common;
using LAgarden_CNPM.Common;

namespace LAgardenCNPM.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        // GET: Admin/Auth
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult loginAdmin(LoginModel model)
        {
            Session[CommonConstants.USER_SESSION] = null;
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.LoginAdmin(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result==true)
                {
                    var user = dao.GetByID(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.IDKH;
                    userSession.GroupID = "1";
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "CTMONAN");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng!");
                }
            }
            return View("Login");
        }

        public ActionResult Logout()
        {
            Session[CommonConstantsAdmin.USER_SESSIONADMIN] = null;
            return Redirect("/");
        }
    }
}