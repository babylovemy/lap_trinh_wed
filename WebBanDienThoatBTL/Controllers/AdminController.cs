using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDienThoatBTL.Models;


namespace WebBanDienThoatBTL.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sTaiKhoan = f["txtTaiKhoan"].ToString();
            string sMatKhau = f.Get("txtMatKhau").ToString();
            Admin admin = db.Admins.SingleOrDefault(n => n.TenDangNhap == sTaiKhoan && n.MatKhau == sMatKhau);
            if (admin != null)
            {
                ViewBag.ThongBao = "Đăng nhập thành công!";
                Session["TaiKhoanAdmin"] = admin;
                return RedirectToAction("Index","QuanLySanPham");
            }
            else
            {
                ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không chính xác!";
                return View();
            }
        }

        public ActionResult Thoat()
        {
            Session["TaiKhoanAdmin"] = null;
            return RedirectToAction("DangNhap","Admin");
        }
    }
}