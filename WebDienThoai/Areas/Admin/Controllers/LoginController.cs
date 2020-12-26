using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDienThoai.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {

        // GET: Admin/Login
        public ActionResult Index()
        {
            if (!Session["UserAdmin"].Equals(""))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection field)
        {
            WebDienThoaiDBModel db = new WebDienThoaiDBModel();
            string strerr = "";
            string username = field["username"];
            string password = field["password"];

            var rowuser = db.TaiKhoans.Where(n => n.Username == username).FirstOrDefault();
            if (rowuser == null)
            {
                strerr = "Không tồn tại tài khoản";
            }
            else
            {
                if (rowuser.Password.Equals(password))
                {
                    Session["UserAdmin"] = rowuser.Username;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    strerr = "Mật khẩu không đúng";
                }
            }

            ViewBag.Error = "<span class='text-danger'>" + strerr + "</span>";
            return View();
        }

        public ActionResult Logout()
        {
            Session["UserAdmin"] = "";
            return View("Index");
        }
    }
}