using AnarisDLL.BLL.Value;
using AnarisEvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace AnarisEvo.Commands.ValueManager
{
    public class SelectionCommand : ICommand
    {
        private ValueManagerViewModel _ViewModel;
        public SelectionCommand(ValueManagerViewModel viewModel)
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
            return true;
        }


        public void Execute(object parameter)
        {
            SingleValue tmp = (SingleValue)parameter;
            _ViewModel.CloneSelection(tmp);
        }
    }
}
