using LAgarden_CNPM.Areas.Admin.Common;
using LAgarden_CNPM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LAgardenCNPM.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base

            protected override void OnActionExecuting(ActionExecutingContext filterContext)
            {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (session == null || session.GroupID != "1")
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Auth", action = "Login", Area = "Admin" }));
            }
            base.OnActionExecuting(filterContext);
            }
        }
    }