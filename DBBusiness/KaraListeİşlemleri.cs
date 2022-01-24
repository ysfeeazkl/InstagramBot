using SolidİnstaDeneme2;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBusiness
{
    public class KaraListeİşlemleri : IDBKaraListe
    {
        IDBişlemleri servis = new Veritabanİşlemler();
        Baglanti baglanti = new Baglanti();


        public void HashtagKaralisteAyırma()
        {
            var KaraListedekiler = servis.EngellenenKullanıcılar();

            for (int i = 0; i < KaraListedekiler.Count; i++)
            {
                servis.delete($"delete from HesapBilgileri where HesapAd = '{KaraListedekiler[i]}'");
            }
        }
        public void KaralisteAyırma(string rakipad)
        {
            var KaraListedekiler = servis.EngellenenKullanıcılar();

            for (int i = 0; i < KaraListedekiler.Count; i++)
            {
                if (KaraListedekiler[i] != rakipad)
                {
                    servis.delete($"delete from HesapBilgileri where HesapAd = '{KaraListedekiler[i]}'");
                }        
            }
            
        }

        public List<string> HesapAdAyrıştırma() //hesap adına göre Kara listeye alma bunun tablosu yapılcak
        {
            List<string> Argocular = new List<string>();
            var argoKelimeler = servis.Argolar();


            for (int i = 0; i < argoKelimeler.Count; i++)
            {           
                SqlCommand komut = new SqlCommand($"select HesapAd from HesapBilgileri where HesapAd like '%{argoKelimeler[i]}%'", baglanti.BaglantiAc());
                SqlDataReader read = komut.ExecuteReader();
                while (read.Read())
                {
                    Argocular.Add(read["HesapAd"].ToString());
                }
                baglanti.BaglantiKapa();
            }



            int sayaç = 0;
            for (int i = 0; i < Argocular.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (Argocular[i] == Argocular[j])
                    {
                        sayaç++;
                    }
                }
                if (sayaç == 0)
                {
                    servis.insert($"insert into EngelliTablosu (EngelliAd) values ('{Argocular[i]}')");
                }
                sayaç = 0;
            }

            var EngelliKullanıcılar = servis.EngellenenKullanıcılar();

            return EngelliKullanıcılar;
        }

        public List<string> HesapYorumAyrıştırma(List<string> HesapAdlar, List<string> Yorumlar) //yoruma göre karalisteye alma
        {
            List<string> Argocular = new List<string>();
            var argoKelimeler = servis.Argolar();

            for (int i = 0; i < Yorumlar.Count; i++)
            {
                for (int j = 0; j < argoKelimeler.Count; j++)
                {
                    if (Yorumlar[i].Contains($"{argoKelimeler[j]}"))
                    {
                        Argocular.Add("" + HesapAdlar[i]);
                    }

                }

            }

            int sayaç = 0;
            for (int i = 0; i < Argocular.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (Argocular[i] == Argocular[j])
                    {
                        sayaç++;
                    }
                }
                if (sayaç == 0)
                {
                    servis.insert($"insert into EngelliTablosu (EngelliAd) values ('{Argocular[i]}')");
                }
                sayaç = 0;
            }

            return null;
        }

      
    }
}
