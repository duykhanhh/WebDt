using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDienThoai.Models
{
    public class CartItem
    {
        public SanPham SanPham { get; set; }

        public int quantity { get; set; }
    }
}