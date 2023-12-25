using System;
using System.Collections.Generic;
using System.Text;
using TravelRecordApp.ViewModel.Commands;

namespace TravelRecordApp.ViewModel
{
    public class ProfilePageVM
    {
        public LogoutCommand LogoutCommand { get; set; }

        public ProfilePageVM()
        {
            LogoutCommand = new LogoutCommand(this);
        }

        public async void Logout()
        {
            var result = await App.Current.MainPage.DisplayAlert("ALERT", "Logout of the Application?", "Yes", "No");
            if (result)
            {
                App.gUser = null;
                await App.Current.MainPage.Navigation.PopAsync(); // or anything else
            }
        }

    }
}
