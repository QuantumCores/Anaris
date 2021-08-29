using AnarisEvo.ViewModels;
using AnarisEvo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WinInterop = System.Windows.Interop;
using System.Runtime.InteropServices;
using AnarisDLL.BLL.SaveDataBase;
using AnarisDLL.BLL.AnarisGrid;
using AnarisDLL.BLL.Database;
using AnarisDLL.BLL.Anaris;
using AnarisDLL.BLL.Risk;
using AnarisEvo.Helpers;
using AnarisDLL.BLL.SaveAnaris;

namespace AnarisEvo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CategoryManager CategoryManager;
        private GeneralInformation GeneralInformation;
        private NewDatabase NewDatabase;
        private Views.ProjectProperties ProjectProperties;
        private ReportSettings ReportSettings;
        private ScenarioManager ScenarioManager;
        private ValueManager ValueManager;
        private ValuePie ValuePie;
        private MergeDatabase MergeDatabase;
        private ChartActInv ChartActInv;
        private ChartRisks ChartRisks;
        private WelcomeView WelcomeView;
        private MergeAnaris MergeAnaris;



        public MainWindow()
        {
            InitializeComponent();
            this.SourceInitialized += new EventHandler(win_SourceInitialized);

            var context = SetupMainWindowViewModelContext();

            cbx_Agents.IsEnabled = false;
            cbx_Agents.SelectionChanged += Cbx_Agents_SelectionChanged;
            Services.Service tmp = new Services.Service();

            CenterWindowOnScreen();
            this.Loaded += new RoutedEventHandler(win_Loaded);

            MenuViewModel menuContext = new MenuViewModel();
            menuContext.CreateNewDatabaseAction = new RoutedEventHandler(mnu_NewDatabase_Click);
            menuContext.OpenDatabaseAction = mnu_OpenDatabase_Click;
            menuContext.SaveDatabaseAsAction = mnu_SaveDatabase_Click;
            menuContext.SaveDatabaseAction = SaveDatabase;
            menuContext.CreateNewAnarisAction = new RoutedEventHandler(mnu_NewAnalysis_Click);
            menuContext.OpenAnarisAction = mnu_OpenAnalysis_Click;
            menuContext.SaveAnarisAsAction = mnu_SaveAnalysis_Click;
            menuContext.SaveAnarisAction = SaveAnaris;
            menuContext.GenerateReportAction = mnu_GenerateReport_Click;
            menuContext.ShowWindowActionField = ShowWindow;
            mnu_Window.DataContext = menuContext;

            spn_ToolBarLeft.DataContext = menuContext;
            spn_ToolBarRight.DataContext = menuContext;
            spn_Combobox.DataContext = context;

        }

        private MainWindowViewModel SetupMainWindowViewModelContext()
        {
            MainWindowViewModel context = new MainWindowViewModel();
            context.CreateNewDatabaseAction = SetupDatabaseView;
            context.CreateNewAnarisAction = SetupAnalysisView;
            context.ShowWindowActionField = ShowWindow;
            grd_Window.DataContext = context;
            MainWindowViewModel.SelectedAgent = -1;

            return context;
        }

        private void mnu_NewDatabase_Click(object sender, RoutedEventArgs e)
        {
            Views.NewDatabase databaseDailog = new Views.NewDatabase();
            databaseDailog.Owner = this;
            databaseDailog.ShowInTaskbar = false;
            databaseDailog.Topmost = true;
            ((NewDatabaseViewModel)databaseDailog.DataContext).CreateNewDatabase = SetupDatabaseView;
            databaseDailog.Show();
        }

        private void mnu_OpenDatabase_Click(object sender, RoutedEventArgs e)
        {
            using (OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog())
            {
                dialog.InitialDirectory = "C:";
                dialog.Title = "Otwórz bazę danych Anaris";
                dialog.FileName = "";
                dialog.Filter = "Anaris Pliki|*.anrb|Word Documents|*.doc";

                if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                {
                    LoadDatabase(dialog.FileName);
                }
            }
        }

        private void mnu_SaveDatabase_Click(object sender, RoutedEventArgs e)
        {
            using (SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog())
            {
                dialog.InitialDirectory = "C:";
                dialog.Title = "Zapisz projekt jako";
                dialog.FileName = "";
                dialog.Filter = "Anaris Pliki|*.anrb| Wszystkie Pliki|*.*";

                if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                {
                    try
                    {
                        SaveDatabase(dialog.FileName);
                        tbc_ProjectName.Text = Database.Instance.ProjectProperties.FilePath;
                    }
                    catch (Exception exc)
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Podczas zapisywania pliku wystąpił następujący błąd" + Environment.NewLine + exc.ToString());
                    }
                }
            }
        }

        private void SaveDatabase(string FileName)
        {
            Services.Service.ConvertObservableToDatabase();
            Database.Instance.ProjectProperties.FilePath = FileName;
            Database.Instance.ProjectProperties.Culture = System.Globalization.CultureInfo.CurrentCulture.Name;
            Database.Instance.ProjectProperties.ModifiedTime = DateTime.UtcNow;
            System.Windows.Controls.DataGrid kid = null;

            if (grd_DataGrid.Children[2] is System.Windows.Controls.DataGrid)
            {
                kid = (System.Windows.Controls.DataGrid)grd_DataGrid.Children[2];
            }
            else
            {
                kid = (System.Windows.Controls.DataGrid)(((TabItem)((System.Windows.Controls.TabControl)grd_DataGrid.Children[2]).Items[0]).Content);
            }

            Database.Instance.SetColumnWidths(GetColumnWidth(kid));
            SaveDataBase.Save(FileName, Database.Instance);
        }

        private void mnu_NewAnalysis_Click(object sender, RoutedEventArgs e)
        {
            NewAnalysis analysisDailog = new NewAnalysis();
            analysisDailog.Owner = this;
            analysisDailog.ShowInTaskbar = false;
            analysisDailog.Topmost = true;
            ((NewAnalysisViewModel)analysisDailog.DataContext).CreateNewAnalysis = SetupAnalysisView;
            analysisDailog.Show();
        }

        private void mnu_OpenAnalysis_Click(object sender, RoutedEventArgs e)
        {
            using (OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog())
            {
                dialog.InitialDirectory = "C:";
                dialog.Title = "Otwórz analizę ryzyka Anaris";
                dialog.FileName = "";
                dialog.Filter = "Anaris analiza ryzyka|*.anrs|Anaris baza danych|*.anrb";

                if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                {
                    LoadAnalysis(dialog.FileName);
                }
            }
        }


        private void mnu_SaveAnalysis_Click(object sender, RoutedEventArgs e)
        {
            using (SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog())
            {
                dialog.InitialDirectory = "C:";
                dialog.Title = "Zapisz projekt jako";
                dialog.FileName = "";
                dialog.Filter = "Anaris Pliki|*.anrs| Wszystkie Pliki|*.*";

                if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                {
                    try
                    {
                        SaveAnaris(dialog.FileName);
                        tbc_ProjectName.Text = Anaris.Instance.ProjectProperties.FilePath;
                    }
                    catch (Exception exc)
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Podczas zapisywania pliku wystąpił następujący błąd" + Environment.NewLine + exc.ToString());
                    }
                }
            }
        }

        private void SaveAnaris(string FileName)
        {
            Services.Service.ConvertObservableToAnaris();
            Anaris.Instance.ProjectProperties.FilePath = FileName;
            Anaris.Instance.ProjectProperties.ModifiedTime = DateTime.UtcNow;

            Anaris.Instance.SetColumnWidths(GetColumnWidth(((System.Windows.Controls.TabControl)grd_DataGrid.Children[2]).Items));

            Database.Instance.ProjectProperties.Culture = System.Globalization.CultureInfo.CurrentCulture.Name;
            Database.Instance.ProjectProperties.ModifiedTime = DateTime.UtcNow;
            var kid = (System.Windows.Controls.DataGrid)(((TabItem)((System.Windows.Controls.TabControl)grd_DataGrid.Children[2]).Items[0]).Content);
            Database.Instance.SetColumnWidths(GetColumnWidth(kid));
            SaveProject.Save(FileName, Anaris.Instance);
        }


        private void ShowWindow(string windowName)
        {
            if (string.IsNullOrWhiteSpace(windowName))
            {
                throw new NullReferenceException("windowName parameter in MainWindow.ShowWindow() is null");
            }

            FieldInfo Prop = typeof(MainWindow).GetField(windowName, BindingFlags.NonPublic | BindingFlags.Instance);
            var Instance = Prop.GetValue(this);
            Type T = Type.GetType("AnarisEvo.Views." + windowName);

            if (Instance != null)
            {
                PropertyInfo IsDisposed = T.GetProperty("IsDisposed", BindingFlags.NonPublic | BindingFlags.Instance);
                bool IsDisposedValue = (bool)IsDisposed.GetValue(Instance);

                if (IsDisposedValue)
                {
                    Instance = null;
                }
            }

            if (Instance == null)
            {
                Instance = Activator.CreateInstance(T);
                PropertyInfo ShownInTaskBar = T.GetProperty("ShowInTaskbar", BindingFlags.Public | BindingFlags.Instance);
                ShownInTaskBar.SetValue(Instance, false);
                PropertyInfo Owner = typeof(Window).GetProperty("Owner", BindingFlags.Public | BindingFlags.Instance);
                Owner.SetValue(Instance, this);
                Prop.SetValue(this, Instance);
            }


            MethodInfo Show = T.GetMethod("Show");
            Show.Invoke(Instance, null);
        }

        private void HideWindow(string windowName)
        {
            if (string.IsNullOrWhiteSpace(windowName))
            {
                throw new NullReferenceException("windowName parameter in MainWindow.HideWindow() is null");
            }

            FieldInfo Prop = typeof(MainWindow).GetField(windowName, BindingFlags.NonPublic | BindingFlags.Instance);
            var Instance = Prop.GetValue(this);
            if (Instance != null)
            {
                Prop.SetValue(this, null);
            }

        }

        private void LoadDatabase(string fileName)
        {
            try
            {
                string version = AnarisDLL.BLL.LoadDataBase.LoadDataBase.GetTheAssemblyVersion(0, fileName);
                Database.Instance = AnarisDLL.BLL.LoadDataBase.LoadDataBase.Load(version, fileName);

                Services.Service.Instance.SetUpData();
                SetupDatabaseView();
            }
            catch (Exception exc)
            {
                string error = exc.ToString();
                string version = AnarisDLL.BLL.LoadDataBase.LoadDataBase.GetTheAssemblyVersion(0, fileName);
                System.Windows.MessageBox.Show("Plik jest nieodpowiedni bądź zawiera błędy.\n Wersja bazy danych " + version + ".");
                CloseProject();
            }
        }

        private void SetupDatabaseView()
        {
            grd_MagnitudeBar.Visibility = Visibility.Visible;
            tbc_MagnitudeOfRisk.Visibility = Visibility.Hidden;
            tbc_MagnitudeOfRiskVal.Visibility = Visibility.Hidden;
            grd_ProjectBar.Visibility = Visibility.Visible;
            tbc_ProjectName.Text = AnarisDLL.BLL.Database.Database.Instance.ProjectProperties.FilePath;
            grd_ProjectBar.Background = new SolidColorBrush(Color.FromRgb(136, 192, 207));


            if (grd_DataGrid.DataContext == null)
            {
                grd_DataGrid.DataContext = new AgentsViewModel();
            }

            System.Windows.Controls.DataGrid database = GridBuilder.BuildBaseDataGrid(Database.Instance);
            database.ItemsSource = ((AgentsViewModel)grd_DataGrid.DataContext).oDatabase.Rows;

            Grid.SetRow(database, 1);
            Grid.SetColumn(database, 0);

            grd_DataGrid.Children.Add(database);

        }

        private void LoadAnalysis(string fileName)
        {
            try
            {
                string extension = System.IO.Path.GetExtension(fileName);
                if (extension == ".anrs")
                {
                    string version = AnarisDLL.BLL.LoadAnaris.LoadProject.GetTheAssemblyVersion(0, fileName);
                    AnarisDLL.BLL.Anaris.Anaris.Instance = AnarisDLL.BLL.LoadAnaris.LoadProject.Load(version, fileName);
                    Database.Instance = Anaris.Instance.DataBase;
                }
                else if (extension == ".anrb")
                {
                    string version = AnarisDLL.BLL.LoadDataBase.LoadDataBase.GetTheAssemblyVersion(0, fileName);

                    Database.Instance = AnarisDLL.BLL.LoadDataBase.LoadDataBase.Load(version, fileName);

                    Anaris.Instance = new Anaris();
                    Anaris.Instance.DataBase = Database.Instance;
                    Anaris.Instance.ProjectProperties = Database.Instance.ProjectProperties;
                    Anaris.Instance.ProjectProperties.FilePath = System.IO.Path.Combine(System.IO.Directory.GetParent(Database.Instance.ProjectProperties.FilePath).FullName, Database.Instance.ProjectProperties.ProjectName + ".anrs");
                    Anaris.Instance.ProjectProperties.CreationTime = DateTime.UtcNow;
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                    Anaris.Instance.ProjectProperties.ProgramVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
                    Anaris.Instance.ScenarioManager.Initialize();
                    Anaris.Instance.RiskAnalysis.Initialize(Anaris.Instance.ScenarioManager);

                    for (int i = 0; i < Anaris.Instance.RiskAnalysis.RiskAnalysis.Count; i++)
                    {
                        RiskDgvList risk = Anaris.Instance.RiskAnalysis.RiskAnalysis[i];
                        AnarisDLL.BLL.AnarisGrid.Dgv dgv = new AnarisDLL.BLL.AnarisGrid.Dgv();
                        dgv.Clone(Anaris.Instance.DataBase.dgv);
                        dgv.name = "BD - " + Anaris.Instance.ScenarioManager.Risks[i].name;
                        dgv.text = "BD - " + Anaris.Instance.ScenarioManager.Risks[i].name;
                        risk.dgvList.Add(dgv);
                    }
                }

                Services.Service.Instance.SetUpData();
                SetupAnalysisView();
            }
            catch (Exception exc)
            {
                string error = exc.ToString();
                System.Windows.MessageBox.Show("Plik jest nieodpowiedni bądź zawiera błędy.");
                CloseProject();
            }
        }

        private void SetupAnalysisView()
        {
            grd_MagnitudeBar.Visibility = Visibility.Visible;
            grd_ProjectBar.Visibility = Visibility.Visible;
            tbc_MagnitudeOfRisk.Visibility = Visibility.Visible;
            tbc_MagnitudeOfRiskVal.Visibility = Visibility.Visible;
            tbc_ProjectName.Text = Anaris.Instance.ProjectProperties.FilePath;
            grd_ProjectBar.Background = new SolidColorBrush(Color.FromRgb(232, 189, 216));

            System.Windows.Controls.TabControl tabControl = new System.Windows.Controls.TabControl();
            Grid.SetRow(tabControl, 1);
            Grid.SetColumn(tabControl, 0);
            //tabControl.Name = "tbc_TabCollection";
            //Add this event handler from AgentViewModel

            TabItem tab = new TabItem();
            tab.Header = "Baza danych";
            tab.Background = new SolidColorBrush(Color.FromRgb(136, 192, 207));

            if (grd_DataGrid.DataContext == null)
            {
                AgentsViewModel dataContext = new AgentsViewModel();
                grd_DataGrid.DataContext = dataContext;

                tabControl.SelectionChanged += TabControl_SelectionChanged;
                Services.Service.Instance.BindEvents();
            }

            System.Windows.Controls.DataGrid database = GridBuilder.BuildBaseDataGrid(Anaris.Instance.DataBase);
            database.ItemsSource = ((AgentsViewModel)grd_DataGrid.DataContext).oDatabase.Rows;

            tab.Content = database;

            tabControl.Items.Insert(tabControl.Items.Count, tab);

            GridBuilder.BuildAnalysisTabs(grd_DataGrid, tabControl);
            grd_DataGrid.Children.Add(tabControl);

            cbx_Agents.IsEnabled = true;
        }



        private void Cbx_Agents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainWindowViewModel.SelectedAgent != -1)
            {
                int ScenarioIndex = AgentsViewModel.SelectedScenario[MainWindowViewModel.SelectedAgent];
                System.Windows.Controls.TabControl tabContainer = grd_DataGrid.Children.OfType<System.Windows.Controls.TabControl>().FirstOrDefault(); //AgentsViewModel.Instance.DisplayedScenarios[ScenarioIndex]
                TabItem tabItem = (TabItem)tabContainer.Items[tabContainer.SelectedIndex];

                Grid scenarioGrid = (Grid)tabItem.Content;
                System.Windows.Controls.DataGrid dataGrid = scenarioGrid.Children.OfType<System.Windows.Controls.DataGrid>().First();

                //System.Windows.Controls.DataGrid dataGrid = (System.Windows.Controls.DataGrid)tabItem.Content;
                int columns = dataGrid.Columns.Count;
                if (AgentsViewModel.SelectedScenario[MainWindowViewModel.SelectedAgent] == 0)
                {
                    dataGrid.Columns[columns - 1].Visibility = Visibility.Hidden;
                    dataGrid.Columns[columns - 2].Visibility = Visibility.Hidden;
                    dataGrid.Columns[columns - 3].Visibility = Visibility.Hidden;
                }
                else
                {
                    dataGrid.Columns[columns - 1].Visibility = Visibility.Visible;
                    dataGrid.Columns[columns - 2].Visibility = Visibility.Visible;
                    dataGrid.Columns[columns - 3].Visibility = Visibility.Visible;
                }

                //AgentsViewModel.Instance.ChangeDisplayedScenario();
                dataGrid.ItemsSource = AgentsViewModel.Instance.DisplayedScenarios[MainWindowViewModel.SelectedAgent].Rows;

            }
        }


        public void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Change SelectedTab in the ViewModel
            System.Windows.Controls.TabControl tabControl = (System.Windows.Controls.TabControl)sender;
            int SelectedIndex = tabControl.SelectedIndex - 1;
            MainWindowViewModel.SelectedAgent = SelectedIndex;
            MainWindowViewModel.Instance.UpdateScenarios();

            if (SelectedIndex < 0)
            {
                tbc_MagnitudeOfRisk.Visibility = Visibility.Hidden;
                tbc_MagnitudeOfRiskVal.Visibility = Visibility.Hidden;
            }
            else
            {
                tbc_MagnitudeOfRisk.Visibility = Visibility.Visible;
                tbc_MagnitudeOfRiskVal.Visibility = Visibility.Visible;
            }
        }


        private void mnu_MergeAnalysis_Click(object sender, RoutedEventArgs e)
        {
            using (OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog())
            {
                dialog.InitialDirectory = "C:";
                dialog.Title = "Otwórz analizę ryzyka Anaris";
                dialog.FileName = "";
                dialog.Filter = "Anaris Pliki|*.anrs|Word Documents|*.doc";

                if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                {
                    //Merge
                }
            }
        }

        #region WindowMaximize

        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        void win_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;

            if (System.Windows.Application.Current.Properties["ArbitraryArgName"] != null)
            {
                string fileName = System.Windows.Application.Current.Properties["ArbitraryArgName"].ToString();

                string extension = System.IO.Path.GetExtension(fileName);
                if (extension == ".anrs")
                {
                    this.LoadAnalysis(fileName);
                    return;
                }
                else if (extension == ".anrb")
                {
                    this.LoadDatabase(fileName);
                    return;
                }
            }

            WelcomeView = new WelcomeView();
            ((WelcomeViewViewModel)WelcomeView.DataContext).LoadDatabase = mnu_OpenDatabase_Click;
            ((WelcomeViewViewModel)WelcomeView.DataContext).LoadAnaris = mnu_OpenAnalysis_Click;
            WelcomeView.SetupDatabaseView = SetupDatabaseView;
            WelcomeView.SetupAnalysisView = SetupAnalysisView;

            WelcomeView.Owner = this;
            WelcomeView.ShowInTaskbar = false;
            WelcomeView.Topmost = true;
            WelcomeView.Show();

        }


        void win_SourceInitialized(object sender, EventArgs e)
        {
            System.IntPtr handle = (new WinInterop.WindowInteropHelper(this)).Handle;
            WinInterop.HwndSource.FromHwnd(handle).AddHook(new WinInterop.HwndSourceHook(WindowProc));
        }

        private static System.IntPtr WindowProc(System.IntPtr hwnd, int msg, System.IntPtr wParam, System.IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case 0x0024:
                    WmGetMinMaxInfo(hwnd, lParam);
                    handled = true;
                    break;
            }

            return (System.IntPtr)0;
        }

        private static void WmGetMinMaxInfo(System.IntPtr hwnd, System.IntPtr lParam)
        {

            MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));

            // Adjust the maximized size and position to fit the work area of the correct monitor
            int MONITOR_DEFAULTTONEAREST = 0x00000002;
            System.IntPtr monitor = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);

            if (monitor != System.IntPtr.Zero)
            {

                MONITORINFO monitorInfo = new MONITORINFO();
                GetMonitorInfo(monitor, monitorInfo);
                RECT rcWorkArea = monitorInfo.rcWork;
                RECT rcMonitorArea = monitorInfo.rcMonitor;
                mmi.ptMaxPosition.x = Math.Abs(rcWorkArea.left - rcMonitorArea.left);
                mmi.ptMaxPosition.y = Math.Abs(rcWorkArea.top - rcMonitorArea.top);
                mmi.ptMaxSize.x = Math.Abs(rcWorkArea.right - rcWorkArea.left);
                mmi.ptMaxSize.y = Math.Abs(rcWorkArea.bottom - rcWorkArea.top);
            }

            Marshal.StructureToPtr(mmi, lParam, true);
        }

        /// <summary>
        /// POINT aka POINTAPI
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            /// <summary>
            /// x coordinate of point.
            /// </summary>
            public int x;
            /// <summary>
            /// y coordinate of point.
            /// </summary>
            public int y;

            /// <summary>
            /// Construct a point of coordinates (x,y).
            /// </summary>
            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        };

        /// <summary>
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class MONITORINFO
        {
            /// <summary>
            /// </summary>            
            public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));

            /// <summary>
            /// </summary>            
            public RECT rcMonitor = new RECT();

            /// <summary>
            /// </summary>            
            public RECT rcWork = new RECT();

            /// <summary>
            /// </summary>            
            public int dwFlags = 0;
        }


        /// <summary> Win32 </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        public struct RECT
        {
            /// <summary> Win32 </summary>
            public int left;
            /// <summary> Win32 </summary>
            public int top;
            /// <summary> Win32 </summary>
            public int right;
            /// <summary> Win32 </summary>
            public int bottom;

            /// <summary> Win32 </summary>
            public static readonly RECT Empty = new RECT();

            /// <summary> Win32 </summary>
            public int Width
            {
                get { return Math.Abs(right - left); }  // Abs needed for BIDI OS
            }
            /// <summary> Win32 </summary>
            public int Height
            {
                get { return bottom - top; }
            }

            /// <summary> Win32 </summary>
            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }


            /// <summary> Win32 </summary>
            public RECT(RECT rcSrc)
            {
                this.left = rcSrc.left;
                this.top = rcSrc.top;
                this.right = rcSrc.right;
                this.bottom = rcSrc.bottom;
            }

            /// <summary> Win32 </summary>
            public bool IsEmpty
            {
                get
                {
                    // BUGBUG : On Bidi OS (hebrew arabic) left > right
                    return left >= right || top >= bottom;
                }
            }
            /// <summary> Return a user friendly representation of this struct </summary>
            public override string ToString()
            {
                if (this == RECT.Empty) { return "RECT {Empty}"; }
                return "RECT { left : " + left + " / top : " + top + " / right : " + right + " / bottom : " + bottom + " }";
            }

            /// <summary> Determine if 2 RECT are equal (deep compare) </summary>
            public override bool Equals(object obj)
            {
                if (!(obj is Rect)) { return false; }
                return (this == (RECT)obj);
            }

            /// <summary>Return the HashCode for this struct (not garanteed to be unique)</summary>
            public override int GetHashCode()
            {
                return left.GetHashCode() + top.GetHashCode() + right.GetHashCode() + bottom.GetHashCode();
            }


            /// <summary> Determine if 2 RECT are equal (deep compare)</summary>
            public static bool operator ==(RECT rect1, RECT rect2)
            {
                return (rect1.left == rect2.left && rect1.top == rect2.top && rect1.right == rect2.right && rect1.bottom == rect2.bottom);
            }

            /// <summary> Determine if 2 RECT are different(deep compare)</summary>
            public static bool operator !=(RECT rect1, RECT rect2)
            {
                return !(rect1 == rect2);
            }


        }

        [DllImport("user32")]
        internal static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);

        /// <summary>
        /// 
        /// </summary>
        [DllImport("User32")]
        internal static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);


        #endregion

        private void btn_CloseProject_Click(object sender, RoutedEventArgs e)
        {
            CloseProject();
        }

        private void CloseProject()
        {
            Services.Service tmp = new Services.Service();
            Anaris.Instance = null;
            Database.Instance = null;
            AgentsViewModel.Instance = null;
            ObservableGrid.DatabaseColumnCount = 0;

            GridBuilder.DataBaseGrid = null;
            GridBuilder.RiskGrids = new List<System.Windows.Controls.DataGrid>();

            grd_MagnitudeBar.Visibility = Visibility.Hidden;
            grd_ProjectBar.Visibility = Visibility.Hidden;
            grd_ProjectBar.Background = new SolidColorBrush(Colors.LightGray);
            grd_DataGrid.DataContext = null;
            grd_DataGrid.Children.RemoveAt(grd_DataGrid.Children.Count - 1);

            var context = (MenuViewModel)mnu_Window.DataContext;
            string[] names = context.GetAllManagersNames();
            foreach (string name in names)
            {
                HideWindow(name);
            }

            MainWindowViewModel.Instance.Scenarios.Clear();
            MainWindowViewModel.Instance.SelectedScenario = new KeyValuePair<int, string>(0, "");
            MainWindowViewModel.SelectedAgent = -1;
            
        }

        private void mnu_GenerateReport_Click(object sender, RoutedEventArgs e)
        {

            //Gather all the important data here like byteArray immages
            List<byte[]> categoryImages = new List<byte[]>();
            foreach (AnarisDLL.BLL.Category.Category cat in Services.Service.Instance.ValuePieCategories)
            {
                categoryImages.Add(Services.Service.Instance.LoadPieChartImage(cat.name));
            }

            ReportBuilder rb = new ReportBuilder();

            Services.Service.ConvertObservableToScenarios();
            rb.CreateReport(Anaris.Instance);
        }

        private List<double> GetColumnWidth(System.Windows.Controls.DataGrid grid)
        {
            return grid.Columns.Select(c => c.ActualWidth).ToList();
        }

        private List<List<double>> GetColumnWidth(ItemCollection tabControl)
        {
            List<List<double>> list = new List<List<double>>();
            for (int i = 1; i < tabControl.Count; i++)
            {
                var grid = (System.Windows.Controls.DataGrid)(((Grid)((TabItem)tabControl[i]).Content).Children[1]);
                list.Add(GetColumnWidth(grid));
            }

            return list;
        }

        private void mnu_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
