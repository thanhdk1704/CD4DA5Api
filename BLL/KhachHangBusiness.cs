using BLL.Interfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
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
        public List<KhachHangModel> Cusbyid(string id)
        {
            return _res.getbyid(id);
        }
        public List<DiaChiModel> GetAddress(string id)
        {
            return _res.GeDiachi(id);
        }

    }
}
