using AnarisEvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnarisEvo.Commands.ScenarioManager
{
    public class ApplyCommand : ICommand
    {
        private ScenarioManagerViewModel _ViewModel;
        public ApplyCommand(ScenarioManagerViewModel viewModel)
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
