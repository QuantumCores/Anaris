using AnarisDLL.BLL.Category;
using AnarisEvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnarisEvo.Commands.CategoryManager
{
    class CloneSelectedItemCommnad : ICommand
    {
        private CategoryManagerViewModel _ViewModel;
        public CloneSelectedItemCommnad(CategoryManagerViewModel viewModel)
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
            return parameter != null ? true : false; ;
        }


        public void Execute(object parameter)
        {
            Category cat = (Category)parameter?? new Category();
            _ViewModel.CloneSelection(cat);
        }
    }
}
