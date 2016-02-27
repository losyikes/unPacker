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
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace unPacker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Grid> mainGridList = new List<Grid>();
        
        public MainWindow()
        {
            InitializeComponent();
            populateLists();
        }

        private void mainBtnClick(object sender, RoutedEventArgs e)
        {
            showGrid(mainWindowGrid, mainGridList);
        }

        private void settingsBtnClick(object sender, RoutedEventArgs e)
        {
            showGrid(settingsGrid, mainGridList);
        }
        void populateLists()
        {
            mainGridList.Add(mainWindowGrid);
            mainGridList.Add(settingsGrid);
        }
        void showGrid(Grid grid, List<Grid> gridList)
        {
            foreach(Grid gridItem in gridList)
            {
                if(gridItem == grid)
                    gridItem.Visibility = Visibility.Visible;
                else
                    gridItem.Visibility = Visibility.Hidden;
            }
        }
    }
}
