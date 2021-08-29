using AnarisEvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnarisEvo.Commands.ScenarioManager
{
    public class AddScenarioCommand : ICommand
    {
        private ScenarioManagerViewModel _ViewModel;
        public AddScenarioCommand(ScenarioManagerViewModel viewModel)
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

            return _ViewModel.CanAddScenario(parameter);
        }


        public void Execute(object parameter)
        {
            _ViewModel.AddScenario(parameter);
        }
    }
}
