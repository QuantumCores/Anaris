﻿using AnarisEvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnarisEvo.Commands.MainMenu
{
    public class SaveDatabaseCommand : ICommand
    {
        private MenuViewModel _ViewModel;
        public SaveDatabaseCommand(MenuViewModel viewModel)
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
            return _ViewModel.CanSaveDatabase();
        }


        public void Execute(object parameter)
        {
            _ViewModel.SaveDatabase();
        }
    }
}
