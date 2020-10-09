using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers.Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLSanPhamController : ControllerBase
    {
        private ISanPhamBusiness isp;
        public QLSanPhamController(ISanPhamBusiness isp)
        {
            this.isp = isp;
        }
        [Route("all")]
        public IEnumerable<SanPhamModel> Getall()
        {
            return isp.all();
        }
    }
}
