using AnarisDLL.BLL.Database;
using AnarisDLL.BLL.Helpers;
using AnarisDLL.BLL.Value;
using AnarisEvo.Commands.ValueManager;
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
    public class ValueManagerViewModel : ViewModelBase
    {
        public ValueManagerViewModel()
        {
            Values = ReloadValues(Database.Instance.valueManager.valueList.OrderByDescending(s => s.value).ToList());
            //Values = new ObservableCollection<SingleValue>(Database.Instance.valueManager.valueList.OrderByDescending(s => s.value).ToList());
            ValuesDescription = Database.Instance.valueManager.ValuesDescription;

            NewValue = new SingleValue();
            EditedValue = new SingleValue();

            AddNewValueCommand = new AddNewValueCommand(this);
            SelectionCommand = new SelectionCommand(this);
            EditValueCommand = new EditValueCommand(this);
            ApplyCommand = new ApplyCommand(this);
            CancelCommand = new CancelCommand(this);
            DeleteCommand = new DeleteCommand(this);
        }

        #region Commands
        public ICommand AddNewValueCommand { get; set; }
        public ICommand SelectionCommand { get; set; }
        public ICommand EditValueCommand { get; set; }
        public ICommand ApplyCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        #endregion

        private ObservableCollection<SingleValue> ReloadValues(IList<SingleValue> valueList)
        {
            //reload Values from database
            if (valueList == null)
            {
                Values.Clear();
                valueList = Database.Instance.valueManager.valueList;

                foreach (SingleValue val in valueList)
                {
                    SingleValue tmp = new SingleValue();
                    tmp.description = val.description;
                    tmp.name = val.name;
                    tmp.text = val.text;
                    tmp.value = val.value;

                    Values.Add(tmp);
                }

                return Values;
            }
            else
            {
                ObservableCollection<SingleValue> values = new ObservableCollection<SingleValue>();
                foreach (SingleValue val in valueList)
                {
                    SingleValue tmp = new SingleValue();
                    tmp.description = val.description;
                    tmp.name = val.name;
                    tmp.text = val.text;
                    tmp.value = val.value;

                    values.Add(tmp);
                }

                return values;
            }
        }



        private ObservableCollection<SingleValue> _Values;
        public ObservableCollection<SingleValue> Values
        {
            get { return _Values; }
            set
            {
                _Values = value;
                OnPropertyChanged("Values");
            }
        }

        private SingleValue _EditedValue;
        public SingleValue EditedValue
        {
            get { return _EditedValue; }
            set
            {
                _EditedValue = value;
                OnPropertyChanged("EditedValue");
            }
        }

        private string _ValuesDescription;
        public string ValuesDescription
        {
            get { return _ValuesDescription; }
            set
            {
                _ValuesDescription = value;
                OnPropertyChanged("ValuesDescription");
            }
        }

        private SingleValue _NewValue;
        public SingleValue NewValue
        {
            get { return _NewValue; }
            set
            {
                _NewValue = value;
                OnPropertyChanged("_NewValue");
            }
        }


        #region Methods

        internal bool CanAddNewValue()
        {
            if (!string.IsNullOrWhiteSpace(NewValue.text) && NewValue.value != 0)
            {
                if (Values.Where(s => s.text == NewValue.text).Count() == 0)
                {
                    return true;
                }
            }

            return false;
        }

        internal void AddNewValue()
        {
            string name = string.Empty;
            do
            {
                name = RandomNameGenerator.Generate(3);
            }
            while (Values.Select(v => v.name).Contains(name));

            NewValue.name = name;
            Values.Add(new SingleValue().Clone(NewValue));
            Values = new ObservableCollection<SingleValue>(Values.OrderByDescending(s => s.value));
            NewValue.Clear();
        }


        internal void Cancel()
        {
            ValuesDescription = Database.Instance.valueManager.ValuesDescription;
            ReloadValues(null);
        }

        internal bool CanApply()
        {
            return true;
        }

        internal void Apply()
        {
            //this will apply changes only to the visible and bound observblegrids rest has to bo chaged manualy
            ObservableCollection<SingleValue> values = ReloadValues(Values);
            Services.Service.Instance.LoadValues(values, ValuesDescription);
        }

        internal void CloneSelection(SingleValue toClone)
        {
            if (toClone != null)
            {
                SingleValue tmp = new SingleValue();
                tmp.description = toClone.description;
                tmp.name = toClone.name;
                tmp.text = toClone.text;
                tmp.value = toClone.value;

                EditedValue = tmp;
            }
            else
            {
                EditedValue = new SingleValue();
            }
        }


        internal void EditValue()
        {
            SingleValue tmp = Values.Where(s => s.name == EditedValue.name).FirstOrDefault();
            tmp.description = EditedValue.description;
            tmp.name = EditedValue.name;
            tmp.text = EditedValue.text;
            tmp.value = EditedValue.value;
        }

        internal bool CanEdit()
        {
            if (!string.IsNullOrWhiteSpace(EditedValue.text) && EditedValue.value != 0)
            {
                //if (Values.Where(s => s.text == EditedValue.text).Count() == 0 || Values.FirstOrDefault(s => s.name == EditedValue.name).value)
                {
                    return true;
                }
            }

            return false;
        }

        internal bool CanDelete()
        {
            return !string.IsNullOrWhiteSpace(EditedValue.text);
        }

        internal void Delete()
        {
            var toBeDeleted = Values.FirstOrDefault(v => v.text == EditedValue.text);
            if (toBeDeleted != null)
            {
                Values.Remove(toBeDeleted);
                //Services.Service.Instance.UpdateDisplay();                
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Nie można usunąć wartości o nazwie " + EditedValue.text + " ponieważ taka wartość nie istnieje.");
            }
        }

        #endregion

    }
}
