using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public partial interface IKhachHangBusiness
    {

        public List<KhachHangModel> AllCtm();
        public List<KhachHangModel> Cusbyid(string id);
        public List<DiaChiModel> GetAddress(string id);
    }
}
