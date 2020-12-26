using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class LoaiSanPhamDAO
    {
        WebDienThoaiDBModel db = new WebDienThoaiDBModel();
        public List<LoaiSanPham> ListAll()
        {
            return db.LoaiSanPhams.ToList();
        }

        public int Insert(LoaiSanPham entity)
        {
            db.LoaiSanPhams.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public LoaiSanPham ViewDetail(int id)
        {
            return db.LoaiSanPhams.Find(id);
        }

        public bool Update(LoaiSanPham entity)
        {
            try
            {
                var lsp = db.LoaiSanPhams.Find(entity.ID);
                lsp.TenLSP = entity.TenLSP;
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
                var lsp = db.LoaiSanPhams.Find(id);
                db.LoaiSanPhams.Remove(lsp);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
