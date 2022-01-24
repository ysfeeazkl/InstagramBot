using DBBusiness;
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

namespace Sunum.Sayfalarİki.Olaylar
{
    /// <summary>
    /// Interaction logic for TakipOlayı.xaml
    /// </summary>
    public partial class TakipOlayı : Page
    {
        int kullanıcıIdsi = Sunum.Sayfalarİki.KullaniciBilgileriSayfaları.KullaniciGiris.KullanıcıIDVeri; 
        IFWetme takipServisi = new FWişlemleri();
        IDBişlemleri servis = new Veritabanİşlemler();
        public TakipOlayı()
        {
            InitializeComponent();
            btnhpdmgonder.Click += Btnhpdmgonder_Click;

            DgDoldur();
        }

        public void DgDoldur()
        {
            var lbDoldur = servis.HesaplarListesi("select * from HesapBilgileri");
            lbcekilenkullaniciler.ItemsSource = lbDoldur;
        }

        private void Btnhpdmgonder_Click(object sender, RoutedEventArgs e)
        {
            if (kullanıcıIdsi != 0)
            {
                takipServisi.RakipTakipBaşlat(kullanıcıIdsi);
            }
            else
            {
                MessageBox.Show("Giriş yapınız");
            }

           
        }
    }
}
