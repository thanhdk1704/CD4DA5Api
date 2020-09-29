using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
using DAL.Interfaces;
namespace BLL
{
    public partial interface ILoaiCon1Business
    {
        List<LoaiCon1Model> GetLoaiCon();
    }
}
