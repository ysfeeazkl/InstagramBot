using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBusiness.DTO
{
    public class SözcüklerDTO
    {
        public int SözcükID { get; set; }
        public string SözcükAd { get; set; }

        public override string ToString()
        {
            return "" + SözcükAd;
        }
    }
}
