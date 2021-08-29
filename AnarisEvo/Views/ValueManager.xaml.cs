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
    /// Interaction logic for ValueManager.xaml
    /// </summary>
    public partial class ValueManager : Window
    {
        public ValueManager()
        {
            DataContext = new ValueManagerViewModel();
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
       

        private void lst_Values_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ValueManagerViewModel com = ((ValueManagerViewModel)DataContext);
            com.CloneSelection((AnarisDLL.BLL.Value.SingleValue)((ListView)sender).SelectedItem);
        }
    }
}
