using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class ThongKeModel
    {
        public int totalamount { get; set; }
        public int totalvalue { get; set; }
        public List<SanPhamModel> spbanchay { get; set; }
    }
}
