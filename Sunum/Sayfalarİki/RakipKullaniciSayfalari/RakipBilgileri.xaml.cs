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

namespace Sunum.Sayfalarİki.RakipKullaniciSayfalari
{
    /// <summary>
    /// Interaction logic for RakipBilgileri.xaml
    /// </summary>
    public partial class RakipBilgileri : Page
    {
        bool karalisteFiltrele;
        int kullanıcıIdsi = Sunum.Sayfalarİki.KullaniciBilgileriSayfaları.KullaniciGiris.KullanıcıIDVeri;
        IHesapDetayları detayServisi = new HesapDetaylarıİşlemleri();
        ITakipciCekme TakipçiÇekmeServisi = new TakipciCekmeİşlemi();
        IDBişlemleri servis = new Veritabanİşlemler();
        public RakipBilgileri()
        {
            InitializeComponent();
            btnrakipkullanici.Click += Btnrakipkullanici_Click;
            btnrakiptakipci.Click += Btnrakiptakipci_Click;
            cbKaraListeFiltre.Click += CbKaraListeFiltre_Click;
            btnListeyiBoşalt.Click += BtnListeyiBoşalt_Click;
            DgDoldur();
        }

        private void BtnListeyiBoşalt_Click(object sender, RoutedEventArgs e)
        {
            servis.delete("delete from HesapBilgileri");
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

        private void Btnrakiptakipci_Click(object sender, RoutedEventArgs e)
        {
            if (kullanıcıIdsi != 0)
            {
                int çekilecekSayı = int.Parse(txtTakipçiSayısı.Text);

                TakipçiÇekmeServisi.TakipciCekmeOlayı(txtRakipAd.Text, çekilecekSayı, kullanıcıIdsi, karalisteFiltrele);
            }
            else
            {
                MessageBox.Show("Giriş yapınız");
            }
            
        }

        private void Btnrakipkullanici_Click(object sender, RoutedEventArgs e)
        {
            if (kullanıcıIdsi != 0)
            {
                var kullanıcıDetay = detayServisi.RakipDetayları(txtRakipAd.Text, kullanıcıIdsi);

                tbrakipkullaniciadi.Text = "" + kullanıcıDetay[0];
                tbrakiptakipcisayisi.Text ="" + kullanıcıDetay[1];
                tbrakipgonderisayisi.Text = "" + kullanıcıDetay[2];
                tbrakiptakipsayisi.Text = "" + kullanıcıDetay[3];
            }
            else
            {
                MessageBox.Show("Giriş yapınız");
            }

           
        }
    }
}
