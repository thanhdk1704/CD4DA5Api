using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public partial interface IDonHangRepository
    {
        List<DonHangModel> GetDonHangByShop(string mashop, int page_index, int page_size, out long total);
        List<ChiTietDonHangModel> getctbymadonhang(string madon);
    }
}
