using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDienThoatBTL.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;


namespace WebBanDienThoatBTL.Controllers
{
    public class QuanLyDonHangController : Controller
    {
        // GET: QuanLySanPham
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.DonHangs.ToList().OrderBy(n => n.MaDonHang).ToPagedList(pageNumber, pageSize));
        }
        //Thêm mới điện thoại
        #region
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(DonHang dh, HttpPostedFileBase fileUpload)
        {
            db.DonHangs.Add(dh);
            db.SaveChanges();
            return View();
        }
        //Chỉnh sửa sản phẩm
        [HttpGet]
        public ActionResult ChinhSua(int MaDonHang)
        {
            //Lấy ra điện thoại theo mã
            DonHang dh = db.DonHangs.SingleOrDefault(n => n.MaDonHang == MaDonHang);
            if (dh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dh);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(DonHang dh, FormCollection f)
        {
            ////Lấy dữ liệu từ textbox
            //DienThoai dt1 = db.DienThoais.SingleOrDefault(n => n.MaDT == dt.MaDT);
            //dt1.Mota = dt.Mota;
            //dt1.Mota = f.Get("abc").ToString();
            //db.SaveChanges();

            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhập trong model
                db.Entry(dh).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //Hiển thị
        public ActionResult HienThi(int MaDonHangChiTiet)
        {
            //Lấy ra chi tiết đơn hàng theo mã
            //DonHang dh = db.DonHangs.SingleOrDefault(n => n.MaDonHang == MaDonHang);
            //ChiTietDonHang ctdh = db.ChiTietDonHangs.ToList().OrderBy(n=>n.MaDonHang == MaDonHangChiTiet);
            //if (ctdh == null)
            //{
            //    Response.StatusCode = 404;
            //    return null;
            //}
            return View(db.ChiTietDonHangs.ToList().OrderBy(n=>n.MaDonHang).Where(n=>n.MaDonHang==MaDonHangChiTiet));
        }
        //Xóa sản phẩm
        [HttpGet]
        public ActionResult Xoa(int MaDonHang)
        {
            //Lấy ra điện thoại theo mã
            DonHang dh = db.DonHangs.SingleOrDefault(n => n.MaDonHang == MaDonHang);
            if (dh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dh);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaDonHang)
        {
            DonHang dh = db.DonHangs.SingleOrDefault(n => n.MaDonHang == MaDonHang);
            if (dh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.DonHangs.Remove(dh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}