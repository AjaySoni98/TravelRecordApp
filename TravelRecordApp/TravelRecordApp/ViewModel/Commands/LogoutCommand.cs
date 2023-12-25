using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TravelRecordApp.ViewModel.Commands
{
    public class LogoutCommand : ICommand
    {
        public ProfilePageVM ProfilePageVM { get; set; }

        public LogoutCommand(ProfilePageVM viewModel)
        {
            ProfilePageVM = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ProfilePageVM.Logout();
        }
    }
}
