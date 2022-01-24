using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEBusiness.DMişlemleri
{
    public interface IDMatma
    {
        void DmOlayıBaşlat(string AtılcakMesaj,int KullanıcıId);

        void GönderiYorumBaşlat(string AtılcakMesaj, int KullanıcıId,string RakipAd,int PostSayı);
        void HashtagYorumBaşlat(string AtılcakMesaj, int KullanıcıId,string HashtagAd,int PostSayı);

        void LinkYorumBaşlat(string AtılcakMesaj, int KullanıcıId, string Link);

    }
}
