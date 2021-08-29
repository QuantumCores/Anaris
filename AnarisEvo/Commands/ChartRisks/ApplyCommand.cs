using AnarisEvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnarisEvo.Commands.ChartRisks
{
    public class ApplyCommand : ICommand
    {
        private ChartRisksViewModel _ViewModel;
        public ApplyCommand(ChartRisksViewModel viewModel)
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
