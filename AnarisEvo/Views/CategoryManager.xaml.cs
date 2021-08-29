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
using System.Windows.Interactivity;
using AnarisEvo.ViewModels;

namespace AnarisEvo.Views
{
    /// <summary>
    /// Interaction logic for CategoryManager.xaml
    /// </summary>
    public partial class CategoryManager : Window
    {
        public CategoryManager()
        {
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

        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            CategoryManagerViewModel man = (CategoryManagerViewModel)this.DataContext;
            Dictionary<int, string> dick = (Dictionary<int,string>)cmb_Type.ItemsSource;    
        }


        private void lst_Categories_SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selection = ((TreeView)sender).SelectedItem;
            CategoryManagerViewModel com = ((CategoryManagerViewModel)DataContext);
            com.CloneSelection( ((TreeView)sender).SelectedItem);
        }
    }
}
