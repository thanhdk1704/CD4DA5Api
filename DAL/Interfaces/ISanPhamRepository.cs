using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ISanPhamRepository
    {
        public List<SanPhamModel> GetSanPhams(int pageIndex, int pageSize,out long total);
        SanPhamModel GetSPbyID(string id);
        List<SanPhamModel> Getspbyshop(string mashop, int pageIndex, int pageSize, out long total);
        List<KhoModel> GetKho();
        List<GiaBanModel> GetGiaBans(string masp);
        GiaBanModel Getgiahientai(string masp);
        KhoModel Getkhobysp(string masp);
        List<SanPhamModel> allwithpagedlist(int pageIndex, int pageSize, out long total);
        List<SanPhamModel> GetByLoai2(int pageIndex, int pageSize, string link, out long total);
        List<SanPhamModel> SPtheoKhoangGia(int min, int max);
        List<SanPhamModel> GetCungLoai(string masp);
        LoaiModel getloaibySanPham(string masp);
        LoaiCon1Model getloai1bySanPham(string masp);
        LoaiCon2Model getloai2bySanPham(string masp);
        List<SanPhamModel> Getspbyloai1(string link);
        List<SanPhamModel> Getspbyloai(int pageIndex, int pageSize, string link, out long total);
        List<SanPhamModel> Getspbyshop(int pageIndex, int pageSize, string link, out long total);
        SanPhamModel Create(SanPhamModel spmoi);
        int Delete(string masp);
        List<KhoModel> AddKho(KhoModel kho);
        GiaBanModel Addprice(GiaBanModel gb);
        List<ChiTietLuaChonModel> getluachonbysp(string masp);
        int getRevenue(string magb);
    }
}
