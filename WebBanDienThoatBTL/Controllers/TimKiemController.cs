using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDienThoatBTL.Models;
using PagedList.Mvc;
using PagedList;

namespace WebBanDienThoatBTL.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<DienThoai> lstKQTK = db.DienThoais.Where(n => n.TenDT.Contains(sTuKhoa)).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy thông tin sản phẩm!";
                return View(db.DienThoais.OrderBy(n => n.TenDT).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy: " + lstKQTK.Count + "kết quả!";
            return View(lstKQTK.OrderBy(n=>n.TenDT).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult KetQuaTimKiem(int? page, string sTuKhoa)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<DienThoai> lstKQTK = db.DienThoais.Where(n => n.TenDT.Contains(sTuKhoa)).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy thông tin sản phẩm!";
                return View(db.DienThoais.OrderBy(n => n.TenDT).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy: " + lstKQTK.Count + "kết quả!";
            return View(lstKQTK.OrderBy(n => n.TenDT).ToPagedList(pageNumber, pageSize));
        }
    }
}