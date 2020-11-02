using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class ThongKeBusiness:IThongKeBusiness
    {
        private ILoaiRepository l;
        private ISanPhamRepository sp;
        private IThongKeRepository tk;
        

        public ThongKeBusiness(ILoaiRepository l, ISanPhamRepository sp, IThongKeRepository tk,IDonHangRepository dh)
        {
            this.l = l;
            this.sp = sp;
            this.tk = tk;
           
        }
        public ThongKeModel ThongkeThang(string mashop,int thang, out int doanhthu)
        {doanhthu = 0;
            var kq = new ThongKeModel();
            kq = tk.TongQuanThang(mashop,thang);
            kq.incomebycates = l.GetDataAll();
            kq.sphethang = tk.Sphethang(mashop);
            kq.spbanchay = tk.Spbanchay(mashop, thang);
           
            foreach(var i in kq.incomebycates)
            {
                
                i.income = tk.doanhthutheoloaitheothang(mashop, i.MaLoai, thang, out doanhthu);
            }
            return kq;
        }
    }
}
