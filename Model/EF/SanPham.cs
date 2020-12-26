namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            BinhLuans = new HashSet<BinhLuan>();
            DonDatHangs = new HashSet<DonDatHang>();
        }

        public int ID { get; set; }
        [Display(Name = "Nhà sản xuất")]
        public int? IDNSX { get; set; }
        [Display(Name = "Loại sản phẩm")]
        public int? IDLSP { get; set; }

        [Required]
        [Display(Name ="Tên SP")]
        [StringLength(100)]
        public string TenSP { get; set; }
        [Display(Name = "Hình ảnh")]
        [StringLength(100)]
        public string HinhAnh { get; set; }

        [StringLength(100)]
        public string Hinh1 { get; set; }

        [StringLength(100)]
        public string Hinh2 { get; set; }

        [StringLength(100)]
        public string Hinh3 { get; set; }
        [Display(Name = "Giá")]
        public decimal? Gia { get; set; }
        [Display(Name = "Mô tả")]
        public string Mota { get; set; }
        [Display(Name = "Bảo hành")]
        [StringLength(100)]
        public string BaoHanh { get; set; }
        [Display(Name = "Tạo ngày")]
        public DateTime? TaoNgay { get; set; }
        [Display(Name = "Hot")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? Hot { get; set; }
        [Display(Name = "Lượt xem")]
        public int? LuotXem { get; set; }
        [Display(Name = "Trạng thái")]
        public bool? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonDatHang> DonDatHangs { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }

        public virtual NhaSanXuat NhaSanXuat { get; set; }
    }
}
