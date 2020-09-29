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
    public class LoaiCon1Controller : ControllerBase
    {
            private ILoaiCon1Business i1b;
            public LoaiCon1Controller(ILoaiCon1Business t) 
        {
            i1b = t;
        }
        [Route("get-loai-1")]
        public List<LoaiCon1Model> GetLoaiCon()
        {
            return i1b.GetLoaiCon();
        }
    }
}

