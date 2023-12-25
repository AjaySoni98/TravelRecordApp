using System;
using System.Collections.Generic;
using System.Text;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel.Commands;

namespace TravelRecordApp.ViewModel
{
    public class MainVM
    {
        public Users User { get; set; }

        public LoginCommand LoginCommand { get; set; }

        public NavToRegCommand NavToRegCommand { get; set; }

        public MainVM()
        {
            User = new Users();
            LoginCommand = new LoginCommand(this);
            NavToRegCommand = new NavToRegCommand(this);
        }

        public async void Login()
        {
            if (Users.Login(User.Email, User.Password))
            {
                User.Email = User.Password = null;
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            }
            else
            {
                User.Email = User.Password = null;
                await App.Current.MainPage.DisplayAlert("Error", "Incorrect Email or Password", "Ok");
            }
        }

        public async void NavToReg()
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
    }
}
