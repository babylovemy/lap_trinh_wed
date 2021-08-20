using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDienThoatBTL.Models;

namespace WebBanDienThoatBTL.Controllers
{
    public class DienThoaiController : Controller
    {
        // GET: DienThoai /DienThoaiPartial
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        public PartialViewResult DienThoaiPartial()
        {
            var lstDienThoai = db.DienThoais.Take(3).ToList();
            return PartialView(lstDienThoai);
        }
        //Xem chi tiết
        public ViewResult XemChiTiet(int MaDT=0)
        {
            DienThoai dt = db.DienThoais.SingleOrDefault(n=>n.MaDT==MaDT);
            if(dt == null)
            {
                //Trả về trang báo lỗi
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.TenNSX = db.NhaSanXuats.Single(n => n.MaNSX == dt.MaNSX).TenNSX;
            ViewBag.LoaiDT = db.LoaiDienThoais.Single(n => n.MaLDT == dt.MaLDT).TenLDT;
            return View(dt);
        }
    }
}