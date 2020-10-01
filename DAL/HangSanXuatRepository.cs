using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    interface HangSanXuatRepository:IHangSanXuatRepository
    {
        public List<HangSanXuatModel> GetDonHang()
        {
            return null;
        }
    }
}
