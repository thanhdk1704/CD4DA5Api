using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ILoaiRepository
    {
        bool Create(LoaiModel model);
        List<LoaiModel> GetDataAll();
    }
}
