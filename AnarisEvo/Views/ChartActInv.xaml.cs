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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AnarisEvo.Views
{
    /// <summary>
    /// Interaction logic for ChartActInv.xaml
    /// </summary>
    public partial class ChartActInv : Window
    {
        public ChartActInv()
        {
            DataContext = new ChartActInvViewModel();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChartActInvViewModel com = (ChartActInvViewModel)DataContext;
        }
    }
}
