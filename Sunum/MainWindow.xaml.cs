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

namespace Sunum
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();         


            BTNhastag.Click += BTNhastag_Click;
            btnkullanicibilgileri.Click += Btnkullanicibilgileri_Click;
            btnrakipkullanici.Click += Btnrakipkullanici_Click;
            btnrakippost.Click += Btnrakippost_Click;
            btnyasaklilar.Click += Btnyasaklilar_Click;
            btnOlaylar.Click += BtnOlaylar_Click;
            btnKaraListe.Click += BtnKaraListe_Click;
            btnHesaplar.Click += BtnHesaplar_Click;

            rbFace.Click += RbFace_Click;
            rbİnsta.Click += Rbİnsta_Click;

        
        }

        private void Rbİnsta_Click(object sender, RoutedEventArgs e)
        {
            gridinsta.Visibility = Visibility.Visible;
            gridface.Visibility = Visibility.Hidden;
            rbFace.IsChecked = false;
        }

        private void RbFace_Click(object sender, RoutedEventArgs e)
        {
            gridinsta.Visibility = Visibility.Hidden;
            gridface.Visibility = Visibility.Visible;
            rbİnsta.IsChecked = false;
        }

        private void BTNhastag_Click(object sender, RoutedEventArgs e)
        {
            frmmw.Source = new Uri($"/Sayfalarİki/HashtagPostSayfalari/MainHPS.xaml", UriKind.Relative);
        }

        private void BtnHesaplar_Click(object sender, RoutedEventArgs e)
        {
            frmmw.Source = new Uri($"/Sayfalarİki/Hesaplar.xaml", UriKind.Relative);
        }

        private void BtnKaraListe_Click(object sender, RoutedEventArgs e)
        {
            frmmw.Source = new Uri($"/Sayfalarİki/KaraListe.xaml", UriKind.Relative);
        }

        private void BtnOlaylar_Click(object sender, RoutedEventArgs e)
        {
            frmmw.Source = new Uri($"/Sayfalarİki/Olaylar/MainTDS.xaml", UriKind.Relative);
        }

        private void Btnyasaklilar_Click(object sender, RoutedEventArgs e)
        {
            frmmw.Source = new Uri($"/Sayfalarİki/Sözcükler.xaml", UriKind.Relative);
        }

        private void Btnrakippost_Click(object sender, RoutedEventArgs e)
        {
            frmmw.Source = new Uri($"/Sayfalarİki/RakipPostSayfalari/MainRPS.xaml", UriKind.Relative);
        }

        private void Btnrakipkullanici_Click(object sender, RoutedEventArgs e)
        {
            frmmw.Source = new Uri($"/Sayfalarİki/RakipKullaniciSayfalari/MainRKS.xaml", UriKind.Relative);
        }

        private void Btnkullanicibilgileri_Click(object sender, RoutedEventArgs e)
        {
            frmmw.Source = new Uri($"/Sayfalarİki/KullaniciBilgileriSayfaları/MainKBS.xaml", UriKind.Relative);
        }


    }
}
