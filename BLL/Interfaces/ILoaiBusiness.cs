using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL
{
    interface ILoaiBusiness
    {
        List<LoaiModel> GetLoais();
    }
}
