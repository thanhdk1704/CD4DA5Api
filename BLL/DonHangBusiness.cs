using BLL.Interfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public class DonHangBusiness:IDonHangBusiness
    {
         private IDonHangRepository isp;
        private IKhachHangRepository isp2;
        public DonHangBusiness(IDonHangRepository isp, IKhachHangRepository isp2)
        {
            this.isp = isp;
            this.isp2 = isp2;
        }
        public List<DonHangModel> GetOdersByShop(string mashop, int pageIndex, int pageSize, out long total)
        {
            var kq= isp.GetDonHangByShop(mashop, pageIndex,  pageSize, out  total);
            foreach(var item in kq)
            {
                item.Tonggiatri = 0;
                item.TongDonVi = 0;
                item.chitiet = isp.getctbymadonhang(item.MaDH);
                {
                    for (int i = 0; i < item.chitiet.Count; i++)
                    {
                        item.Tonggiatri += item.chitiet[i].DonGia * item.chitiet[i].SoLuong;
                        item.TongDonVi += item.chitiet[i].SoLuong;
                    }
                }
                if (item.MaKH != null) { 
                item.thongtinkh = isp2.getbyid(item.MaKH);}
                else
                {
                    continue;
                }
                if (item.MaDiaChi!=0) {
                item.diachinhanhang = isp2.Getdcbyid(item.MaDiaChi);
                item.diachinhanhang.tttinh = isp2.GetTinh(item.diachinhanhang.Tinh);
                item.diachinhanhang.tthuyen = isp2.GetHuyen(item.diachinhanhang.Huyen);
                item.diachinhanhang.ttxa = isp2.GetXa(item.diachinhanhang.Xa);
                }
                else { item.diachinhanhang.tttinh = isp2.GetTinh(item.Tinh);
                    item.diachinhanhang.ttxa = isp2.GetXa(item.Xa);
                    item.diachinhanhang.tthuyen = isp2.GetHuyen(item.Huyen);
                    item.diachinhanhang.ChiTiet = item.DCChitiet;
                }
            }
            return kq;
        }
        public List<DonHangModel> GetOdersByKH(string makh, int pageIndex, int pageSize, out long total)
        {
            var kq = isp.GetDonHangByKhachHang(makh, pageIndex, pageSize, out total);
            foreach (var item in kq)
            {
                item.Tonggiatri = 0;
                item.TongDonVi = 0;
                item.chitiet = isp.getctbymadonhang(item.MaDH);
                {
                    for (int i = 0; i < item.chitiet.Count; i++)
                    {
                        item.Tonggiatri += item.chitiet[i].DonGia * item.chitiet[i].SoLuong;
                        item.TongDonVi += item.chitiet[i].SoLuong;
                    }
                }
                if (item.MaKH != null)
                {
                    item.thongtinkh = isp2.getbyid(item.MaKH);
                }
                else
                {
                    continue;
                }
                if (item.MaDiaChi != 0)
                {
                    item.diachinhanhang = isp2.Getdcbyid(item.MaDiaChi);
                    item.diachinhanhang.tttinh = isp2.GetTinh(item.diachinhanhang.Tinh);
                    item.diachinhanhang.tthuyen = isp2.GetHuyen(item.diachinhanhang.Huyen);
                    item.diachinhanhang.ttxa = isp2.GetXa(item.diachinhanhang.Xa);
                }
                else
                {
                    item.diachinhanhang.tttinh = isp2.GetTinh(item.Tinh);
                    item.diachinhanhang.ttxa = isp2.GetXa(item.Xa);
                    item.diachinhanhang.tthuyen = isp2.GetHuyen(item.Huyen);
                    item.diachinhanhang.ChiTiet = item.DCChitiet;
                }
            }
            return kq;
        }
        public List<DonHangModel> GetOdersByStatus(string mashop,int trangthai,int pageIndex, int pageSize, out long total)
        {
            var kq = isp.GetDonHangByTrangThai(mashop, trangthai,pageIndex, pageSize, out total);
            foreach (var item in kq)
            {

                item.Tonggiatri = 0;
                item.TongDonVi = 0;
                item.chitiet = isp.getctbymadonhang(item.MaDH);
                {
                    for (int i = 0; i < item.chitiet.Count; i++)
                    {
                        item.Tonggiatri += item.chitiet[i].DonGia * item.chitiet[i].SoLuong;
                        item.TongDonVi += item.chitiet[i].SoLuong;
                    }
                }
                if (item.MaKH != null)
                {
                    item.thongtinkh = isp2.getbyid(item.MaKH);
                }
                else
                {
                    continue;
                }
                if (item.MaDiaChi != 0)
                {
                    item.diachinhanhang = isp2.Getdcbyid(item.MaDiaChi);
                    item.diachinhanhang.tttinh = isp2.GetTinh(item.diachinhanhang.Tinh);
                    item.diachinhanhang.tthuyen = isp2.GetHuyen(item.diachinhanhang.Huyen);
                    item.diachinhanhang.ttxa = isp2.GetXa(item.diachinhanhang.Xa);
                }
                else
                {
                    item.diachinhanhang.tttinh = isp2.GetTinh(item.Tinh);
                    item.diachinhanhang.tthuyen = isp2.GetHuyen(item.Huyen);
                    item.diachinhanhang.ttxa = isp2.GetXa(item.Xa);
                    item.diachinhanhang.ChiTiet = item.DCChitiet;
                    
                }
            }
            return kq;
        }
        public DonHangModel GetOdersById(string madon)
        {
            var kq = isp.Getbyid(madon);
            kq.TongDonVi = 0;
            kq.Tonggiatri = 0;
                kq.chitiet = isp.getctbymadonhang(kq.MaDH);
            for (int i = 0; i < kq.chitiet.Count; i++)
            {
                kq.Tonggiatri += kq.chitiet[i].DonGia * kq.chitiet[i].SoLuong;
                kq.TongDonVi += kq.chitiet[i].SoLuong;
            }
            if (kq.MaKH != null)
            {
                kq.thongtinkh = isp2.getbyid(kq.MaKH);
            }
            else
            {
               
            }
            if (kq.MaDiaChi != 0)
            {
                kq.diachinhanhang = isp2.Getdcbyid(kq.MaDiaChi);
                kq.diachinhanhang.tttinh = isp2.GetTinh(kq.diachinhanhang.Tinh);
                kq.diachinhanhang.tthuyen = isp2.GetHuyen(kq.diachinhanhang.Huyen);
                kq.diachinhanhang.ttxa = isp2.GetXa(kq.diachinhanhang.Xa);
            }
            else
            {
                kq.diachinhanhang.tttinh = isp2.GetTinh(kq.Tinh);
                kq.diachinhanhang.tthuyen = isp2.GetHuyen(kq.Huyen);
                kq.diachinhanhang.ttxa = isp2.GetXa(kq.Xa);
                kq.diachinhanhang.ChiTiet = kq.DCChitiet;

            }

            return kq;
        }
        public DonHangModel doitrangthai(string madon)
        {
            return isp.thaydoitrangthaidonhang(madon);
        }
        public DonHangModel huydon(string madon)
        {
            return isp.huydon(madon);
        }
        public List<Provinces> getalltinh()
        {
            return isp.getalltinh();
        }
        public List<Districts> gethuyenbytinh(int matinh)
        {
            return isp.gethuyenbytinh(matinh);
        }
        public List<Wards> getxabyhuyen(int mahuyen)
        {
            return isp.getxabyhuyen(mahuyen);
        }
        public DonHangModel them(DonHangModel dh)
        {

            
            return isp.Them(dh);
        }
    }
}
