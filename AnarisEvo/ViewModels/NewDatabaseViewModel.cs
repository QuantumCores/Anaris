using AnarisDLL.BLL.Anaris;
using AnarisDLL.BLL.Database;
using AnarisDLL.BLL.Helpers;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace AnarisEvo.ViewModels
{
    public class NewDatabaseViewModel : ViewModelBase
    {

        public NewDatabaseViewModel()
        {
            CreateCommand = new NewDatabaseCommand(this);
        }

        public ICommand CreateCommand { get; set; }

        //public Action WindowCloseAction { get; internal set; }
        public Action CreateNewDatabase { get; internal set; }

        private string _ProjectName;
        public string ProjectName
        {
            get { return this._ProjectName; }
            set
            {
                _ProjectName = value;
                OnPropertyChanged("ProjectName");
            }
        }

        private string _ProjectPath;
        public string ProjectPath
        {
            get { return this._ProjectPath; }
            set
            {
                _ProjectPath = value;
                OnPropertyChanged("ProjectPath");
            }
        }


        public void Create()
        {
            Database.Instance = new Database();

            Database.Instance.ProjectProperties.ProjectName = this.ProjectName;
            Database.Instance.ProjectProperties.FilePath = System.IO.Path.Combine(this.ProjectPath, this.ProjectName + ".anrb");
            Database.Instance.ProjectProperties.CreationTime = DateTime.UtcNow;

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            Database.Instance.ProjectProperties.ProgramVersion = fvi.FileVersion;

            Database.Instance.dgv.AddDatabaseColumns();
            Database.Instance.SetUpEmptyProjct();

            Services.Service.Instance.SetUpData();
            CreateNewDatabase();
            
        }

        public bool CanCreate()
        {
            if (!string.IsNullOrWhiteSpace(ProjectName) && !string.IsNullOrWhiteSpace(ProjectPath))
            {
                if (System.IO.Directory.Exists(ProjectPath))
                {
                    return true;
                }
            }

            return false;
        }


    }

    public class NewDatabaseCommand : ICommand
    {
        private NewDatabaseViewModel _ViewModel;
        public NewDatabaseCommand(NewDatabaseViewModel viewModel)
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
            //return _canExecute == null ? false : _canExecute(parameter);
            return _ViewModel.CanCreate();
        }


        public void Execute(object parameter)
        {
            //_execute(parameter);
            _ViewModel.Create();
            ((System.Windows.Window)parameter).Close();
        }
    }

}
