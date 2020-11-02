using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class HoaDonNhapModel
    {
        public string MaHDN{get;set;}
      public string MaNCC{get;set;}
      public string MaShop{get;set;}
      public DateTime NgayNhap{get;set;}
        public List<ChiTietHoaDonNhapModel> chitiet { get; set; }
    }
}
