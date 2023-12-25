using Plugin.Geolocator;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        NewTravelVM viewModel;

        public NewTravelPage()
        {
            InitializeComponent();
            viewModel = new NewTravelVM();
            BindingContext = viewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            loading.IsRunning = true;
            venueListView.IsVisible = false;

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = await Venue.GetVenues(position.Latitude, position.Longitude);

            loading.IsRunning = false;
            loading.IsVisible = false;
            venueListView.IsVisible = true;

            venueListView.ItemsSource = venues;
        }
    }
}