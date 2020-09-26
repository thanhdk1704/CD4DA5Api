using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL.Interfaces
{
   public interface IKhachHangRepository
    {
        List<KhachHangModel> GetAll();
    }
}
