using DBBusiness;
using DBBusiness.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sunum.Sayfalarİki
{
    /// <summary>
    /// Interaction logic for KaraListe.xaml
    /// </summary>
    public partial class KaraListe : Page
    {
        IDBişlemleri servis = new Veritabanİşlemler();
        public KaraListe()
        {
            InitializeComponent();
            btnHesapEkle.Click += BtnHesapEkle_Click;
            btnListeyiBoşalt.Click += BtnListeyiBoşalt_Click;


            DGdoldur();
        }

        private void BtnListeyiBoşalt_Click(object sender, RoutedEventArgs e)
        {
            servis.delete("delete from EngelliTablosu");
            DGdoldur();
        }

        private void BtnHesapEkle_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtHesapAd.Text) == false)
            {
                servis.insert($"insert into EngelliTablosu (EngelliAd) values ('{txtHesapAd.Text}')");
                DGdoldur();
            }
            else
            {
                MessageBox.Show("Hesap Adı Giriniz");
            }

           
        }

        public void DGdoldur()
        {
            var doldur = servis.EngellilerListesi("select * from EngelliTablosu");

            DgHesaplar.ItemsSource = doldur;
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var SeçilenKullanıcı = (EngellilerDTO)DgHesaplar.SelectedItem;

            if (SeçilenKullanıcı != null)
            {
                servis.delete("delete from EngelliTablosu where EngelliID = " + SeçilenKullanıcı.EngelliID);
                DGdoldur();
            }
         
        }

        private void miEngelle_Click(object sender, RoutedEventArgs e)
        {
            var SeçilenKullanıcı = (EngellilerDTO)DgHesaplar.SelectedItem;

            if (SeçilenKullanıcı != null)
            {
                servis.delete("delete from EngelliTablosu where EngelliID = " + SeçilenKullanıcı.EngelliID);
                DGdoldur();

                servis.insert($"insert into HesapBilgileri (HesapAd) values ('{SeçilenKullanıcı.EngelliAd}')");
            }

           
        }
    }
}
