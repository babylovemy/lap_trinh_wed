using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDienThoatBTL.Models;
using PagedList;
using PagedList.Mvc;

namespace WebBanDienThoatBTL.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        public ActionResult Index(int? page)
        {
            //Tạo biến số sản phẩm trên trang
            int pageSize = 6;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            return View(db.DienThoais.Where(n=>n.MaLDT==23).ToList().OrderBy(n=>n.GiaBan).ToPagedList(pageNumber,pageSize));
        }

        public ActionResult MayTinhBang(int? page)
        {
            //Tạo biến số sản phẩm trên trang
            int pageSize = 6;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            return View(db.DienThoais.Where(n => n.MaLDT == 24).ToList().OrderBy(n => n.GiaBan).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult PhuKien(int? page)
        {
            //Tạo biến số sản phẩm trên trang
            int pageSize = 6;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            return View(db.DienThoais.Where(n => n.MaLDT == 25).ToList().OrderBy(n => n.GiaBan).ToPagedList(pageNumber, pageSize));
        }
    }
}