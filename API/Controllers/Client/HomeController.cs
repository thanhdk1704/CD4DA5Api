using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private ILoaiBusiness loai;
        public HomeController(ILoaiBusiness loaibsn)
        {
            this.loai = loaibsn;
        }
        [Route("all")]
        [HttpGet]
        public IEnumerable<LoaiModel> GetAllMenu()
        {
            return loai.GetLoais();
        }
        [Route("loai1")]
        [HttpGet]
        public IEnumerable<LoaiCon1Model> GetAllLoai1()
        {
            return loai.GetLoai1();
        }
        [Route("loai2")]
        [HttpGet]
        public IEnumerable<LoaiCon2Model> GetAllLoai2()
        {
            return loai.GetLoai2();
        }
        [Route("loai1/by-loai/{id}")]
        [HttpGet]
        public IEnumerable<LoaiCon1Model> GetLoai1bycha(int id)
        {
            return loai.GetLoai1theoloai(id);
        }
        [Route("loai2/by-loai1/{id}")]
        [HttpGet]
        public IEnumerable<LoaiCon2Model> GetLoai2byl1(string id)
        {
            return loai.GetLoai2theoloai(id);
        }
    }
}
