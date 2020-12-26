namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        public int ID { get; set; }

        [Required]
        [Display(Name ="Tài Khoản")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Mật Khẩu")]
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
