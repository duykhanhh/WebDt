using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDienThoai.Areas.Admin.Controllers
{
    public class LoaiSanPhamController : BaseController
    {
        // GET: Admin/LoaiSanPham
        public ActionResult Index()
        {
            var dao = new LoaiSanPhamDAO();
            var model = dao.ListAll();
            return View(model);
        }

        // GET: Admin/LoaiSanPham/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/LoaiSanPham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSanPham/Create
        [HttpPost]
        public ActionResult Create(LoaiSanPham lsp)
        {
            try
            {
                var dao = new LoaiSanPhamDAO();
                var model = dao.Insert(lsp);
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

        // GET: Admin/LoaiSanPham/Edit/5
        public ActionResult Edit(int id)
        {
            var lsp = new LoaiSanPhamDAO().ViewDetail(id);
            return View(lsp);
        }

        // POST: Admin/LoaiSanPham/Edit/5
        [HttpPost]
        public ActionResult Edit(LoaiSanPham lsp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new LoaiSanPhamDAO();
                    var result = dao.Update(lsp);
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

        // GET: Admin/LoaiSanPham/Delete/5
        

        // POST: Admin/LoaiSanPham/Delete/5
        
        public ActionResult Delete(int id)
        {
            new LoaiSanPhamDAO().Delete(id);

            return RedirectToAction("Index");
            
        }
    }
}
