using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Model.DAO
{
    public class SanPhamDAO
    {
        WebDienThoaiDBModel db = new WebDienThoaiDBModel();
        public List<SanPham> ListAll()
        {
            return db.SanPhams.ToList();
        }

        public List<SanPham> ViewDetailByNSXID(int id)
        {
            var model = from a in db.SanPhams
                        join b in db.NhaSanXuats
                        on a.IDNSX equals b.ID
                        where a.IDNSX == id
                        
                        select a;
            return model.ToList();
        }

        public List<SanPham> ListAllByIDNSX(int id)
        {
            return db.SanPhams.Where(n => n.IDNSX == id).ToList();
        }

        public List<string> ListName(string keyword)
        {
            return db.SanPhams.Where(n => n.TenSP.Contains(keyword)).Select(n => n.TenSP).ToList();
        }

        public List<SanPham> Search(string keyword)
        {
            return db.SanPhams.Where(n => n.TenSP == keyword).ToList();
        }

        public List<SanPham> ListRelate(int id)
        {
            var idnsx = db.SanPhams.Where(n => n.ID == id).Select(n => n.IDNSX).First();
            return db.SanPhams.Where(n => n.IDNSX == idnsx).ToList();
            
        }



        public List<SanPham> ListFeatured(int top)
        {
            return db.SanPhams.Where(n => n.Gia > 20000000).OrderBy(n => n.Hot).Take(top).ToList();
        }
        public IEnumerable<SanPham> ListAllPaging(string searchString, int page, int pagesize)
        {
            IQueryable<SanPham> model = db.SanPhams;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(n => n.TenSP.Contains(searchString));
            }
            return model.OrderBy(n => n.ID).ToPagedList(page, pagesize);
        }


        public SanPham ViewDetail(int id)
        {
            return db.SanPhams.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var sp = db.SanPhams.Find(id);
                db.SanPhams.Remove(sp);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
