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

namespace Sunum.Sayfalarİki.RakipKullaniciSayfalari
{
    /// <summary>
    /// Interaction logic for MainRKS.xaml
    /// </summary>
    public partial class MainRKS : Page
    {
        public MainRKS()
        {
            InitializeComponent();
            btnrakipkullanicibilgileri.Click += Btnrakipkullanicibilgileri_Click;         
            
        }

     

        private void Btnrakipkullanicibilgileri_Click(object sender, RoutedEventArgs e)
        {
            frmmw.Source = new Uri($"/Sayfalarİki/RakipKullaniciSayfalari/RakipBilgileri.xaml", UriKind.Relative);
        }
    }
}
