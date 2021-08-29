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
    /// Interaction logic for MergeDatabase.xaml
    /// </summary>
    public partial class MergeDatabase : Window
    {
        public MergeDatabase()
        {
            MergeDatabaseViewModel context = new MergeDatabaseViewModel();
            context.Close = this.Close;
            DataContext = context;
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

        private void btn_FindFile_Click(object sender, RoutedEventArgs e)
        {
            using (OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog())
            {
                dialog.InitialDirectory = "C:";
                dialog.Title = "Otwórz bazę danych Anaris";
                dialog.FileName = "";
                dialog.Filter = "Anaris Pliki|*.anrb|Word Documents|*.doc";

                if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                {
                    txt_Name.Text = dialog.FileName;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MergeDatabaseViewModel com = (MergeDatabaseViewModel)DataContext;
            this.Close();
        }
    }
}
