using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBusiness.DTO
{
    public class EngellilerDTO
    {
        public int EngelliID { get; set; }
        public string EngelliAd { get; set; }

        public override string ToString()
        {
            return "" + EngelliAd;
        }
    }
}
