using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ISanPhamRepository
    {
        public List<SanPhamModel> GetSanPhams();
        dynamic Getspbyshop(string mashop);
        List<KhoModel> GetKho();
        List<KhoModel> GetGiaBan();
    }
}
