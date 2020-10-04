using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public interface HangSanXuatRepository:IHangSanXuatRepository
    {
        public List<HangSanXuatModel> GetDonHang()
        {
            return null;
        }
    }
}
