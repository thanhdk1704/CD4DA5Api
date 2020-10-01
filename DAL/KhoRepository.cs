using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface KhoRepository:IKhoRepository
    {
        public List<KhoModel> GetDonHang()
        {
            return null;
        }
    }
}
