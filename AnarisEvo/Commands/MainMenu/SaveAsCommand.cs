using AnarisEvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnarisEvo.Commands.MainMenu
{
    public class SaveAsCommand : ICommand
    {
        private MenuViewModel _ViewModel;
        public SaveAsCommand(MenuViewModel viewModel)
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
            return _ViewModel.CanSave();
        }


        public void Execute(object parameter)
        {
            _ViewModel.SaveAs();
        }
    }
}
