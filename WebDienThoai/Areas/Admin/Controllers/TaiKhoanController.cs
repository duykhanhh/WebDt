using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace WebDienThoai.Areas.Admin.Controllers
{
    public class TaiKhoanController : BaseController
    {
        // GET: Admin/TaiKhoan
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var dao = new TaiKhoanDAO();
            var model = dao.ListAllPaging(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        // GET: Admin/TaiKhoan/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/TaiKhoan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TaiKhoan/Create
        [HttpPost]
        public ActionResult Create(TaiKhoan taikhoan)
        {
            try
            {
                
                
                    
                    var dao = new TaiKhoanDAO();
                    int id = dao.Insert(taikhoan);
                    if (id > 0)
                    {
                        
                        return RedirectToAction("Index", "TaiKhoan");
                    }
                    else
                    {

                    Response.Write("Thêm thất bại");
                    }
                
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/TaiKhoan/Edit/5
        public ActionResult Edit(int id)
        {
            var taikhoan = new TaiKhoanDAO().ViewDetail(id);
            return View(taikhoan);
        }

        // POST: Admin/TaiKhoan/Edit/5
        [HttpPost]
        public ActionResult Edit(TaiKhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();
                var result = dao.Update(taikhoan);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa thất bại");
                }
            }
            return View("Index");
        }

        // GET: Admin/TaiKhoan/Delete/5
        

        // POST: Admin/TaiKhoan/Delete/5
        
        public ActionResult Delete(int id)
        {
            new TaiKhoanDAO().Delete(id);
            return RedirectToAction("Index");
        }
    }
}
