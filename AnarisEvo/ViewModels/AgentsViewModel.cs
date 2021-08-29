using AnarisDLL.BLL.Anaris;
using AnarisDLL.BLL.AnarisGrid;
using AnarisDLL.BLL.Database;
using AnarisDLL.BLL.Risk;
using AnarisEvo.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AnarisEvo.ViewModels
{
    public class AgentsViewModel : INotifyPropertyChanged
    {
        public static int[] SelectedScenario = new int[1];
        public static AgentsViewModel Instance { get; set; }

        public List<int> RecalculateColumns { get; set; }


        public AgentsViewModel()
        {
            //Load all dgvs (each agent and scenario)
            if (Anaris.Instance != null)
            {
                Risks = Anaris.Instance.RiskAnalysis.RiskAnalysis;
                AgentCount = Anaris.Instance.RiskAnalysis.RiskAnalysis.Count;
                DisplayedScenarios = new ObservableCollection<ObservableGrid>();
                SelectedScenario = new int[Risks.Count];

                for (int i = 0; i < Risks.Count; i++)
                {
                    //RiskDgvList agent = Risks[i];
                    //ObservableGrid tmp = new ObservableGrid();
                    //tmp.Clone(agent.dgvList[0]);
                    DisplayedScenarios.Add(new ObservableGrid());

                    if (Services.Service.Instance.ObservableRisks[i][0] != null)
                    {
                        DisplayedScenarios[i] = Services.Service.Instance.ObservableRisks[i][0];
                    }
                }
            }

            oDatabase = new ObservableGrid();
            oDatabase.Clone(Database.Instance.dgv);
            ObservableGrid.DatabaseColumnCount = oDatabase.Columns.Count;

            RecalculateColumns = new List<int>();
            GetRecalculableColumns();
            Instance = this;

            Services.Service.Instance.RecalculatedScenarios += UpdateMagnitudeOfRisk;
        }

        private int AgentCount = 1;
        //obesrvableCollection
        private List<RiskDgvList> Risks;

        public ObservableCollection<ObservableGrid> DisplayedScenarios { get; set; }

        //private KeyValuePair<int, string> _SelectedAgent;
        //public KeyValuePair<int, string> SelectedAgent
        //{
        //    get { return _SelectedAgent; }
        //    set { _SelectedAgent = value; }
        //}

        private ObservableGrid _oDatabase { get; set; }
        public ObservableGrid oDatabase
        {
            get { return _oDatabase; }
            set { _oDatabase = value; }
        }


        public ObservableRow RightClickRow { get; set; }

        private static int _EditedColumn { get; set; }
        public static int EditedColumn
        {
            get { return _EditedColumn; }
            set
            {
                _EditedColumn = value;
            }
        }

        private static int _EditedRow { get; set; }
        public static int EditedRow
        {
            get { return _EditedRow; }
            set { _EditedRow = value; }
        }


        public bool MenuEnabled
        {
            get
            {
                bool enable = false;
                if (MainWindowViewModel.SelectedAgent > -1)
                {
                    enable = (AgentsViewModel.SelectedScenario[MainWindowViewModel.SelectedAgent] == 0) ? true : false;
                }

                return enable;
            }
            set { }

        }

        private double _MagnitudeOfRisk { get; set; }
        public double MagnitudeOfRisk
        {
            get { return _MagnitudeOfRisk; }
            set
            {
                _MagnitudeOfRisk = value;
                OnPropertyChanged("MagnitudeOfRisk");
            }
        }

        public void ChangeDisplayedScenario()
        {
            int scenarioIndex = SelectedScenario[MainWindowViewModel.SelectedAgent];
            DisplayedScenarios[MainWindowViewModel.SelectedAgent] = Services.Service.Instance.ObservableRisks[MainWindowViewModel.SelectedAgent][scenarioIndex];
            MagnitudeOfRisk = DisplayedScenarios[MainWindowViewModel.SelectedAgent].MR;
        }

        //private ObservableCell FormulaCell { get; set; }
        private ObservableRow FormulaRow { get; set; }
        private int FormulaCellIndex { get; set; }
        private bool LockFormula { get; set; }

        private bool _IsFormulaEnabled { get; set; }
        public bool IsFormulaEnabled
        {
            get { return _IsFormulaEnabled; }
            set
            {
                _IsFormulaEnabled = value;
                OnPropertyChanged(nameof(IsFormulaEnabled));
            }
        }


        private double _FormulaNumber { get; set; }
        public double FormulaNumber
        {
            get { return _FormulaNumber; }
            set
            {
                _FormulaNumber = value;
                if (!LockFormula && IsFormulaEnabled && SetNewValue())
                    ObservableCell.SetNewFormula(FormulaRow.Cells[FormulaCellIndex], _FormulaColumn, value);
                OnPropertyChanged(nameof(FormulaNumber));
            }
        }

        private string _FormulaColumn { get; set; }
        public string FormulaColumn
        {
            get { return _FormulaColumn; }
            set
            {
                _FormulaColumn = value;
                if (!LockFormula && IsFormulaEnabled && SetNewValue())
                    ObservableCell.SetNewFormula(FormulaRow.Cells[FormulaCellIndex], value, _FormulaNumber);
                OnPropertyChanged(nameof(FormulaColumn));
            }
        }

        private bool SetNewValue()
        {
            DgvColumn column = oDatabase.Columns.FirstOrDefault(o => o.headerText == _FormulaColumn);
            if (column != null && _FormulaNumber > 0)
            {
                double refNumber = 0;
                if (double.TryParse(FormulaRow.Cells[column.index].Value, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.CurrentCulture, out refNumber))
                {
                    FormulaRow.Cells[FormulaCellIndex].Block = true;
                    FormulaRow.Cells[FormulaCellIndex].Value = Math.Round((refNumber * _FormulaNumber), 2).ToString();
                    FormulaRow.Cells[FormulaCellIndex].Block = false;
                    return true;
                }
            }

            return false;
        }

        public void SetFormulaCell(int rowIndex, int columnIndex)
        {

            if (columnIndex >= oDatabase.Columns.Count)
            {
                IsFormulaEnabled = true;
                FormulaRow = DisplayedScenarios[MainWindowViewModel.SelectedAgent].Rows[rowIndex];
                FormulaCellIndex = columnIndex;

                //FormulaRow.Cells[columnIndex].Block = true;
                KeyValuePair<string, double> values = ObservableCell.DecomposeFormula(FormulaRow.Cells[columnIndex]);

                LockFormula = true;
                FormulaColumn = values.Key;
                FormulaNumber = values.Value;
                LockFormula = false;
                //FormulaRow.Cells[columnIndex].Block = false;
            }
            else
            {
                LockFormula = true;
                IsFormulaEnabled = false;
                FormulaColumn = "";
                FormulaNumber = 0;
                LockFormula = false;
            }
        }

        public void GetRecalculableColumns()
        {
            RecalculateColumns.Clear();

            foreach (DgvColumn col in oDatabase.Columns)
            {
                if (col.name == "Number" || col.name == "Lista")
                {
                    RecalculateColumns.Add(col.index);
                }
            }

            RecalculateColumns.Add(oDatabase.Columns.Count);
            RecalculateColumns.Add(oDatabase.Columns.Count + 1);
            RecalculateColumns.Add(oDatabase.Columns.Count + 2);
        }

        private void UpdateMagnitudeOfRisk(IList<ElementaryRisk> list)
        {
            int i = SelectedScenario[MainWindowViewModel.SelectedAgent];
            if (i > 0)
            {
                MagnitudeOfRisk = Services.Service.Instance.Scenarios[MainWindowViewModel.SelectedAgent][i - 1].MM;
            }
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



