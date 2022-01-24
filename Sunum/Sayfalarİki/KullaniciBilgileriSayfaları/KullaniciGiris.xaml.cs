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

namespace Sunum.Sayfalarİki.KullaniciBilgileriSayfaları
{
    /// <summary>
    /// Interaction logic for KullaniciGiris.xaml
    /// </summary>
    public partial class KullaniciGiris : Page
    {
        public static int KullanıcıIDVeri;
        IDBişlemleri servis = new Veritabanİşlemler();
        public KullaniciGiris()
        {
            InitializeComponent();

            var cbDoldur = servis.KullanıcılarListesi("select * from KullanıcıBilgileri");
            cbkgkullaniciadi.ItemsSource = cbDoldur;

            btnkgirisyap.Click += Btnkgirisyap_Click;
        }

        private void Btnkgirisyap_Click(object sender, RoutedEventArgs e)
        {
            if (tbkgsifre.Text == "" || cbkgkullaniciadi.SelectedIndex == -1)
            {
                MessageBox.Show("Kullanıcı adını ve şifreyi boş girmeyiniz");
            }
            else
            {
                var SeçilenKullanıcı = (KullanıcılarDTO)cbkgkullaniciadi.SelectedItem;
                KullanıcıIDVeri = Convert.ToInt32(SeçilenKullanıcı.KullanıcıID);

          
                try
                {
                    if (tbkgsifre.Text != SeçilenKullanıcı.KullanıcıŞifre)
                    {
                        MessageBox.Show("Yanlış Şifre");
                    }
                    else if (tbkgsifre.Text == SeçilenKullanıcı.KullanıcıŞifre)
                    {
                        KullanıcıIDVeri = SeçilenKullanıcı.KullanıcıID;

                        MessageBox.Show("Giriş yapılmıştır");
                    }

                }
                catch 
                {
                    MessageBox.Show("Tekrar giriş yapmayı deneyin");
                }
                
            }                
        }



    }
}
