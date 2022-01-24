using DBBusiness.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBusiness
{
    public interface IDBişlemleri //bu interface metotları yazıyoruz
    {
        void insert(string SqlCümlesi);
        void delete(string SqlCümlesi);
        void update(string SqlCümlesi);

        List<KullanıcılarDTO> KullanıcılarListesi(string SqlCümlesi); //bu kullanıcı çekerken 
        List<HesaplarDTO> HesaplarListesi(string SqlCümlesi);
        List<EngellilerDTO> EngellilerListesi(string SqlCümlesi);
        List<SözcüklerDTO> SözcüklerListesi(string SqlCümlesi);


        List<String> HesapAdları();
        List<String> Argolar();
        List<String> EngellenenKullanıcılar();
        List<String> KullanıcıBilgisi(int KullanıcıId);
        List<String> FWtakipciÇekme(bool Filtre);
    }
}
