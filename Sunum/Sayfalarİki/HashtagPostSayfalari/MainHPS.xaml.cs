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

namespace Sunum.Sayfalarİki.HashtagPostSayfalari
{
    /// <summary>
    /// Interaction logic for MainHPS.xaml
    /// </summary>
    public partial class MainHPS : Page
    {
        public MainHPS()
        {
            InitializeComponent();
            btnhashtagpost.Click += Btnhashtagpost_Click;
          
            btnhashtagpostyorum.Click += Btnhashtagpostyorum_Click;
        }

        private void Btnhashtagpostyorum_Click(object sender, RoutedEventArgs e)
        {
            frmmhp.Source = new Uri($"/Sayfalarİki/HashtagPostSayfalari/HashtagYorum.xaml", UriKind.Relative);
        }
    

        private void Btnhashtagpost_Click(object sender, RoutedEventArgs e)
        {
            frmmhp.Source = new Uri($"/Sayfalarİki/HashtagPostSayfalari/HashtagPost.xaml", UriKind.Relative);
        }
    }
}
