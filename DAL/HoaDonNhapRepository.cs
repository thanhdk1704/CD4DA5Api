﻿using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class HoaDonNhapRepository:IHoaDonNhapReopository
    {
        private IDatabaseHelper _dbHelper;
        public HoaDonNhapRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<HoaDonNhapModel> GetHDNbyShop(string mashop,int page_index, int page_size, out long total)
        {
            total = 0;
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "gethdnbyshop", "@mashop", mashop,"@page_index", page_index, "@page_size", page_size);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<HoaDonNhapModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public HoaDonNhapModel GetHDNbyID(string mahdn)
        {
            
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "gethdnbyid", "@mahdn", mahdn);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
             
                return dt.ConvertTo<HoaDonNhapModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ChiTietHoaDonNhapModel> GetCtHDN(string mahdn)
        {
            
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getchthdn", "@mahdn", mahdn);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                
                return dt.ConvertTo<ChiTietHoaDonNhapModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
