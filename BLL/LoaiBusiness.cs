using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
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
        public List<LoaiCon1Model> GetLoai1()
        {
            var loais = _res.GetLoai1();

            return loais;
        }
        public List<LoaiCon1Model> GetLoai1theoloai(int id)
        {
            var loais = _res.getloai1byloai(id);

            return loais;
        }
        public List<LoaiCon2Model> GetLoai2()
        {
            var loais = _res.GetLoai2();

            return loais;
        }
        public List<LoaiCon2Model> GetLoai2theoloai(string id)
        {
            var loais = _res.getbyloai1(id);

            return loais;
        }
    }
}
