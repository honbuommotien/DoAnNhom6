using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DoAnNhom6
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ListDongHo",
                url: "he-thong",
                defaults: new { controller = "DongHo", action = "ListDongHo", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "About",
                url: "gioi-thieu",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Contact",
                url: "lien-he",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DetailDongHo",
                url: "chi-tiet-sp-dong-ho-{id}",
                defaults: new { controller = "DongHo", action = "Detail", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CreateDongHo",
                url: "tao-sp-moi",
                defaults: new { controller = "DongHo", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EditDongHo",
                url: "edit-tt-sp-dong-ho-{id}",
                defaults: new { controller = "DongHo", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DeleteDongHo",
                url: "xoa-sp-dong-ho-{id}",
                defaults: new { controller = "DongHo", action = "Delete", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Home",
                url: "trang-chu",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DangKy",
                url: "dang-ky-tai-khoan",
                defaults: new { controller = "NguoiDung", action = "DangKy", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DangNhap",
                url: "dang-nhap",
                defaults: new { controller = "NguoiDung", action = "DangNhap", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "GioHang",
                url: "gio-hang",
                defaults: new { controller = "GioHang", action = "GioHang", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DatHang",
                url: "dat-hang",
                defaults: new { controller = "GioHang", action = "DatHang", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "XacNhanDonHang",
                url: "xac-nhan-don-hang",
                defaults: new { controller = "GioHang", action = "XacNhanDonHang", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
