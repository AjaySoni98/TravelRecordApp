using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TravelRecordApp.ViewModel.Commands
{
    public class RegisterCommand : ICommand
    {
        public RegisterVM RegisterVM { get; set; }

        public RegisterCommand(RegisterVM viewModel)
        {
            RegisterVM = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            RegisterVM.Register();
        }
    }
}
