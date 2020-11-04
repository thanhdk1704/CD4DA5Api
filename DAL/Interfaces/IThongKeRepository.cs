using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface IThongKeRepository
    {
        int doanhthutheoloaitheothang(string mashop, int maloai, int thang, out int doanhthu);
        List<DonHangModel> donhangtheothang(string mashop, int thang);
        List<HoaDonNhapModel> phieunhaptheothang(string mashop, int thang);
        List<SanPhamModel> Spbanchay(string mashop, int thang);
        List<SanPhamModel> Sphethang(string mashop);
        ThongKeModel TongQuanThang(string mashop, int thang);
    }
}
