using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class LoaiModel
    {
        public int MaLoai { get; set; }

        public string TenLoai { get; set; }

        public string MoTa { get; set; }

        public string GhiChu { get; set; }

        public string Link { get; set; }

        public int? Removed { get; set; }

        public int? Displayed { get; set; }
    }
}
