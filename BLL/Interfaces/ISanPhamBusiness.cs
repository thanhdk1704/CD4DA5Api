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
        List<SanPhamModel> SanphamtheoLoaiCon2(int pageIndex, int pageSize, string link, out long total);
        List<SanPhamModel> SPtheoKhoangGia(int min, int max);
        List<SanPhamModel> SPtuongtu(string maloai);
        List<SanPhamModel> spbyloai1(string link);
        List<SanPhamModel> spbyloai(int pageIndex, int pageSize, string link, out long total);
        List<SanPhamModel> Getspbyshop(int index, int size, string link, out long total);
        List<SanPhamModel> Create(SanPhamModel spmoi);
        int delete(string masp);
        List<GiaBanModel> ThemGiaBan(string MaSanPham, int Gia);
        List<KhoModel> ThemKho(string MaSanPham, string MaShop, int SoLuong, int GiaNhap);
    }
}
