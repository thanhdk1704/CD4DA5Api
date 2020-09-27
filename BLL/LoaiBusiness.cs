using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
using DAL.Interfaces;
namespace BLL
{
    public partial class LoaiBusiness : ILoaiBusiness
    {
        private ILoaiRepository _res;
        public LoaiBusiness(ILoaiRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }

        public List<LoaiModel> GetLoais()
        {
            var loais = _res.GetDataAll();
           
            return loais;
        }
    }
}
