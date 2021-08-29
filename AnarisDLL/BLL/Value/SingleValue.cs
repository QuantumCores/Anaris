using AnarisDLL.BLL.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnarisDLL.BLL.Value
{
    [Serializable]
    public class SingleValue : ViewModelBase
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

        private double _value { get; set; }
        public double value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged("value");
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


        public SingleValue Clone(SingleValue toClone)
        {
            this.description = toClone.description;
            this.name = toClone.name;
            this.text = toClone.text;
            this.value = toClone.value;

            return this;
        }

        public void Clear()
        {
            this.description = string.Empty;
            this.name = string.Empty;
            this.text = string.Empty;
            this.value = 0;
        }
    }
}
