using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public partial interface ISanPhamBusiness
    {
        List<SanPhamModel> all();
    }
}
