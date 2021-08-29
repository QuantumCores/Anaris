using AnarisDLL.BLL.Anaris;
using AnarisDLL.BLL.Report;
using AnarisDLL.BLL.Risk;
using AnarisEvo.Commands.ReportSettings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnarisEvo.ViewModels
{
    public class ReportSettingsViewModel : INotifyPropertyChanged
    {
        public List<KeyValuePair<int, string>> TitleFonts { get; set; }
        public List<KeyValuePair<int, string>> ChapterFonts { get; set; }
        public List<KeyValuePair<int, string>> SubChapterFonts { get; set; }
        public List<KeyValuePair<int, string>> SubSubChapterFonts { get; set; }
        public List<KeyValuePair<int, string>> TextFonts { get; set; }

        public List<KeyValuePair<int, string>> TableStyles { get; set; }
        public List<KeyValuePair<int, string>> ImageStyles { get; set; }

        public List<SingleRisk> Scenarios { get; set; }

        public ReportSettingsViewModel()
        {

            Settings = new ReportSettings();
            Settings.Clone(Anaris.Instance.ReportSettings);

            Scenarios = new List<SingleRisk>();

            for (int i = 0; i < Services.Service.Instance.Scenarios.Count; i++)
            {
                Scenarios.Add(new SingleRisk() { name = Anaris.Instance.RiskAnalysis.RiskAnalysis[i].name });
                ObservableCollection<ElementaryRisk> agent = Services.Service.Instance.Scenarios[i];

                foreach (ElementaryRisk elem in agent)
                {
                    Scenarios[i].DistinctiveRisk.Add(elem);
                }
            }

            Services.Service.Instance.UpdatedScenarios += ScenariosUpdated;

            TitleFonts = new List<KeyValuePair<int, string>>();
            PopulateFonts(TitleFonts);
            SelectedTitleFont = TitleFonts.FirstOrDefault(f => f.Value == Settings.TitleFont.Face);

            ChapterFonts = new List<KeyValuePair<int, string>>();
            PopulateFonts(ChapterFonts);
            SelectedChapterFont = ChapterFonts.FirstOrDefault(f => f.Value == Settings.ChapterFont.Face);

            SubChapterFonts = new List<KeyValuePair<int, string>>();
            PopulateFonts(SubChapterFonts);
            SelectedSubChapterFont = SubChapterFonts.FirstOrDefault(f => f.Value == Settings.SectionFont.Face);

            SubSubChapterFonts = new List<KeyValuePair<int, string>>();
            PopulateFonts(SubSubChapterFonts);
            SelectedSubSubChapterFont = SubSubChapterFonts.FirstOrDefault(f => f.Value == Settings.SubSectionFont.Face);

            TextFonts = new List<KeyValuePair<int, string>>();
            PopulateFonts(TextFonts);
            SelectedTextFont = TextFonts.FirstOrDefault(f => f.Value == Settings.RegularFont.Face);

            //Styles
            TableStyles = new List<KeyValuePair<int, string>>();
            PopulateStyles(TableStyles);
            SelectedImageStyle = TableStyles.FirstOrDefault(f => f.Key == 0);

            ImageStyles = new List<KeyValuePair<int, string>>();
            PopulateStyles(ImageStyles);
            SelectedImageStyle = ImageStyles.FirstOrDefault(f => f.Key == 0);

            CancelCommand = new CancelCommand(this);
            ApplyCommand = new ApplyCommand(this);
        }

        #region Commands

        public CancelCommand CancelCommand { get; set; }
        public ApplyCommand ApplyCommand { get; set; }

        #endregion


        private void PopulateFonts(List<KeyValuePair<int, string>> FontList)
        {
            FontList.Add(new KeyValuePair<int, string>(0, "Times"));
            FontList.Add(new KeyValuePair<int, string>(1, "Courier"));
            FontList.Add(new KeyValuePair<int, string>(2, "Helvetica"));
            FontList.Add(new KeyValuePair<int, string>(3, "Symbol"));
        }

        private void PopulateStyles(List<KeyValuePair<int, string>> StyleList)
        {
            StyleList.Add(new KeyValuePair<int, string>(0, "Linia ciągła"));
            StyleList.Add(new KeyValuePair<int, string>(1, "Linia przerywana"));
            StyleList.Add(new KeyValuePair<int, string>(2, "Linia kropkowana"));
        }

        private KeyValuePair<int, string> _SelectedTitleFont;
        public KeyValuePair<int, string> SelectedTitleFont
        {
            get { return _SelectedTitleFont; }
            set
            {
                _SelectedTitleFont = value;
                OnPropertyChanged("SelectedTitleFont");
            }
        }


        private KeyValuePair<int, string> _SelectedChapterFont;
        public KeyValuePair<int, string> SelectedChapterFont
        {
            get { return _SelectedChapterFont; }
            set
            {
                _SelectedChapterFont = value;
                OnPropertyChanged("SelectedChapterFont");
            }
        }

        private KeyValuePair<int, string> _SelectedSubChapterFont;
        public KeyValuePair<int, string> SelectedSubChapterFont
        {
            get { return _SelectedSubChapterFont; }
            set
            {
                _SelectedSubChapterFont = value;
                OnPropertyChanged("SelectedSubChapterFont");
            }
        }

        private KeyValuePair<int, string> _SelectedSubSubChapterFont;
        public KeyValuePair<int, string> SelectedSubSubChapterFont
        {
            get { return _SelectedSubSubChapterFont; }
            set
            {
                _SelectedSubSubChapterFont = value;
                OnPropertyChanged("SelectedSubSubChapterFont");
            }
        }

        private KeyValuePair<int, string> _SelectedTextFont;
        public KeyValuePair<int, string> SelectedTextFont
        {
            get { return _SelectedTextFont; }
            set
            {
                _SelectedTextFont = value;
                OnPropertyChanged("SelectedTextFont");
            }
        }


        private KeyValuePair<int, string> _SelectedTableStyle;
        public KeyValuePair<int, string> SelectedTableStyle
        {
            get { return _SelectedTableStyle; }
            set
            {
                _SelectedTableStyle = value;
                OnPropertyChanged("SelectedTableStyle");
            }
        }

        private KeyValuePair<int, string> _SelectedImageStyle;
        public KeyValuePair<int, string> SelectedImageStyle
        {
            get { return _SelectedTextFont; }
            set
            {
                _SelectedImageStyle = value;
                OnPropertyChanged("SelectedImageStyle");
            }
        }

        private ReportSettings _Settings;
        public ReportSettings Settings
        {
            get { return _Settings; }
            set
            {
                _Settings = value;
                OnPropertyChanged("Settings");
            }
        }

        private ObservableCollection<SingleRisk> _Risks;
        public ObservableCollection<SingleRisk> Risks
        {
            get { return _Risks; }
            set
            {
                _Risks = value;
                OnPropertyChanged("Risks");
            }
        }

        #region Methods
        
        public void ScenariosUpdated(List<ObservableCollection<ElementaryRisk>> scenarios)
        {
            for (int i = 0; i < scenarios.Count; i++)
            {
                Scenarios[i].DistinctiveRisk.Clear();
                ObservableCollection<ElementaryRisk> agent = scenarios[i];

                foreach (ElementaryRisk elem in agent)
                {
                    Scenarios[i].DistinctiveRisk.Add(elem);
                }
            }
        }

        internal bool CanApply()
        {
            return true;
        }

        internal void Cancel()
        {
            Settings.Clone(Anaris.Instance.ReportSettings);
        }

        internal void Apply()
        {
            Anaris.Instance.ReportSettings.Clone(Settings);
        }

        #endregion

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged = null;

        virtual protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName)); //This will update prperty in this binded context
        }
        #endregion
    }
}
