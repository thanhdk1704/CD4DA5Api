using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public partial interface SanPhamRepository:ISanPhamRepository
    {
        public List<SanPhamModel> GetSanPhams()
        {
            return null;
        }
    }
}
