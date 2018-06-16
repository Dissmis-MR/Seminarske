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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NASA_UWP_semi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Slike : Page
    {
        public ObservableCollection<Camera> Camera { get; set; }
        List<Photo> seznamSlik;
        public Slike()
        {
            this.InitializeComponent();
            seznamSlik = new List<Photo>();
            Camera = new ObservableCollection<Camera>();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await Klic.NabiSlike(seznamSlik);
            listView.ItemsSource = seznamSlik;
        }

        private void roverL_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Image image = sender as Image;

            Panel parent = image.Parent as Panel;
            if (parent != null)
            {
                image.RenderTransform = new ScaleTransform() { ScaleX = 2, ScaleY = 2 };
                parent.Children.Remove(image);
                parent.Children.Add(new Popup() { Child = image, IsOpen = true, Tag = parent });
            }
            else
            {
                Popup popup = image.Parent as Popup;
                popup.Child = null;
                Panel panel = popup.Tag as Panel;
                image.RenderTransform = null;
                panel.Children.Add(image);
            }
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
