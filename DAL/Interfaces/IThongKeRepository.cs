using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface IThongKeRepository
    {
        int doanhthutheoloaitheothang(string mashop, int maloai, int thang, out int doanhthu);
        List<SanPhamModel> Spbanchay(string mashop, int thang);
        List<SanPhamModel> Sphethang(string mashop);
        ThongKeModel TongQuanThang(string mashop, int thang);
    }
}
