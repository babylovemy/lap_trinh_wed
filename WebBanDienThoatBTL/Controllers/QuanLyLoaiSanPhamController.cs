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
    public class QuanLyLoaiSanPhamController : Controller
    {
        // GET: QuanLySanPham
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.LoaiDienThoais.ToList().OrderBy(n => n.MaLDT).ToPagedList(pageNumber, pageSize));
        }
        //Thêm mới loại điện thoại
        #region
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(LoaiDienThoai ldt, HttpPostedFileBase fileUpload)
        {
            db.LoaiDienThoais.Add(ldt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Chỉnh sửa sản phẩm
        [HttpGet]
        public ActionResult ChinhSua(int MaLoaiDienThoai)
        {
            //Lấy ra điện thoại theo mã
            LoaiDienThoai ldt = db.LoaiDienThoais.SingleOrDefault(n => n.MaLDT == MaLoaiDienThoai);
            if (ldt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ldt);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(LoaiDienThoai ldt, FormCollection f)
        {
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhập trong model
                db.Entry(ldt).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //Hiển thị
        public ActionResult HienThi(int MaLDT)
        {
            //Lấy ra điện thoại theo mã
            LoaiDienThoai ldt = db.LoaiDienThoais.SingleOrDefault(n => n.MaLDT == MaLDT);
            if (ldt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ldt);
        }
        //Xóa sản phẩm
        [HttpGet]
        public ActionResult Xoa(int MaLDT)
        {
            //Lấy ra điện thoại theo mã
            LoaiDienThoai ldt = db.LoaiDienThoais.SingleOrDefault(n => n.MaLDT == MaLDT);
            if (ldt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ldt);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaLDT)
        {
            LoaiDienThoai ldt = db.LoaiDienThoais.SingleOrDefault(n => n.MaLDT == MaLDT);
            if (ldt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.LoaiDienThoais.Remove(ldt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}