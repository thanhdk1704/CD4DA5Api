using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DonHangRepository:IDonHangRepository
    {

        private IDatabaseHelper _dbHelper;
        public DonHangRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<DonHangModel> GetDonHangByShop(string mashop, int page_index, int page_size, out long total)
        {
            total = 0;
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getdhbyshop", "@mashop",mashop, "@page_index", page_index, "@page_size", page_size);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<DonHangModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DonHangModel Getbyid(string madon)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getdonhangbyid", "@madh", madon);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DonHangModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ChiTietDonHangModel> getctbymadonhang(string madon)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getchitietdonhang", "@madh", madon);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ChiTietDonHangModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Provinces> getalltinh()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getallTinh");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Provinces>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DonHangModel thaydoitrangthaidonhang(string madon)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "doittdonhang", "@madh", madon);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DonHangModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DonHangModel huydon(string madon)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "HuyDon", "@madh", madon);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DonHangModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Districts> gethuyenbytinh(int matinh) 
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "gethuyenbytinh", "@matinh", matinh);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Districts>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Wards> getxabyhuyen(int mahuyen)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getxabyhuyen", "@mahuyen", mahuyen);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Wards>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
