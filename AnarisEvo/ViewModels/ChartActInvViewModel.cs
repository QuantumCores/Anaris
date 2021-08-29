using AnarisDLL.BLL.Anaris;
using AnarisDLL.BLL.Risk;
using AnarisEvo.Commands.ChartActInv;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnarisEvo.ViewModels
{
    public class ChartActInvViewModel : INotifyPropertyChanged
    {
        public ChartActInvViewModel()
        {
            ActNow = new ObservableCollection<ElementaryRisk>();
            Investigate = new ObservableCollection<ElementaryRisk>();
            Later = new ObservableCollection<ElementaryRisk>();
            Leave = new ObservableCollection<ElementaryRisk>();

            RisksDictionary = new Dictionary<int, string>();
            RisksDictionary.Add(0, "Wszytkie");
            for (int i = 0; i < Anaris.Instance.ScenarioManager.Risks.Count; i++)
            {
                SingleRisk sr = Anaris.Instance.ScenarioManager.Risks[i];
                RisksDictionary.Add(i+1, sr.name);
            }

            Magnitude = 10;
            Wobble = 2;
            SelectedRisk = RisksDictionary.FirstOrDefault(r => r.Key == 0);

            RenderCommand = new RenderCommand(this);


            SplitScenarios();
        }

        public ICommand RenderCommand { get; set; }

        private Dictionary<int, string> _RisksDictionary;
        public Dictionary<int, string> RisksDictionary
        {
            get { return _RisksDictionary; }
            set
            {
                _RisksDictionary = value;
                OnPropertyChanged("RisksDictionary");
            }
        }

        private KeyValuePair<int, string> _SelectedRisk;
        public KeyValuePair<int, string> SelectedRisk
        {
            get { return _SelectedRisk; }
            set
            {
                _SelectedRisk = value;
                OnPropertyChanged("SelectedRisk");
            }
        }

        private ObservableCollection<ElementaryRisk> _ActNow;
        public ObservableCollection<ElementaryRisk> ActNow
        {
            get { return _ActNow; }
            set
            {
                _ActNow = value;
                OnPropertyChanged("ActNow");
            }
        }

        private ObservableCollection<ElementaryRisk> _Investigate;
        public ObservableCollection<ElementaryRisk> Investigate
        {
            get { return _Investigate; }
            set
            {
                _Investigate = value;
                OnPropertyChanged("Investigate");
            }
        }

        private ObservableCollection<ElementaryRisk> _Later;
        public ObservableCollection<ElementaryRisk> Later
        {
            get { return _Later; }
            set
            {
                _Later = value;
                OnPropertyChanged("Later");
            }
        }

        private ObservableCollection<ElementaryRisk> _Leave;
        public ObservableCollection<ElementaryRisk> Leave
        {
            get { return _Leave; }
            set
            {
                _Leave = value;
                OnPropertyChanged("Leave");
            }
        }

        private double _Magnitude;
        public double Magnitude
        {
            get { return _Magnitude; }
            set
            {
                _Magnitude = value;
                OnPropertyChanged("Magnitude");
            }
        }

        private double _Wobble;
        public double Wobble
        {
            get { return _Wobble; }
            set
            {
                _Wobble = value;
                OnPropertyChanged("Wobble");
            }
        }

        public void SplitScenarios()
        {
            ActNow.Clear();
            Investigate.Clear();
            Later.Clear();
            Leave.Clear();

            if (SelectedRisk.Key == 0)
            {
                Anaris.Instance.ScenarioManager.Risks.ForEach(r => SplitSingleRisk(r));
            }
            else
            {
                SplitSingleRisk(Anaris.Instance.ScenarioManager.Risks[SelectedRisk.Key - 1]);
            }
        }

        private void SplitSingleRisk(SingleRisk risk)
        {
            foreach (ElementaryRisk elem in risk.DistinctiveRisk)
            {
                if (elem.MM >= Magnitude && elem.Uncertainty <= Wobble)
                {
                    ActNow.Add(elem);
                }
                else if (elem.MM >= Magnitude && elem.Uncertainty > Wobble)
                {
                    Investigate.Add(elem);
                }
                else if (elem.MM < Magnitude && elem.Uncertainty <= Wobble)
                {
                    Later.Add(elem);
                }
                else
                {
                    Leave.Add(elem);
                }
            }
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged = null;

        virtual protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
    }
}
