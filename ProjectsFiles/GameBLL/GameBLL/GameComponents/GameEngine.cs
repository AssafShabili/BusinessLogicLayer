using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameBLL.BLL_Classess;
using GameBLL.GameComponents;
using System.Windows;
using System.Windows.Controls;

namespace GameBLL.GameComponents
{

    

    public class GameEngine
    {
        private GameBL gameBL;
        private bool attackPhase;
        private bool userDied;

      
        public GameEngine(GameBL game)
        {
            this.gameBL = game;
            this.attackPhase = false;
            this.userDied = false;
        }


        public void InitialsTowers(Canvas gameCanvas)
        {
            foreach(TowerBL tower in this.gameBL.GetTowersList())
            {
                Button button = tower.GetTowerButton();
                Point towerLocation = tower.GetLocation();

                gameCanvas.Children.Add(button);
                Canvas.SetLeft(button, towerLocation.X);
                Canvas.SetTop(button, towerLocation.Y);
            }
        }

        /// <summary>
        /// פעולה העדכון של המשחק 
        /// </summary>
        public void Update()
        {
            if(attackPhase)
            {
                
               //attacking time!
            }
            else//building Phase!
            {

            }
        }







        /// <summary>
        /// פעולה שהופכת את המשתנה של מבטה את המצב שהוא נמצא המשחק למצב התקפה 
        /// </summary>
        public void GoToAttackPhase()
        {
            this.attackPhase = true;
        }
        /// <summary>
        /// פעולה שהופכת את המשתנה של מבטה את המצב שהוא נמצא המשחק למצב הגנה  
        /// </summary>
        public void GoToBuildingPhase()
        {
            this.attackPhase = false;
        }


        /// <summary>
        /// פעולה לבניית המגדל
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool CanBuildTower(Point location)
        {
            return this.gameBL.CanBuildTowerHere(location);
        }

        /// <summary>
        /// פעולה לבניית המגדל 
        /// הפעולה בודקת אם אפשר לבנות את המגדל לפי הכסף של המשתמש
        /// </summary>
        /// <param name="towerBL">המגדל שרוצים לבנות</param>
        /// <returns>אמת אם אפשר לבנות המגדל (והפעולה בונה אותו) אחרת הפעולה תחזיר שקר ולא תבנה את המגדל</returns>
        public bool BuildTower(TowerBL towerBL)
        {
            if( (this.gameBL.GetMoney()-towerBL.GetTowerCost()) >= 0 )
            {
                gameBL.AddTowerToGame(towerBL);
                return true;
            }
            return false;
        }



        /// <summary>
        /// פעולה לשידרוג המגדל
        /// </summary>
        /// <param name="towerBL">המגדל שעליו יחול השידרוג</param>
        /// <returns>אמת אם אפשר לעשות את השידרוג(בנוסף לכך אם כן יהיה אפשר לשדרג את המגדל הפעולה תשדרג את המגדל) ושקר אחרת
        public bool UpgradeTowerAttackSpeed(TowerBL towerBL)
        {
           return  gameBL.UpgradeTowerAttackSpeed(towerBL);
        }
        /// <summary>
        /// פעולה לשידרוג המגדל
        /// </summary>
        /// <param name="towerBL">המגדל שעליו יחול השידרוג</param>
        /// <returns>אמת אם אפשר לעשות את השידרוג(בנוסף לכך אם כן יהיה אפשר לשדרג את המגדל הפעולה תשדרג את המגדל) ושקר אחרת
        public bool UpgradeTowerDamage(TowerBL towerBL)
        {
            return gameBL.UpgradeTowerDamage(towerBL);           
        }
        /// <summary>
        /// פעולה לשידרוג המגדל
        /// </summary>
        /// <param name="towerBL">המגדל שעליו יחול השידרוג</param>
        /// <returns>אמת אם אפשר לעשות את השידרוג(בנוסף לכך אם כן יהיה אפשר לשדרג את המגדל הפעולה תשדרג את המגדל) ושקר אחרת
        public bool UpgradeTowerRange(TowerBL towerBL)
        {
            return gameBL.UpgradeTowerRange(towerBL);           
        }

    }


}
