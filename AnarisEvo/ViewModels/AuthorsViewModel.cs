using AnarisDLL.BLL.Anaris;
using AnarisDLL.BLL.Helpers;
using AnarisEvo.Commands.ProjectProperties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnarisEvo.ViewModels
{
    public class AuthorsViewModel : ViewModelBase
    {

        public AuthorsViewModel(Author author, string title, bool add, int list, Action<Author, int> saveAuthor)
        {
            Title = title;
            Add = add;
            SaveAuthor = saveAuthor;
            _List = list;

            FirstName = string.IsNullOrWhiteSpace(author.FirstName) ? "" : author.FirstName;
            LastName = string.IsNullOrWhiteSpace(author.LastName) ? "" : author.LastName;
            CellPhone = string.IsNullOrWhiteSpace(author.CellPhone) ? "" : author.CellPhone;
            WorkPhone = string.IsNullOrWhiteSpace(author.WorkPhone) ? "" : author.WorkPhone;
            Email = string.IsNullOrWhiteSpace(author.Email) ? "" : author.Email;
            JobDescription = string.IsNullOrWhiteSpace(author.JobDescription) ? "" : author.JobDescription;

            SaveAuthorCommand = new SaveAuthorCommand(this);
            ClearAuthorViewCommand = new ClearAuthorViewCommand(this);
        }

        Action<Author, int> SaveAuthor;

        public ICommand SaveAuthorCommand { get; set; }
        public ICommand ClearAuthorViewCommand { get; set; }

        public string Title { get; set; }
        public bool Add { get; set; }
        private int _List { get; set; }


        private string _FirstName { get; set; }
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string _LastName { get; set; }
        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string _CellPhone { get; set; }
        public string CellPhone
        {
            get { return _CellPhone; }
            set
            {
                _CellPhone = value;
                OnPropertyChanged("CellPhone");
            }
        }

        private string _WorkPhone { get; set; }
        public string WorkPhone
        {
            get { return _WorkPhone; }
            set
            {
                _WorkPhone = value;
                OnPropertyChanged("WorkPhone");
            }
        }

        private string _Email { get; set; }
        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                OnPropertyChanged("Email");
            }
        }

        private string _JobDescription { get; set; }
        public string JobDescription
        {
            get { return _FirstName; }
            set
            {
                _JobDescription = value;
                OnPropertyChanged("FirstName");
            }
        }


        internal bool CanAddOrEditAuthor()
        {
            return !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName);
        }

        internal void AddAuthor()
        {
            SaveAuthor(new Author() { FirstName = FirstName, LastName = LastName, CellPhone = CellPhone, Email = Email, JobDescription = JobDescription, WorkPhone = WorkPhone }, _List);
        }

        internal void Clear()
        {
            FirstName = "";
            LastName = "";
            CellPhone = "";
            WorkPhone = "";
            Email = "";
            JobDescription = "";
        }

    }
}
