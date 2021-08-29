using AnarisDLL.BLL.Category;
using AnarisDLL.BLL.Helpers;
using AnarisEvo.Commands.ValuePie;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnarisEvo.ViewModels
{
    public class ValuePieViewModel : ViewModelBase
    {
        public ValuePieViewModel()
        {
            Categories = Services.Service.Instance.ValuePieCategories;
            PieChartData = Services.Service.Instance.PieChartData;
            
            ApplyCommand = new ApplyCommand(this);
            ValuePieCommand = new ValuePieCommand(this);
        }



        public ICommand ApplyCommand { get; set; }
        public ICommand ValuePieCommand { get; set; }

        public delegate byte[] RenderPieChart();
        public RenderPieChart DrawPieChart { get; set; }

        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<KeyValuePair<string, double>> PieChartData { get; set; }

        public Category _SelectedCategory { get; set; }
        public Category SelectedCategory
        {
            get { return _SelectedCategory; }
            set
            {
                _SelectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        private string _TitlePrefix = "Diagram kołowy wartości - ";
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

        internal bool CanApply()
        {
            return (SelectedCategory != null) ? true : false;
        }

        internal void Apply()
        {
            Title = _TitlePrefix + SelectedCategory.text;
            Services.Service.Instance.LoadPieChartData(SelectedCategory.name);
        }

        internal bool CanSaveImage()
        {
            if (string.IsNullOrWhiteSpace(ImgPath) || !System.IO.Directory.GetParent(ImgPath).Exists || SelectedCategory == null)
            {
                return false;
            }

            return true;
        }

        internal void SaveImage()
        {
            byte[] img = Services.Service.Instance.LoadPieChartImage(SelectedCategory.name);
            
            using (MemoryStream ms = new MemoryStream(img))
            {
                var image = System.Drawing.Image.FromStream(ms);
                image.Save(ImgPath, ImageFormat.Bmp);                
            }
        }

        public void Render()
        {
            Services.Service.Instance.LoadPieChartImage(SelectedCategory.name);
            for (int i =0; i< Categories.Count; i++)
            {
                //RenderImages(i);
            }
        }

        public byte[] RenderImages(int categoryIndex)
        {
            SelectedCategory = Categories[categoryIndex];
            Apply();
            byte[] image = DrawPieChart();

            using (System.Drawing.Image img = System.Drawing.Image.FromStream(new MemoryStream(image)))
            {
                img.Save(@"C:\Users\Primus\Desktop\Anaris\output_[" + categoryIndex + "].jpg", ImageFormat.Jpeg);
            }

            return image;
        }

    }
}
