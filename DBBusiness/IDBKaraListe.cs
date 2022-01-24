using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBusiness
{
    public interface IDBKaraListe
    {
        List<String> HesapAdAyrıştırma();
        List<String> HesapYorumAyrıştırma(List<string> HesapAdlar,List<string> Yorumlar);

        void KaralisteAyırma(string rakipad);
        void HashtagKaralisteAyırma();
    }
}
