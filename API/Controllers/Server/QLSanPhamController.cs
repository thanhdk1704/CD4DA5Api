using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace API.Controllers.Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLSanPhamController : ControllerBase
    {
        private ISanPhamBusiness isp;
        private string _path;
        public QLSanPhamController(ISanPhamBusiness isp, IConfiguration configuration)
        {
            this.isp = isp;
            _path = configuration["AppSettings:PATH"];
        }
        public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        {
            try
            {
                string result = "";
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        {
            if (dataFromBase64String.Contains("base64,"))
            {
                dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
            }
            return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        }
        [Route("all")]
        public IEnumerable<SanPhamModel> Getall(int pageIndex, int pageSize, out long total)
        {
            return isp.all( pageIndex,  pageSize, out  total);
        }
        [Route("ban-chay/{mashop}/{thang}")]
        public IEnumerable<SanPhamModel> GetBanChay(string mashop, int thang)
        {
            return isp.getspbanchay(mashop,thang);
        }
        [Route("detail/{link}")]
        public SanPhamModel Chitietsanpham(string link)
        {
            
            return isp.Chitietsanpham(link); ;
        }
        [Route("all-by-shop/{link}/{pageIndex}/{pageSize}")]
        public ResponseModel getspbyshop(string link,int pageIndex, int pageSize)
        {
            long total;
            var response = new ResponseModel();
            response.Page = pageIndex;
            response.PageSize = pageSize;
            response.Data= isp.getspbyshop(link,pageIndex,pageSize,out total);
            response.TotalItems = total;
            return response;
        }
        [Route("all-with-details/{pageIndex}/{pageSize}")]
        public List<SanPhamModel> getfulldetails(int pageIndex, int pageSize)
        {
            long total =0;
            var kq= isp.getspwithfulldetail( pageIndex,  pageSize, out  total);
            foreach (var item in kq) item.Total = total;
            return kq;
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
        public SanPhamModel create( string MaLoai2, string TenSanPham,
                            string MoTa,
                           string GhiChu,
                           string Link,
                           string Anh,
                            string MaShop,
                            int SoLuong,
                              int GiaNhap,
                                    int Gia)
        {
          
            SanPhamModel spmoi = new SanPhamModel();
            KhoModel kho = new KhoModel();
            GiaBanModel gbmoi = new GiaBanModel();
            spmoi.MaLoai2 = MaLoai2;
            spmoi.TenSanPham = TenSanPham;
            spmoi.MoTa = MoTa;
            spmoi.GhiChu = GhiChu;
            spmoi.Link = Link;
            spmoi.Anh = Anh;
            kho.MaShop = MaShop;
            kho.SoLuong = SoLuong;
            
            kho.GiaNhap = GiaNhap;
            gbmoi.Gia = Gia;
            var newpro = isp.Create(spmoi, gbmoi, kho);

            return newpro;

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
