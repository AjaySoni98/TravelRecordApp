using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TravelRecordApp.ViewModel.Commands
{
    public class NavToRegCommand : ICommand
    {
        public MainVM MainPageViewModel { get; set; }

        public NavToRegCommand(MainVM viewModel)
        {
            MainPageViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MainPageViewModel.NavToReg();
        }
    }
}
