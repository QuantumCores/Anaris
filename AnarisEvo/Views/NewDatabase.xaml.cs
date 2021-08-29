using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;
using AnarisDLL.BLL.Anaris;
using AnarisDLL.BLL.Database;
using AnarisEvo.ViewModels;

namespace AnarisEvo.Views
{
    /// <summary>
    /// Interaction logic for NewDatabase.xaml
    /// </summary>
    public partial class NewDatabase : Window
    {
        public NewDatabase()
        {
            NewDatabaseViewModel vm = new NewDatabaseViewModel();
            //vm.WindowCloseAction = this.Close;
            DataContext = vm;
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

        private void btn_Browse_Click(object sender, RoutedEventArgs e)
        {
            using (FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txt_ProjectPath.Text = dialog.SelectedPath;
                }
            }
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }        
    }
}
