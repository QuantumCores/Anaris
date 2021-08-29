using AnarisEvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnarisEvo.Commands.ValuePie
{
    public class ValuePieCommand : ICommand
    {
        private ValuePieViewModel _ViewModel;
        public ValuePieCommand(ValuePieViewModel viewModel)
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
            return _ViewModel.CanSaveImage(); ;
        }


        public void Execute(object parameter)
        {
            _ViewModel.SaveImage();
        }
    }
}
