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
        public List<KhachHangModel> getallkhach()
        {
            return item.AllCtm();
        }
        [Route("khach-hang/{id}")]
        [HttpGet]
        public KhachHangModel getkhachbyid(string id)
        {
            return item.Cusbyid(id);
        }
        [Route("khach-hang/dia-chi/{id}")]
        [HttpGet]
        public List<DiaChiModel> Diachibykh(string id)
        {
            return item.GetAddress(id);
        }
        [Route("khach-hang/dia-chi")]
        [HttpGet]
        public List<KhachHangModel>KhWDiaChi()
        {
            return item.KhwDiaChi();
        }
        [Route("khach-hang/full")]
        public List<KhachHangModel> Getfull()
        {
            return item.Getfulldetails();
        }
    }
}
