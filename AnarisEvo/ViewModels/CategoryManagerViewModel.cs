using AnarisDLL.BLL.Category;
using AnarisDLL.BLL.Database;
using AnarisDLL.BLL.Helpers;
using AnarisEvo.Commands.CategoryManager;
using AnarisEvo.Converter.CategoryManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace AnarisEvo.ViewModels
{
    public class CategoryManagerViewModel : ViewModelBase
    {

        public CategoryManagerViewModel()
        {
            Categories = ReloadCategories(Database.Instance.categoryManager.List);
            CategoryTypes = new Dictionary<int, string>() { { 0, "Kategoria" }, { 1, "Podkategoria" } };

            NewCategory = new Category();
            EditedCategory = new Category();
            NewSelectedType = CategoryTypes.FirstOrDefault(kv => kv.Key == 0);

            AddNewCategoryCommand = new AddNewCategoryCommand(this);
            EditCategoryCommand = new EditCategoryCommand(this);
            CategoryToBoolConverter = new CategoryToBoolConverter();
            ApplyCommand = new ApplyCommand(this);
            DeleteCommand = new DeleteCommand(this);
            CancelCommand = new CancelCommand(this);
        }


        #region Commands
        public ICommand AddNewCategoryCommand { get; set; }
        public ICommand EditCategoryCommand { get; set; }
        public ICommand ApplyCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        #endregion

        #region Converters
        public IValueConverter CategoryToBoolConverter { get; set; }
        #endregion

        private bool _IsHidden;
        public bool IsHidden
        {
            get { return _IsHidden; }
            set { _IsHidden = value; }
        }

        private ObservableCollection<Category> _Categories;
        public ObservableCollection<Category> Categories
        {
            get { return _Categories; }
            set { _Categories = value; }
        }

        private Category _EditedCategory;
        public Category EditedCategory
        {
            get { return _EditedCategory; }
            set
            {
                _EditedCategory = value;
                OnPropertyChanged("EditedCategory");
            }
        }

        private Dictionary<int, string> _CategoryTypes;
        public Dictionary<int, string> CategoryTypes
        {
            get { return _CategoryTypes; }
            set { _CategoryTypes = value; }
        }


        private KeyValuePair<int, string> _NewSelectedType;
        public KeyValuePair<int, string> NewSelectedType
        {
            get { return _NewSelectedType; }
            set
            {
                _NewSelectedType = value;
                OnPropertyChanged("NewSelectedType");
                EnableParent = System.Convert.ToBoolean(_NewSelectedType.Key);
            }
        }

        private Category _NewCategory;
        public Category NewCategory
        {
            get { return _NewCategory; }
            set
            {
                _NewCategory = value;
                OnPropertyChanged("NewCategory");
            }
        }

        private bool _EnableParent;
        public bool EnableParent
        {
            get { return _EnableParent; }
            set
            {
                _EnableParent = value;
                OnPropertyChanged("EnableParent");
            }
        }

        #region Methods
        public void AddNewCategory(string parent)
        {
            if (NewSelectedType.Key == 0)
            {
                AddNewCategory(NewCategory, null);
            }
            else
            {
                AddNewCategory(NewCategory, parent);
            }
        }

        internal bool CanAddNewCategory(string parent)
        {
            if (string.IsNullOrWhiteSpace(NewCategory.text))
            {
                return false;
            }

            if (NewSelectedType.Key == 0 && Categories.Select(C => C.text).Contains(NewCategory.text))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(parent) && NewSelectedType.Key == 1)
            {
                return false;
            }

            if (NewSelectedType.Key == 1 && Categories.FirstOrDefault(C => C.name == parent).subCategories.Select(s => s.text).Contains(NewCategory.text))
            {
                return false;
            }

            return true;
        }


        public void AddNewCategory(Category category, string parent)
        {
            string tmp = "";
            bool isOriginal = false;


            while (!isOriginal)
            {
                isOriginal = true;
                tmp = RandomNameGenerator.Generate(DataBaseCategories.NameLength);
                isOriginal = CheckIfNameIsOriginal(tmp);
            }

            if (string.IsNullOrWhiteSpace(parent))
            {
                category.name = DataBaseCategories.Sufix + tmp;
                Categories.Add(category);
                NewCategory = new Category();
            }
            else
            {
                SubCategory sub = new SubCategory();
                sub.name = tmp;
                sub.text = category.text;
                sub.description = category.description;

                Category cat = Categories.Where(c => c.name == parent).FirstOrDefault();
                cat.subCategories.Add(sub);
                NewCategory = new Category();
            }
        }


        private bool CheckIfNameIsOriginal(string name)
        {
            bool isOriginal = true;

            if (name.Length != DataBaseCategories.NameLength)
            {
                return false;
            }

            foreach (Category cat in Categories)
            {
                if (cat.name == DataBaseCategories.Sufix + name)
                {
                    isOriginal = false;
                    break;
                }

                foreach (SubCategory sub in cat.subCategories)
                {
                    if (sub.name == name)
                    {
                        isOriginal = false;
                        break;
                    }
                }

                if (!isOriginal)
                {
                    break;
                }
            }

            return isOriginal;
        }

        internal void CloneSelection(object selected)
        {
            if (selected is Category)
            {
                Category toClone = new Category();
                toClone = (Category)selected;
                Category tmp = new Category();
                tmp.description = toClone.description;
                tmp.name = toClone.name;
                tmp.text = toClone.text;

                EditedCategory = tmp;
            }
            else if (selected is SubCategory)
            {
                SubCategory toClone = new SubCategory();
                toClone = (SubCategory)selected;
                Category tmp = new Category();
                tmp.description = toClone.description;
                tmp.name = toClone.name;
                tmp.text = toClone.text;

                EditedCategory = tmp;
            }

        }

        internal void EditCategory()
        {
            Category tmp = Categories.Where(s => s.name == EditedCategory.name).FirstOrDefault();
            if (tmp != null)
            {
                tmp.description = EditedCategory.description;
                tmp.text = EditedCategory.text;
            }
            else
            {
                SubCategory sub = Categories.FirstOrDefault(c => c.subCategories.FirstOrDefault(s => s.name == EditedCategory.name) != null).subCategories.FirstOrDefault(s => s.name == EditedCategory.name);
                sub.description = EditedCategory.description;
                sub.text = EditedCategory.text;
            }
        }


        internal bool CanDelete()
        {
            if (!string.IsNullOrWhiteSpace(EditedCategory.name))
            {
                return true;
            }

            return false;
        }

        internal void Delete()
        {
            Category tmp = Categories.Where(s => s.name == EditedCategory.name).FirstOrDefault();
            if (tmp != null)
            {
                Categories.Remove(tmp);
            }
            else
            {
                Category sub = Categories.FirstOrDefault(c => c.subCategories.FirstOrDefault(s => s.name == EditedCategory.name) != null);
                if (sub != null)
                {
                    sub.subCategories.Remove(sub.subCategories.FirstOrDefault(s => s.name == EditedCategory.name));
                }
            }
        }



        internal bool CanEdit()
        {
            if (!string.IsNullOrWhiteSpace(EditedCategory.text))
            {
                if (Categories.Where(s => s.text == EditedCategory.text).Count() == 0)
                {
                    return true;
                }
            }

            return false;
        }


        internal void Cancel()
        {
            ReloadCategories(null);
            EditedCategory = new Category();
        }

        internal void Apply()
        {
            Services.Service.Instance.ApplyCategories(Categories);
            Database.Instance.categoryManager.List = Services.Service.Instance.Categories.ToList();
        }

        private ObservableCollection<Category> ReloadCategories(IList<Category> categoryList)
        {
            if (categoryList == null)
            {
                Categories.Clear();
                categoryList = Database.Instance.categoryManager.List;

                foreach (Category cat in categoryList)
                {
                    Category tmp = new Category();
                    tmp.description = cat.description;
                    tmp.name = cat.name;
                    tmp.text = cat.text;

                    foreach (SubCategory sub in cat.subCategories)
                    {
                        SubCategory stm = new SubCategory();
                        stm.description = sub.description;
                        stm.name = sub.name;
                        stm.text = sub.text;

                        tmp.subCategories.Add(stm);
                    }

                    Categories.Add(tmp);
                }

                return Categories;
            }
            else
            {
                ObservableCollection<Category> categories = new ObservableCollection<Category>();
                foreach (Category cat in categoryList)
                {
                    Category tmp = new Category();
                    tmp.description = cat.description;
                    tmp.name = cat.name;
                    tmp.text = cat.text;

                    foreach (SubCategory sub in cat.subCategories)
                    {
                        SubCategory stm = new SubCategory();
                        stm.description = sub.description;
                        stm.name = sub.name;
                        stm.text = sub.text;

                        tmp.subCategories.Add(stm);
                    }

                    categories.Add(tmp);
                }

                return categories;
            }
        }

    }

    #endregion

}
