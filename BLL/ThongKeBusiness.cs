using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class ThongKeBusiness:IThongKeBusiness
    {
        private ILoaiRepository l;
        private ISanPhamRepository sp;
        private IThongKeRepository tk;
        private IDonHangRepository dh;
        private IHoaDonNhapReopository hdn;
        private IKhachHangRepository kh;
        

        public ThongKeBusiness(ILoaiRepository l, ISanPhamRepository sp, IThongKeRepository tk,IDonHangRepository dh, IHoaDonNhapReopository hdn, IKhachHangRepository kh)
        {
            this.l = l;
            this.sp = sp;
            this.tk = tk;
            this.dh = dh;
            this.hdn = hdn;
            this.kh = kh;
        }
        public ThongKeModel ThongkeThang(string mashop,int thang, out int doanhthu)
        {doanhthu = 0;
            var kq = new ThongKeModel();
            kq = tk.TongQuanThang(mashop,thang);
            kq.incomebycates = l.GetDataAll();
            kq.sphethang = tk.Sphethang(mashop);
            kq.spbanchay = tk.Spbanchay(mashop, thang);
            kq.dsdh = tk.donhangtheothang(mashop,thang);
            kq.dshdn = tk.phieunhaptheothang(mashop, thang);
            foreach(var item in kq.spbanchay)
            {
                item.dsgiaban = sp.GetGiaBans(item.MaSanPham);
                item.giahientai = sp.Getgiahientai(item.MaSanPham);
                item.kho = sp.Getkhobysp(item.MaSanPham);
                item.danhmuc = sp.getloaibySanPham(item.MaSanPham);
                item.loaicon1 = sp.getloai1bySanPham(item.MaSanPham);
                item.loaicon2 = sp.getloai2bySanPham(item.MaSanPham);
            }
            foreach (var item in kq.sphethang)
            {
                item.dsgiaban = sp.GetGiaBans(item.MaSanPham);
                item.giahientai = sp.Getgiahientai(item.MaSanPham);
                item.kho = sp.Getkhobysp(item.MaSanPham);
                item.danhmuc = sp.getloaibySanPham(item.MaSanPham);
                item.loaicon1 = sp.getloai1bySanPham(item.MaSanPham);
                item.loaicon2 = sp.getloai2bySanPham(item.MaSanPham);
            }
            foreach(var item in kq.dsdh)
            {
                item.Tonggiatri = 0;
                item.TongDonVi = 0;
                item.chitiet = dh.getctbymadonhang(item.MaDH);
                for (int i = 0; i < item.chitiet.Count; i++)
                {
                    item.Tonggiatri += item.chitiet[i].DonGia * item.chitiet[i].SoLuong;
                    item.TongDonVi += item.chitiet[i].SoLuong;
                }
                item.thongtinkh = kh.getbyid(item.MaKH);
                item.diachinhanhang = kh.Getdcbyid(item.MaDiaChi);
                item.diachinhanhang.tttinh = kh.GetTinh(item.diachinhanhang.Tinh);
                item.diachinhanhang.tthuyen = kh.GetHuyen(item.diachinhanhang.Huyen);
                item.diachinhanhang.ttxa = kh.GetXa(item.diachinhanhang.Xa);
            }
            foreach(var item in kq.dshdn)
            {
                item.Tongdonvi=0;
                item.Tongchiphi=0;
                item.chitiet = hdn.GetCtHDN(item.MaHDN);
                      for (int i = 0; i < item.chitiet.Count; i++)
                {
                    item.Tongdonvi += item.chitiet[i].Soluong;
                    item.Tongchiphi += item.chitiet[i].Soluong * item.chitiet[i].DonGia;
                }
            }
            foreach (var i in kq.incomebycates)
            {
                
                i.income = tk.doanhthutheoloaitheothang(mashop, i.MaLoai, thang, out doanhthu);
            }
            return kq;
        }
    }
}
