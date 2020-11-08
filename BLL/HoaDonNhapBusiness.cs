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
            kq.Tongchiphi = 0;
            kq.Tongdonvi = 0;
            kq.chitiet = _res.GetCtHDN(mahdn);
            for (int i = 0; i < kq.chitiet.Count; i++)
            {
                kq.Tongdonvi += kq.chitiet[i].Soluong;
                kq.Tongchiphi += kq.chitiet[i].Soluong * kq.chitiet[i].DonGia;
            }
            return kq;
        }
       public List<HoaDonNhapModel> GetHDNbyShop(string mashop,int page_index, int page_size, out long total)
        {
            var kq = _res.GetHDNbyShop(mashop,page_index, page_size, out total);
            foreach(var item in kq)
            {
                item.Tongchiphi = 0;
                item.Tongdonvi = 0;
                item.chitiet = _res.GetCtHDN(item.MaHDN);
                for (int i = 0; i < item.chitiet.Count; i++)
                {
                    item.Tongdonvi += item.chitiet[i].Soluong;
                    item.Tongchiphi += item.chitiet[i].Soluong * item.chitiet[i].DonGia;
                }
            }
            return kq;
        }
        public List<ChiTietHoaDonNhapModel> getbyhdn(string mahdn)
        {
            return _res.GetCtHDN(mahdn);
        }
        public HoaDonNhapModel Them(HoaDonNhapModel hdn)
        {
            return _res.Them(hdn);
        }
    }
}
