using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanDienThoatBTL.Models
{
    public class GioHang
    {
        //private int iMaSP;

        //public int IMaSP
        //{
        //    get
        //    {
        //        return iMaSP;
        //    }

        //    set
        //    {
        //        iMaSP = value;
        //    }
        //}
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        public int iMaDT { get; set; }
        public string sTenDT { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double ThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        //Hàm tạo cho giỏ hàng
        public GioHang(int MaDT)
        {
            iMaDT = MaDT;
            DienThoai dt = db.DienThoais.Single(n => n.MaDT == iMaDT);
            sTenDT = dt.TenDT;
            sAnhBia = dt.AnhBia;
            dDonGia = double.Parse(dt.GiaBan.ToString());
            iSoLuong = 1;
        }
    }
}