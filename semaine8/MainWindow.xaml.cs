using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace semaine8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PlaceData placesData = new PlaceData();
            this.listBoxPhotos.DataContext = placesData.PlacesList;
        }

        private void listBoxPhotos_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Place place = (Place)listBoxPhotos.SelectedItem;
            BitmapSource photo = BitmapFrame.Create(new Uri(place.Path));
            image1.Source = photo;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Place place = (Place)listBoxPhotos.SelectedItem;
            place.Vote();
        }
    }
}
