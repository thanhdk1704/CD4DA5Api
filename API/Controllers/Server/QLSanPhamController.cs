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

        [Route("detail/{link}")]
        public SanPhamModel Chitietsanpham(string link)
        {
            return isp.Chitietsanpham(link); ;
        }
        [Route("all-by-shop/{id}")]
        public dynamic getspbyshop(string id)
        {
            return isp.getspbyshop(id);
        }
        [Route("all-with-details")]
        public List<SanPhamModel> getfulldetails()
        {
            return isp.getspwithfulldetail();
        }

        [Route("all-pagedlist")]
        public ResponseModel Phantrang([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                long total = 0;
                var data = isp.phantrang(page, pageSize, out total);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
        [Route("all-in-loai-2/{id}")]
        public IEnumerable<SanPhamModel> SanPhamtheoloaicon2(string id)
        {
            return isp.SanphamtheoLoaiCon2(id);
        }
        [Route("{min}/{max}")]
        public IEnumerable<SanPhamModel> SanPhamtheoKhoangGia(int min, int max) {
            return isp.SPtheoKhoangGia(min, max);
        }
        [Route("tuong-tu/{id}")]
        public IEnumerable<SanPhamModel> TuongTu(string id)
        {
            return isp.SPtuongtu(id);
        }
    }
}
