using AnarisDLL.BLL.Helpers;
using AnarisEvo.Commands.MergeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnarisEvo.ViewModels
{
    public class MergeAnalysisViewModel : ViewModelBase
    {
        public MergeAnalysisViewModel()
        {
            Options = new Dictionary<int, string>() { { 0, "Importuj wszystkie wiersze" }, { 1, "Importuj oryginalne wiersze" } };
            SelectedOption = Options.FirstOrDefault(s => s.Key == 0);
            MergeCommand = new MergeCommand(this);
        }


        public ICommand MergeCommand { get; set; }

        private string _FilePath;
        public string FilePath
        {
            get { return _FilePath; }
            set
            {
                _FilePath = value;
                OnPropertyChanged("FilePath");
            }
        }

        public Dictionary<int, string> Options { get; set; }

        private KeyValuePair<int, string> _SelectedOption;
        public KeyValuePair<int, string> SelectedOption
        {
            get { return _SelectedOption; }
            set
            {
                _SelectedOption = value;
                OnPropertyChanged("SelectedOption");
            }
        }

        internal void Merge()
        {
            bool importAll = !System.Convert.ToBoolean(SelectedOption.Key);

            string version = AnarisDLL.BLL.LoadDataBase.LoadDataBase.GetTheAssemblyVersion(0, FilePath);
           
        }


    }
}
