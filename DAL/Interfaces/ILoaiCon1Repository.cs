using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public partial interface ILoaiCon1Repository
    {
        bool Create(ItemModel model);
        List<LoaiCon1Model> GetDataAll();
    }
}
