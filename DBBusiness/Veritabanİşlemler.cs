using DBBusiness.DTO;
using SolidİnstaDeneme2;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBusiness
{
    public class Veritabanİşlemler : IDBişlemleri //buraya IDBişlemleri  i implament ediyoz metotlar geliyor içini dolduruyoz 
    {
        
        Baglanti baglanti = new Baglanti();
        Command cmd = new Command();

        public List<string> HesapAdları()
        {
            List<string> hesapAdları = new List<string>();

            SqlCommand komut = new SqlCommand($"select HesapAd from HesapBilgileri", baglanti.BaglantiAc());
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                hesapAdları.Add(read["HesapAd"].ToString());
            }
            baglanti.BaglantiKapa();
            return hesapAdları;
        }

        public List<string> Argolar()
        {
            List<string> Argolar = new List<string>();

            SqlCommand komut = new SqlCommand($"select SözcükAd from YasaklıSözcükler", baglanti.BaglantiAc());
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                Argolar.Add(read["SözcükAd"].ToString());
            }
            baglanti.BaglantiKapa();
            return Argolar;
        }

        public List<string> EngellenenKullanıcılar()
        {
            List<string> Engellenenler = new List<string>();

            SqlCommand komut = new SqlCommand($"select EngelliAd from EngelliTablosu", baglanti.BaglantiAc());
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                Engellenenler.Add(read["EngelliAd"].ToString());
            }
            baglanti.BaglantiKapa();
            return Engellenenler;
        }

        public List<string> FWtakipciÇekme(bool Filtre)
        {
            List<string> followEdilcekler = new List<string>();

            SqlCommand komut = new SqlCommand($"select HesapAd from HesapBilgileri where TakipDurum = '{Filtre}'", baglanti.BaglantiAc());
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                followEdilcekler.Add(read["HesapAd"].ToString());
            }
            baglanti.BaglantiKapa();
            return followEdilcekler;
        }

        public List<string> KullanıcıBilgisi(int KullanıcıId)
        {
            List<string> kullanıcıbilgisi = new List<string>();
         
            SqlCommand komut = new SqlCommand($"Select KullanıcıAd,KullanıcıŞifre From KullanıcıBilgileri where KullanıcıID = {KullanıcıId}", baglanti.BaglantiAc()); //burada kullanıcının adını şifresini çekiyom diziye atıyom
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                kullanıcıbilgisi.Add(read["KullanıcıAd"].ToString());
                kullanıcıbilgisi.Add(read["KullanıcıŞifre"].ToString());
            }
            baglanti.BaglantiKapa();

            return kullanıcıbilgisi;
        }

        public void delete(string SqlCümlesi)
        {
            SqlCommand tsqlKomut = cmd.komut(SqlCümlesi);
            tsqlKomut.ExecuteNonQuery();
            baglanti.BaglantiKapa();
        }

        public void insert(string SqlCümlesi)
        {
            SqlCommand tsqlKomut = cmd.komut(SqlCümlesi);
            tsqlKomut.ExecuteNonQuery();
            baglanti.BaglantiKapa();
        }

        public void update(string SqlCümlesi)
        {
            SqlCommand tsqlKomut = cmd.komut(SqlCümlesi);
            tsqlKomut.ExecuteNonQuery();
            baglanti.BaglantiKapa();
        }

        public List<KullanıcılarDTO> KullanıcılarListesi(string SqlCümlesi)
        {
            SqlCommand tsqlKomut = new SqlCommand(SqlCümlesi, baglanti.BaglantiAc());
            SqlDataReader dr = tsqlKomut.ExecuteReader();

            List<KullanıcılarDTO> kdto = new List<KullanıcılarDTO>();

            while (dr.Read())
            {
                kdto.Add(new KullanıcılarDTO
                {
                    KullanıcıID = int.Parse(dr["KullanıcıID"].ToString()),
                    KullanıcıAd = dr["KullanıcıAd"].ToString(),
                    KullanıcıŞifre = dr["KullanıcıŞifre"].ToString(),
                });
            }
            baglanti.BaglantiKapa();
            return kdto;
        }

      

        public List<HesaplarDTO> HesaplarListesi(string SqlCümlesi)
        {
            SqlCommand tsqlKomut = new SqlCommand(SqlCümlesi, baglanti.BaglantiAc());
            SqlDataReader dr = tsqlKomut.ExecuteReader();

            List<HesaplarDTO> hdto = new List<HesaplarDTO>();

     
            while (dr.Read())
            {
                hdto.Add(new HesaplarDTO
                {
                    HesapID = int.Parse(dr["HesapID"].ToString()),
                    HesapAd = dr["HesapAd"].ToString(),
                    //TakipDurum = bool.Parse(dr["TakipDurum"].ToString()),
                });
            }
            baglanti.BaglantiKapa();
                    
            return hdto;

        }

        public List<EngellilerDTO> EngellilerListesi(string SqlCümlesi)
        {
            SqlCommand tsqlKomut = new SqlCommand(SqlCümlesi, baglanti.BaglantiAc());
            SqlDataReader dr = tsqlKomut.ExecuteReader();

            List<EngellilerDTO> edto = new List<EngellilerDTO>();

            while (dr.Read())
            {
                edto.Add(new EngellilerDTO
                {
                    EngelliID = int.Parse(dr["EngelliID"].ToString()),
                    EngelliAd = dr["EngelliAd"].ToString(),                 
                });
            }
            baglanti.BaglantiKapa();
            return edto;
        }

        public List<SözcüklerDTO> SözcüklerListesi(string SqlCümlesi)
        {
            SqlCommand tsqlKomut = new SqlCommand(SqlCümlesi, baglanti.BaglantiAc());
            SqlDataReader dr = tsqlKomut.ExecuteReader();

            List<SözcüklerDTO> sdto = new List<SözcüklerDTO>();

            while (dr.Read())
            {
                sdto.Add(new SözcüklerDTO
                {
                    SözcükID= int.Parse(dr["SözcükID"].ToString()),
                    SözcükAd = dr["SözcükAd"].ToString(),
                });
            }
            baglanti.BaglantiKapa();
            return sdto;
        }

     
    }
}
