using System;
using System.Collections.Generic;
using System.Text;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel.Commands;

namespace TravelRecordApp.ViewModel
{
    public class RegisterVM
    {
        public Users User { get; set; }

        public RegisterCommand RegisterCommand { get; set; }

        public RegisterVM()
        {
            User = new Users();
            RegisterCommand = new RegisterCommand(this);
        }

        public void Register()
        {
            if (Users.Register(User) == true)
            {
                User.Email = User.Password = User.ConfirmPassword = null;
                App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                User.Email = User.Password = User.ConfirmPassword = null;
                App.Current.MainPage.DisplayAlert("Error", "Either Email already registered or the Passwords don't match or Some fields are empty", "Ok");
            }
        }
    }
}
