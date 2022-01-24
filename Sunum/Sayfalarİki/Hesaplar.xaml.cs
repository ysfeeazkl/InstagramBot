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
    /// Interaction logic for Hesaplar.xaml
    /// </summary>
    public partial class Hesaplar : Page
    {
        IDBişlemleri servis = new Veritabanİşlemler();
        public Hesaplar()
        {
            InitializeComponent();
            btnHesapEkle.Click += BtnHesapEkle_Click;
            btnListeyiBoşalt.Click += BtnListeyiBoşalt_Click;
            DGdoldur();
        }

        private void BtnListeyiBoşalt_Click(object sender, RoutedEventArgs e)
        {
            servis.delete("delete from HesapBilgileri");
            DGdoldur();
        }

        private void BtnHesapEkle_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(txtHesapAd.Text) == false) 
            {
                servis.insert($"insert into HesapBilgileri (HesapAd) values ('{txtHesapAd.Text}')");
                DGdoldur();
            }
            else
            {
                MessageBox.Show("Hesap Adı Giriniz");
            }

          
        }

        public void DGdoldur()
        {
            var KaraListeDoldur = servis.HesaplarListesi("select * from HesapBilgileri");

            DgHesaplar.ItemsSource = KaraListeDoldur;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var SeçilenKullanıcı = (HesaplarDTO)DgHesaplar.SelectedItem;

            if (SeçilenKullanıcı != null)
            {
                servis.delete("delete from HesapBilgileri where HesapID = " + SeçilenKullanıcı.HesapID);
                DGdoldur();
            }

         
        }

        private void miEngelle_Click(object sender, RoutedEventArgs e)
        {
            var SeçilenKullanıcı = (HesaplarDTO)DgHesaplar.SelectedItem;

            if (SeçilenKullanıcı != null)
            {
                servis.delete("delete from HesapBilgileri where HesapID = " + SeçilenKullanıcı.HesapID);
                DGdoldur();

                servis.insert($"insert into EngelliTablosu (EngelliAd) values ('{SeçilenKullanıcı.HesapAd}')");
            }

        
        }
    }
}
