using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface NhaCungCapRepository:INhaCungCapRepository
    {
        public List<NhaCungCapModel> GetDonHang()
        {
            return null;
        }
    }
}
