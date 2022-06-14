using DoAnNhom6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnNhom6.Controllers
{
    public class DongHoController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult ListDongHo()
        {
            var all_dongho = from ss in data.DongHos select ss;
            return View(all_dongho);
        }
        public ActionResult Detail(int id)
        {
            var D_dongho = data.DongHos.Where(m => m.id == id).First();
            return View(D_dongho);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, DongHo s)
        {
            var E_ten = collection["ten"];
            var E_mota = collection["mota"];
            var E_hang = collection["hang"];
            var E_gia = Convert.ToDecimal(collection["gia"]);
            var E_hinh = collection["hinh"];
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycapnhat"]);
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            if (string.IsNullOrEmpty(E_ten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.ten = E_ten.ToString();
                s.mota = E_mota.ToString();
                s.hang = E_hang.ToString();
                s.gia = E_gia;
                s.hinh = E_hinh.ToString();
                s.ngaycapnhat = E_ngaycapnhat;
                s.soluongton = E_soluongton;
                data.DongHos.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("ListDongHo");
            }
            return this.Create();
        }
        public ActionResult Edit(int id)
        {
            var E_dongho = data.DongHos.First(m => m.id == id);
            return View(E_dongho);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_dongho = data.DongHos.First(m => m.id == id);
            var E_ten = collection["ten"];
            var E_mota = collection["mota"];
            var E_hang = collection["hang"];
            var E_gia = Convert.ToDecimal(collection["gia"]);
            var E_hinh = collection["hinh"];
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycapnhat"]);
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            E_dongho.id = id;
            if (string.IsNullOrEmpty(E_ten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_dongho.ten = E_ten;
                E_dongho.mota = E_mota;
                E_dongho.hang = E_mota;
                E_dongho.gia = E_gia;
                E_dongho.hinh = E_hinh;
                E_dongho.ngaycapnhat = E_ngaycapnhat;
                E_dongho.soluongton = E_soluongton;
                UpdateModel(E_dongho);
                data.SubmitChanges();
                return RedirectToAction("ListDongHo");
            }
            return this.Edit(id);
        }
        public ActionResult Delete(int id)
        {
            var D_dongho = data.DongHos.First(m => m.id == id);
            return View(D_dongho);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_dongho = data.DongHos.Where(m => m.id == id).First();
            data.DongHos.DeleteOnSubmit(D_dongho);
            data.SubmitChanges();
            return RedirectToAction("ListDongHo");
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }
    }
}