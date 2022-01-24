using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBusiness.DTO
{
    public class HesaplarDTO //tabloların özelliklerini giriyoz
    {
        public int HesapID { get; set; }
        public string HesapAd { get; set; }
       

        public override string ToString()
        {
            return "" + HesapAd;
        }
    }
}
