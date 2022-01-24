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

namespace Sunum.Sayfalarİki.RakipPostSayfalari
{
    /// <summary>
    /// Interaction logic for RakipPostYotum.xaml
    /// </summary>
    public partial class RakipPostYotum : Page
    {
        int kullanıcıIdsi = Sunum.Sayfalarİki.KullaniciBilgileriSayfaları.KullaniciGiris.KullanıcıIDVeri;
        IDBişlemleri servis = new Veritabanİşlemler();
        IDMatma mesajServisi = new Dmİşlemleri();
        public RakipPostYotum()
        {
            InitializeComponent();
            btnrkyorumgonder.Click += Btnrkyorumgonder_Click;
        }

        private void Btnrkyorumgonder_Click(object sender, RoutedEventArgs e)
        {
            if (kullanıcıIdsi != 0)
            {
                if (String.IsNullOrWhiteSpace(txtAtılcakYorum.Text) == true || String.IsNullOrWhiteSpace(txtGönderisayısı.Text) == true || String.IsNullOrWhiteSpace(txtRakipAd.Text) == true)
                {
                    MessageBox.Show("Boşlukları doldurunuz");
                }
                else
                {
                    mesajServisi.GönderiYorumBaşlat(txtAtılcakYorum.Text, kullanıcıIdsi, txtRakipAd.Text, int.Parse(txtGönderisayısı.Text));
                }
            }
            else
            {
                MessageBox.Show("Giriş yapınız");
            }
          

        }
    }
}
