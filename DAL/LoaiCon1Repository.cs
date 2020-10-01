using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Linq;
using DAL.Helper;
namespace DAL
{
    public partial class LoaiCon1Repository:ILoaiCon1Repository
    {

        private IDatabaseHelper _dbHelper;
        public LoaiCon1Repository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<LoaiCon1Model> GetLoaiCon()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getloai1");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LoaiCon1Model>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
