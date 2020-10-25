using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using BLL.Interfaces;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers.Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLDonHangController : ControllerBase
    {
        private IDonHangRepository isp;
        public QLDonHangController(IDonHangRepository isp)
        {
            this.isp = isp;
        }
        [Route("getbyshop/{mashop}/{pageIndex}/{pageSize}")]
        public ResponseModel GetOdersbyShop(string mashop,int pageIndex, int pageSize)
        {
            long total = 0;

            var orders = new ResponseModel();
            orders.Page = pageIndex;
            orders.PageSize = pageSize;
            orders.Data = isp.GetDonHangByShop(mashop, pageIndex, pageSize,out total);
            orders.TotalItems = total;
            return orders;
            

        }
    }
}
