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
    public class QuanLySanPhamController : Controller
    {
        // GET: QuanLySanPham
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.DienThoais.ToList().OrderBy(n=>n.MaDT).ToPagedList(pageNumber,pageSize));
        }
        //Thêm mới điện thoại
        #region
        [HttpGet]
        public ActionResult ThemMoi()
        {
            //Đưa dữ liệu vào dropdownList
            ViewBag.MaLDT = new SelectList(db.LoaiDienThoais.ToList().OrderBy(n=>n.TenLDT),"MaLDT","TenLDT");
            ViewBag.MaNSX = new SelectList(db.NhaSanXuats.ToList().OrderBy(n=>n.TenNSX),"MaNSX", "TenNSX");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(DienThoai dt, HttpPostedFileBase fileUpload)
        {
            ViewBag.MaLDT = new SelectList(db.LoaiDienThoais.ToList().OrderBy(n => n.TenLDT), "MaLDT", "TenLDT");
            ViewBag.MaNSX = new SelectList(db.NhaSanXuats.ToList().OrderBy(n => n.TenNSX), "MaNSX", "TenNSX");
            //Kiểm tra đường dẫn ảnh bìa
            if(fileUpload == null)
            {
                ViewBag.ThongBao = "Chọn hình ảnh!";
                return View();
            }
            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                //Lưu tên file
                var fileName = Path.GetFileName(fileUpload.FileName);
                //Lưu đường dẫn của file
                var path = Path.Combine(Server.MapPath("~/HinhAnhSP/"), fileName);
                //Kiểm tra tồn tại hình ảnh
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                }
                else
                {
                    fileUpload.SaveAs(path);
                }
                dt.AnhBia = fileUpload.FileName;
                db.DienThoais.Add(dt);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //Chỉnh sửa sản phẩm
        [HttpGet]
        public ActionResult ChinhSua(int MaDienThoai)
        {
            //Lấy ra điện thoại theo mã
            DienThoai dt = db.DienThoais.SingleOrDefault(n=>n.MaDT == MaDienThoai);
            if(dt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaLDT = new SelectList(db.LoaiDienThoais.ToList().OrderBy(n => n.TenLDT), "MaLDT", "TenLDT",dt.MaLDT);
            ViewBag.MaNSX = new SelectList(db.NhaSanXuats.ToList().OrderBy(n => n.TenNSX), "MaNSX", "TenNSX",dt.MaNSX);
            return View(dt);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(DienThoai dt, HttpPostedFileBase fileUpload)
        {
            ////Lấy dữ liệu từ textbox
            //trên , FormCollection f
            //DienThoai dt1 = db.DienThoais.SingleOrDefault(n => n.MaDT == dt.MaDT);
            //dt1.Mota = dt.Mota;
            //dt1.Mota = f.Get("abc").ToString();
            //db.SaveChanges();

            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhập trong model
                db.Entry(dt).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            ViewBag.MaLDT = new SelectList(db.LoaiDienThoais.ToList().OrderBy(n => n.TenLDT), "MaLDT", "TenLDT",dt.MaLDT);
            ViewBag.MaNSX = new SelectList(db.NhaSanXuats.ToList().OrderBy(n => n.TenNSX), "MaNSX", "TenNSX",dt.MaNSX);
            return RedirectToAction("Index");
        }
        //Hiển thị
        public ActionResult HienThi(int MaDT)
        {
            //Lấy ra điện thoại theo mã
            DienThoai dt = db.DienThoais.SingleOrDefault(n => n.MaDT == MaDT);
            if (dt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dt);
        }
        //Xóa sản phẩm
        [HttpGet]
        public ActionResult Xoa(int MaDT)
        {
            //Lấy ra điện thoại theo mã
            DienThoai dt = db.DienThoais.SingleOrDefault(n => n.MaDT == MaDT);
            if (dt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dt);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaDT)
        {
            DienThoai dt = db.DienThoais.SingleOrDefault(n => n.MaDT == MaDT);
            if (dt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.DienThoais.Remove(dt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}