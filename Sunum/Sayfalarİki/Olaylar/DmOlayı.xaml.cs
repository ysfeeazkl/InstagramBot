using DBBusiness;
using SEBusiness.DMişlemleri;
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
    /// Interaction logic for DmOlayı.xaml
    /// </summary>
    public partial class DmOlayı : Page
    {
        int kullanıcıIdsi = Sunum.Sayfalarİki.KullaniciBilgileriSayfaları.KullaniciGiris.KullanıcıIDVeri;
        IDMatma dmServisi = new Dmİşlemleri();
        IDBişlemleri servis = new Veritabanİşlemler();
        public DmOlayı()
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
                dmServisi.DmOlayıBaşlat(tbhpdmmesaj.Text, kullanıcıIdsi);
            }
            else
            {
                MessageBox.Show("Giriş yapınız");
            }
           

            
        }
    }
}
