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
    public class AddNewCategoryCommand : ICommand
    {
        private CategoryManagerViewModel _ViewModel;
        public AddNewCategoryCommand(CategoryManagerViewModel viewModel)
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
            Category cat = (Category)parameter;
            string name = cat == null ? "" : cat.name;
            return _ViewModel.CanAddNewCategory(name);
        }


        public void Execute(object parameter)
        {
            Category cat = (Category)parameter;
            string name = cat == null ? "" : cat.name ;
            _ViewModel.AddNewCategory(name);
        }
    }
}
