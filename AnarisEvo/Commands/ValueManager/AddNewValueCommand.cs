using AnarisDLL.BLL.Category;
using AnarisEvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnarisEvo.Commands.ValueManager
{
    public class AddNewValueCommand : ICommand
    {
        private ValueManagerViewModel _ViewModel;
        public AddNewValueCommand(ValueManagerViewModel viewModel)
        {
            _ViewModel = viewModel;
        }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _ViewModel.CanAddNewValue();
        }


        public void Execute(object parameter)
        {
            _ViewModel.AddNewValue();
        }
    }
}
