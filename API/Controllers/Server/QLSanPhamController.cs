using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
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
        [Route("all-in-loai-2/{pageIndex}/{pageSize}/{link}")]
        public IEnumerable<SanPhamModel> SanPhamtheoloaicon2(int pageIndex,int pageSize,string link)
        {
            long total = 0;
            var kq= isp.SanphamtheoLoaiCon2(pageIndex,pageSize,link,out total);
            foreach(var item in kq)
            {
                item.Total = total;
            }
            return kq;
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
        [Route("all-in-loai-1/{id}")]
        public IEnumerable<SanPhamModel> GetByloai1(string id)
        {
            return isp.spbyloai1(id);
        }
        [Route("all-in-loai/{pageIndex}/{pageSize}/{link}")]
        public IEnumerable<SanPhamModel> GetByloai(int pageIndex,int pageSize, string link)
        {
            long total = 0;
            var kq = isp.spbyloai(pageIndex, pageSize, link, out total);
            foreach (var item in kq)
            {
                item.Total = total;
            }
            return kq;
        }
        [Route("get-by-shop/{index}/{size}/{link}")]
        public IEnumerable<SanPhamModel> getspbyshop(int? index, int? size, string link)
        {
            long total=9;
            index = (index < 1 || index == null) ? 1 : index;
            size = (index < 1 || index == null) ? 10 : size;
            return isp.Getspbyshop(index.Value, size.Value, link, out total);
        }
        [Route("them")]
        [HttpPost]
        public int create(SanPhamModel spmoi,string MaShop,int SLKho,int GiaNhap,int GiaBan)
        {
            if (GiaNhap > GiaBan) { 
            var newpro= isp.Create(spmoi);
            var sto = isp.ThemKho(spmoi.MaSanPham, MaShop, SLKho, GiaNhap);
            var price = isp.ThemGiaBan(spmoi.MaSanPham, GiaBan);
            if (newpro == null || newpro.ToArray() == null) return -1;
            if (sto == null || sto.ToArray() == null) return -2;
            if (price == null || price.ToArray() == null) return -3;
            return 1;}
            else return 0;

        }
        [Route("update")]
        [HttpPut]
        public void sua(string masp)
        {

        }
        [Route("xoa/{id}")]
        [HttpGet]
        public int delete(string id)
        {
            return isp.delete(id);
        }
    }
}
