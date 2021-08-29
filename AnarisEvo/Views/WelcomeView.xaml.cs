using AnarisEvo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AnarisEvo.Views
{
    /// <summary>
    /// Interaction logic for WelcomeView.xaml
    /// </summary>
    public partial class WelcomeView : Window
    {
        public WelcomeView()
        {
            DataContext = new WelcomeViewViewModel();
            InitializeComponent();
            CenterWindowOnScreen();
        }

        void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void btn_LoadDatabase_Click(object sender, RoutedEventArgs e)
        {
            //using (OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog())
            //{
            //    dialog.InitialDirectory = "C:";
            //    dialog.Title = "Otwórz bazę danych Anaris";
            //    dialog.FileName = "";
            //    dialog.Filter = "Anaris Pliki|*.anrb|Word Documents|*.doc";

            //    if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            //    {
            WelcomeViewViewModel com = (WelcomeViewViewModel)DataContext;
            com.LoadDatabase(sender, e);
            this.Close();
            //    }
            //}
        }

        private void btn_LoadAnaris_Click(object sender, RoutedEventArgs e)
        {
            //using (OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog())
            //{
            //    dialog.InitialDirectory = "C:";
            //    dialog.Title = "Otwórz analizę ryzyka Anaris";
            //    dialog.FileName = "";
            //    dialog.Filter = "Anaris Pliki|*.anrs|Word Documents|*.doc";

            //    if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            //    {
            WelcomeViewViewModel com = (WelcomeViewViewModel)DataContext;
            com.LoadAnaris(sender, e);
            this.Close();
            //    }
            //}
        }

        public Action SetupDatabaseView;
        private void btn_NewDatabase_Click(object sender, RoutedEventArgs e)
        {
            NewDatabase databaseDailog = new NewDatabase();
            ((NewDatabaseViewModel)databaseDailog.DataContext).CreateNewDatabase = SetupDatabaseView;
            databaseDailog.Show();
            this.Close();
        }

        public Action SetupAnalysisView;
        private void btn_NewAnaris_Click(object sender, RoutedEventArgs e)
        {
            NewAnalysis analysisDailog = new NewAnalysis();
            ((NewAnalysisViewModel)analysisDailog.DataContext).CreateNewAnalysis = SetupAnalysisView;
            analysisDailog.Show();
            this.Close();
        }
    }
}
