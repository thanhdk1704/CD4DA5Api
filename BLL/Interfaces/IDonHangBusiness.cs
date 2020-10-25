using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IDonHangBusiness
    {
        List<DonHangModel> GetOdersByShop(string mashop, int pageIndex, int pageSize, out long total);
    }
}
