using AnarisDLL.BLL.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnarisDLL.BLL.AnarisGrid;
using AnarisDLL.BLL.Category;
using System.Windows.Input;
using AnarisEvo.Commands.MergeDatabase;

namespace AnarisEvo.ViewModels
{
    public class MergeDatabaseViewModel : INotifyPropertyChanged
    {
        public MergeDatabaseViewModel()
        {
            Options = new Dictionary<int, string>() { { 0, "Importuj wszystkie wiersze" }, { 1, "Importuj oryginalne wiersze" } };
            SelectedOption = Options.FirstOrDefault(s => s.Key == 0);
            MergeCommand = new MergeCommand(this);

        }


        public ICommand MergeCommand { get; set; }
        public Action Close { get; set; }

        private string _FilePath;
        public string FilePath
        {
            get { return _FilePath; }
            set
            {
                _FilePath = value;
                OnPropertyChanged("FilePath");
            }
        }

        public Dictionary<int, string> Options { get; set; }

        private KeyValuePair<int, string> _SelectedOption;
        public KeyValuePair<int, string> SelectedOption
        {
            get { return _SelectedOption; }
            set
            {
                _SelectedOption = value;
                OnPropertyChanged("SelectedOption");
            }
        }

        internal void Merge()
        {
            bool importAll = !System.Convert.ToBoolean(SelectedOption.Key);

            string version = AnarisDLL.BLL.LoadDataBase.LoadDataBase.GetTheAssemblyVersion(0, FilePath);
            Database Import = AnarisDLL.BLL.LoadDataBase.LoadDataBase.Load(version, FilePath);
            Services.Service.ConvertObservableToDatabase();
            
            Dictionary<string, int> columnMapping = Dgv.GetMappingDictionary(Database.Instance.dgv);
            Dictionary<string, int> icolumnMapping = Dgv.GetMappingDictionary(Import.dgv);
            Dictionary<int, Dictionary<string, string>> catMap = DataBaseCategories.MapCategories(Database.Instance.categoryManager, columnMapping);
            Dictionary<int, Dictionary<string, string>> iCatMap = DataBaseCategories.MapCategories(Import.categoryManager, icolumnMapping);
            Dictionary<int, Dictionary<string, string>> valueMap = Database.Instance.categoryManager.MapValues(Import.categoryManager, columnMapping);

            //here we add values mapping to the pravious category mapping for all columns
            valueMap = Database.Instance.valueManager.MapDBValues(Import.valueManager.valueList, columnMapping["Lista"], valueMap);
            catMap.Add(columnMapping["Lista"], Database.Instance.valueManager.valueList.ToDictionary(v => v.name, v => v.text));
            iCatMap.Add(icolumnMapping["Lista"], Import.valueManager.valueList.ToDictionary(v => v.name, v => v.text));

            List<DgvRow> Imported = Database.Instance.dgv.MergeDatabases(Import.dgv, importAll, catMap, iCatMap, valueMap);

            if (Imported.Count > 0)
            {                
                foreach (DgvRow r in Imported)
                {
                    ObservableRow row = new ObservableRow(0);
                    row.Clone(r);
                    AgentsViewModel.Instance.oDatabase.Rows.Add(row.Clone(r));
                }

                //Rows are already added in the merge method
                //Database.Instance.dgv.rows.InsertRange(Database.Instance.dgv.rows.Count - 1, Imported);                
                //Database.Instance.dgv.AddDataGridViewRows(Imported, newDataBase.dataGridView1);
            }

            Close();
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged = null;

        virtual protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName)); //This will update prperty in this binded context
        }
        #endregion
    }
}
