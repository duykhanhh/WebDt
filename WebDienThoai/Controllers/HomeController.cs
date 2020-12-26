using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDienThoai.Controllers
{
    public class HomeController : Controller
    {
        

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.NSX = new NhaSanXuatDAO().ListAll();
            ViewBag.ListFeatured = new SanPhamDAO().ListFeatured(4);
            return View();
        }

        public static string getString(string s)
        {
            if (s.Length > 10)
            {
                return s.Substring(0, 10) + "...";
            }
            else
            {
                return s;
            }
        }
    }
}