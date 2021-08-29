using AnarisDLL.BLL.Helpers;
using AnarisEvo.Commands.GeneralInformation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace AnarisEvo.ViewModels
{
    public class GeneralInformationViewModel : ViewModelBase
    {
        public GeneralInformationViewModel()
        {
            ChnagePage = new ChnagePage(this);
            CurrentPage = new Page();
        }

        public ICommand ChnagePage { get; set; }

        private Page _CurrentPage { get; set; }
        public Page CurrentPage
        {
            get { return _CurrentPage; }
            set
            {
                _CurrentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        public void OnChangePage(int page)
        {
            switch (page)
            {
                case 1:
                    CurrentPage = new Pages.Tutorial.DataBasePage();
                    break;
                default:
                    CurrentPage = new Page();
                    break;
            }
        }
    }
}
