using AnarisDLL.BLL.Anaris;
using AnarisDLL.BLL.AnarisGrid;
using AnarisDLL.BLL.Database;
using AnarisDLL.BLL.Helpers;
using AnarisDLL.BLL.Risk;
using AnarisEvo.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace AnarisEvo.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static MainWindowViewModel Instance { get; set; }

        private static int _SelectedAgent { get; set; }
        public static int SelectedAgent
        {
            get { return _SelectedAgent; }
            set
            {
                _SelectedAgent = value;
            }
        }

        

        public MainWindowViewModel()
        {           
            //Database = Database.MockupDatabase();
            Scenarios = new ObservableCollection<KeyValuePair<int, string>>();
            //Scenarios.Add(-1, "Lista scenuriuszy jest pusta");
            //SelectedScenario = Scenarios.FirstOrDefault(kv => kv.Key == -1);

            Instance = this;
        }

        #region Commands
        public ICommand NewDatabaseCommand { get; set; }
        public ICommand ShowWindowCommand { get; set; }
        #endregion

        #region Converters
        IMultiValueConverter ShowWindowConverter { get; set; }
        #endregion

        #region Delegates
        public Action CreateNewDatabaseAction;
        public Action CreateNewAnarisAction;
        public delegate void ShowWindowAction(string windowName);
        #endregion

        private ShowWindowAction _ShowWindowActionField;
        public ShowWindowAction ShowWindowActionField
        {
            get { return _ShowWindowActionField; }
            set { _ShowWindowActionField = value; }
        }

        //private Anaris _Anaris;
        //public Anaris Anaris
        //{
        //    get { return _Anaris; }
        //    set { _Anaris = value; }
        //}

        //private Database _Database;
        //public Database Database
        //{
        //    get { return _Database; }
        //    set { _Database = value; }
        //}

        private ObservableCollection<KeyValuePair<int, string>> _Scenarios;
        public ObservableCollection<KeyValuePair<int, string>> Scenarios
        {
            get { return _Scenarios; }
            set { _Scenarios = value; }
        }

        private KeyValuePair<int, string> _SelectedScenario;
        public KeyValuePair<int, string> SelectedScenario
        {
            get { return _SelectedScenario; }
            set
            {

                _SelectedScenario = value;
                OnPropertyChanged("SelectedScenario");
                if (SelectedAgent != -1)
                {
                    AgentsViewModel.SelectedScenario[SelectedAgent] = SelectedScenario.Key;
                    AgentsViewModel.Instance.ChangeDisplayedScenario();
                    AgentsViewModel.Instance.MenuEnabled = false;
                }
            }
        }


        public void UpdateScenarios()
        {
            Scenarios.Clear();

            if (_SelectedAgent != -1)
            {
                //SingleRisk Agent = Anaris.Instance.ScenarioManager.Risks[SelectedAgent];
                List<ObservableGrid> Agent = Services.Service.Instance.ObservableRisks[SelectedAgent];
                //Scenarios.Add(new KeyValuePair<int, string>(-1, "Pochodna baza daych"));

                for (int i = 0; i < Agent.Count; i++)
                {
                    Scenarios.Add(new KeyValuePair<int, string>(i, Agent[i].Text));
                }

                SelectedScenario = Scenarios[AgentsViewModel.SelectedScenario[SelectedAgent]];

            }
            else
            {
                Scenarios.Add(new KeyValuePair<int, string>(-1, "Lista scenuriuszy jest pusta"));
                SelectedScenario = Scenarios.First();
            }
        }



    }
}
