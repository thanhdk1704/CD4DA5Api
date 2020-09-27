using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using Model;

namespace API.Controllers.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private ILoaiBusiness loai;
        public LoaiController(ILoaiBusiness loaibsn)
        {
            loai = loaibsn;
        }
        [Route("get-loai")]
        [HttpGet]
        public IEnumerable<LoaiModel> GetAllMenu()
        {
            return loai.GetLoais();
        }
    }
}
