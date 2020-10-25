using BLL.Interfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public class DonHangBusiness:IDonHangBusiness
    {
         private IDonHangRepository isp;
        public DonHangBusiness(IDonHangRepository isp)
        {
            this.isp = isp;
        }
        public List<DonHangModel> GetOdersByShop(string mashop, int pageIndex, int pageSize, out long total)
        {
            var kq= isp.GetDonHangByShop(mashop, pageIndex,  pageSize, out  total);
            foreach(var item in kq)
            {
                item.chitiet = isp.getctbymadonhang(item.MaDH);
            }
            return kq;
        } 
    }
}
