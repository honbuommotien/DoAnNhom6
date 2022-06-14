using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnNhom6.Models
{
    public class Giohang
    {
        MyDataDataContext data = new MyDataDataContext();
        public int id { get; set; }
        [Display(Name = "Tên")]
        public string ten { get; set; }
        [Display(Name = "Ảnh bìa")]
        public string hinh { get; set; }
        [Display(Name = "Giá bán")]
        public Double gia { get; set; }
        [Display(Name = "Số lượng")]
        public int iSoluong { get; set; }
        [Display(Name = "Thành tiền")]
        public Double dThanhtien
        {
            get { return iSoluong * gia; }
        }
        public Giohang(int id)
        {
            this.id = id;
            DongHo dongho = data.DongHos.Single(n => n.id == id);
            ten = dongho.ten;
            hinh = dongho.hinh;
            gia = double.Parse(dongho.gia.ToString());
            iSoluong = 1;
        }
    }
}