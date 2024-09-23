using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LAgardenCNPM
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Thanh toán",
                url: "thanh-toan",
                defaults: new { controller = "Cart", action = "ThanhToan", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Thay đổi mật khẩu",
                url: "doi-mat-khau",
                defaults: new { controller = "User", action = "ChangePassword", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Thông tin tài khoản",
                url: "thong-tin-tai-khoan",
                defaults: new { controller = "User", action = "MyInformation", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Food",
                url: "dat-mon",
                defaults: new { controller = "Site", action = "Order", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Đăng xuất",
                url: "dang-xuat",
                defaults: new { controller = "User", action = "Logout", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Category",
                url: "danh-muc/{metatitle}-{DanhMucID}",
                defaults: new { controller = "Site", action = "DanhMucOrder", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Detail",
                url: "chi-tiet/{metatitle}-{IDMA}",
                defaults: new { controller = "Site", action = "CTSP", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Contact",
                url: "ho-tro",
                defaults: new { controller = "Site", action = "HoTro", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Register",
                url: "dang-ky",
                defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Login",
                url: "dang-nhap",
                defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Information",
                url: "thong-tin",
                defaults: new { controller = "Site", action = "Information", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Table",
                url: "dat-ban",
                defaults: new { controller = "Site", action = "Table", id = UrlParameter.Optional }
            );



            routes.MapRoute(
               name: "Add Cart",
               url: "them-gio-hang",
               defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "Giỏ Hàng",
              url: "gio-hang",
              defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional }
          );

            routes.MapRoute(
                name: "Default",
                url: "{Controller}/{Action}/{ID}",
                defaults: new { controller = "Site", action = "Home", id = UrlParameter.Optional }
            );

            
        }
    }
}
