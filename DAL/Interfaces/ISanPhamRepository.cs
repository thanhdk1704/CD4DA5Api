using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ISanPhamRepository
    {
        public List<SanPhamModel> GetSanPhams();
        SanPhamModel GetSPbyID(string id);
        dynamic Getspbyshop(string mashop);
        List<KhoModel> GetKho();
        List<GiaBanModel> GetGiaBans(string masp);
        GiaBanModel Getgiahientai(string masp);
        KhoModel Getkhobysp(string masp);
        List<SanPhamModel> allwithpagedlist(int pageIndex, int pageSize, out long total);
        List<SanPhamModel> GetByLoai2(string maloai);
        List<SanPhamModel> SPtheoKhoangGia(int min, int max);
        List<SanPhamModel> GetCungLoai(string masp);
    }
}
