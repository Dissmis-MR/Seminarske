using NASA_UWP_semi.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NASA_UWP_semi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Rover> rover { get; set; }
        List<Photo> seznamSlik;
        public MainPage()
        {
            this.InitializeComponent();
            seznamSlik = new List<Photo>();
            rover = new ObservableCollection<Rover>();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            await Klic.NabiSlike(seznamSlik);
            Podatki.DataContext = seznamSlik;
                              
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Slike));
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Slike));
        }
    }
}
