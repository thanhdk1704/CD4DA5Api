using BLL.Interfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class KhachHangBusiness:IKhachHangBusiness
    {
        private IKhachHangRepository _res;
        public KhachHangBusiness(IKhachHangRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<KhachHangModel> AllCtm()
        {
            return _res.GetKh();
        }
        public List<KhachHangModel> KhwDiaChi()
        {
            var kh = _res.GetKh();
            foreach(var item in kh)
            {
                item.dsdiachi = _res.GeDiachi(item.MaKhachHang);
            }
            return kh;
        }
        public KhachHangModel Cusbyid(string id)
        {
            var kh = _res.getbyid(id);
            kh.dsdiachi = _res.GeDiachi(id);
            return kh;
        }
        public List<DiaChiModel> GetAddress(string id)
        {
            return _res.GeDiachi(id);
        }
        public List<KhachHangModel> Getfulldetails()
        {
            var kh = _res.GetKh();
            foreach (var item in kh)
            {
                item.dsdiachi = _res.GeDiachi(item.MaKhachHang);
                item.tk = _res.GetTaiKhoan(item.MaKhachHang);
            }
            return kh;
        }
    }
}
