using System;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace speedoMeter
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void _x_btn_speed_Click(object sender, RoutedEventArgs e)
        {
            Geolocator _geolocator = new Geolocator();
            _geolocator.DesiredAccuracyInMeters = 0;
            _geolocator.DesiredAccuracy = PositionAccuracy.High;
            try
            {
                Geoposition _geoposition = await _geolocator.GetGeopositionAsync();
                _x_tbx_speed.Text = _geoposition.Coordinate.Speed.ToString();
            }
            catch (Exception ex)
            {
                if ((uint)ex.HResult == 0x80004004)
                {
                    // the application does not have the right capability or the location master switch is off
                    _x_tbx_speed.Text = "location  is disabled in phone settings.";
                }
            }

        }
    }
}
