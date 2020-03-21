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
using GameBLL.GameComponents;
using GameBLL.BLL_Classess;
using System.Windows.Threading;

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

        private GameBL game;
        private GameEngine gameEngine;
        DispatcherTimer gameTimer;
        

        public MainWindow()
        {
            //TODO: add to ctor the game object form the gameLobby
            InitializeComponent();
            gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromSeconds(1);
            gameTimer.Tick += timer_Tick;
            gameTimer.Start();
            game = new GameBL(1);
            gameEngine = new GameEngine(game);
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            //Fires every second!
            
        }

        private void gameCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(selection != TowerSelection.None)
            {
                Point point = Mouse.GetPosition(gameCanvas);

                Image image = new Image();
                image.Width = 500;
                image.Height = 500;
                image.Source = GetBitmapImage("Tower_air.png");
                image.Stretch = Stretch.None;


                Button button = new Button();
                button.Content = image ;

                

                button.Width = 50;
                button.Height = 50;
                gameCanvas.Children.Add(button);

                Canvas.SetLeft(button, point.X);
                Canvas.SetTop(button, point.Y);

                selection = TowerSelection.None;
            }

        }



        /// <summary>
        /// פעולה שמקבלת את השם של המפה  
        /// ומחזירה את המפה כ - bitmapImage
        /// </summary>
        /// <param name="mapName">שם של המפה של המשחק</param>
        /// <returns>הפעולה תחזיר את התמונה  שכדאי שנוכל להכניס אותה לתוך הפקד של התמונה</returns>
        public BitmapImage GetBitmapImage(string mapName)
        {
            BitmapImage bitMap = new BitmapImage();
            bitMap.BeginInit();
            bitMap.UriSource = new Uri($@"{mapName}", UriKind.Relative);
            bitMap.EndInit();
            return bitMap;
        }

        private void TowerButton_Click(object sender, RoutedEventArgs e)
        {
            this.selection = TowerSelection.TowerFire;
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
