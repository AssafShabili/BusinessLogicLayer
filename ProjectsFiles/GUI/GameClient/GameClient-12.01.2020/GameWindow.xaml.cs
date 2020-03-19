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
using System.Windows.Threading;
using GameBLL.BLL_Classess;
using GameBLL.GameComponents;

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

       // private List<Label> labels = new List<Label>();


        public MainWindow()
        {
            InitializeComponent();
            gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromSeconds(1);
            gameTimer.Tick += timer_Tick;
            gameTimer.Start();
            game = new GameBL(1);
            gameEngine = new GameEngine(game);

            #region labels-list
            //this.labels.Add(LabelTowerInfo);
            //this.labels.Add(LabelTowercost);
            //this.labels.Add(LabelTowerDamage);
            //this.labels.Add(LabelTowerAttackSpeed);
            //this.labels.Add(LabelTowerRange);    
            #endregion
            
            this.InitialsTowers(gameCanvas);

        }
        
        private void InitialsTowers(Canvas gameCanvas)
        {
            int i = 0;
            foreach (TowerBL tower in this.game.GetTowersList())
            {
                Button button = tower.GetTowerButton();
                Point towerLocation = tower.GetLocation();

                tower.GetTowerButton().Click += TowerButton_MouseClick;
                tower.GetTowerButton().Name = "B" + i.ToString();
                i++;

                gameCanvas.Children.Add(button);
                Canvas.SetLeft(button, towerLocation.X);
                Canvas.SetTop(button, towerLocation.Y);
            }
        }



        private void timer_Tick(object sender, EventArgs e)
        {
            
        }

        private void gameCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(selection != TowerSelection.None)
            {
                Point point = Mouse.GetPosition(gameCanvas);
                Button button = new Button();
                button.Content = "PogU";
                button.Width = 50;               
                button.Height = 50;
                gameCanvas.Children.Add(button);

                Canvas.SetLeft(button, point.X);
                Canvas.SetTop(button, point.Y);

                selection = TowerSelection.None;
            }

        }


        /// <summary>
        /// פעולת הלחיצה בכפתור על מגדל
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TowerButton_MouseClick(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(
                (((Button)(sender)).Name).Trim('B')
                );

            TowerBL tower = gameEngine.GetTowerByIndex(index);

            LabelTowerInfo.Content = tower.GetTowerType().ToString() + $"{index}";

            LabelTowerAttackSpeed.Content = "Tower AttackSpeed: "+tower.GetAttackSpeed();
            LabelTowerDamage.Content = "Tower Damage: "+ tower.GetDamage();
            LabelTowerRange.Content = "Tower Range: "+tower.GetRange();

            LabelTowercost.Content = tower.GetTowerCost();
           



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
