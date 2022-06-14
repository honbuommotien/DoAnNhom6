using DoAnNhom6.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnNhom6.Controllers
{
    public class HomeController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var all_dongho = (from s in data.DongHos select s).OrderBy(m => m.id);
            int pageSize = 6;
            int pageNum = page ?? 1;
            return View(all_dongho.ToPagedList(pageNum, pageSize));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult DangKy()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}