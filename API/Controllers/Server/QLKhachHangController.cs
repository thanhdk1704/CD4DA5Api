﻿using System;
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
        [Route("{index}/{size}")]
        [HttpGet]
        public ResponseModel getallkhach(int index,int size)
        {
            long total = 0;
            var kq = new ResponseModel();
            kq.Data= item.GetKh(index, size,out total);
            kq.TotalItems = total;
            return kq;
        }
        [Route("{id}")]
        [HttpGet]
        public KhachHangModel getkhachbyid(string id)
        {
            return item.Cusbyid(id);
        }
        [Route("dia-chi/{id}")]
        [HttpGet]
        public List<DiaChiModel> Diachibykh(string id)
        {
            return item.GetAddress(id);
        }
        [Route("dia-chi/{index}/{size}")]
        [HttpGet]
        public ResponseModel KhWDiaChi(int index, int size)
        {
            long total = 0;
            var kq = new ResponseModel();
            kq.Data = item.KhwDiaChi(index,size,out total);
            kq.TotalItems = total;
            return kq;
        }
        [Route("full/{index}/{size}")]
        public ResponseModel Getfull(int index, int size)
        {

            long total = 0;
            var kq = new ResponseModel();
            kq.Data = item.Getfulldetails(index, size, out total);
            kq.TotalItems = total;
            return kq;
        }
        [Route("them-dc")]
        [HttpPost]
        public DiaChiModel themdiachi(DiaChiModel dc) {
            DiaChiModel dcmoi = new DiaChiModel();
            dcmoi = item.ThemDiaChi(dc);
            return dcmoi;
        }
    }
}
