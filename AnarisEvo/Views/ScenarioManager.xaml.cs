using AnarisDLL.BLL.Risk;
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
    /// Interaction logic for ScenarioManager.xaml
    /// </summary>
    public partial class ScenarioManager : Window
    {
        public ScenarioManager()
        {
            DataContext = new ScenarioManagerViewModel();
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


        private void lst_Scenarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ScenarioManagerViewModel com = (ScenarioManagerViewModel)DataContext;
            ElementaryRisk selected = (ElementaryRisk)lst_Scenarios.SelectedItem;

            if (selected != null)
            {
                com.CloneSelection(selected);
            }
            
        }
    }
}
