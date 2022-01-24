using DBBusiness;
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

namespace Sunum.Sayfalarİki.KullaniciBilgileriSayfaları
{
    /// <summary>
    /// Interaction logic for KullaniciKayit.xaml
    /// </summary>
    public partial class KullaniciKayit : Page
    {
        IDBişlemleri servis = new Veritabanİşlemler();
        public KullaniciKayit()
        {
            InitializeComponent();
            btnkkayitol.Click += Btnkkayitol_Click;
        }

        private void Btnkkayitol_Click(object sender, RoutedEventArgs e)
        {
            if (tbkKkullaniciadi.Text == null || tbkKsifre.Text == null)
            {
                MessageBox.Show("Kullanıcı Adı Veya Şifre boş");
            }
            else
            {
                servis.insert($"insert KullanıcıBilgileri (KullanıcıAd,KullanıcıŞifre) values ('{tbkKkullaniciadi.Text}','{tbkKsifre.Text}')");
                MessageBox.Show("Kayıt Edildi");
            }
        }
    }
}
