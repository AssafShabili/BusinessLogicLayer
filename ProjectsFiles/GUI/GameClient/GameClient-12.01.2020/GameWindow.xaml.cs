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
        private DispatcherTimer gameTimer;

       


        public MainWindow()
        {
            InitializeComponent();
            gameTimer = new DispatcherTimer();

            gameTimer.Interval = TimeSpan.FromMilliseconds(20);

            gameTimer.Tick += timer_Tick;
            gameTimer.Start();
            game = new GameBL(1);
            gameEngine = new GameEngine(game);

            LabelMoney.Content ="Money: "+this.game.GetMoney()+" $";
            LabelWave.Content = "Wave ID: "+this.game.GetWave().GetWaveID();

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
            this.gameEngine.Update(gameCanvas);
        }

        /// <summary>
        /// בנייה של המגדל
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point point = Mouse.GetPosition(gameCanvas);
            if (selection != TowerSelection.None && this.gameEngine.CanUserBuyTower()
                && this.gameEngine.CanBuildTower(point))
            {
                TowerBL towerBL = new TowerBL();
                int towerID = towerBL.makeTower(TowerSelectionToString(selection),(int)point.X,(int)point.Y);
                towerBL = new TowerBL(towerID);

                gameCanvas.Children.Add(towerBL.GetTowerButton());
                Canvas.SetLeft(towerBL.GetTowerButton(), point.X);
                Canvas.SetTop(towerBL.GetTowerButton(), point.Y);

                this.gameEngine.AddTowerToGame(towerBL);

                selection = TowerSelection.None;
            }
            else
            {
                this.LabelError.Content = "can build here nor, \n you don't have money to buy it";
            }

        }

        /// <summary>
        /// פעולה להמרת סוג של הבחירה לסטרינג
        /// </summary>
        /// <param name="towerSelection">בחירה של הסוג של הבניין</param>
        /// <returns>הפעולה מחזירה את הסוג של אותו בחירה </returns>
        public string TowerSelectionToString(TowerSelection towerSelection)
        {
            switch(towerSelection)
            {
                case TowerSelection.TowerAir:
                    return "air";
                case TowerSelection.TowerEarth:
                    return "earth";
                case TowerSelection.TowerFire:
                    return "fire";
                case TowerSelection.TowerWater:
                    return "water";
                default:
                    return "";
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
            LabelTowercost.Content ="Tower is worth: " +tower.GetTowerCost().ToString()+"$";
            LabelTowerAttackSpeed.Content = "Tower AttackSpeed: "+tower.GetAttackSpeed();
            LabelTowerDamage.Content = "Tower Damage: "+ tower.GetDamage();
            LabelTowerRange.Content = "Tower Range: "+tower.GetRange();


            AttackSpeedButton.Content = tower.GetCostToUpgradeAttackSpeed() + " $";
            DamageButton.Content = tower.GetCostToUpgradeDamage() + " $";
            RangeButton.Content = tower.GetCostToUpgradeRange() + " $";
        }




      

        //בחריה של סוג האש
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

        private void ButtonSelectFire_Click(object sender, RoutedEventArgs e)
        {
            this.selection = TowerSelection.TowerFire;
        }

        private void ButtonSelectAir_Click(object sender, RoutedEventArgs e)
        {
            this.selection = TowerSelection.TowerAir;
        }

        private void ButtonSelectWater_Click(object sender, RoutedEventArgs e)
        {
            this.selection = TowerSelection.TowerWater;
        }

        private void ButtonSelectEarth_Click(object sender, RoutedEventArgs e)
        {
            this.selection = TowerSelection.TowerEarth;
        }
    }
}
