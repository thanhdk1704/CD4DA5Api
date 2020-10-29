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
                item.chitiet = isp.getctbymadonhang(item.MaDH);
                item.thongtinkh = isp2.getbyid(item.MaKH);
                item.diachinhanhang = isp2.Getdcbyid(item.MaDiaChi);
                item.diachinhanhang.tttinh = isp2.GetTinh(item.diachinhanhang.Tinh);
                item.diachinhanhang.tthuyen = isp2.GetHuyen(item.diachinhanhang.Huyen);
                item.diachinhanhang.ttxa = isp2.GetXa(item.diachinhanhang.Xa);
            }
            return kq;
        }
        public DonHangModel GetOdersById(string madon)
        {
            var kq = isp.Getbyid(madon);
            
                kq.chitiet = isp.getctbymadonhang(kq.MaDH);
                kq.thongtinkh = isp2.getbyid(kq.MaKH);
                kq.diachinhanhang = isp2.Getdcbyid(kq.MaDiaChi);
            kq.diachinhanhang.tttinh = isp2.GetTinh(kq.diachinhanhang.Tinh);
            kq.diachinhanhang.tthuyen = isp2.GetHuyen(kq.diachinhanhang.Huyen);
            kq.diachinhanhang.ttxa = isp2.GetXa(kq.diachinhanhang.Xa);

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
    }
}
