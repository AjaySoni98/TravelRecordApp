using Microsoft.WindowsAzure.MobileServices;
using System;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;

        /* (1) Azure (Udemy Lecture 87) (commenting the code since couldn't add github repo to Azure deployment center)
         * this link (remove spaces after https) in below code constructor - https ://travelrecordappxama.azurewebsites.net
        public static MobileServiceClient client = new MobileServiceClient("");
        */

        public static Users gUser = new Users();

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databaseLocation)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            DatabaseLocation = databaseLocation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
