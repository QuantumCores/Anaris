using AnarisDLL.BLL.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AnarisEvo.ViewModels
{
    public class WelcomeViewViewModel : ViewModelBase
    {
        public WelcomeViewViewModel()
        {
            
        }

        //public ICommand RenderCommand { get; set; }


        public delegate void LoadOrNew(string filePath);

        //public LoadOrNew LoadDatabase { get; set; }
        //public LoadOrNew LoadAnaris { get; set; }

        //public LoadOrNew NewDatabase { get; set; }
        //public LoadOrNew NewAnaris { get; set; }

        public RoutedEventHandler LoadDatabase { get; set; }
        public RoutedEventHandler LoadAnaris { get; set; }
        //public RoutedEventHandler NewDatabase { get; set; }
        //public RoutedEventHandler NewAnaris { get; set; }



    }
}
