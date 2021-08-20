using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDienThoatBTL.Models;

namespace WebBanDienThoatBTL.Controllers
{
    public class GioHangController : Controller
    {
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        #region Giỏ Hàng
        //Lấy giỏi hàng
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                //Nếu giỏ hàng chưa tồn tại thì tiến hành khởi tạo list giỏ hàng
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        //Thêm giỏ hàng
        public ActionResult ThemGioHang(int iMaDT, string strURL)
        {
            DienThoai dt = db.DienThoais.SingleOrDefault(n => n.MaDT == iMaDT);
            if (dt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy ra session giỏ hàng
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra điện thoại đã tồn tại trong session[giohang]
            GioHang sanpham = lstGioHang.Find(n => n.iMaDT == iMaDT);
            if(sanpham == null)
            {
                sanpham = new GioHang(iMaDT);
                //Add sản phẩm mới vào list
                lstGioHang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);
            }
        }
        //Cập nhập giỏ hàng
        public ActionResult CapNhapGioHang(int iMaSP, FormCollection f)
        {
            //kiểm tra mã điện thoại
            DienThoai dt = db.DienThoais.SingleOrDefault(n => n.MaDT == iMaSP);
            //Nếu lấy sai mã sản phẩm thì trả về trang lỗi
            if (dt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng từ Session
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sản phẩm có tồn tại trong session
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMaDT == iMaSP);
            if(sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("SuaGioHang");
        }
        //Xóa giỏ hàng
        public ActionResult XoaGioHang(int iMaSP)
        {
            //kiểm tra mã điện thoại
            DienThoai dt = db.DienThoais.SingleOrDefault(n => n.MaDT == iMaSP);
            //Nếu lấy sai mã sản phẩm thì trả về trang lỗi
            if (dt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng từ Session
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sản phẩm có tồn tại trong session
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMaDT == iMaSP);
            if (sanpham != null)
            {
                lstGioHang.RemoveAll(n => n.iMaDT == iMaSP);
            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("SuaGioHang");
        }
        //Xây dựng trang giỏ hàng
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }
        //Tính tổng số lượng và tổng tiền
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if(lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.ThanhTien);
            }
            return dTongTien;
        }
        //Tạo partial giỏ hàng
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        //Xây dựng view cho người dùng chỉnh sửa giỏ hàng
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }
        #endregion
        #region Đặt Hàng   
        //Xây dựng chức năng đặt hàng
        [HttpPost]
        public ActionResult DatHang()
        {
            //Kiểm tra đăng nhập
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            //Kiểm tra giỏ hàng
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            //Thêm đơn hàng
            DonHang ddh = new DonHang();
            KhachHang kh = (KhachHang)Session["TaiKhoan"];
            List<GioHang> gh = LayGioHang();
            ddh.MaKH = kh.MaKH;
            ddh.NgayDat = DateTime.Now;
            ddh.DiaChi = kh.DiaChi;
            ddh.DienThoai = kh.DienThoai;
            db.DonHangs.Add(ddh);
            db.SaveChanges();
            //Thêm chi tiết đơn hàng
            foreach(var item in gh)
            {
                ChiTietDonHang ctDH = new ChiTietDonHang();
                ctDH.MaDonHang = ddh.MaDonHang;
                ctDH.MaDT = item.iMaDT;
                ctDH.SoLuong = item.iSoLuong;
                ctDH.DonGia = item.dDonGia.ToString();
                db.ChiTietDonHangs.Add(ctDH);
            }
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        #endregion
    }
}