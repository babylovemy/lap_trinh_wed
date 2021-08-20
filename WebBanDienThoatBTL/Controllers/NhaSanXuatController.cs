using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDienThoatBTL.Models;

namespace WebBanDienThoatBTL.Controllers
{
    public class NhaSanXuatController : Controller
    {
        // GET: NhaSanXuat
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        public PartialViewResult NhaSanXuatPartial()
        {
            return PartialView(db.NhaSanXuats.OrderBy(n=>n.TenNSX).ToList());
        }
        //Hien thi dien theo nha san xuat
        public ViewResult DTTheoNSX(int MaNSX = 0)
        {
            //Kiem tra loai dien thoai ton tai
            NhaSanXuat nsx = db.NhaSanXuats.SingleOrDefault(n => n.MaNSX == MaNSX);
            if (nsx == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Truy xuat dien thoai theo nha san xuat
            List<DienThoai> dt = db.DienThoais.Where(n => n.MaNSX == MaNSX).OrderBy(n => n.GiaBan).ToList();
            if (dt.Count == 0)
            {
                ViewBag.DienThoai = "Không có điện thoại của hãng này!";
            }
            return View(dt);
        }
    }
}