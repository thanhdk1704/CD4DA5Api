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
    public class QLKhachHangController : ControllerBase
    {
        private IKhachHangBusiness item;
        public QLKhachHangController(IKhachHangBusiness items)
        {
            item = items;
        }
        [Route("khach-hang")]
        [HttpGet]
        public List<KhachHangModel> allkhach()
        {
            return item.AllCtm();
        }
    }
}
