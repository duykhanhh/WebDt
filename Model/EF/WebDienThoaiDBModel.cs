namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebDienThoaiDBModel : DbContext
    {
        public WebDienThoaiDBModel()
            : base("name=WebDienThoaiDBModel")
        {
        }

        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<DoanhThu> DoanhThus { get; set; }
        public virtual DbSet<DonDatHang> DonDatHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiKhachHang> LoaiKhachHangs { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<NhaSanXuat> NhaSanXuats { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonDatHang>()
                .HasMany(e => e.DoanhThus)
                .WithOptional(e => e.DonDatHang)
                .HasForeignKey(e => e.IDDDH);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.BinhLuans)
                .WithOptional(e => e.KhachHang)
                .HasForeignKey(e => e.IDKH);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.DonDatHangs)
                .WithOptional(e => e.KhachHang)
                .HasForeignKey(e => e.IDKH);

            modelBuilder.Entity<LoaiKhachHang>()
                .HasMany(e => e.KhachHangs)
                .WithOptional(e => e.LoaiKhachHang)
                .HasForeignKey(e => e.IDLKH);

            modelBuilder.Entity<LoaiSanPham>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.LoaiSanPham)
                .HasForeignKey(e => e.IDLSP);

            modelBuilder.Entity<NhaSanXuat>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.NhaSanXuat)
                .HasForeignKey(e => e.IDNSX);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.BinhLuans)
                .WithOptional(e => e.SanPham)
                .HasForeignKey(e => e.IDSP);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.DonDatHangs)
                .WithOptional(e => e.SanPham)
                .HasForeignKey(e => e.IDSP);
        }
    }
}
