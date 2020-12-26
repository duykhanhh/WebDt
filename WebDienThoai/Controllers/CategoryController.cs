using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDienThoai.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index(int id)
        {

            var model = new SanPhamDAO().ViewDetailByNSXID(id);
            // Tesst
            return View(model);
        }
    }
}