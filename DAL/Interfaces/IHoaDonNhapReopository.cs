using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface IHoaDonNhapReopository
    {
        List<ChiTietHoaDonNhapModel> GetCtHDN(string mahdn);
        HoaDonNhapModel GetHDNbyID(string mahdn);
        List<HoaDonNhapModel> GetHDNbyShop(string mashop, int page_index, int page_size, out long total);
    }
}
