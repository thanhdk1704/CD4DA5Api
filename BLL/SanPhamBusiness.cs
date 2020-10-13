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
        public List<SanPhamModel> all()
        {
            return isp.GetSanPhams();
        } 
        public SanPhamModel Chitietsanpham(string link)
        {
            var kq = isp.GetSPbyID(link);
            if (kq != null) { 
            kq.dsgiaban = isp.GetGiaBans(kq.MaSanPham);
            kq.giahientai = isp.Getgiahientai(kq.MaSanPham);
            kq.kho = isp.Getkhobysp(kq.MaSanPham);
            }
            return kq;
        }
        public dynamic getspbyshop(string mashop) 
        { 
            return isp.Getspbyshop(mashop); 
        }
        public List<SanPhamModel> xemlichsugia()
        {
            var kq = isp.GetSanPhams();
            {
                foreach(var item in kq)
                {
                    item.dsgiaban = isp.GetGiaBans(item.MaSanPham);
                }
            }return kq;
        }
        public List<SanPhamModel> getspwithfulldetail()
        {
            var kq = isp.GetSanPhams();
            {
                foreach (var item in kq)
                {
                    item.dsgiaban = isp.GetGiaBans(item.MaSanPham);
                    item.giahientai = isp.Getgiahientai(item.MaSanPham);
                    item.kho = isp.Getkhobysp(item.MaSanPham);
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
                }
            }
            return kq;
        }
        public List<SanPhamModel> SanphamtheoLoaiCon2(string maloai)
        {
            var kq = isp.GetByLoai2(maloai);
            {
                foreach (var item in kq)
                {
                    item.dsgiaban = isp.GetGiaBans(item.MaSanPham);
                    item.giahientai = isp.Getgiahientai(item.MaSanPham);
                    item.kho = isp.Getkhobysp(item.MaSanPham);
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
                }
            }
            return kq;
        }
    }
}
