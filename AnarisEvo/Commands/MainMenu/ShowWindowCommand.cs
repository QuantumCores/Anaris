using AnarisDLL.BLL.Database;
using AnarisEvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnarisEvo.Commands.MainMenu
{
    public class ShowWindowCommand : ICommand
    {
        private MenuViewModel _ViewModel;
        public ShowWindowCommand(MenuViewModel viewModel)
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
           return  _ViewModel.CanShowWindow((string)parameter);            
        }

        delegate void Del(string message);

        public void Execute(object parameter)
        {
            _ViewModel.ShowWindowActionField((string)parameter);
        }
    }
}
