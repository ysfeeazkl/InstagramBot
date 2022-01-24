using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEBusiness
{
    public interface ITakipciCekme
    {
        List<String> TakipciCekmeOlayı(string RakipAd, int ÇekilecekSayı, int KullanıcıId,bool KaralisteFiltre);
        List<String> GönderidenTakipçiÇekme(string RakipAd, int KullanıcıId,bool KaralisteFiltre,int ÇekilecekSayı);
        List<String> HashtagDenTakipçiÇekme(string Hashtag, int KullanıcıId,bool KaralisteFiltre, int ÇekilecekSayı);
        
    }
}
