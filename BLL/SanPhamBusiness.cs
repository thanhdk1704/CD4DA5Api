using BLL.Interfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class SanPhamBusiness:ISanPhamBusiness
    {
        private ISanPhamRepository isp;
        public SanPhamBusiness(ISanPhamRepository isp)
        {
            this.isp = isp;
        }
        public List<SanPhamModel> all()
        {
            return isp.GetSanPhams();
        }
        public dynamic getspbyshop(string mashop) 
        { 
            return isp.Getspbyshop(mashop); 
        }
    }
}
