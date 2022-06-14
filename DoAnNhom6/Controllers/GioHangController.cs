using DoAnNhom6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnNhom6.Controllers
{
    public class GioHangController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        public List<Giohang> LayGioHang()
        {
            List<Giohang> listGiohang = Session["GioHang"] as List<Giohang>;
            if (listGiohang == null)
            {
                listGiohang = new List<Giohang>();
                Session["GioHang"] = listGiohang;
            }
            return listGiohang;
        }
        public ActionResult ThemGioHang(int id, string strURL)
        {
            List<Giohang> listGiohang = LayGioHang();
            Giohang sanpham = listGiohang.Find(n => n.id == id);
            if (sanpham == null)
            {
                sanpham = new Giohang(id);
                listGiohang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoluong++;
                return Redirect(strURL);
            }
        }
        private int TongSoluong()
        {
            int tong = 0;
            List<Giohang> listgiohang = Session["GioHang"] as List<Giohang>;
            if (listgiohang != null)
            {
                tong = listgiohang.Sum(n => n.iSoluong);
            }
            return tong;
        }

        private int TongSoLuongSanPham()
        {
            int tong = 0;
            List<Giohang> listgiohang = Session["GioHang"] as List<Giohang>;
            if (listgiohang != null)
            {
                tong = listgiohang.Count;
            }
            return tong;
        }

        private double TongTien()
        {
            double tongtien = 0;
            List<Giohang> listGioHnag = Session["GioHang"] as List<Giohang>;
            if (listGioHnag != null)
            {
                tongtien = listGioHnag.Sum(n => n.dThanhtien);
            }
            return tongtien;
        }

        public ActionResult GioHang()
        {
            List<Giohang> listGiohang = LayGioHang();
            ViewBag.Tongsoluong = TongSoluong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return View(listGiohang);
        }

        public ActionResult GioHangPartial()
        {
            ViewBag.Tongsoluong = TongSoluong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return PartialView();
        }

        public ActionResult XoaGioHang(int id)
        {
            List<Giohang> listGiohang = LayGioHang();
            Giohang sanpham = listGiohang.SingleOrDefault(n => n.id == id);
            if (sanpham != null)
            {
                listGiohang.RemoveAll(n => n.id == id);
                return RedirectToAction("GioHang");
            }
            return RedirectToAction("GioHang");
        }

        public ActionResult CapNhatGioHang(int id, FormCollection collection)
        {
            List<Giohang> listGiohang = LayGioHang();
            Giohang sanpham = listGiohang.SingleOrDefault(n => n.id == id);
            if (sanpham != null)
            {
                sanpham.iSoluong = int.Parse(collection["txtSoluong"].ToString());
            }
            return RedirectToAction("GioHang");
        }

        public ActionResult XoaTatCaGioHang()
        {
            List<Giohang> listGiohang = LayGioHang();
            listGiohang.Clear();
            return RedirectToAction("GioHang");
        }
        [HttpGet]
        public ActionResult DatHang()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            if (Session["Giohang"] == null)
            {
                return RedirectToAction("Index", "DongHo");
            }
            List<Giohang> lstGiohang = LayGioHang();
            ViewBag.Tongsoluong = TongSoluong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return View(lstGiohang);
        }


        public ActionResult DatHang(FormCollection collection)
        {
            DonHang dh = new DonHang();
            KhachHang kh = (KhachHang)Session["TaiKhoan"];
            DongHo s = new DongHo();

            List<Giohang> gh = LayGioHang();
            var ngaygiao = String.Format("{0:MM/dd/yyyy}", collection["NgayGiao"]);

            dh.makh = kh.makh;
            dh.ngaydat = DateTime.Now;
            dh.ngaygiao = DateTime.Parse(ngaygiao);
            dh.giaohang = false;
            dh.thanhtoan = false;

            data.DonHangs.InsertOnSubmit(dh);
            data.SubmitChanges();
            foreach (var item in gh)
            {
                ChiTietDonHang ctdh = new ChiTietDonHang();
                ctdh.madon = dh.madon;
                ctdh.id = item.id;
                ctdh.soluong = item.iSoluong;
                ctdh.gia = (decimal)item.gia;
                s = data.DongHos.Single(n => n.id == item.id);
                s.soluongton -= ctdh.soluong;
                data.SubmitChanges();

                data.ChiTietDonHangs.InsertOnSubmit(ctdh);
            }
            data.SubmitChanges();
            Session["Giohang"] = null;
            return RedirectToAction("XacnhanDonhang", "GioHang");
        }
        public ActionResult XacnhanDonhang()
        {
            return View();
        }

    }
}