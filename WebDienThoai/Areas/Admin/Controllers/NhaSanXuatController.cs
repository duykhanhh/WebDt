using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDienThoai.Areas.Admin.Controllers
{
    public class NhaSanXuatController : BaseController
    {
        // GET: Admin/NhaSanXuat
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            
            var dao = new NhaSanXuatDAO();
            var model = dao.ListAllPaging(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        // GET: Admin/NhaSanXuat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/NhaSanXuat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhaSanXuat/Create
        [HttpPost]
        public ActionResult Create(NhaSanXuat nsx)
        {
            try
            {
                var dao = new NhaSanXuatDAO();
                var model = dao.Insert(nsx);
                if (model > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/NhaSanXuat/Edit/5
        public ActionResult Edit(int id)
        {
            var nsx = new NhaSanXuatDAO().ViewDetail(id);
            return View(nsx);
        }

        // POST: Admin/NhaSanXuat/Edit/5
        [HttpPost]
        public ActionResult Edit(NhaSanXuat nsx)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new NhaSanXuatDAO();
                    var result = dao.Update(nsx);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Sửa thất bại");
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/NhaSanXuat/Delete/5
        
        public ActionResult Delete(int id)
        {
            new NhaSanXuatDAO().Delete(id);

            return RedirectToAction("Index");
            
        }
    }
}
