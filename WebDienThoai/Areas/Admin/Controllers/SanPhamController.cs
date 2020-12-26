using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDienThoai.Areas.Admin.Controllers
{
    
    public class SanPhamController : Controller
    {

        WebDienThoaiDBModel db = new WebDienThoaiDBModel();
        // GET: Admin/SanPham
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var dao = new SanPhamDAO();
            var model = dao.ListAllPaging(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public void SetViewBagTenNSX()
        {

        }

        // GET: Admin/SanPham/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/SanPham/Create
        public ActionResult Create()
        {
            
            SetViewBagNSX();
            SetViewBagLSP();
            return View();
        }

        // POST: Admin/SanPham/Create
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(SanPham sp,HttpPostedFileBase imgfile)
        {
            SanPham sanpham = new SanPham();
            string path = uploadimage(imgfile);
            if (path.Equals("-1"))
            {

            }
            else
            {
                sanpham.IDNSX = sp.IDNSX;
                sanpham.IDLSP = sp.IDLSP;
                sanpham.TenSP = sp.TenSP;
                sanpham.HinhAnh = path;
                sanpham.Hinh1 = sp.Hinh1;
                sanpham.Hinh2 = sp.Hinh2;
                sanpham.Hinh3 = sp.Hinh3;
                sanpham.Gia = sp.Gia;
                sanpham.Mota = sp.Mota;
                sanpham.BaoHanh = sp.BaoHanh;
                sanpham.TaoNgay = sp.TaoNgay;
                sanpham.Hot = sp.Hot;
                sanpham.LuotXem = sp.LuotXem;
                sanpham.Status = sp.Status;
                db.SanPhams.Add(sanpham);
                db.SaveChanges();
                
            }


            SetViewBagNSX();
            SetViewBagLSP();
            return RedirectToAction("Index");
            
        }

        public void SetViewBagNSX(int? selectedID = null)
        {
            var dao = new NhaSanXuatDAO();
            ViewBag.IDNSX = new SelectList(dao.ListName(), "ID", "TenNSX", selectedID);
        }

        public void SetViewBagLSP(int? selectedID = null)
        {
            var dao = new LoaiSanPhamDAO();
            ViewBag.IDLSP = new SelectList(dao.ListAll(), "ID", "TenLSP", selectedID);
        }
        public string uploadimage(HttpPostedFileBase file)
        {
            string path = "-1";
            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("/Assets/uploadimg/"), Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "/Assets/uploadimg/" + Path.GetFileName(file.FileName);
                    }
                    catch(Exception ex)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("Chỉ được chọn 3 file đuôi ảnh thôi");
                }
            }
            else
            {
                Response.Write("Vui lòng chọn file ảnh");
                path = "-1";
            }
            return path;
        }

        // GET: Admin/SanPham/Edit/5
        public ActionResult Edit(int id)
        {
            SetViewBagNSX();
            SetViewBagLSP();
            var dao = new SanPhamDAO();
            var model = dao.ViewDetail(id);
            return View(model);
        }

        // POST: Admin/SanPham/Edit/5
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(SanPham sp, HttpPostedFileBase imgfile)
        {
            var sanpham = db.SanPhams.Find(sp.ID);
            string path = uploadimage(imgfile);
            if (path.Equals("-1"))
            {

            }
            else
            {
                sanpham.IDNSX = sp.IDNSX;
                sanpham.IDLSP = sp.IDLSP;
                sanpham.TenSP = sp.TenSP;
                sanpham.HinhAnh = path;
                sanpham.Hinh1 = sp.Hinh1;
                sanpham.Hinh2 = sp.Hinh2;
                sanpham.Hinh3 = sp.Hinh3;
                sanpham.Gia = sp.Gia;
                sanpham.Mota = sp.Mota;
                sanpham.BaoHanh = sp.BaoHanh;
                sanpham.TaoNgay = sp.TaoNgay;
                sanpham.Hot = sp.Hot;
                sanpham.LuotXem = sp.LuotXem;
                sanpham.Status = sp.Status;
                
                db.SaveChanges();

            }


            SetViewBagNSX();
            SetViewBagLSP();
            return RedirectToAction("Index");
        }

        // GET: Admin/SanPham/Delete/5
        

        // POST: Admin/SanPham/Delete/5

        public ActionResult Delete(int id)
        {
            new SanPhamDAO().Delete(id);

            return RedirectToAction("Index");
            
        }
    }
}
