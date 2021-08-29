using AnarisEvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnarisEvo.Commands.ReportSettings
{
    public class ApplyCommand : ICommand
    {
        private ReportSettingsViewModel _ViewModel;
        public ApplyCommand(ReportSettingsViewModel viewModel)
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
            return _ViewModel.CanApply();
        }


        public void Execute(object parameter)
        {
            _ViewModel.Apply();
        }
    }
}
