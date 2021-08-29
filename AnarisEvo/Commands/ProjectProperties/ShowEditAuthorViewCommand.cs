using AnarisEvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnarisEvo.Commands.ProjectProperties
{
    class ShowEditAuthorViewCommand : ICommand
    {
        private ProjectPropertiesViewModel _ViewModel;
        public ShowEditAuthorViewCommand(ProjectPropertiesViewModel viewModel)
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
            return _ViewModel.CanEditAuthor(1);
        }


        public void Execute(object parameter)
        {
            _ViewModel.ShowAuthorEditor(false);
        }
    }
}
