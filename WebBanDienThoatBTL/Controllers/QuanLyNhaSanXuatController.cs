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
    public class QuanLyNhaSanXuatController : Controller
    {
        // GET: QuanLySanPham
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.NhaSanXuats.ToList().OrderBy(n => n.MaNSX).ToPagedList(pageNumber, pageSize));
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
        public ActionResult ThemMoi(NhaSanXuat nsx, HttpPostedFileBase fileUpload)
        {
          
            db.NhaSanXuats.Add(nsx);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Chỉnh sửa sản phẩm
        [HttpGet]
        public ActionResult ChinhSua(int MaNSX)
        {
            //Lấy ra điện thoại theo mã
            NhaSanXuat nsx = db.NhaSanXuats.SingleOrDefault(n => n.MaNSX == MaNSX);
            if (nsx == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nsx);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(NhaSanXuat nsx, FormCollection f)
        {
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhập trong model
                db.Entry(nsx).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //Hiển thị
        public ActionResult HienThi(int MaNSX)
        {
            //Lấy ra điện thoại theo mã
            NhaSanXuat nsx = db.NhaSanXuats.SingleOrDefault(n => n.MaNSX == MaNSX);
            if (nsx == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nsx);
        }
        //Xóa sản phẩm
        [HttpGet]
        public ActionResult Xoa(int MaNSX)
        {
            //Lấy ra điện thoại theo mã
            NhaSanXuat nsx = db.NhaSanXuats.SingleOrDefault(n => n.MaNSX == MaNSX);
            if (nsx == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nsx);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaNSX)
        {
            NhaSanXuat nsx = db.NhaSanXuats.SingleOrDefault(n => n.MaNSX == MaNSX);
            if (nsx == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.NhaSanXuats.Remove(nsx);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}