using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class HoaDonNhapBusiness: IHoaDonNhapBusiness
    {
        private IHoaDonNhapReopository _res;

        public HoaDonNhapBusiness(IHoaDonNhapReopository res)
        {
            _res = res;
        }

       public HoaDonNhapModel GetHDNbyID(string mahdn)
        {
            var kq = _res.GetHDNbyID(mahdn);
            kq.chitiet = _res.GetCtHDN(mahdn);
            return kq;
        }
       public List<HoaDonNhapModel> GetHDNbyShop(string mashop,int page_index, int page_size, out long total)
        {
            var kq = _res.GetHDNbyShop(mashop,page_index, page_size, out total);
            foreach(var item in kq)
            {
                item.chitiet = _res.GetCtHDN(item.MaHDN);
            }
            return kq;
        }
        public List<ChiTietHoaDonNhapModel> getbyhdn(string mahdn)
        {
            return _res.GetCtHDN(mahdn);
        }
    }
}
