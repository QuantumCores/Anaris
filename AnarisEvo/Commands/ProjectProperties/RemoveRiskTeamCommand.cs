using AnarisEvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnarisEvo.Commands.ProjectProperties
{
    public class RemoveRiskTeamCommand : ICommand
    {
        private ProjectPropertiesViewModel _ViewModel;
        public RemoveRiskTeamCommand(ProjectPropertiesViewModel viewModel)
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
            return _ViewModel.CanEditAuthor(0);
        }


        public void Execute(object parameter)
        {
            _ViewModel.Remove(0);
        }
    }
}
