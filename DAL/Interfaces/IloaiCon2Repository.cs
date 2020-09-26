using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace DAL.Interfaces
{
    public partial interface IloaiCon2Repository
    {
        bool Create(ItemModel model);
        List<LoaiCon2Model> GetDataAll();
    }
}
