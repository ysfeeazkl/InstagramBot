using DBBusiness;
using SEBusiness;
using SEBusiness.Hesap_İşlemleri;
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

namespace Sunum.Sayfalarİki.RakipPostSayfalari
{
    /// <summary>
    /// Interaction logic for RakipPost.xaml
    /// </summary>
    public partial class RakipPost : Page
    {
        bool karalisteFiltrele;
        ITakipciCekme takipçiÇekmeServisi = new TakipciCekmeİşlemi();
        IHesapDetayları detayServisi = new HesapDetaylarıİşlemleri();
        IDBişlemleri servis = new Veritabanİşlemler(); 
        int kullanıcıIdsi = Sunum.Sayfalarİki.KullaniciBilgileriSayfaları.KullaniciGiris.KullanıcıIDVeri;
        public RakipPost()
        {
            InitializeComponent();
            btnListeyiBoşalt.Click += BtnListeyiBoşalt_Click;
            btnrakipkullanici.Click += Btnrakipkullanici_Click;
            btnTakipçiÇek.Click += BtnTakipçiÇek_Click;
            cbKaraListeFiltre.Click += CbKaraListeFiltre_Click;

            DgDoldur();
        }

        public void DgDoldur()
        {
            var lbDoldur = servis.HesaplarListesi("select * from HesapBilgileri");
            lbcekilenkullaniciler.ItemsSource = lbDoldur;
        }
        private void CbKaraListeFiltre_Click(object sender, RoutedEventArgs e)
        {
            if (cbKaraListeFiltre.IsChecked == true)
            {
                karalisteFiltrele = true;
            }
            else
            {
                karalisteFiltrele = false;
            }
        }

        private void BtnTakipçiÇek_Click(object sender, RoutedEventArgs e)
        {
            if (kullanıcıIdsi != 0)
            {
                takipçiÇekmeServisi.GönderidenTakipçiÇekme(txtRakipAd.Text, kullanıcıIdsi, karalisteFiltrele, int.Parse(txtTakipçiSayısı.Text));
            }
            else
            {
                MessageBox.Show("Giriş yapınız");
            }

            DgDoldur();


        }

        private void Btnrakipkullanici_Click(object sender, RoutedEventArgs e)
        {
            if (kullanıcıIdsi != 0)
            {
                var kullanıcıDetay = detayServisi.RakipDetayları(txtRakipAd.Text, kullanıcıIdsi);

                tbrakipkullaniciadi.Text = "Rakibin Kullanıcı Adı: " + kullanıcıDetay[0];
                tbrakiptakipcisayisi.Text = "Rakibin Takipçisi: " + kullanıcıDetay[1];
                tbrakipgonderisayisi.Text = "Rakibin Gönderi Sayısı: " + kullanıcıDetay[2];
                tbrakiptakipsayisi.Text = "Rakibin Takip Ettikleri: " + kullanıcıDetay[3];
            }
            else
            {
                MessageBox.Show("Giriş yapınız");
            }
         
        }

        private void BtnListeyiBoşalt_Click(object sender, RoutedEventArgs e)
        {
            servis.delete("delete from HesapBilgileri");
            DgDoldur();
        }
    }
}
