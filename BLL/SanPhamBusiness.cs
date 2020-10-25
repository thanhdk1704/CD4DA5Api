using BLL.Interfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class SanPhamBusiness:ISanPhamBusiness
    {
        private ISanPhamRepository isp;
        public SanPhamBusiness(ISanPhamRepository isp)
        {
            this.isp = isp;
        }
        public List<SanPhamModel> all(int pageIndex, int pageSize, out long total)
        {
            return isp.GetSanPhams( pageIndex,  pageSize, out  total);
        } 

        public SanPhamModel Chitietsanpham(string link)
        {
            var kq = isp.GetSPbyID(link);
            if (kq != null) { 
            kq.dsgiaban = isp.GetGiaBans(kq.MaSanPham);
            kq.giahientai = isp.Getgiahientai(kq.MaSanPham);
            kq.kho = isp.Getkhobysp(kq.MaSanPham);
                kq.danhmuc = isp.getloaibySanPham(kq.MaSanPham);
                kq.loaicon1 = isp.getloai1bySanPham(kq.MaSanPham);
                kq.loaicon2 = isp.getloai2bySanPham(kq.MaSanPham);
            }
            return kq;
        }
        public List<SanPhamModel> getspbyshop(string mashop, int pageIndex, int pageSize, out long total) 
        {
            var kq = isp.Getspbyshop(mashop,pageIndex, pageSize, out total);
            {
                foreach (var item in kq)
                {
                    item.dsgiaban = isp.GetGiaBans(item.MaSanPham);
                    item.giahientai = isp.Getgiahientai(item.MaSanPham);
                    item.kho = isp.Getkhobysp(item.MaSanPham);
                    item.danhmuc = isp.getloaibySanPham(item.MaSanPham);
                    item.loaicon1 = isp.getloai1bySanPham(item.MaSanPham);
                    item.loaicon2 = isp.getloai2bySanPham(item.MaSanPham);
                }
            }
            return kq;
        }
        public List<SanPhamModel> xemlichsugia(int pageIndex, int pageSize, out long total)
        {
            var kq = isp.GetSanPhams( pageIndex,  pageSize, out  total);
            {
                foreach(var item in kq)
                {
                    item.dsgiaban = isp.GetGiaBans(item.MaSanPham);
                }
            }return kq;
        }
        public List<SanPhamModel> getspwithfulldetail(int pageIndex, int pageSize, out long total)
        {
            var kq = isp.GetSanPhams( pageIndex, pageSize, out total);
            {
                foreach (var item in kq)
                {
                    item.dsgiaban = isp.GetGiaBans(item.MaSanPham);
                    item.giahientai = isp.Getgiahientai(item.MaSanPham);
                    item.kho = isp.Getkhobysp(item.MaSanPham);
                    item.danhmuc = isp.getloaibySanPham(item.MaSanPham);
                    item.loaicon1 = isp.getloai1bySanPham(item.MaSanPham);
                    item.loaicon2 = isp.getloai2bySanPham(item.MaSanPham);
                }
            }
            return kq;
        }
        public List<SanPhamModel> phantrang(int index,int size,out long total)
        {
                var kq = isp.allwithpagedlist(index,size,out total);
            {
                foreach (var item in kq)
                {
                    item.dsgiaban = isp.GetGiaBans(item.MaSanPham);
                    item.giahientai = isp.Getgiahientai(item.MaSanPham);
                    item.kho = isp.Getkhobysp(item.MaSanPham);
                    item.danhmuc = isp.getloaibySanPham(item.MaSanPham);
                    item.loaicon1 = isp.getloai1bySanPham(item.MaSanPham);
                    item.loaicon2 = isp.getloai2bySanPham(item.MaSanPham);
                }
            }
            return kq;
        }
        public List<SanPhamModel> SanphamtheoLoaiCon2(int pageIndex,int pageSize,string link, out long total)
        {
            var kq = isp.GetByLoai2(pageIndex,pageSize,link,out total);
            {
                foreach (var item in kq)
                {
                    item.dsgiaban = isp.GetGiaBans(item.MaSanPham);
                    item.giahientai = isp.Getgiahientai(item.MaSanPham);
                    item.kho = isp.Getkhobysp(item.MaSanPham);
                    item.danhmuc = isp.getloaibySanPham(item.MaSanPham);
                    item.loaicon1 = isp.getloai1bySanPham(item.MaSanPham);
                    item.loaicon2 = isp.getloai2bySanPham(item.MaSanPham);
                }
            }
            return kq;
        }
        public List<SanPhamModel> SPtheoKhoangGia(int min,int max)
        {
            var kq = isp.SPtheoKhoangGia(min, max);
            foreach(var item in kq)
            {
                item.dsgiaban = isp.GetGiaBans(item.MaSanPham);
                item.giahientai = isp.Getgiahientai(item.MaSanPham);
                item.kho = isp.Getkhobysp(item.MaSanPham);
                item.danhmuc = isp.getloaibySanPham(item.MaSanPham);
                item.loaicon1 = isp.getloai1bySanPham(item.MaSanPham);
                item.loaicon2 = isp.getloai2bySanPham(item.MaSanPham);
            }
            return kq;
        }
        public List<SanPhamModel> SPtuongtu(string maloai)
        {
            var kq = isp.GetCungLoai(maloai);
            {
                foreach (var item in kq)
                {
                    item.dsgiaban = isp.GetGiaBans(item.MaSanPham);
                    item.giahientai = isp.Getgiahientai(item.MaSanPham);
                    item.kho = isp.Getkhobysp(item.MaSanPham);
                    item.danhmuc = isp.getloaibySanPham(item.MaSanPham);
                    item.loaicon1 = isp.getloai1bySanPham(item.MaSanPham);
                    item.loaicon2 = isp.getloai2bySanPham(item.MaSanPham);
                }
            }
            return kq;
        }
        public List<SanPhamModel> spbyloai1(string link)
        {
            var kq = isp.Getspbyloai1(link);
            {
                foreach (var item in kq)
                {
                    item.dsgiaban = isp.GetGiaBans(item.MaSanPham);
                    item.giahientai = isp.Getgiahientai(item.MaSanPham);
                    item.kho = isp.Getkhobysp(item.MaSanPham);
                    item.danhmuc = isp.getloaibySanPham(item.MaSanPham);
                    item.loaicon1 = isp.getloai1bySanPham(item.MaSanPham);
                    item.loaicon2 = isp.getloai2bySanPham(item.MaSanPham);
                }
            }
            return kq;
        }
        public List<SanPhamModel> spbyloai(int pageIndex,int  pageSize, string link, out long total)
        {
            var kq = isp.Getspbyloai(pageIndex,pageSize,link,out total);
            {
                foreach (var item in kq)
                {
                    item.dsgiaban = isp.GetGiaBans(item.MaSanPham);
                    item.giahientai = isp.Getgiahientai(item.MaSanPham);
                    item.kho = isp.Getkhobysp(item.MaSanPham);
                    item.danhmuc = isp.getloaibySanPham(item.MaSanPham);
                    item.loaicon1 = isp.getloai1bySanPham(item.MaSanPham);
                    item.loaicon2 = isp.getloai2bySanPham(item.MaSanPham);
                }
            }
            return kq;
        }
        public List<SanPhamModel> Getspbyshop(int index, int size,string link, out long total)
        {
            var kq = isp.Getspbyshop(index, size, link,out total);
            {
                foreach (var item in kq)
                {
                    item.dsgiaban = isp.GetGiaBans(item.MaSanPham);
                    item.giahientai = isp.Getgiahientai(item.MaSanPham);
                    item.kho = isp.Getkhobysp(item.MaSanPham);
                    item.Total = total;
                }
            }
            return kq;
        }
        public List<SanPhamModel> Create(SanPhamModel spmoi)
        {
            return isp.Create(spmoi);
        }
        public List<KhoModel> ThemKho(string MaSanPham, string MaShop, int SoLuong, int GiaNhap)
        {
            return isp.AddKho(MaSanPham, MaShop,  SoLuong,  GiaNhap);
        }
        public List<GiaBanModel> ThemGiaBan(string MaSanPham,int Gia)
        {
            return isp.Addprice(MaSanPham,Gia);
        }
        public int delete(string masp)
        {
            return isp.Delete(masp);
        }
    }
    
}
