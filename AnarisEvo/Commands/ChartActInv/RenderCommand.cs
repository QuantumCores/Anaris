using AnarisEvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnarisEvo.Commands.ChartActInv
{
    public class RenderCommand : ICommand
    {
        private ChartActInvViewModel _ViewModel;
        public RenderCommand(ChartActInvViewModel viewModel)
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
            return _ViewModel.Magnitude > 0 && _ViewModel.Wobble > 0 ? true : false;
        }


        public void Execute(object parameter)
        {
            _ViewModel.SplitScenarios();
        }
    }
}
