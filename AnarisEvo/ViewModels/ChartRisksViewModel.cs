using AnarisDLL.BLL.Helpers;
using AnarisDLL.BLL.Risk;
using AnarisEvo.Commands.ChartRisks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Drawing.Imaging;

namespace AnarisEvo.ViewModels
{
    public class ChartRisksViewModel : ViewModelBase
    {
        public ChartRisksViewModel()
        {
            SortMode = new ObservableCollection<KeyValuePair<int, string>>();

            SortMode.Add(new KeyValuePair<int, string>(0, "Całkowite ryzyko"));
            SortMode.Add(new KeyValuePair<int, string>(1, "Składowa A"));
            SortMode.Add(new KeyValuePair<int, string>(2, "Składowa B"));
            SortMode.Add(new KeyValuePair<int, string>(3, "Składowa C"));

            SelectedSortMode = SortMode.FirstOrDefault(a => a.Key == 0);

            Agents = Services.Service.Instance.TornadoChartAgents;
            SelectedAgent = Agents.FirstOrDefault(a => a.Key == 0);

            ApplyCommand = new ApplyCommand(this);
            SaveImageCommand = new SaveImageCommand(this);
        }



        public ICommand ApplyCommand { get; set; }
        public ICommand SaveImageCommand { get; set; }

        public Action<int, int> DiplayImageAction { get; set; }
        public Func<KeyValuePair<int, int>> GetImageSize { get; set; }


        public List<KeyValuePair<int, string>> Agents { get; set; }

        public ObservableCollection<KeyValuePair<string, double>> RiskChartData { get; set; }

        private KeyValuePair<int, string> _SelectedAgent { get; set; }
        public KeyValuePair<int, string> SelectedAgent
        {
            get { return _SelectedAgent; }
            set
            {
                _SelectedAgent = value;
                OnPropertyChanged("SelectedAgent");
            }
        }


        public ObservableCollection<KeyValuePair<int, string>> SortMode { get; set; }

        private KeyValuePair<int, string> _SelectedSortMode { get; set; }
        public KeyValuePair<int, string> SelectedSortMode
        {
            get { return _SelectedSortMode; }
            set
            {
                _SelectedSortMode = value;
                OnPropertyChanged("SelectedSortMode");
            }
        }

        private string _ImgPath { get; set; }
        public string ImgPath
        {
            get { return _ImgPath; }
            set
            {
                _ImgPath = value;
                OnPropertyChanged("ImgPath");
            }
        }


        private string _Title { get; set; }
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                OnPropertyChanged("Title");
            }
        }

        internal bool CanApply()
        {
            return true;
        }

        internal void Apply()
        {
            Title = SelectedAgent.Value;
            //Services.Service.Instance.LoadTornadoChartData(SelectedSortMode.Key, SelectedAgent.Key - 1);
            //byte[] imgArray = Services.Service.Instance.LoadTornadoChartImage(SelectedSortMode.Key, SelectedAgent.Key - 1, 1000, 600);
            this.DiplayImageAction(SelectedSortMode.Key, SelectedAgent.Key - 1);
        }

        public void Render()
        {

        }


        internal bool CanSaveImage()
        {
            if (string.IsNullOrWhiteSpace(ImgPath) || !System.IO.Directory.GetParent(ImgPath).Exists)
            {
                return false;
            }

            return true;
        }


        internal void SaveImage()
        {
            var size = GetImageSize();
            byte[] img = Services.Service.Instance.LoadTornadoChartImage(SelectedSortMode.Key, SelectedAgent.Key-1, size.Value, size.Key);

            using (MemoryStream ms = new MemoryStream(img))
            {
                var image = System.Drawing.Image.FromStream(ms);
                image.Save(ImgPath, ImageFormat.Bmp);
            }
        }


    }

}
