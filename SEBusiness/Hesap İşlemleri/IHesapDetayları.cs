using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEBusiness.Hesap_İşlemleri
{
    public interface IHesapDetayları
    {
        List<String> RakipDetayları(string RakipAd,int KullanıcıId);
    }
}
