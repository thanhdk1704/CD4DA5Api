using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public partial interface ISanPhamBusiness
    {
        List<SanPhamModel> all();
        SanPhamModel Chitietsanpham(string link);
        dynamic getspbyshop(string mashop);
        public List<SanPhamModel> xemlichsugia();
        List<SanPhamModel> getspwithfulldetail();
        List<SanPhamModel> phantrang(int index, int size, out long total);
        List<SanPhamModel> SanphamtheoLoaiCon2(string maloai);
        List<SanPhamModel> SPtheoKhoangGia(int min, int max);
        List<SanPhamModel> SPtuongtu(string maloai);
    }
}
