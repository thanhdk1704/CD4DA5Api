using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class DonHangModel
    {
        public string MaDH {get; set; }
      public string MaKH {get; set; }
      public string MaShop {get; set; }
      public string NgayDat {get; set; }
      public int ThanhToan {get; set; }
      public int  TrangThai {get; set; }
        public List<ChiTietDonHangModel> chitiet { get; set; }
    }
}
