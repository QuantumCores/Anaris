using AnarisEvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnarisEvo.Commands.GeneralInformation
{
    public class ChnagePage : ICommand
    {
        private GeneralInformationViewModel _ViewModel;
        public ChnagePage(GeneralInformationViewModel viewModel)
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
            return true;
        }


        public void Execute(object parameter)
        {
            int page = -1;

            try
            {
                page = Convert.ToInt32(parameter);
                _ViewModel.OnChangePage(page);
            }
            catch
            {
                _ViewModel.OnChangePage(page);
            }
        }
    }
}
