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

namespace Sunum.Sayfalarİki.HashtagPostSayfalari
{
    /// <summary>
    /// Interaction logic for HashtagYorum.xaml
    /// </summary>
    public partial class HashtagYorum : Page
    {
        int kullanıcıIdsi = Sunum.Sayfalarİki.KullaniciBilgileriSayfaları.KullaniciGiris.KullanıcıIDVeri;
        IDBişlemleri servis = new Veritabanİşlemler();
        IDMatma mesajServisi = new Dmİşlemleri();
        public HashtagYorum()
        {
            InitializeComponent();
            btnhpyorumgonder.Click += Btnhpyorumgonder_Click;
        }

        private void Btnhpyorumgonder_Click(object sender, RoutedEventArgs e)
        {
            if (kullanıcıIdsi != 0)
            {
                if (String.IsNullOrWhiteSpace(txtHashtagAd.Text) == true || String.IsNullOrWhiteSpace(txtpostSayısı.Text) == true || String.IsNullOrWhiteSpace(txtyorum.Text) == true)
                {
                    MessageBox.Show("Boşlukları doldurunuz");
                }
                else
                {
                    mesajServisi.HashtagYorumBaşlat(txtyorum.Text,kullanıcıIdsi,txtHashtagAd.Text,int.Parse(txtpostSayısı.Text));
                }
            }
            else
            {
                MessageBox.Show("Giriş yapınız");
            }
           
        }
    }
}
