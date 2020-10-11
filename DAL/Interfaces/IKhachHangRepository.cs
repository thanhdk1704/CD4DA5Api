using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
   public interface IKhachHangRepository
    {
        List<KhachHangModel> GetKh();
        KhachHangModel getbyid(string id);
        List<DiaChiModel> GeDiachi(string id);
        TaiKhoanModel GetTaiKhoan(string makh);
    }
}
