using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDienThoatBTL.Models;

namespace WebBanDienThoatBTL.Controllers
{
    public class LoaiDTController : Controller
    {
        // GET: LoaiDT
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        public ActionResult LoaiDTPartial()
        {
            return PartialView(db.LoaiDienThoais.Take(5).ToList());
        }
        //Điện thoại theo loại điện thoại
        public ViewResult DTTheoLoai(int MaLDT = 0)
        {
            //Kiem tra loai dien thoai ton tai
            LoaiDienThoai ldt = db.LoaiDienThoais.SingleOrDefault(n => n.MaLDT == MaLDT);
            if(ldt == null)    
            {
                Response.StatusCode = 404;
                return null;
            }
            //Truy xuat dien thoai theo loai dt
            List<DienThoai> dt = db.DienThoais.Where(n => n.MaLDT == MaLDT).OrderBy(n => n.GiaBan).ToList();
            if (dt.Count == 0)
            {
                ViewBag.DienThoai = "Không có điện thoại của loại này!";
            }
            return View(dt);
        }
    }
}