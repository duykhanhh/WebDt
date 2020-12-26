using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDienThoai.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            ViewBag.NSX = new NhaSanXuatDAO().ListAll();
            ViewBag.Relate = new SanPhamDAO().ListRelate(id);
            var model = new SanPhamDAO().ViewDetail(id);

            return View(model);
        }

        public JsonResult ListName(string q)
        {
            var data = new SanPhamDAO().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            },JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchProduct(string keyword)
        {
            var model = new SanPhamDAO().Search(keyword);
            return View(model);
        }
    }
}