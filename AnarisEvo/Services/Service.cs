using AnarisDLL.BLL.Anaris;
using AnarisDLL.BLL.AnarisGrid;
using AnarisDLL.BLL.Category;
using AnarisDLL.BLL.Database;
using AnarisDLL.BLL.Helpers;
using AnarisDLL.BLL.Risk;
using AnarisDLL.BLL.Value;
using AnarisEvo.Helpers;
using AnarisEvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnarisEvo.Services
{

    public class Service : ViewModelBase
    {

        public static Service Instance { get; set; }
        public List<List<ObservableGrid>> ObservableRisks { get; set; }
        public Dictionary<string, double> ValuesDictionary { get; set; }

        public delegate void UpdatedScenariosDelegate(List<ObservableCollection<ElementaryRisk>> scenarios);
        public event UpdatedScenariosDelegate UpdatedScenarios;

        public delegate void RecalculatedScenariosEvent(List<ElementaryRisk> scenarios);
        public event RecalculatedScenariosEvent RecalculatedScenarios;

        private ObservableCollection<SingleValue> _Values { get; set; }
        public ObservableCollection<SingleValue> Values
        {
            get { return _Values; }
            set
            {
                _Values = value;
                OnPropertyChanged("Values");
            }
        }


        private ObservableCollection<Category> _Categories { get; set; }
        public ObservableCollection<Category> Categories
        {
            get { return _Categories; }
            set
            {
                _Categories = value;
                OnPropertyChanged("Categories");
            }
        }

        private ObservableCollection<Category> _ValuePieCategories { get; set; }
        public ObservableCollection<Category> ValuePieCategories
        {
            get { return _ValuePieCategories; }
            set
            {
                _ValuePieCategories = value;
                OnPropertyChanged("ValuePieCategories");
            }
        }

        private List<KeyValuePair<int, string>> _TornadoChartAgents { get; set; }
        public List<KeyValuePair<int, string>> TornadoChartAgents
        {
            get { return _TornadoChartAgents; }
            set
            {
                _TornadoChartAgents = value;
                OnPropertyChanged("TornadoChartAgents");
            }
        }

        public List<ObservableCollection<ElementaryRisk>> Scenarios { get; set; }


        public ObservableCollection<KeyValuePair<string, double>> PieChartData { get; set; }


        public Service()
        {
            Instance = this;
            ObservableRisks = new List<List<ObservableGrid>>();
            PieChartData = new ObservableCollection<KeyValuePair<string, double>>();
            ValuePieCategories = new ObservableCollection<Category>();
            TornadoChartAgents = new List<KeyValuePair<int, string>>();
            Values = new ObservableCollection<SingleValue>();
            Categories = new ObservableCollection<Category>();
        }


        public void SetUpData()
        {
            LoadValues(Database.Instance.valueManager.valueList.OrderByDescending(s => s.value).ToList(), Database.Instance.valueManager.ValuesDescription);
            LoadCategories(Database.Instance.categoryManager.List);
            UpdateValuePieCategories();

            if (Anaris.Instance != null)
            {
                ConvertRisksToObservable();
                Scenarios = LoadScenarios(null);
                UpdateTornadoChartAgents();

            }
        }

        public void LoadValues(IList<SingleValue> values, string valuesDescription)
        {
            if (values != null)
            {
                Values.Clear();
                foreach (SingleValue val in values)
                {
                    Values.Add(val);
                }
                LoadValuesDictionary();

                Database.Instance.valueManager.ValuesDescription = valuesDescription;
                Database.Instance.valueManager.valueList = values.ToList();
            }

            if (AgentsViewModel.Instance != null)
            {
                AgentsViewModel.Instance.oDatabase.CalculateTotalNumber();
                AgentsViewModel.Instance.oDatabase.CalculateTotalValue(this.ValuesDictionary);
            }
        }


        private void LoadValuesDictionary()
        {
            ValuesDictionary = Values.ToDictionary(v => v.name, v => v.value);
        }

        public void LoadCategories(IList<Category> categoryList)
        {
            Categories.Clear();

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

        }

        public List<ObservableCollection<ElementaryRisk>> LoadScenarios(IList<ObservableCollection<ElementaryRisk>> viewScenarios)
        {
            List<ObservableCollection<ElementaryRisk>> scenarios = new List<ObservableCollection<ElementaryRisk>>();

            if (viewScenarios == null)
            {
                viewScenarios = Anaris.Instance.ScenarioManager.Risks.Select(r => r.DistinctiveRisk).ToList();
            }

            for (int i = 0; i < viewScenarios.Count; i++)
            {
                scenarios.Add(new ObservableCollection<ElementaryRisk>());
                foreach (ElementaryRisk elr in Anaris.Instance.ScenarioManager.Risks[i].DistinctiveRisk)
                {
                    ElementaryRisk tmp = new ElementaryRisk().Clone(elr);
                    scenarios[i].Add(tmp);
                }
            }

            return scenarios;
        }


        public void LoadPieChartData(string categoryName)
        {
            Dictionary<string, double> dataSplit = new Dictionary<string, double>();
            if (categoryName == "Grupa")
            {
                dataSplit = AnarisDLL.BLL.PieChartHelper.LoadDataByNameValue(AgentsViewModel.Instance.oDatabase, ValuesDictionary);
            }
            else
            {
                dataSplit = AnarisDLL.BLL.PieChartHelper.LoadDataByCategoryValue(AgentsViewModel.Instance.oDatabase, Categories, categoryName, ValuesDictionary);
            }

            PieChartData.Clear();

            //double TotalSum = dataSplit.Sum(p => p.Value);
            double TotalSum = AgentsViewModel.Instance.oDatabase.CollectionTotalValue;
            foreach (KeyValuePair<string, double> data in dataSplit)
            {
                PieChartData.Add(new KeyValuePair<string, double>(data.Key + " - " + string.Format("{0:N2}", (data.Value * 100 / TotalSum)), data.Value));
            }
        }

        public byte[] LoadTornadoChartImage(int sort, int riskIndex, int width, int height)
        {
            //1000, 600
            //LoadTornadoChartData(sort, riskIndex);
            System.Windows.Forms.DataVisualization.Charting.Chart chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart.Size = new System.Drawing.Size(width, height);
            chart.BorderlineColor = System.Drawing.Color.White;
            chart.Margin = new System.Windows.Forms.Padding() { All = 0 };

            chart.Legends.Add("Legend");

            chart.ChartAreas.Add("ChartArea");

            System.Drawing.Font tickFont = new Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold);
            System.Windows.Forms.DataVisualization.Charting.Axis[] axes = new System.Windows.Forms.DataVisualization.Charting.Axis[4];
            System.Windows.Forms.DataVisualization.Charting.Axis X = new System.Windows.Forms.DataVisualization.Charting.Axis();
            X.Title = "Scenariusz";
            X.TitleFont = tickFont;
            X.Interval = 1;
            axes[0] = X;
            System.Windows.Forms.DataVisualization.Charting.Axis Y = new System.Windows.Forms.DataVisualization.Charting.Axis();
            Y.Title = "Wielkość ryzyka";
            Y.TitleFont = tickFont;
            Y.Maximum = 15;
            Y.Interval = 5;
            axes[1] = Y;
            System.Windows.Forms.DataVisualization.Charting.Axis x = new System.Windows.Forms.DataVisualization.Charting.Axis();
            axes[2] = x;
            System.Windows.Forms.DataVisualization.Charting.Axis y = new System.Windows.Forms.DataVisualization.Charting.Axis();
            y.Interval = 1;
            y.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            axes[3] = y;

            chart.ChartAreas[0].Axes = axes;
            chart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            chart.ChartAreas[0].AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chart.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.FromArgb(122, 122, 122);

            chart.Series.Add("Składowa A");
            chart.Series.Add("Składowa B");
            chart.Series.Add("Składowa C");

            chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            chart.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            chart.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;


            chart.Titles.Add("Title");
            chart.Titles[0].Text = riskIndex < 0 ? TornadoChartAgents[0].Value : TornadoChartAgents[riskIndex + 1].Value;
            System.Drawing.Font font = new Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold);
            chart.Titles[0].Font = font;

            chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            List<Color> allColors = AnarisDLL.BLL.PieChartHelper.GetCustomPalette();
            List<Color> selected = new List<Color>();
            selected.Add(allColors[7]);
            selected.Add(allColors[1]);
            selected.Add(allColors[0]);
            chart.PaletteCustomColors = selected.ToArray();

            IEnumerable<ElementaryRisk> Ordered = new List<ElementaryRisk>();

            if (riskIndex == -2)//Report
            {
                Ordered = Scenarios.SelectMany(er => er).Where(er => er.Print);
                //Ordered = Anaris.Instance.ScenarioManager.Risks.SelectMany(er => er.DistinctiveRisk).Where(er => er.Print);
            }
            else if (riskIndex == -1)//All
            {
                Ordered = Scenarios.SelectMany(er => er);
                //Ordered = Anaris.Instance.ScenarioManager.Risks.SelectMany(er => er.DistinctiveRisk);
            }
            else //Single Agent
            {
                Ordered = Scenarios[riskIndex];
                //Ordered = Anaris.Instance.ScenarioManager.Risks[riskIndex].DistinctiveRisk;
            }

            switch (sort)
            {
                case 1:
                    Ordered = Ordered.OrderBy(dr => dr.AMM);
                    break;
                case 2:
                    Ordered = Ordered.OrderBy(dr => dr.BMM);
                    break;
                case 3:
                    Ordered = Ordered.OrderBy(dr => dr.CMM);
                    break;
                case 0:
                    Ordered = Ordered.OrderBy(dr => (dr.AMM + dr.BMM + dr.CMM));
                    break;
                default:
                    Ordered = Ordered.OrderBy(dr => (dr.AMM + dr.BMM + dr.CMM));
                    break;
            };

            foreach (ElementaryRisk er in Ordered)
            {
                chart.Series[0].Points.AddXY(er.Text, er.AMM);
                chart.Series[1].Points.AddXY(er.Text, er.BMM);
                chart.Series[2].Points.AddXY(er.Text, er.CMM);
            }

            //using (MemoryStream ms = new MemoryStream())
            //{
            //    chart.SaveImage(@"C:\Users\Primus\Desktop\Anaris\Img_Agent_" + riskIndex + ".bmp", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Bmp);
            //}

            using (MemoryStream ms = new MemoryStream())
            {
                chart.SaveImage(ms, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Bmp);
                return ms.ToArray();
            }



        }

        public byte[] LoadPieChartImage(string categoryName)
        {
            System.Windows.Forms.DataVisualization.Charting.Chart chr_PieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chr_PieChart.Size = new System.Drawing.Size(1000, 600);
            chr_PieChart.BorderlineColor = System.Drawing.Color.White;
            chr_PieChart.Margin = new System.Windows.Forms.Padding() { All = 0 };

            chr_PieChart.Series.Add("PieChartSerie");
            //chr_PieChart.Series[0].CustomProperties = "PieLabelStyle=Outside";
            chr_PieChart.Series[0]["PieLabelStyle"] = "Outside";
            chr_PieChart.Series[0]["PieLineColor"] = "Black";
            chr_PieChart.Series[0].SmartLabelStyle.Enabled = true;
            chr_PieChart.Series[0].SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.No;
            chr_PieChart.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chr_PieChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            chr_PieChart.Series[0].IsVisibleInLegend = true;
            chr_PieChart.Series[0].IsVisibleInLegend = false;
            chr_PieChart.Series[0].Font = new System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, 12.5f, System.Drawing.FontStyle.Regular);

            chr_PieChart.Titles.Add("Title");
            chr_PieChart.Titles[0].Text = "Diagram kołowy wartości - " + ValuePieCategories.FirstOrDefault(c => c.name == categoryName).text;
            System.Drawing.Font font = new Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold);
            chr_PieChart.Titles[0].Font = font;
            chr_PieChart.ChartAreas.Add("ChartArea");
            chr_PieChart.ChartAreas[0].Area3DStyle.Enable3D = true;
            chr_PieChart.ChartAreas[0].Area3DStyle.Inclination = 0;

            chr_PieChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            chr_PieChart.PaletteCustomColors = AnarisDLL.BLL.PieChartHelper.GetCustomPalette().ToArray();

            Dictionary<string, double> dataSplit = new Dictionary<string, double>();
            if (categoryName == "Grupa")
            {
                dataSplit = AnarisDLL.BLL.PieChartHelper.LoadDataByNameValue(AgentsViewModel.Instance.oDatabase, ValuesDictionary);
            }
            else
            {
                dataSplit = AnarisDLL.BLL.PieChartHelper.LoadDataByCategoryValue(AgentsViewModel.Instance.oDatabase, Categories, categoryName, ValuesDictionary);
            }
            //double TotalSum = dataSplit.Sum(p => p.Value);
            double TotalSum = AgentsViewModel.Instance.oDatabase.CollectionTotalValue;

            foreach (KeyValuePair<string, double> pair in dataSplit)
            {
                double value = Math.Round(pair.Value / TotalSum * 100, 1);
                chr_PieChart.Series["PieChartSerie"].Points.AddXY(pair.Key + ": " + value.ToString() + "%", pair.Value);
            }

            using (MemoryStream ms = new MemoryStream())
            {
                chr_PieChart.SaveImage(ms, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Bmp);
                return ms.ToArray();
            }
        }

        public void ApplyScenarios(IList<ObservableCollection<ElementaryRisk>> viewScenarios)
        {

            //First remove scenarios
            for (int i = 0; i < viewScenarios.Count; i++)
            {
                ObservableCollection<ElementaryRisk> risk = viewScenarios[i];
                string[] future = risk.Select(s => s.Name).ToArray();
                List<ElementaryRisk> Rmv = Scenarios[i].Where(s => !future.Contains(s.Name)).ToList();

                foreach (ElementaryRisk elr in Rmv)
                {
                    Scenarios[i].Remove(elr);
                    ObservableGrid rmv = ObservableRisks[i].FirstOrDefault(o => o.Name == elr.Name);
                    int deletedIndex = ObservableRisks[i].IndexOf(rmv);
                    if (AgentsViewModel.SelectedScenario[i] == deletedIndex)
                    {
                        AgentsViewModel.SelectedScenario[i] = 0;
                        AgentsViewModel.Instance.ChangeDisplayedScenario();
                    }

                    ObservableRisks[i].Remove(rmv);
                }
            }

            //Next Add or Update scenarios           
            for (int i = 0; i < viewScenarios.Count; i++)
            {

                for (int j = 0; j < viewScenarios[i].Count; j++)
                {
                    ElementaryRisk elr = viewScenarios[i][j];
                    ElementaryRisk upd = Scenarios[i].FirstOrDefault(s => s.Name == elr.Name);

                    if (upd != null)
                    {
                        upd.Clone(elr);
                        ObservableRisks[i].FirstOrDefault(o => o.Name == elr.Name).Text = elr.Text;

                    }
                    else
                    {
                        ElementaryRisk tmp = new ElementaryRisk().Clone(elr);
                        Scenarios[i].Insert(j, tmp);
                        ObservableRisks[i].Add(new ObservableGrid().CreateScenarioGrid(ObservableRisks[i][0], elr.Name, elr.Text));
                    }
                }
            }

            MainWindowViewModel.Instance.UpdateScenarios();
            UpdatedScenarios?.Invoke(this.Scenarios);
        }

        private void UpdateTornadoChartAgents()
        {
            TornadoChartAgents.Clear();

            //SingleRisk grupa = new SingleRisk() { name = "Wszystkie" };            
            TornadoChartAgents.Add(new KeyValuePair<int, string>(1, "Wszystkie"));

            for (int i = 0; i < Anaris.Instance.ScenarioManager.Risks.Count; i++)
            {
                //SingleRisk tmp = new SingleRisk().Clone(sir);
                TornadoChartAgents.Add(new KeyValuePair<int, string>(i + 1, Anaris.Instance.ScenarioManager.Risks[i].name));
            }
        }


        public void ApplyCategories(IList<Category> viewCategories)
        {
            //First remove columns
            string[] future = viewCategories.Select(c => c.name).ToArray();
            List<Category> Rmv = Categories.Where(c => !future.Contains(c.name)).ToList();

            foreach (Category cat in Rmv)
            {
                Categories.Remove(cat);
                AgentsViewModel.Instance.oDatabase.RemoveColumn(cat.name);
                --ObservableGrid.DatabaseColumnCount;

                foreach (List<ObservableGrid> risk in ObservableRisks)
                {
                    foreach (ObservableGrid grid in risk)
                    {
                        grid.RemoveColumn(cat.name);
                    }
                }
            }

            //Next update columns
            List<Category> Add = new List<Category>();
            for (int i = 0; i < viewCategories.Count; i++)
            {
                Category cat = viewCategories[i];
                Category upd = Categories.FirstOrDefault(c => c.name == cat.name);

                if (upd != null)
                {
                    upd.text = cat.text;
                    upd.description = cat.description;

                    foreach (SubCategory sub in cat.subCategories)
                    {
                        SubCategory ups = upd.subCategories.FirstOrDefault(s => s.name == sub.name);

                        if (ups != null)
                        {
                            ups.text = sub.text;
                            ups.description = sub.description;
                        }
                        else
                        {
                            upd.subCategories.Add(new SubCategory().Clone(sub));
                        }
                    }

                    string[] subFuture = cat.subCategories.Select(s => s.name).ToArray();
                    List<SubCategory> subRmv = upd.subCategories.Where(s => !subFuture.Contains(s.name)).ToList();

                    subRmv.ForEach(s => UpdateAllCells(upd.name, s.name));
                    subRmv.ForEach(s => upd.subCategories.Remove(s));

                }
                else
                {
                    Category tmp = new Category().Clone(cat);
                    Add.Add(tmp);
                    Categories.Insert(i, tmp);
                }
            }

            //Last add columns
            string[] addHeaders = Add.Select(a => a.name).ToArray();
            for (int i = 0; i < viewCategories.Count; i++)
            {
                Category cat = viewCategories[i];

                if (addHeaders.Contains(cat.name))
                {
                    AgentsViewModel.Instance.oDatabase.AddNewColumn(i + 2, cat.text.Length * 5 + 10, cat);
                    ++ObservableGrid.DatabaseColumnCount;

                    foreach (List<ObservableGrid> risk in ObservableRisks)
                    {
                        foreach (ObservableGrid grid in risk)
                        {
                            grid.AddNewColumn(i + 2, cat.text.Length * 5 + 10, cat);
                        }
                    }
                }
            }

            AgentsViewModel.Instance.GetRecalculableColumns();
            GridBuilder.AdaptGridsToCategories(Add, Rmv, viewCategories);
            UpdateValuePieCategories();
        }


        private void UpdateValuePieCategories()
        {
            ValuePieCategories.Clear();

            Category grupa = new Category() { name = "Grupa", text = "Grupa" };
            ValuePieCategories.Add(grupa);

            foreach (Category cat in Categories)
            {
                Category tmp = new Category().Clone(cat);
                ValuePieCategories.Add(tmp);
            }
        }

        private void UpdateAllCells(string categoryName, string subName)
        {
            int colId = AgentsViewModel.Instance.oDatabase.Columns.FirstOrDefault(c => c.name == categoryName).index;
            int agent = 0;

            foreach (List<ObservableGrid> risk in ObservableRisks)
            {
                int i = 0;
                foreach (ObservableGrid scenario in risk)
                {
                    foreach (ObservableRow row in scenario.Rows)
                    {
                        if (row.Cells[colId].Value == subName)
                        {
                            row.Cells[colId].Value = string.Empty;
                        }
                    }

                    i++;
                }
                agent++;
            }

            foreach (ObservableRow row in AgentsViewModel.Instance.oDatabase.Rows)
            {
                if (row.Cells[colId].Value == subName)
                {
                    row.Cells[colId].Value = string.Empty;
                }
            }

        }

        public void BindEvents()
        {
            AgentsViewModel.Instance.oDatabase.Rows.CollectionChanged += AllRows_CollectionChanged;
        }

        public void ConvertRisksToObservable()
        {
            List<RiskDgvList> Risks = Anaris.Instance.RiskAnalysis.RiskAnalysis;

            for (int i = 0; i < Risks.Count; i++)
            {
                RiskDgvList agent = Risks[i];
                List<ObservableGrid> Agent = new List<ObservableGrid>();

                for (int j = 0; j < agent.dgvList.Count; j++)
                {
                    ObservableGrid tmp = new ObservableGrid();
                    tmp.Clone(agent.dgvList[j]);
                    Agent.Add(tmp);
                }

                ObservableRisks.Add(Agent);
            }
        }

        private static void ConvertObservableToValues()
        {
            Database.Instance.valueManager.valueList = Instance.Values.ToList();
        }

        private static void ConvertObservableToCategories()
        {
            Database.Instance.categoryManager.List = Instance.Categories.ToList();
        }

        internal static void ConvertObservableToScenarios()
        {
            for (int i = 0; i < Instance.Scenarios.Count; i++)
            {
                ObservableCollection<ElementaryRisk> scenarios = new ObservableCollection<ElementaryRisk>();
                foreach (ElementaryRisk elr in Instance.Scenarios[i])
                {
                    ElementaryRisk tmp = new ElementaryRisk().Clone(elr);
                    scenarios.Add(tmp);
                }

                Anaris.Instance.ScenarioManager.Risks[i].DistinctiveRisk = scenarios;
            }
        }

        public static void ConvertObservableToDatabase()
        {
            ConvertObservableToValues();
            ConvertObservableToCategories();
            Database.Instance.dgv = AgentsViewModel.Instance.oDatabase.Convert();
        }


        public static void ConvertObservableToAnaris()
        {
            ConvertObservableToRisks();
            ConvertObservableToScenarios();
            ConvertObservableToDatabase();
        }

        private static void ConvertObservableToRisks()
        {
            for (int i = 0; i < Anaris.Instance.RiskAnalysis.RiskAnalysis.Count; i++)
            {
                List<Dgv> oldList = Anaris.Instance.RiskAnalysis.RiskAnalysis[i].dgvList;
                List<Dgv> list = new List<Dgv>();

                for (int j = 0; j < Instance.ObservableRisks[i].Count; j++)
                {
                    Dgv tmp = Instance.ObservableRisks[i][j].Convert();
                    list.Add(tmp);
                }

                Anaris.Instance.RiskAnalysis.RiskAnalysis[i].dgvList = list;
            }

        }

        public void UpdateAllGrids(string value)
        {
            string name = AgentsViewModel.Instance.oDatabase.Rows[AgentsViewModel.EditedRow].Name;
            //string value = AgentsViewModel.Instance.oDatabase.Rows[AgentsViewModel.EditedRow].Cells[AgentsViewModel.EditedColumn].Value;
            //string formula = AgentsViewModel.Instance.oDatabase.Rows[AgentsViewModel.EditedRow].Cells[AgentsViewModel.EditedColumn].Value;
            AgentsViewModel.Instance.oDatabase.Rows[AgentsViewModel.EditedRow].Cells[AgentsViewModel.EditedColumn].Value = value;

            int agent = 0;
            foreach (List<ObservableGrid> risk in ObservableRisks)
            {
                int i = 0;
                foreach (ObservableGrid scenario in risk)
                {
                    ObservableRow row = ObservableRisks[agent][i][name];

                    if (row.IsDBrow)
                    {
                        foreach (string kid in row.ChildRows)
                        {
                            var tmp = ObservableRisks[agent][i][kid];
                            tmp.Cells[AgentsViewModel.EditedColumn].Value = value;
                        }
                    }

                    row.Cells[AgentsViewModel.EditedColumn].Value = value;

                    i++;
                }
                agent++;
            }
        }

        public void RecalculateAllGrids()
        {
            if (AgentsViewModel.Instance.RecalculateColumns.Contains(AgentsViewModel.EditedColumn))
            {
                AgentsViewModel.Instance.oDatabase.CalculateTotalNumber();
                AgentsViewModel.Instance.oDatabase.CalculateTotalValue(this.ValuesDictionary);

                int agent = 0;
                foreach (List<ObservableGrid> risk in ObservableRisks)
                {
                    int i = 0;
                    foreach (ObservableGrid scenario in risk)
                    {
                        if (AgentsViewModel.EditedColumn <= AgentsViewModel.Instance.oDatabase.Columns.Count)// we are not editing cmin cmid cmax values
                        {
                            scenario.CollectionTotalNumber = AgentsViewModel.Instance.oDatabase.CollectionTotalNumber;
                            scenario.CollectionTotalValue = AgentsViewModel.Instance.oDatabase.CollectionTotalValue;
                            //scenario.CalculateTotalNumber();
                            //scenario.CalculateTotalValue(this.ValuesDictionary);
                        }

                        if (i > 0)
                        {
                            scenario.CalculateMagnitudeOfRisk(this.ValuesDictionary, Scenarios[agent][i - 1]);
                        }
                        i++;
                    }
                    agent++;
                }

            }

        }


        public void UpdateDerivedGrids(string value)
        {
            int agent = MainWindowViewModel.SelectedAgent;
            string name = ObservableRisks[agent][0].Rows[AgentsViewModel.EditedRow].Name;
            //string value = ObservableRisks[agent][0].Rows[AgentsViewModel.EditedRow].Cells[AgentsViewModel.EditedColumn].Value;
            //string formula = ObservableRisks[agent][0].Rows[AgentsViewModel.EditedRow].Cells[AgentsViewModel.EditedColumn].Value;

            if (AgentsViewModel.EditedColumn < AgentsViewModel.Instance.oDatabase.Columns.Count)//<=
            {
                ObservableRisks[agent][0].Rows[AgentsViewModel.EditedRow].Cells[AgentsViewModel.EditedColumn].Value = value;
            }

            for (int i = 1; i < ObservableRisks[agent].Count; i++)
            {
                ObservableCell cell = ObservableRisks[agent][i][name].Cells[AgentsViewModel.EditedColumn];
                cell.Value = value;
                //cell.Formula = formula;
            }
        }

        public void RecalculateDerivedGrids(bool recalculateAllScenarios)
        {
            int agent = MainWindowViewModel.SelectedAgent;
            List<ElementaryRisk> updated = new List<ElementaryRisk>();

            if (!recalculateAllScenarios)
            {
                int i = MainWindowViewModel.Instance.SelectedScenario.Key;
                ObservableRisks[agent][i].CalculateMagnitudeOfRisk(this.ValuesDictionary, Scenarios[agent][i - 1]);
                updated.Add(Scenarios[agent][i - 1]);
            }
            else
            {
                for (int i = 1; i < ObservableRisks[agent].Count; i++)
                {
                    ObservableGrid scenario = ObservableRisks[agent][i];
                    //if (AgentsViewModel.EditedColumn <= AgentsViewModel.Instance.oDatabase.Columns.Count)
                    //{
                    //we should not recalculate here because we are repeating the calculations that are performed only on DB
                    //scenario.CalculateTotalNumber();
                    //scenario.CalculateTotalValue(this.ValuesDictionary);
                    //}

                    if (i > 0)
                    {
                        //scenario.CalculateMagnitudeOfRisk(this.ValuesDictionary, Anaris.Instance.ScenarioManager.Risks[agent].DistinctiveRisk[i - 1]);
                        scenario.CalculateMagnitudeOfRisk(this.ValuesDictionary, Scenarios[agent][i - 1]);
                        updated.Add(Scenarios[agent][i - 1]);
                    }
                }
            }

            if (updated.Any() && RecalculatedScenarios != null)
            {
                RecalculatedScenarios(updated);
            }
        }

        private void AllRows_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //observable gird event will add the row 
            //this event will add rows to all other grids
            //add remove rows in all grids

            string name = AgentsViewModel.Instance.oDatabase.Rows.Last().Name;

            int agent = 0;
            foreach (List<ObservableGrid> risk in ObservableRisks)
            {
                int i = 0;
                foreach (ObservableGrid scenario in risk)
                {
                    if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                    {
                        int columns = (i == 0) ? ObservableRisks[agent][0].Columns.Count : ObservableRisks[agent][i].Columns.Count;
                        ObservableRow row = ObservableRisks[agent][i].CreateNewRow(columns, name, true, string.Empty); // Rows.Add(new ObservableRow() { Name = name, IsDBrow = true, IsARrow = false })
                        ObservableRisks[agent][i].Rows.Add(row);
                        //cell.Formula = formula;
                    }

                    if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                    {

                    }

                    i++;
                }
                agent++;
            }

        }

        public void DatabaseRow_Add(string name)
        {
            var db = AgentsViewModel.Instance.oDatabase;
            int DBcolumns = db.Columns.Count;
            string rowName = RandomNameGenerator.GenerateAndCheck(ObservableRisks.SelectMany(s => s).ToList(), ObservableGrid.DBRowNameLength);

            for (int agent = 0; agent < ObservableRisks.Count; agent++)
            {
                for (int i = 0; i < ObservableRisks[agent].Count; i++)
                {
                    ObservableGrid scenario = ObservableRisks[agent][i];
                    ObservableRow r = scenario[name];
                    int ix = scenario.Rows.IndexOf(r);

                    ObservableRow tmp = scenario.CreateNewRow(DBcolumns + 3, rowName, true, string.Empty);
                    scenario.Rows.Insert(ix, tmp);
                }
            }

            ObservableRow DBrow = AgentsViewModel.Instance.oDatabase.CreateNewRow(DBcolumns, rowName, true, string.Empty);
            int index = db.Rows.IndexOf(db[name]);
            db.Rows.Insert(index, DBrow);

        }

        public void DerivedRow_Split(string parentName)
        {
            int agent = MainWindowViewModel.SelectedAgent;
            ObservableRow row = new ObservableRow();

            ObservableRow parent = ObservableRisks[agent][0][parentName];
            int index = ObservableRisks[agent][0].Rows.IndexOf(parent) + parent.ChildRows.Count + 1;

            for (int i = 0; i < ObservableRisks[agent].Count; i++)
            {

                int columns = (i == 0) ? ObservableRisks[agent][0].Columns.Count : ObservableRisks[agent][i].Columns.Count;
                if (string.IsNullOrWhiteSpace(row.Name))
                {
                    row = ObservableRisks[agent][i].AddNewChildRow(parent, columns, string.Empty);
                }
                //else
                //{
                //    row = ObservableRisks[agent][i].AddNewChildRow(parent, columns, row.Name);
                //}

                ObservableRisks[agent][i].Rows.Insert(index, row);

            }

        }

        public void DatabaseRow_Delete(string name)
        {

            for (int agent = 0; agent < ObservableRisks.Count; agent++)
            {
                for (int i = 0; i < ObservableRisks[agent].Count; i++)
                {
                    ObservableRow row = ObservableRisks[agent][i][name];

                    foreach (string kid in row.ChildRows)
                    {
                        ObservableRisks[agent][i].Rows.Remove(ObservableRisks[agent][i][kid]);
                    }

                    ObservableRisks[agent][i].Rows.Remove(row);
                }
            }

            AgentsViewModel.Instance.oDatabase.Rows.Remove(AgentsViewModel.Instance.oDatabase[name]);
            this.RecalculateAllGrids();
        }

        public void DerivedRow_Delete(string name)
        {
            int agent = MainWindowViewModel.SelectedAgent;
            bool recalculate = false;

            for (int i = 0; i < ObservableRisks[agent].Count; i++)
            {
                ObservableRow row = ObservableRisks[agent][i][name];
                foreach (int index in AgentsViewModel.Instance.RecalculateColumns)
                {
                    if (!string.IsNullOrWhiteSpace(row.Cells[index].Value))
                    {
                        AgentsViewModel.EditedColumn = index;
                        recalculate = true;
                        break;
                    }
                }

                ObservableRow parent = ObservableRisks[agent][i][row.Parent];
                parent.ChildRows.Remove(row.Name);
                ObservableRisks[agent][i].Rows.Remove(row);
            }

            if (recalculate)
            {
                this.RecalculateDerivedGrids(true);
            }

        }

        private void DerivedRows_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //add remove rows in derived grids
        }


        private void UpdateViewModels()
        {
            //foreach (Delegate eh in Changed.GetInvocationList())
            //{
            //    eh.DynamicInvoke();
            //}
        }

        public void UpdateDisplay()
        {
            if (MainWindowViewModel.SelectedAgent != -1)
            {
                GridBuilder.RiskGrids[AgentsViewModel.SelectedScenario[MainWindowViewModel.SelectedAgent]].UpdateLayout();
            }
            else
            {
                GridBuilder.DataBaseGrid.UpdateLayout();
                GridBuilder.DataBaseGrid.Items.Refresh();
            }

        }


    }

}
