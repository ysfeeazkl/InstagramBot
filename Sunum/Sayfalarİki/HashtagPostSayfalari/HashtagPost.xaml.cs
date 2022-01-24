using DBBusiness;
using SEBusiness;
using SEBusiness.Takipİşlemleri;
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

namespace Sunum.Sayfalarİki.HashtagPostSayfalari
{
    /// <summary>
    /// Interaction logic for HashtagPost.xaml
    /// </summary>
    public partial class HashtagPost : Page
    {
        bool karalisteFiltrele = false;

        int kullanıcıIdsi = Sunum.Sayfalarİki.KullaniciBilgileriSayfaları.KullaniciGiris.KullanıcıIDVeri; 
        IDBişlemleri servis = new Veritabanİşlemler();
        ITakipciCekme takipçiÇekmeServisi = new TakipciCekmeİşlemi();
        public HashtagPost()
        {
            InitializeComponent();
            btnrakiptakipci.Click += Btnrakiptakipci_Click;
            btnListeyiBoşalt.Click += BtnListeyiBoşalt_Click;
            cbKaraListeFiltre.Click += CbKaraListeFiltre_Click;



            DgDoldur();
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

        public void DgDoldur()
        {
            var lbDoldur = servis.HesaplarListesi("select * from HesapBilgileri");
            lbcekilenkullaniciler.ItemsSource = lbDoldur;
        }

        private void BtnListeyiBoşalt_Click(object sender, RoutedEventArgs e)
        {
            servis.delete("delete from HesapBilgileri");
            DgDoldur();
        }

        private void Btnrakiptakipci_Click(object sender, RoutedEventArgs e)
        {
            if (kullanıcıIdsi != 0)
            {
                int çekilecekSayı = int.Parse(txtTakipçiSayısı.Text);

                var takipçiÇekme = takipçiÇekmeServisi.HashtagDenTakipçiÇekme(txthashtag.Text, kullanıcıIdsi, karalisteFiltrele, çekilecekSayı);

                lbcekilenkullaniciler.ItemsSource = takipçiÇekme;
            }
            else
            {
                MessageBox.Show("Giriş yapınız");
            }

           

        }
    }
}
