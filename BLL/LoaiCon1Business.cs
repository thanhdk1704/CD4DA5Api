using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public partial class LoaiCon1Business:ILoaiCon1Business
    {
        private ILoaiCon1Repository ires;
        public LoaiCon1Business(ILoaiCon1Repository res)
        {
            ires = res;
        }
        public List<LoaiCon1Model> GetLoaiCon()
        {
            return ires.GetLoaiCon();
        }
    }
}
