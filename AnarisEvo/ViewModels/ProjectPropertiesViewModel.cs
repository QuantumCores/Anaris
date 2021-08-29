using AnarisDLL.BLL.Anaris;
using AnarisEvo.Commands.ProjectProperties;
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
    public class ProjectPropertiesViewModel : INotifyPropertyChanged
    {
        public ProjectPropertiesViewModel()
        {
            Properties = new ProjectProperties().Clone(Anaris.Instance.ProjectProperties);

            Authors = new ObservableCollection<Author>(Anaris.Instance.ProjectProperties.Authors);
            RiskTeam = new ObservableCollection<Author>(Anaris.Instance.ProjectProperties.RiskTeam);

            ShowAddAuthorViewCommand = new ShowAddAuthorViewCommand(this);
            ShowEditAuthorViewCommand = new ShowEditAuthorViewCommand(this);
            ShowAddOtherViewCommand = new ShowAddRiskTeamViewCommand(this);
            ShowEditOtherViewCommand = new ShowEditRiskTeamViewCommand(this);
            ApplyCommand = new ApplyCommand(this);
            CancelCommand = new CancelCommand(this);
            RemoveRiskTeamCommand = new RemoveRiskTeamCommand(this);
            RemoveAuthorCommand = new RemoveAuthorCommand(this);


        }

        public ICommand ShowAddAuthorViewCommand { get; set; }
        public ICommand ShowEditAuthorViewCommand { get; set; }
        public ICommand ShowAddOtherViewCommand { get; set; }
        public ICommand ShowEditOtherViewCommand { get; set; }
        public ICommand ApplyCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand RemoveAuthorCommand { get; set; }
        public ICommand RemoveRiskTeamCommand { get; set; }

        private Views.Authors _authors = null;
        private Views.Authors _riskTeam = null;

        private void CloneAuthorList(IList<Author> source, IList<Author> target)
        {
            target.Clear();
            foreach (Author a in source)
            {
                target.Add(new Author().Clone(a));
            }
        }

        public ObservableCollection<Author> Authors { get; set; }
        public ObservableCollection<Author> RiskTeam { get; set; }


        private ProjectProperties _Properties;
        public ProjectProperties Properties
        {
            get { return _Properties; }
            set
            {
                _Properties = value;
                OnPropertyChanged("Properties");
            }
        }

        private Author _SelectedAuthor;
        public Author SelectedAuthor
        {
            get { return _SelectedAuthor; }
            set
            {
                _SelectedAuthor = value;
                OnPropertyChanged("SelectedAuthor");
            }
        }

        private Author _SelectedRiskTeam;
        public Author SelectedRiskTeam
        {
            get { return _SelectedRiskTeam; }
            set
            {
                _SelectedRiskTeam = value;
                OnPropertyChanged("SelectedRiskTeam");
            }
        }

        internal bool CanAddAuthor(int list)
        {
            if (list == 0)
            {
                return _riskTeam == null;
            }
            else //if (list == 1)
            {
                return _authors == null;
            }
        }

        internal bool CanEditAuthor(int list)
        {
            if (list == 0)
            {
                return SelectedRiskTeam != null;
            }
            else //if (list == 1)
            {
                return SelectedAuthor != null;
            }
        }


        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged = null;

        internal void ShowAuthorEditor(bool isAdded)
        {
            AuthorsViewModel vm = null;
            if (isAdded)
            {
                vm = new AuthorsViewModel(new Author(), "Dodaj autora raportu", true, 1, AddAuthor);
            }
            else
            {
                vm = new AuthorsViewModel(SelectedAuthor, "Edytuj autora raportu", true, 1, EditAuthor);
            }

            _authors = new Views.Authors(vm);
            _authors.Show();
        }

        internal void ShowRiskTeamEditor(bool isAdded)
        {
            AuthorsViewModel vm = null;
            if (isAdded)
            {
                vm = new AuthorsViewModel(new Author(), "Dodaj członka zespołu", true, 0, AddAuthor);
            }
            else
            {
                vm = new AuthorsViewModel(SelectedAuthor, "Edytuj członka zespołu", true, 0, EditAuthor);
            }

            _riskTeam = new Views.Authors(vm);
            _riskTeam.Show();
        }

        internal void AddAuthor(Author author, int list)
        {
            if (list == 0)
            {
                RiskTeam.Add(author);
                DisposeView(ref _riskTeam);
            }
            else if (list == 1)
            {
                Authors.Add(author);
                DisposeView(ref _authors);
            }
        }

        internal void EditAuthor(Author author, int list)
        {
            if (list == 0)
            {
                RiskTeam[RiskTeam.IndexOf(SelectedRiskTeam)] = author;
                DisposeView(ref _riskTeam);
            }
            else if (list == 1)
            {
                Authors[Authors.IndexOf(SelectedAuthor)] = author;
                DisposeView(ref _authors);
            }
        }

        internal void Remove(int list)
        {
            if (list == 0)
            {
                RiskTeam.Remove(SelectedRiskTeam);
            }
            else if (list == 1)
            {
                Authors.Remove(SelectedAuthor);
            }
        }

        internal void Apply()
        {
            Properties.RiskTeam = RiskTeam.ToList();
            Properties.Authors = Authors.ToList();
            Anaris.Instance.ProjectProperties.Clone(Properties);
        }

        internal void Cancel()
        {
            Properties = new ProjectProperties().Clone(Anaris.Instance.ProjectProperties);

            CloneAuthorList(Anaris.Instance.ProjectProperties.Authors, Authors);
            CloneAuthorList(Anaris.Instance.ProjectProperties.RiskTeam, RiskTeam);
        }

        private void DisposeView(ref Views.Authors view)
        {
            if (view != null)
            {
                view.Close();
                view = null;
            }
        }

        public void DisposeAllViews()
        {
            DisposeView(ref _authors);
            DisposeView(ref _riskTeam);
        }

        virtual protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName)); //This will update prperty in this binded context
        }
        #endregion
    }
}
