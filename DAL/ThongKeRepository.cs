using DAL.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL.Interfaces;
using System.Linq;

namespace DAL
{
    public partial class ThongKeRepository : IThongKeRepository
    {
        private IDatabaseHelper _dbHelper;
        public ThongKeRepository(IDatabaseHelper _dbHelper)
        {
            this._dbHelper = _dbHelper;
        }
        public ThongKeModel TongQuanThang(string mashop, int thang)
        {
            var kq = new ThongKeModel();
            kq.totalValue = 0;
            kq.totalAmount = 0;
            /* kq: 0 is amount, 1 is income,
             * 2 is total orders that paid,3 is total orders that return
            */
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "doanhthutheoshoptheothang", "@mashop", mashop, "@thang", thang);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0 && dt.Rows[0]["DoanhThu"] != DBNull.Value) kq.totalValue = (int)dt.Rows[0]["DoanhThu"];
                if (dt.Rows.Count > 0 && dt.Rows[0]["DonVi"] != DBNull.Value) kq.totalAmount = (int)dt.Rows[0]["DonVi"];
                if (dt.Rows.Count > 0 && dt.Rows[0]["Orders"] != null) kq.totalOrders = (int)dt.Rows[0]["Orders"];
                return kq;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public int doanhthutheoloaitheothang(string mashop, int maloai, int thang, out int doanhthu)
        {
            doanhthu = 0;
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "doanhthutheoloaitheothang", "@mashop", mashop, "@thang", thang, "@maloai", maloai);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0 && dt.Rows[0]["DoanhThu"] != null) doanhthu = (int)dt.Rows[0]["DoanhThu"];
                return doanhthu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanPhamModel> Spbanchay(string mashop, int thang)
        {
            string msgError = "";
            
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "spbanchaytheoshoptheothang", "@mashop", mashop,"@thang",thang);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
              
                var kq= dt.ConvertTo<SanPhamModel>().ToList();
                foreach(var item in kq) { }
                return kq;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanPhamModel> Sphethang(string mashop)
        {
            string msgError = "";
            
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sphethangbyshop", "@mashop", mashop);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                var kq = dt.ConvertTo<SanPhamModel>().ToList();
                foreach (var item in kq) { }
                return kq;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
