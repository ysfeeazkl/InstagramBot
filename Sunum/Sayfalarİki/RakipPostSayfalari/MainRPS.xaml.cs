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
    /// Interaction logic for MainRPS.xaml
    /// </summary>
    public partial class MainRPS : Page
    {
        public MainRPS()
        {
            InitializeComponent();
            btnrakippost.Click += Btnrakippost_Click;
            btnrakippostyorum.Click += Btnrakippostyorum_Click;
        }

        private void Btnrakippostyorum_Click(object sender, RoutedEventArgs e)
        {
            frmmw.Source = new Uri($"/Sayfalarİki/RakipPostSayfalari/RakipPostYotum.xaml", UriKind.Relative);
        }

        private void Btnrakippostdm_Click(object sender, RoutedEventArgs e)
        {
            frmmw.Source = new Uri($"/Sayfalarİki/RakipPostSayfalari/RakipPostDm.xaml", UriKind.Relative);
        }

        private void Btnrakippost_Click(object sender, RoutedEventArgs e)
        {
            frmmw.Source = new Uri($"/Sayfalarİki/RakipPostSayfalari/RakipPost.xaml", UriKind.Relative);
        }
    }
}
