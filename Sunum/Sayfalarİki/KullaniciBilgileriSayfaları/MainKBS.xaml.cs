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
    /// Interaction logic for MainKBS.xaml
    /// </summary>
    public partial class MainKBS : Page
    {
        public MainKBS()
        {
            InitializeComponent();
            btnkullanicigiris.Click += Btnkullanicigiris_Click; 
            btnkullanicikayit.Click += Btnkullanicikayit_Click;
        }

        private void Btnkullanicikayit_Click(object sender, RoutedEventArgs e)
        {
            frmmw.Source = new Uri($"/Sayfalarİki/KullaniciBilgileriSayfaları/KullaniciKayit.xaml", UriKind.Relative);
        }

        private void Btnkullanicigiris_Click(object sender, RoutedEventArgs e)
        {
            frmmw.Source = new Uri($"/Sayfalarİki/KullaniciBilgileriSayfaları/KullaniciGiris.xaml", UriKind.Relative);
        }
    }
}
