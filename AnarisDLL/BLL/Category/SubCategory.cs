using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnarisDLL.BLL.Category
{
    [Serializable]
    public class SubCategory : INotifyPropertyChanged
    {
        private string _text { get; set; }
        public string text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged("text");
            }
        }

        private string _name { get; set; }
        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
        }

        private string _description { get; set; }
        public string description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("description");
            }
        }


        public SubCategory Clone(SubCategory toClone)
        {
            name = toClone.name;
            text = toClone.text;
            description = toClone.description;

            return this;
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
