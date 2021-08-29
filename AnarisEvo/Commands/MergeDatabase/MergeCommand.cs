using AnarisEvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnarisEvo.Commands.MergeDatabase
{
    public class MergeCommand : ICommand
    {
        private MergeDatabaseViewModel _ViewModel;
        public MergeCommand(MergeDatabaseViewModel viewModel)
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
            return string.IsNullOrWhiteSpace(_ViewModel.FilePath) || !System.IO.File.Exists(_ViewModel.FilePath) ? false : true;
        }


        public void Execute(object parameter)
        {
            _ViewModel.Merge();
        }
    }
}
