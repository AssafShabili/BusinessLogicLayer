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

namespace WpfAppGameTesing
{
    public enum TowerSelection
    {
        TowerWater,
        TowerFire,
        TowerAir,
        TowerEarth,
        None
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TowerSelection selection = TowerSelection.None;
        int a = 9;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void gameCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(selection != TowerSelection.None)
            {
                Point point = Mouse.GetPosition(gameCanvas);
                Button button = new Button();
                button.Content = "PogU";
                button.Width = 50;
                if(a != 5)
                {

                }
                button.Height = 50;
                gameCanvas.Children.Add(button);

                Canvas.SetLeft(button, point.X);
                Canvas.SetTop(button, point.Y);

                selection = TowerSelection.None;
            }

        }

        private void b_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Button button = new Button();
            button.Content = "PogU";

            gameGrid.Children.Add(button);
            button.Width = 50;
            button.Height = 50;
            Grid.SetColumn(button, 0);
            Grid.SetColumn(button, 0);
        }

        private void b_Click(object sender, RoutedEventArgs e)
        {
            this.selection = TowerSelection.TowerFire;

        }

        private void b_LostFocus(object sender, RoutedEventArgs e)
        {
           
        }

        private void b_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
