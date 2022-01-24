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
    /// Interaction logic for Sözcükler.xaml
    /// </summary>
    public partial class Sözcükler : Page
    {
        IDBişlemleri servis = new Veritabanİşlemler();
        public Sözcükler()
        {
            InitializeComponent();
            btnSözcükEkle.Click += BtnSözcükEkle_Click;
            btnListeyiBoşalt.Click += BtnListeyiBoşalt_Click;
            DGdoldur();
        }

        private void BtnListeyiBoşalt_Click(object sender, RoutedEventArgs e)
        {
            servis.delete("delete from YasaklıSözcükler");
            DGdoldur();
        }

        private void BtnSözcükEkle_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSözcükAd.Text) == false)
            {

                servis.insert($"insert into YasaklıSözcükler(SözcükAd) values('{txtSözcükAd.Text}')");
                DGdoldur();
            }
            else
            {
                MessageBox.Show("Sözcük Giriniz");
            }
        }

        public void DGdoldur()
        {
            var doldur = servis.SözcüklerListesi("select * from YasaklıSözcükler");

            DgHesaplar.ItemsSource = doldur;
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var SeçilenKullanıcı = (SözcüklerDTO)DgHesaplar.SelectedItem;

            if (SeçilenKullanıcı != null)
            {
                servis.delete("delete from YasaklıSözcükler where SözcükID = " + SeçilenKullanıcı.SözcükID);
                DGdoldur();
            }

          
        }
    }
}
