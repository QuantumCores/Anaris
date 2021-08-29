using AnarisDLL.BLL.Anaris;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnarisDLL.BLL.Risk;
using AnarisEvo.Services;
using System.Windows.Input;
using AnarisEvo.Commands.ScenarioManager;
using AnarisDLL.BLL.Helpers;

namespace AnarisEvo.ViewModels
{
    public class ScenarioManagerViewModel : ViewModelBase
    {
        public ScenarioManagerViewModel()
        {
            Risks = new List<ObservableCollection<ElementaryRisk>>();
            RisksDictionary = new List<KeyValuePair<int, string>>();
            SelectedScenario = new ElementaryRisk();

            for (int i = 0; i < Anaris.Instance.ScenarioManager.Risks.Count; i++)
            {
                SingleRisk sr = Anaris.Instance.ScenarioManager.Risks[i];
                RisksDictionary.Add(new KeyValuePair<int, string>(i, sr.name));
            }

            Risks = Service.Instance.LoadScenarios(null);

            SelectedRisk = RisksDictionary.FirstOrDefault(r => r.Key == 0);
            Scenarios = Risks[0];


            if (Risks[0].Count != 0)
            {
                SelectedScenario.Clone(Risks[0][0]);
            }
            else
            {
                SelectedScenario.Name = "Tutaj wpisz nazwę scenariusza np. \"Upuszczenie\"";
                SelectedScenario.opis = "Opisz scenariusz w kliku zdaniach.";
                SelectedScenario.AHigh = SelectedScenario.AMid = SelectedScenario.ALow = 50;
                SelectedScenario.BHigh = SelectedScenario.BMid = SelectedScenario.BLow = 10;
                SelectedScenario.opisA = "Opis składowej A.";
                SelectedScenario.opisB = "Opis składowej B.";
                SelectedScenario.opisC = "Opis składowej C.";
            }

            Services.Service.Instance.RecalculatedScenarios += UpdateScenariosMagnitude;

            AddScenarioCommand = new AddScenarioCommand(this);
            ApplyCommand = new ApplyCommand(this);
            EditScenarioCommand = new EditScenarioCommand(this);
            DeleteCommand = new DeleteCommand(this);
        }


        #region Commands
        public ICommand AddScenarioCommand { get; set; }
        public ICommand ApplyCommand { get; set; }
        public ICommand EditScenarioCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        #endregion

        private int SelectedScenarioID { get; set; }

        private List<ObservableCollection<ElementaryRisk>> _Risks;
        public List<ObservableCollection<ElementaryRisk>> Risks
        {
            get { return _Risks; }
            set
            {
                _Risks = value;
                OnPropertyChanged("Risks");
            }
        }

        private ObservableCollection<ElementaryRisk> _Scenarios;
        public ObservableCollection<ElementaryRisk> Scenarios
        {
            get { return _Scenarios; }
            set
            {
                _Scenarios = value;
                OnPropertyChanged("Scenarios");
            }
        }


        public List<KeyValuePair<int, string>> RisksDictionary { get; set; }


        private KeyValuePair<int, string> _SelectedRisk;
        public KeyValuePair<int, string> SelectedRisk
        {
            get { return _SelectedRisk; }
            set
            {
                _SelectedRisk = value;
                OnPropertyChanged("SelectedRisk");
                SelectedRiskChanged();
            }
        }

        private ElementaryRisk _SelectedScenario;
        public ElementaryRisk SelectedScenario
        {
            get { return _SelectedScenario; }
            set
            {
                _SelectedScenario = value;
                OnPropertyChanged("SelectedScenario");
            }
        }

        public void CloneSelection(ElementaryRisk scenario)
        {
            ElementaryRisk tmp = new ElementaryRisk();
            tmp.Clone(scenario);

            SelectedScenarioID = Risks[SelectedRisk.Key].IndexOf(scenario);
            SelectedScenario = tmp;
        }

        internal bool CanAddScenario(object parameter)
        {
            if (Risks[SelectedRisk.Key].Select(e => e.Text).Contains(SelectedScenario.Text))
            {
                return false;
            }

            return true;
        }


        internal void AddScenario(object parameter)
        {
            SelectedScenario.Name = RandomNameGenerator.GenerateAndCheck(Risks.SelectMany(er => er).ToList(), RiskCollection.ScenarioNameLength);
            Risks[SelectedRisk.Key].Add(new ElementaryRisk().Clone(SelectedScenario).Update(0, 0, 0));
        }


        internal bool CanEdit()
        {
            List<ElementaryRisk> tmp = Risks[SelectedRisk.Key].Where(e => e.Text == SelectedScenario.Text).ToList();
            if (tmp.Any())
            {
                if (tmp.Count() == 1 && SelectedScenarioID == Risks[SelectedRisk.Key].IndexOf(tmp[0]))
                {
                    return true;
                }

                return false;
            }

            return true;
        }

        internal void EditScenario()
        {
            Risks[SelectedRisk.Key][SelectedScenarioID] = new ElementaryRisk().Clone(SelectedScenario);
        }


        internal void Delete()
        {
            ElementaryRisk tmp = Risks[SelectedRisk.Key].FirstOrDefault(e => e.Name == SelectedScenario.Name);
            Risks[SelectedRisk.Key].Remove(tmp); //here selection is changed and clone() on ElementaryRisk fails text is null
        }


        internal bool CanApply()
        {
            return true;
        }


        internal void Apply()
        {
            Service.Instance.ApplyScenarios(Risks);
        }

        private void SelectedRiskChanged()
        {
            Scenarios = Risks[SelectedRisk.Key];
            if (Risks[SelectedRisk.Key].Count != 0)
            {
                // 
                SelectedScenario = new ElementaryRisk().Clone(Risks[SelectedRisk.Key][0]);
            }
            else
            {
                ElementaryRisk tmp = new ElementaryRisk();
                tmp.Name = "Tutaj wpisz nazwę scenariusza np. \"Upuszczenie\"";
                tmp.opis = "Opisz scenariusz w kliku zdaniach.";
                tmp.AHigh = tmp.AMid = tmp.ALow = 50;
                tmp.BHigh = tmp.BMid = tmp.BLow = 10;
                tmp.opisA = "Opis składowej A.";
                tmp.opisB = "Opis składowej B.";
                tmp.opisC = "Opis składowej C.";

                SelectedScenario = tmp;
            }
        }

        private void UpdateScenariosMagnitude(IList<ElementaryRisk> list)
        {
            if (list.Any())
            {
                List<ElementaryRisk> tmp = Risks.SelectMany(r => r).ToList();

                foreach (ElementaryRisk elem in list)
                {
                    ElementaryRisk s = tmp.FirstOrDefault(e => e.Name == elem.Name);

                    if (s != null)
                    {
                        s.CMid = elem.CMid;
                        s.CLow = elem.CLow;
                        s.CHigh = elem.CHigh;
                    }                    
                }
            }
        }
    }
}
