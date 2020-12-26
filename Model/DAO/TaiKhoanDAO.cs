using Model.EF;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    
    public class TaiKhoanDAO
    {
        WebDienThoaiDBModel db = new WebDienThoaiDBModel();

        public IEnumerable<TaiKhoan> ListAllPaging(string searchString, int page, int pagesize)
        {
            IQueryable<TaiKhoan> model = db.TaiKhoans;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(n => n.Username.Contains(searchString));
            }
            return model.OrderBy(n=>n.ID).ToPagedList(page, pagesize);            
        }
        public int Insert(TaiKhoan entity)
        {
            db.TaiKhoans.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public TaiKhoan ViewDetail(int id)
        {
            return db.TaiKhoans.Find(id);
        }

        public bool Update(TaiKhoan entity)
        {
            try
            {
                var taikhoan = db.TaiKhoans.Find(entity.ID);
                taikhoan.Username = entity.Username;
                taikhoan.Password = entity.Password;
                db.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var taikhoan = db.TaiKhoans.Find(id);
                db.TaiKhoans.Remove(taikhoan);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
