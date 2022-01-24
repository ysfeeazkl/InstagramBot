using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBusiness.DTO
{
    public class KullanıcılarDTO
    {
        public int KullanıcıID { get; set; }
        public string KullanıcıAd { get; set; }
        public string KullanıcıŞifre { get; set; }

        public override string ToString()
        {
            return "" + KullanıcıAd;
        }
    }
}
