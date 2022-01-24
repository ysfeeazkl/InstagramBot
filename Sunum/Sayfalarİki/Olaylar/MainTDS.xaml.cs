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
    /// Interaction logic for MainTDS.xaml
    /// </summary>
    public partial class MainTDS : Page
    {
        public MainTDS()
        {
            InitializeComponent();
            btnDm.Click += BtnDm_Click;
            btnTakip.Click += BtnTakip_Click;
        }

        private void BtnTakip_Click(object sender, RoutedEventArgs e)
        {
            frmmw.Source = new Uri($"/Sayfalarİki/Olaylar/TakipOlayı.xaml", UriKind.Relative);
        }

        private void BtnDm_Click(object sender, RoutedEventArgs e)
        {
            frmmw.Source = new Uri($"/Sayfalarİki/Olaylar/DmOlayı.xaml", UriKind.Relative);
        }
    }
}
