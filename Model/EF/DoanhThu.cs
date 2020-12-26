namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DoanhThu")]
    public partial class DoanhThu
    {
        public int ID { get; set; }

        public int? IDDDH { get; set; }

        public decimal? TongTien { get; set; }

        public bool? Status { get; set; }

        public virtual DonDatHang DonDatHang { get; set; }
    }
}
