using System;
using System.Collections.Generic;
using System.Data;
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
using GameClient_12._01._2020.GameServiceReference;


namespace GameClient_12._01._2020
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
    public partial class GameWindow : Window
    {
        public TowerSelection selection = TowerSelection.None;

        private GameBL game;
        private GameEngine gameEngine;
        private DispatcherTimer gameTimer;
        private UserBL user;



        public GameWindow(GameBL game,UserBL user)
        {
            InitializeComponent();
            gameTimer = new DispatcherTimer();

            gameTimer.Interval = TimeSpan.FromMilliseconds(20);

            gameTimer.Tick += timer_Tick;
            gameTimer.Start();
            this.game = game;
            this.user = user;


            gameEngine = new GameEngine(game, NextWaveButton);

            this.InitialsTowers(gameCanvas);
        }

        public GameWindow()
        {
            InitializeComponent();
            gameTimer = new DispatcherTimer();

            gameTimer.Interval = TimeSpan.FromMilliseconds(20);

            gameTimer.Tick += timer_Tick;
            gameTimer.Start();
            this.game = new GameBL(7);
            //this.user = new UserBL("assafShabili@gmail.com", "0524598498");

            gameEngine = new GameEngine(game, NextWaveButton);

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
            this.gameEngine.Update(gameCanvas, this);
            LabelMoney.Content = "Money: " + this.game.GetMoney() + " $";
            LabelWave.Content = "Wave ID: " + this.game.GetWave().GetWaveID() + " Type: " + this.game.GetWave();
            LabelScore.Content = "Score: " + this.game.GetScore();
            LabelHp.Content = this.game.GetUserHealth();
           
            //AttackSpeedButton.Content = this.gameEngine.

        }

        /// <summary>
        /// בנייה של המגדל
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point point = Mouse.GetPosition(gameCanvas);
            LabelError.Content = "";

            if (selection != TowerSelection.None && this.gameEngine.CanUserBuyTower()
                && this.gameEngine.CanBuildTower(point))
            {
                TowerBL towerBL = new TowerBL();
                int towerID = towerBL.makeTower(TowerSelectionToString(selection), (int)point.X, (int)point.Y);
                towerBL = new TowerBL(towerID);

                gameCanvas.Children.Add(towerBL.GetTowerButton());
                Canvas.SetLeft(towerBL.GetTowerButton(), point.X);
                Canvas.SetTop(towerBL.GetTowerButton(), point.Y);

                this.gameEngine.AddTowerToGame(towerBL);
                this.gameEngine.SetGameMoney(50);



                LabelMoney.Content = "Money: " + this.game.GetMoney() + " $";

                selection = TowerSelection.None;
            }
            else if (!this.gameEngine.CanUserBuyTower() || !this.gameEngine.CanBuildTower(point))
            {
                this.LabelError.Content = "can build here nor, \n you don't have money to buy it";
            }

            sectionA.Visibility = Visibility.Hidden;

        }

        /// <summary>
        /// פעולה להמרת סוג של הבחירה לסטרינג
        /// </summary>
        /// <param name="towerSelection">בחירה של הסוג של הבניין</param>
        /// <returns>הפעולה מחזירה את הסוג של אותו בחירה </returns>
        public string TowerSelectionToString(TowerSelection towerSelection)
        {
            switch (towerSelection)
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

            sectionA.Visibility = Visibility.Visible;

            TowerBL tower = gameEngine.GetTowerByIndex(index);

            LabelTowerInfo.Content = tower.GetTowerType().ToString() + $"{index}";
            LabelTowercost.Content = "Tower is worth: " + tower.GetTowerCost().ToString() + "$";
            LabelTowerAttackSpeed.Content = "Tower AttackSpeed: " + tower.GetAttackSpeed();
            LabelTowerDamage.Content = "Tower Damage: " + tower.GetDamage();
            LabelTowerRange.Content = "Tower Range: " + tower.GetRange();

            ComboBoxTypeTower.Name = "B" + index;
            
            if(tower.GetAttackSpeedLevel() <= 9)
            {
                AttackSpeedButton.Content = tower.GetCostToUpgradeAttackSpeed() + " $";
                AttackSpeedButton.Name = "B" + index.ToString();
            }
            else
            {
                AttackSpeedButton.IsEnabled = false;
            }
            AttackSpeedButton.Content = tower.GetCostToUpgradeAttackSpeed() + " $";
            AttackSpeedButton.Name = "B" + index.ToString();
            DamageButton.Content = tower.GetCostToUpgradeDamage() + " $";
            DamageButton.Name = "B" + (index.ToString());
            RangeButton.Content = tower.GetCostToUpgradeRange() + " $";
            RangeButton.Name = "B" + (index.ToString());
        }


        public int GetTowerTypeInComboBoxIndex(TowerType towerType)
        {
            switch (towerType)
            {
                case TowerType.Fire:
                    return 0;
                case TowerType.Air:
                    return 2;
                case TowerType.Water:
                    return 1;
                case TowerType.Earth:
                    return 3;
                default:
                    return 0;
            }

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


        /// <summary>
        /// המשתמש עובד לסיבוב הבא
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextWaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.gameEngine.NextWave() == true)
            {
                MessageBox.Show("You Won Good job!");
                this.Close();
            }
            LabelWave.Content = "Wave ID: " + this.game.GetWave().GetWaveID();
            this.gameEngine.GoToAttackPhase();

        }

        #region פעולות לשדרוג הבניין ושינוי הבניין
        private void AttackSpeedButton_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(((Button)sender).Name.Trim('B'), out int index))
            {
                TowerBL tower = gameEngine.GetTowerByIndex(index);
                if(tower.GetAttackSpeedLevel() < 9)
                {
                    if (!this.gameEngine.UpgradeTowerAttackSpeed(tower))
                    {
                        LabelError.Content = "You dont have the money \n for it!";
                    }
                    else
                    {
                        AttackSpeedButton.Content = tower.GetCostToUpgradeAttackSpeed() + " $";
                        LabelTowerAttackSpeed.Content = "Tower AttackSpeed: " + tower.GetAttackSpeed();
                    }
                }
                else
                {
                    AttackSpeedButton.IsEnabled = false;
                }
            }

            
        }
        private void DamageButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(((Button)sender).Name.Trim('B'), out int index))
            {
                TowerBL tower = gameEngine.GetTowerByIndex(index);
                if (!this.gameEngine.UpgradeTowerDamage(tower))
                {
                    LabelError.Content = "You dont have the money \n for it!";
                }
                else
                {
                    LabelTowerDamage.Content = "Tower Damage: " + tower.GetDamage();
                    DamageButton.Content = tower.GetCostToUpgradeDamage() + " $";
                   
                }
            }
        }
        private void RangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(((Button)sender).Name.Trim('B'), out int index))
            {
                TowerBL tower = gameEngine.GetTowerByIndex(index);
                if (!this.gameEngine.UpgradeTowerRange(tower))
                {
                    LabelError.Content = "You dont have the money \n for it!";
                }
                else
                {
                    RangeButton.Content = tower.GetCostToUpgradeRange() + " $";
                    LabelTowerRange.Content = "Tower Range: " + tower.GetRange();
                }
            }
        }



        private void ComboBoxTypeTower_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = int.Parse(
               (((ComboBox)(sender)).Name).Trim('B')
               );

            /*
             * אני לא צריך לדאוג לגביי החיוב של התשלום של המשתמשים שלי
             */
            TowerBL tower = this.gameEngine.GetTowerByIndex(index);
            switch (ComboBoxTypeTower.SelectedIndex)
            {
                case 0:
                    tower.SetTowerType(TowerType.Fire);
                    tower.UpdateImage();
                    break;
                case 1:
                    tower.SetTowerType(TowerType.Water);
                    tower.UpdateImage();
                    break;
                case 2:
                    tower.SetTowerType(TowerType.Air);
                    tower.UpdateImage();
                    break;
                case 3:
                    tower.SetTowerType(TowerType.Earth);
                    tower.UpdateImage();
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void ShouldBuiltButton_Click(object sender, RoutedEventArgs e)
        {          
            LabelShouldBuilt.Content = this.gameEngine.ShouldBuildTowers();
        }

        private void window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(this.gameEngine.GetLost())
            {//המשתמש הפסיד
                user.RemoveGameSave(user.GetIndexOfGameBL(this.game));                
            }
            try
            {
                using (ServiceClient client = new ServiceClient())
                {
                    DataTable dataTableProperties = GameDAL.DAL_Classess.Properties.GeAllWaveProperties();
                    for (int i = 0; i < dataTableProperties.Rows.Count; i++)
                    {
                        client.SendPropertiesInfoByFullInfo(
                            (int)dataTableProperties.Rows[i]["Property_ID"],
                             (int)dataTableProperties.Rows[i]["Wave_ID"],
                             (int)dataTableProperties.Rows[i]["numbers_of_wins"],
                             (int)dataTableProperties.Rows[i]["numbers_of_losess"],
                            (int)dataTableProperties.Rows[i]["numbers_of_water_towers"],
                            (int)dataTableProperties.Rows[i]["numbers_of_fire_towers"],
                            (int)dataTableProperties.Rows[i]["numbers_of_air_towers"],                        
                            (int)dataTableProperties.Rows[i]["numbers_of_earth_towers"]);
                    }
                }
            }
            catch
            {
                // לא צריך להראות למשתמש מה שקורא
            }
            
           
        }
    }
}
