using AnarisDLL.BLL.Anaris;
using AnarisDLL.BLL.Database;
using AnarisDLL.BLL.Helpers;
using AnarisDLL.BLL.SaveAnaris;
using AnarisDLL.BLL.SaveDataBase;
using AnarisEvo.Commands.MainMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AnarisEvo.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private string[] DatabaseManagers { get; set; }
        private string[] AnalysisManagers { get; set; }

        public MenuViewModel()
        {
            //CanCreateProjects = false;
            NewDatabaseCommand = new Commands.MainMenu.NewDatabaseCommand(this);
            OpenDatabaseCommand = new OpenDatabaseCommand(this);
            SaveDatabaseCommand = new SaveDatabaseCommand(this);
            NewAnarisCommand = new NewAnarisCommand(this);
            OpenAnarisCommand = new OpenAnarisCommand(this);
            SaveAnarisCommand = new SaveAnarisCommand(this);
            SaveCommand = new SaveCommand(this);
            SaveAsCommand = new SaveAsCommand(this);
            ShowWindowCommand = new ShowWindowCommand(this);
            GenerateReportCommand = new GenerateReportCommand(this);

            DatabaseManagers = new string[4];
            DatabaseManagers[0] = "ValueManager";
            DatabaseManagers[1] = "CategoryManager";
            DatabaseManagers[2] = "ValuePie";
            DatabaseManagers[3] = "MergeDatabase";

            AnalysisManagers = new string[7];
            AnalysisManagers[0] = "ScenarioManager";
            AnalysisManagers[1] = "ChartRisks";
            AnalysisManagers[2] = "ChartActInv";
            AnalysisManagers[3] = "ProjectProperties";
            AnalysisManagers[4] = "ReportSettings";
            AnalysisManagers[5] = "ScenarioManager";
            AnalysisManagers[6] = "MergeAnaris";

        }

        

        public ICommand NewDatabaseCommand { get; set; }
        public ICommand OpenDatabaseCommand { get; set; }
        public ICommand SaveDatabaseCommand { get; set; }
        public ICommand NewAnarisCommand { get; set; }
        public ICommand OpenAnarisCommand { get; set; }
        public ICommand SaveAnarisCommand { get; set; }
        public ICommand ShowWindowCommand { get; set; }
        public ICommand GenerateReportCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand SaveAsCommand { get; set; }

        public RoutedEventHandler CreateNewDatabaseAction { get; set; }
        public RoutedEventHandler OpenDatabaseAction { get; set; }
        public RoutedEventHandler SaveDatabaseAsAction { get; set; }
        public Action<string> SaveDatabaseAction { get; set; }

        public RoutedEventHandler CreateNewAnarisAction { get; set; }
        public RoutedEventHandler OpenAnarisAction { get; set; }
        public RoutedEventHandler SaveAnarisAsAction { get; set; }
        public Action<string> SaveAnarisAction { get; set; }

        public delegate void ShowWindowAction(string windowName);
        public ShowWindowAction ShowWindowActionField { get; set; }
        public RoutedEventHandler GenerateReportAction { get; set; }

        //private bool _CanCreateProjects { get; set; }
        //public bool CanCreateProjects
        //{
        //    get { return (Database.Instance == null && Anaris.Instance == null); }
        //    set
        //    {
        //        _CanCreateProjects = value;
        //        OnPropertyChanged("CanCreateProjects");
        //    }
        //}


        //DATABASE 
        internal bool CanCreateNewDatabase()
        {
            return Database.Instance == null;
        }

        internal void CreateNewDatabase()
        {
            CreateNewDatabaseAction(null, new RoutedEventArgs());
        }

        internal void OpenDatabase()
        {
            OpenDatabaseAction(null, new RoutedEventArgs());
        }

        public bool CanSaveDatabase()
        {
            return Database.Instance != null;
        }

        internal void SaveDatabase()
        {
            SaveDatabaseAsAction(null, new RoutedEventArgs());
        }


        //ANALYSIS
        internal bool CanCreateNewAnaris()
        {
            return Anaris.Instance == null && Database.Instance == null;
        }

        internal void CreateNewAnaris()
        {
            CreateNewAnarisAction(null, new RoutedEventArgs());
        }

        internal void OpenAnaris()
        {
            OpenAnarisAction(null, new RoutedEventArgs());
        }

        public bool CanSaveAnaris()
        {
            return Anaris.Instance != null;
        }

        internal void SaveAnaris()
        {
            SaveAnarisAsAction(null, new RoutedEventArgs());
        }

        internal bool CanSave()
        {
            if (Database.Instance != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void Save()
        {
            try
            {
                if (Anaris.Instance != null)
                {
                    Services.Service.ConvertObservableToAnaris();
                    SaveAnarisAction(Anaris.Instance.ProjectProperties.FilePath);                    
                    //SaveProject.Save(Anaris.Instance.ProjectProperties.FilePath, Anaris.Instance);
                }
                else if (Database.Instance != null)
                {
                    Services.Service.ConvertObservableToDatabase();
                    SaveDatabaseAction(Database.Instance.ProjectProperties.FilePath);                    
                    //SaveDataBase.Save(Database.Instance.ProjectProperties.FilePath, Database.Instance);
                }
            }
            catch (Exception exc)
            {
                throw new Exception("Wystąpił bład podczas zapisywania. \n" + exc.ToString());
            }
        }


        internal void SaveAs()
        {
            if (Anaris.Instance != null)
            {
                SaveAnaris();
            }
            else if (Database.Instance != null)
            {
                SaveDatabase();
            }
        }


        //MainWINODW

        internal bool CanShowWindow(string parameter)
        {
            if (parameter == "GeneralInformation")
            {
                return true;
            }
            else if (Database.Instance == null)
            {
                return false;
            }
            else if (Database.Instance != null && DatabaseManagers.Contains(parameter))
            {
                return true;
            }
            else if (Anaris.Instance != null && AnalysisManagers.Contains(parameter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal string[] GetAllManagersNames()
        {
            List<string> names = new List<string>();
            names.AddRange(DatabaseManagers);
            names.AddRange(AnalysisManagers);

            return names.ToArray();                ;
        }

        internal void GenerateReport()
        {
            GenerateReportAction(null, new RoutedEventArgs());
        }

    }
}
