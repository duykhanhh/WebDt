using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class NhaSanXuatDAO
    {
        WebDienThoaiDBModel db = new WebDienThoaiDBModel();
        public IEnumerable<NhaSanXuat> ListAllPaging(string searchString, int page, int pagesize)
        {
            IQueryable<NhaSanXuat> model = db.NhaSanXuats;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(n => n.TenNSX.Contains(searchString));
            }
            return model.OrderBy(n => n.ID).ToPagedList(page, pagesize);

        }

        public List<NhaSanXuat> ListAll()
        {
            return db.NhaSanXuats.ToList();
        }

        public int Insert(NhaSanXuat entity)
        {
            db.NhaSanXuats.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public NhaSanXuat ViewDetail(int id)
        {
            return db.NhaSanXuats.Find(id);
        }

        public bool Update(NhaSanXuat entity)
        {
            try
            {
                var nsx = db.NhaSanXuats.Find(entity.ID);
                nsx.TenNSX = entity.TenNSX;
                nsx.Status = entity.Status;
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var nsx = db.NhaSanXuats.Find(id);
                db.NhaSanXuats.Remove(nsx);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<NhaSanXuat> ListName()
        {
            return db.NhaSanXuats.ToList();
        }
    }
}
