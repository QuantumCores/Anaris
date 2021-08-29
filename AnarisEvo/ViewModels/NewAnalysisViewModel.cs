using AnarisDLL.BLL.Anaris;
using AnarisDLL.BLL.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnarisEvo.ViewModels
{
    public class NewAnalysisViewModel : INotifyPropertyChanged
    {

        public NewAnalysisViewModel()
        {
            CreateCommand = new NewAnalysisCommand(this);
        }

        public ICommand CreateCommand { get; set; }

        //public Action WindowCloseAction { get; internal set; }
        public Action CreateNewAnalysis { get; internal set; }

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
            Anaris.Instance = new Anaris();
            Anaris.Instance.ProjectProperties.ProjectName = this.ProjectName;
            Anaris.Instance.ProjectProperties.FilePath = System.IO.Path.Combine(this.ProjectPath, this.ProjectName + ".anrs");
            Anaris.Instance.ProjectProperties.CreationTime = DateTime.UtcNow;
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            Anaris.Instance.ProjectProperties.ProgramVersion = fvi.FileVersion;

            Database.Instance = Anaris.Instance.DataBase;
            Database.Instance.dgv.AddDatabaseColumns();
            Database.Instance.SetUpEmptyProjct();

            Anaris.Instance.ScenarioManager.Initialize();
            Anaris.Instance.RiskAnalysis.Initialize(Anaris.Instance.ScenarioManager);

            for (int i = 0; i < Anaris.Instance.RiskAnalysis.RiskAnalysis.Count; i++)
            {
                RiskDgvList risk = Anaris.Instance.RiskAnalysis.RiskAnalysis[i];
                AnarisDLL.BLL.AnarisGrid.Dgv dgv = new AnarisDLL.BLL.AnarisGrid.Dgv();
                dgv.Clone(Anaris.Instance.DataBase.dgv);
                dgv.name = "BD - " + Anaris.Instance.ScenarioManager.Risks[i].name;
                dgv.text = "BD - " + Anaris.Instance.ScenarioManager.Risks[i].name;
                risk.dgvList.Add(dgv);
            }

            Services.Service.Instance.SetUpData();
            CreateNewAnalysis();
            //WindowCloseAction();
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

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged = null;

        virtual protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName)); //This will update prperty in this binded context
        }
        #endregion
    }

    public class NewAnalysisCommand : ICommand
    {
        private NewAnalysisViewModel _ViewModel;
        public NewAnalysisCommand(NewAnalysisViewModel viewModel)
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
