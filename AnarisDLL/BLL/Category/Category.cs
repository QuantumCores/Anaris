using AnarisDLL.BLL.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AnarisDLL.BLL.Category
{
    [Serializable]
    public class Category: ViewModelBase
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

        private ObservableCollection<SubCategory> _subCategories { get; set; }
        public ObservableCollection<SubCategory> subCategories
        {
            get { return _subCategories; }
            set
            {
                _subCategories = value;
                OnPropertyChanged("subCategories");
            }
        }

        public Category()
        {
            subCategories = new ObservableCollection<SubCategory>();
        }

        public Category Clone(Category toClone)
        {            
            name = toClone.name;
            text = toClone.text;
            description = toClone.description;

            foreach (SubCategory sub in toClone.subCategories)
            {
                subCategories.Add(new SubCategory().Clone(sub));
            }

            return this;
        }

       
    }
}
