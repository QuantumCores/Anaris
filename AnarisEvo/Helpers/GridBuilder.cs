using AnarisDLL.BLL.Anaris;
using AnarisDLL.BLL.AnarisGrid;
using AnarisDLL.BLL.Category;
using AnarisDLL.BLL.Database;
using AnarisDLL.BLL.Risk;
using AnarisEvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace AnarisEvo.Helpers
{
    public class GridBuilder
    {

        public static DataGrid DataBaseGrid { get; set; }
        public static List<DataGrid> RiskGrids = new List<DataGrid>();

        public static DataGrid BuildBaseDataGrid(Database db)
        {
            DataGrid grid = new DataGrid();
            GridBuilder.DataBaseGrid = grid;
            grid.Name = "grd_DataBase";
            grid.AutoGenerateColumns = false;
            grid.HorizontalGridLinesBrush = new SolidColorBrush(Colors.Gray);
            grid.VerticalGridLinesBrush = new SolidColorBrush(Colors.Gray);
            //grid.LayoutUpdated += BaseGrid_LayoutUpdated;

            DgvColumn select = db.dgv.columns[0];
            var slc = new DataGridCheckBoxColumn();
            slc.Width = select.width;
            slc.Header = select.headerText;
            grid.Columns.Add(slc);

            //if (Anaris.Instance != null)
            //{
            grid.CellEditEnding += AllGrid_CellEditEnding; //method that updates all grids when database changes                
            //}

            ContextMenu menu = new ContextMenu();
            menu.Opened += MenuDB_Opened;

            MenuItem AddRow = new MenuItem();
            AddRow.Header = "Dodaj wiersz";
            AddRow.Click += AddDBRow_Click;
            MenuItem DeleteRow = new MenuItem();
            DeleteRow.Header = "Usuń wiersz";
            DeleteRow.Click += DeleteDBRow_Click;
            menu.Items.Add(AddRow);
            menu.Items.Add(DeleteRow);
            grid.ContextMenu = menu;


            for (int i = 1; i < db.dgv.columns.Count; i++)
            {
                AnarisDLL.BLL.AnarisGrid.DgvColumn col = db.dgv.columns[i];
                if (col.name == "Lista")
                {
                    var dgc = new DataGridComboBoxColumn();
                    dgc.ItemsSource = Services.Service.Instance.Values;
                    dgc.DisplayMemberPath = "text";
                    dgc.SelectedValuePath = "name";
                    dgc.Width = col.width;
                    dgc.SelectedValueBinding = new System.Windows.Data.Binding("Cells[" + i + "].Value");
                    dgc.Header = col.headerText;
                    grid.Columns.Add(dgc);
                }
                else if (col.name.StartsWith("CAT"))
                {
                    var dgc = new DataGridComboBoxColumn();
                    dgc.ItemsSource = Services.Service.Instance.Categories.FirstOrDefault(c => c.name == col.name).subCategories; //db.categoryManager.List.Where(c => c.name == col.name).FirstOrDefault().subCategories;
                    dgc.DisplayMemberPath = "text";
                    dgc.SelectedValuePath = "name";
                    dgc.Width = col.width;
                    dgc.SelectedValueBinding = new System.Windows.Data.Binding("Cells[" + i + "].Value");
                    dgc.Header = col.headerText;
                    grid.Columns.Add(dgc);
                }
                else
                {
                    var dgc = new DataGridTextColumn();
                    dgc.Width = col.width;
                    dgc.Header = col.headerText;
                    dgc.Binding = new System.Windows.Data.Binding("Cells[" + i + "].Value");
                    grid.Columns.Add(dgc);
                }
            }

            return grid;
        }

        public static void BuildAnalysisTabs(Grid grd_DataGrid, TabControl tabControl)
        {
            AgentsViewModel DataGridContext = ((AgentsViewModel)grd_DataGrid.DataContext);

            for (int i = 0; i < Anaris.Instance.ScenarioManager.Risks.Count; i++)
            {
                SingleRisk risk = Anaris.Instance.ScenarioManager.Risks[i];
                TabItem tab = new TabItem();
                tab.Header = risk.name;
                tab.Background = new SolidColorBrush(Colors.White);
                //tab.Padding = new Thickness(0,0,0,0);

                //ObservableGrid derivedRows = Services.Service.Instance.ObservableRisks[i][0];
                ObservableGrid derivedRows = DataGridContext.DisplayedScenarios[i];
                DataGrid derived = BuildScenarioGrid(Anaris.Instance.DataBase, derivedRows);
                derived.ItemsSource = derivedRows.Rows;

                StackPanel stackPanel = BuildFormulaPanel();

                Grid scenarioGrid = new Grid();
                RowDefinition rowDefinition = new RowDefinition() { Height = new GridLength(35) };
                scenarioGrid.RowDefinitions.Add(rowDefinition);
                scenarioGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

                scenarioGrid.Children.Add(stackPanel);
                scenarioGrid.Children.Add(derived);
                Grid.SetRow(stackPanel, 0);
                Grid.SetRow(derived, 1);

                GridBuilder.RiskGrids.Add(derived);

                tab.Content = scenarioGrid;
                tabControl.Items.Insert(tabControl.Items.Count, tab);
            }
        }

        //private static void CreateColumnBinding2(DataGridColumn column, ObservableGrid scenario, int columnIndex)
        //{
        //    Binding columnBinding = new Binding();

        //    var tmp = Anaris.Instance.RiskAnalysis.RiskAnalysis.SelectMany(d => d.dgvList).FirstOrDefault(d => d.name == scenario.Name).columns[columnIndex];
        //    columnBinding.Source = tmp;//Services.Service.Instance.ObservableRisks;
        //    columnBinding.Path = new PropertyPath("width");
        //    columnBinding.Mode = BindingMode.TwoWay;
        //    columnBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        //    BindingOperations.SetBinding(column, DataGridColumn.WidthProperty, columnBinding);
        //}

        private static StackPanel BuildFormulaPanel()
        {
            StackPanel stackPanel = new StackPanel() { Orientation = Orientation.Horizontal, Background = new SolidColorBrush(Colors.White) };

            double fontSize = 22;
            SolidColorBrush foreground = new SolidColorBrush(Colors.Gray);

            TextBlock formula = new TextBlock();
            formula.VerticalAlignment = VerticalAlignment.Center;
            formula.Text = "Formuła = [";
            formula.Foreground = foreground;
            formula.Height = 30;
            formula.Margin = new Thickness(15, 5, 0, 5);
            formula.Background = Brushes.White;
            formula.FontSize = fontSize;
            stackPanel.Children.Add(formula);

            TextBox column = new TextBox();
            column.VerticalAlignment = VerticalAlignment.Center;
            column.HorizontalAlignment = HorizontalAlignment.Center;
            column.Height = 20;
            column.Margin = new Thickness(0, 5, 0, -1);
            column.Background = Brushes.White;
            column.Width = 100;

            Binding columnBinding = new Binding();
            columnBinding.Source = AgentsViewModel.Instance;
            columnBinding.Path = new PropertyPath("FormulaColumn");
            columnBinding.Mode = BindingMode.TwoWay;
            columnBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(column, TextBox.TextProperty, columnBinding);

            Binding columnBindingEnabled = new Binding();
            columnBindingEnabled.Source = AgentsViewModel.Instance;
            columnBindingEnabled.Path = new PropertyPath("IsFormulaEnabled");
            columnBindingEnabled.Mode = BindingMode.TwoWay;
            columnBindingEnabled.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(column, TextBox.IsEnabledProperty, columnBindingEnabled);

            //column.FontSize = fontSize;
            stackPanel.Children.Add(column);

            TextBlock formula2 = new TextBlock();
            formula2.VerticalAlignment = VerticalAlignment.Center;
            formula2.Text = "] * ";
            formula2.Foreground = foreground;
            formula2.Height = 30;
            formula2.Margin = new Thickness(0, 5, 0, 5);
            formula2.Background = Brushes.White;
            formula2.FontSize = fontSize;
            stackPanel.Children.Add(formula2);

            TextBox quantity = new TextBox();
            quantity.VerticalAlignment = VerticalAlignment.Center;
            column.HorizontalAlignment = HorizontalAlignment.Center;
            quantity.Text = "0";
            quantity.Height = 20;
            quantity.Margin = new Thickness(0, 5, 0, -1);
            quantity.Background = Brushes.White;
            quantity.Width = 50;

            Binding numberBinding = new Binding();
            numberBinding.Source = AgentsViewModel.Instance;
            numberBinding.Path = new PropertyPath("FormulaNumber");
            numberBinding.Mode = BindingMode.TwoWay;
            numberBinding.ConverterCulture = System.Globalization.CultureInfo.CurrentCulture;
            //numberBinding.Delay = 250;
            numberBinding.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
            BindingOperations.SetBinding(quantity, TextBox.TextProperty, numberBinding);

            Binding numberBindingEnabled = new Binding();
            numberBindingEnabled.Source = AgentsViewModel.Instance;
            numberBindingEnabled.Path = new PropertyPath("IsFormulaEnabled");
            numberBindingEnabled.Mode = BindingMode.TwoWay;
            numberBindingEnabled.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(quantity, TextBox.IsEnabledProperty, numberBindingEnabled);

            //quantity.FontSize = fontSize;
            stackPanel.Children.Add(quantity);

            TextBlock separator = new TextBlock();
            
            separator.VerticalAlignment = VerticalAlignment.Center;
            //separator.HorizontalAlignment = HorizontalAlignment.Center;
            separator.Text = "Separator dziesiętny (" + System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + ")";
            separator.Foreground = foreground;
            separator.Height = 20;
            separator.Margin = new Thickness(10, 13, 0, 5);
            separator.Background = Brushes.White;
            separator.FontSize = fontSize - 10;
            stackPanel.Children.Add(separator);

            return stackPanel;

        }


        public static void AdaptGridsToCategories(List<Category> CategoriesToAdd, List<Category> CategoriesToRemove, IList<Category> NewCategories)
        {
            AdaptSingleGrid(DataBaseGrid, null, CategoriesToAdd, CategoriesToRemove, NewCategories);
            RebindColumns(DataBaseGrid);

            foreach (DataGrid grid in RiskGrids)
            {
                AdaptSingleGrid(grid, "DerivedGrid", CategoriesToAdd, CategoriesToRemove, NewCategories);
                RebindColumns(grid);
            }


        }

        private static void AdaptSingleGrid(DataGrid dataGrid, string style, IList<Category> Add, IList<Category> Rmv, IList<Category> All)
        {
            Dictionary<string, int> Order = Database.Instance.dgv.columns.OrderByDescending(v => v.index).ToDictionary(r => r.name, r => r.index);

            string[] rmvHeaders = Rmv.Select(r => r.text).ToArray();

            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                DataGridColumn col = dataGrid.Columns[i];
                if (rmvHeaders.Contains(col.Header))
                {
                    dataGrid.Columns.Remove(col);
                    i--;
                }
            }

            string[] addHeaders = Add.Select(a => a.text).ToArray();
            for (int i = 0; i < All.Count; i++)
            {
                Category cat = All[i];

                if (addHeaders.Contains(cat.text))
                {
                    DataGridComboBoxColumn column = ComboBoxColumn(cat.name, i + 2, cat.text.Length * 10 + 10, cat.text, style);
                    dataGrid.Columns.Insert(i + 2, column);
                }
            }

            for (int i = 0; i < All.Count; i++)
            {
                Category cat = All[i];
                dataGrid.Columns[i + 2].Header = cat.text;
            }

            dataGrid.UpdateLayout();

        }

        private static DataGrid BuildScenarioGrid(Database db, ObservableGrid scenario)//System.Windows.Controls.DataGrid grid
        {
            DataGrid grid = new DataGrid();
            grid.IsSynchronizedWithCurrentItem = true;
            grid.SelectionUnit = DataGridSelectionUnit.Cell;
            grid.SelectedCellsChanged += SelectedCellsChanged;
            grid.PreviewMouseRightButtonDown += Grid_PreviewMouseRightButtonDown;
            grid.PreviewMouseLeftButtonDown += Grid_PreviewMouseLeftButtonDown;
            grid.CanUserReorderColumns = false;
            //grid.LayoutUpdated += Grid_LayoutUpdated;

            grid.AutoGenerateColumns = false;
            grid.HorizontalGridLinesBrush = new SolidColorBrush(Colors.LightGray);
            grid.VerticalGridLinesBrush = new SolidColorBrush(Colors.LightGray);
            grid.RowHeight = 24;
            grid.CanUserAddRows = false;//
            grid.Margin = new Thickness(0, 0, 0, 0);


            grid.CellEditEnding += DerivedGrid_CellEditEnding;
            //grid.PreparingCellForEdit += 

            ContextMenu menu = new ContextMenu();
            menu.Opened += Menu_Opened;

            Binding myBinding = new Binding();
            myBinding.Source = AgentsViewModel.Instance;
            myBinding.Path = new PropertyPath("MenuEnabled");
            myBinding.Mode = BindingMode.OneWay;
            myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(menu, ContextMenu.IsEnabledProperty, myBinding);

            MenuItem SplitRow = new MenuItem();
            SplitRow.Header = "Podziel wiersz";
            SplitRow.Click += SplitRow_Click;
            MenuItem DeleteRow = new MenuItem();
            DeleteRow.Header = "Usuń wiersz";
            DeleteRow.Click += DeleteRow_Click;
            menu.Items.Add(SplitRow);
            menu.Items.Add(DeleteRow);
            grid.ContextMenu = menu;
            //grid.ContextMenu.Items.Add(SplitRow);


            DgvColumn select = scenario.Columns[0];
            var slc = new DataGridCheckBoxColumn();
            slc.Width = select.width;
            slc.Header = select.headerText;
            grid.Columns.Add(slc);
            //CreateColumnBinding(slc, scenario, 0);

            //for (int i = 1; i < scenario.Columns.Count - 2; i++)
            for (int i = 1; i < scenario.Columns.Count; i++)
            {
                DgvColumn col = scenario.Columns[i];
                if (col.name == "Lista")
                {
                    var dgc = new DataGridComboBoxColumn();
                    dgc.ItemsSource = Services.Service.Instance.Values;
                    dgc.DisplayMemberPath = "text";
                    dgc.SelectedValuePath = "name";
                    dgc.Width = col.width;
                    dgc.SelectedValueBinding = new System.Windows.Data.Binding("Cells[" + i + "].Value");
                    dgc.Header = col.headerText;
                    //CreateColumnBinding(dgc, scenario, i);

                    dgc.CellStyle = System.Windows.Application.Current.FindResource("DerivedGrid") as System.Windows.Style;
                    //dgc.CellStyle = System.Windows.Application.Current.FindResource("SubDerivedGrid") as System.Windows.Style;
                    grid.Columns.Add(dgc);
                }
                else if (col.name.StartsWith("CAT"))
                {
                    var dgc = new DataGridComboBoxColumn();
                    dgc.ItemsSource = Services.Service.Instance.Categories.FirstOrDefault(c => c.name == col.name).subCategories; //.categoryManager.List.Where(c => c.name == col.name).FirstOrDefault().subCategories;
                    dgc.DisplayMemberPath = "text";
                    dgc.SelectedValuePath = "name";
                    dgc.Width = col.width;
                    dgc.SelectedValueBinding = new System.Windows.Data.Binding("Cells[" + i + "].Value");
                    dgc.Header = col.headerText;
                    //CreateColumnBinding(dgc, scenario, i);

                    dgc.CellStyle = System.Windows.Application.Current.FindResource("DerivedGrid") as System.Windows.Style;
                    grid.Columns.Add(dgc);
                }
                else
                {
                    var dgc = new DataGridTextColumn();
                    dgc.Width = col.width;
                    dgc.Header = col.headerText;
                    dgc.Binding = new System.Windows.Data.Binding("Cells[" + i + "].Value");
                    //CreateColumnBinding(dgc, scenario, i);

                    if (col.name == "Number" || col.name == "Item")
                    {
                        dgc.CellStyle = System.Windows.Application.Current.FindResource("SubDerivedGrid") as System.Windows.Style;
                    }
                    else
                    {
                        dgc.CellStyle = System.Windows.Application.Current.FindResource("DerivedGrid") as System.Windows.Style;
                    }
                    grid.Columns.Add(dgc);

                }
            }

            for (int i = 0; i < 3; i++)
            {
                string[] names = new string[] { "Dolna", "Prawdopodobna", "Górna" };
                DataGridTextColumn mdgc = CColumn(new DgvColumn() { width = 120, headerText = names[i], name = names[i] }, scenario.Columns.Count + i);
                grid.Columns.Add(mdgc);

            }


            return grid;

        }

        //private static void Grid_LayoutUpdated(object sender, EventArgs e)
        //{
        //    if (sender != null)
        //    {
        //        Console.WriteLine("Sender is of type: " + sender.GetType());
        //    }
        //    Console.WriteLine("Event is of type: " + e.GetType());
        //    int u = 0;
        //}

        //private static void BaseGrid_LayoutUpdated(object sender, EventArgs e)
        //{
        //    if (sender != null)
        //    {
        //        Console.WriteLine("Sender is of type: " + sender.GetType());
        //    }
        //    Console.WriteLine("Event is of type: " + e.GetType());

        //    int u = 0;
        //}

        private static void Grid_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ((DataGrid)sender).ContextMenu.IsOpen = false;
        }

        private static void Grid_PreviewMouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.OriginalSource is DataGridCellsPanel)
            {
                AgentsViewModel.Instance.RightClickRow = (ObservableRow)((DataGridCellsPanel)e.OriginalSource).DataContext;
            }
            else if (e.OriginalSource is TextBlock)
            {
                AgentsViewModel.Instance.RightClickRow = (ObservableRow)((TextBlock)e.OriginalSource).DataContext;
            }

        }

        private static void SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            //int indexo = grid.CurrentCell.Column.DisplayIndex;
            //int index = e.AddedCells.First().Column.DisplayIndex;


            if (grid.CurrentColumn != null && grid.CurrentItem != null)
            {
                int column = grid.CurrentColumn.DisplayIndex;
                int row = grid.Items.IndexOf(grid.CurrentItem);
                AgentsViewModel.Instance.SetFormulaCell(row, column);
            }
        }

        private static void Menu_Opened(object sender, RoutedEventArgs e)
        {
            ContextMenu menu = (ContextMenu)sender;
            ObservableRow row = AgentsViewModel.Instance.RightClickRow;
            DataGrid grid = (DataGrid)menu.PlacementTarget;
            menu.IsEnabled = AgentsViewModel.Instance.MenuEnabled;

            if (row == null)
            {
                e.Handled = true;
                MessageBox.Show("Krytyczny błąd aplikacji. Nie znaleziono edytowanego wiersza.");
                return;
            }

            if (row.IsDBrow)
            {
                ((MenuItem)menu.Items[0]).IsEnabled = true;
                ((MenuItem)menu.Items[1]).IsEnabled = false;
            }
            else
            {
                ((MenuItem)menu.Items[0]).IsEnabled = false;
                ((MenuItem)menu.Items[1]).IsEnabled = true;
            }

            e.Handled = true;
        }

        private static void MenuDB_Opened(object sender, RoutedEventArgs e)
        {
            ObservableRow row = (ObservableRow)DataBaseGrid.SelectedItem;
            ContextMenu menu = (ContextMenu)sender;


            if (row == null)
            {
                e.Handled = true;
                MessageBox.Show("Krytyczny błąd aplikacji. Nie znaleziono edytowanego wiersza.");
                return;
            }

            e.Handled = true;
        }

        private static void SplitRow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ObservableRow row = AgentsViewModel.Instance.RightClickRow;
                Services.Service.Instance.DerivedRow_Split(row.Name);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Podczas dzielenia wiersza wystąpił następujący bład" + Environment.NewLine + exc.ToString());
            }
        }

        private static void DeleteRow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ObservableRow row = AgentsViewModel.Instance.RightClickRow;
                Services.Service.Instance.DerivedRow_Delete(row.Name);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Podczas usuwania wiersza wystąpił następujący bład" + Environment.NewLine + exc.ToString());
            }
        }

        private static void AddDBRow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ObservableRow row = (ObservableRow)DataBaseGrid.SelectedItem;
                Services.Service.Instance.DatabaseRow_Add(row.Name);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Podczas dodawania wiersza wystąpił następujący bład" + Environment.NewLine + exc.ToString());
            }
        }

        private static void DeleteDBRow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ObservableRow row = (ObservableRow)DataBaseGrid.SelectedItem;
                Services.Service.Instance.DatabaseRow_Delete(row.Name);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Podczas usuwania wiersza wystąpił następujący bład" + Environment.NewLine + exc.ToString());
            }
        }

        private static void Grid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            AgentsViewModel.EditedColumn = e.Column.DisplayIndex;
        }

        private static void AllGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                AgentsViewModel.EditedColumn = e.Column.DisplayIndex;
                AgentsViewModel.EditedRow = e.Row.GetIndex();

                string val = GetCellValue(e.EditingElement);
                if (val != null)
                {
                    Services.Service.Instance.UpdateAllGrids(val);
                    Services.Service.Instance.RecalculateAllGrids();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Podczas edycji komórki wystąpił następujący błąd" + Environment.NewLine + exc.ToString());
            }
        }

        private static string GetCellValue(FrameworkElement cell)
        {
            string value = string.Empty;

            if (cell is TextBox)
            {
                value = (string)((TextBox)cell).Text;
            }
            else if (cell is ComboBox)
            {
                ComboBox tmp = (ComboBox)cell;
                value = (string)((ComboBox)cell).SelectedValue;
            }


            return value;


        }

        private static void DerivedGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                AgentsViewModel.EditedColumn = e.Column.DisplayIndex;
                AgentsViewModel.EditedRow = e.Row.GetIndex();
                string val = GetCellValue(e.EditingElement);

                if (val != null)
                {
                    if (MainWindowViewModel.Instance.SelectedScenario.Key == 0)
                    {
                        Services.Service.Instance.UpdateDerivedGrids(val);
                    }

                    //here we recalculate only if number and C columns are edited
                    if (AgentsViewModel.EditedColumn > AgentsViewModel.Instance.oDatabase.Columns.Count - 2)
                    {
                        bool all = (MainWindowViewModel.Instance.SelectedScenario.Key == 0) ? true : false;
                        Services.Service.Instance.RecalculateDerivedGrids(all);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Podczas edycji komórki wystąpił następujący błąd" + Environment.NewLine + exc.ToString());
            }

        }

        public static DataGridTextColumn CColumn(DgvColumn column, int index)
        {
            DataGridTextColumn mdgc = new DataGridTextColumn();
            mdgc.Width = column.width;
            mdgc.Header = column.headerText;
            mdgc.Binding = new System.Windows.Data.Binding("Cells[" + index + "].Value");
            mdgc.CellStyle = System.Windows.Application.Current.FindResource("DerivedGridCCol") as System.Windows.Style;
            //DerivedGridCCol

            return mdgc;
        }

        private static DataGridComboBoxColumn ComboBoxColumn(string categoryName, int cellIndex, int width, string header, string style)
        {
            var dgc = new DataGridComboBoxColumn();
            dgc.ItemsSource = Services.Service.Instance.Categories.FirstOrDefault(c => c.name == categoryName).subCategories; //.categoryManager.List.Where(c => c.name == col.name).FirstOrDefault().subCategories;
            dgc.DisplayMemberPath = "text";
            dgc.SelectedValuePath = "name";
            dgc.Width = width;
            //dgc.SelectedValueBinding = new System.Windows.Data.Binding("Cells[" + cellIndex + "].Value");
            dgc.Header = header;

            if (!string.IsNullOrWhiteSpace(style))
            {
                dgc.CellStyle = System.Windows.Application.Current.FindResource(style) as System.Windows.Style;
            }

            return dgc;
        }

        private static void RebindColumns(DataGrid dataGrid)
        {
            for (int i = 2; i < dataGrid.Columns.Count; i++)
            {
                DataGridColumn col = dataGrid.Columns[i];
                if (col is DataGridTextColumn)
                {
                    ((DataGridTextColumn)col).Binding = new System.Windows.Data.Binding("Cells[" + i + "].Value");
                }
                else if (col is DataGridComboBoxColumn)
                {
                    ((DataGridComboBoxColumn)col).SelectedValueBinding = new System.Windows.Data.Binding("Cells[" + i + "].Value");
                }

            }

        }
    }
}
