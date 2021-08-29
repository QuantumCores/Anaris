using AnarisEvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnarisEvo.Commands.ScenarioManager
{
    public class ScenarioManagerCommand : ICommand
    {
        private ScenarioManagerViewModel _ViewModel;
        public ScenarioManagerCommand(ScenarioManagerViewModel viewModel)
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
            return false;
        }


        public void Execute(object parameter)
        {
           
        }
    }
}
