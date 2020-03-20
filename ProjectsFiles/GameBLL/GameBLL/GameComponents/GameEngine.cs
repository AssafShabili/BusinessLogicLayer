using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameBLL.BLL_Classess;
using GameBLL.GameComponents;
using System.Windows;
using System.Windows.Controls;
using System.Threading;

namespace GameBLL.GameComponents
{

    

    public class GameEngine
    {
        private GameBL gameBL;
        private bool attackPhase;
        private bool userDied;
        private Random random;

        private List<TowerProjectile> projectilelist = new List<TowerProjectile>();

        private double gameTime;





        private int currentEnemeysDeploy = 0;
        private List<Enemy> currentEnemey = new List<Enemy>();

        public GameEngine(GameBL game)
        {
            this.gameBL = game;
            this.attackPhase = true;//return to false
            this.userDied = false;
            this.gameTime = 0.0;
            this.random = new Random();
        }

        /// <summary>
        /// פעולה להחזרת המגדל לפי המיקום שלו בשרשרת המגדלים
        /// הנחה שלא ינתן מיקום שלא קיים בשרשרת
        /// </summary>
        /// <param name="index">מיקום המגדל בשרשרת המגדלים</param>
        /// <returns>אובייקט המגדל המתאים לפי גודל</returns>
        public TowerBL GetTowerByIndex(int index)
        {
            //מה קורה אם שי מיקום שהוא לא קיים
            //אולי אני צריך לתת לכפתורים את השמות עד פעם ?
            // כן!
            return this.gameBL.GetTowersList()[index];
        }
        


        /// <summary>
        /// פעולה העדכון של המשחק 
        /// </summary>
        public void Update(Canvas gameCanvas)
        {
            this.gameTime++;
            
            if(attackPhase)
            {
               
                if(this.currentEnemeysDeploy < this.gameBL.GetWave().GetEnemies().Count)
                {
                    this.currentEnemey.Add(this.gameBL.GetWave().GetEnemies()[this.currentEnemeysDeploy]);
                    this.currentEnemeysDeploy++;
                }


                this.currentEnemey.ForEach(enemey => enemey.Move(gameCanvas));
                this.gameBL.GetTowersList().ForEach(tower =>
                {
                    this.projectilelist = tower.TowerAttack(this.gameBL.GetWave().GetEnemies(), this.projectilelist, this.gameTime);
                });
                this.projectilelist.ForEach(projectile => projectile.Move(gameCanvas));
                this.currentEnemey.ForEach(enemy => enemy.Update(gameCanvas));


                if (CheckIfAllAreDead() && CheckIfAllprojectile())
                {
                    GoToBuildingPhase();
                    //MessageBox.Show("help");
                }



            }
            else//building Phase!
            {

            }
        }


        private bool CheckIfAllAreDead()
        {
            foreach(Enemy enemy in this.gameBL.GetWave().GetEnemies())
            {
                if(!enemy.IsDead())
                {
                    return false;
                }
            }
            return true;
        }
        private bool CheckIfAllprojectile()
        {
            foreach (TowerProjectile projectile in this.projectilelist)
            {
                if(!projectile.projectileHit())
                {
                    return false;
                }
            }
            return true;
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
