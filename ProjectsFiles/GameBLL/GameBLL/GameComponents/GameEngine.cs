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

        private Random random;

        private bool wonWave;


        private List<TowerProjectile> projectilelist = new List<TowerProjectile>();

        private double gameTime;

        private Button nextWaveButton;







        private int currentEnemeysDeploy = 0;
        private List<Enemy> currentEnemey = new List<Enemy>();


        public GameEngine(GameBL game, Button button)
        {
            this.gameBL = game;
            this.attackPhase = true;//return to false
            this.userDied = false;
            this.gameTime = 0.0;
         
            this.nextWaveButton = button;
            this.nextWaveButton.IsEnabled = true;
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
        /// <param name="gameCanvas">לוח המשחק</param>
        /// <param name="window">לוח של המשחק</param>
        /// <param name="user">משתמש</param>
        public void Update(Canvas gameCanvas, Window window,UserBL user)
        {
            this.gameTime++;

            if (attackPhase)
            {

                if (this.currentEnemeysDeploy < this.gameBL.GetWave().GetEnemies().Count)
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
                this.currentEnemey.ForEach(enemy => enemy.Update(gameCanvas, this.gameBL));



                if (this.gameBL.GetUserHealth() <= 0)
                {
                    MessageBox.Show("You have lost! \n deleting your save ...");
                    user.RemoveGameSave(user.GetIndexOfGameBL(this.gameBL));
                    window.Close();
                }

                //תנאי הניצחון
                if ((CheckIfAllAreDead() && CheckIfAllprojectile()) || CheckIfDeadOrEnd() || checkIfAllAtEnd())
                {
                    this.currentEnemey = new List<Enemy>();
                    this.currentEnemeysDeploy = 0;
                    this.projectilelist.ForEach(projectile => projectile.Update(gameCanvas));
                    GoToBuildingPhase();

                    this.wonWave = CheckIfAllAreDead();
                }
               

            }
            else//building Phase!
            {
                if (this.gameBL.GetUserHealth() <= 0)
                {
                    MessageBox.Show("You have lost!");
                    window.Close();
                }
            }
        }


        public bool NextWave()
        {
            int money = this.gameBL.GetWave().GetMoneyGive();
            int score = this.gameBL.GetWave().GetCompleteScore();
            int preWaveID = this.gameBL.GetWave().GetWaveID();
            WaveBL waveBL = this.gameBL.NextWave();

            if (waveBL != null)
            {
                this.gameBL.AddMoney(money);
                this.gameBL.AddScore(score);

                //הפעולה למורכבת שלי 
                this.gameBL.GetWave().RecalculateEnemyWave(this.gameBL,
                    this.gameBL.GetMap().GetMapID());

                this.gameBL.UpdatePropertiesInfo(this.wonWave, preWaveID);

                this.gameBL.UpdateGameScore();

                return false;
            }
            return true;
        }





        private bool CheckIfAllAreDead()
        {
            foreach (Enemy enemy in this.gameBL.GetWave().GetEnemies())
            {
                if (!enemy.IsDead())
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
                if (!projectile.projectileHit())
                {
                    return false;
                }
            }
            return true;
        }
        private bool CheckIfDeadOrEnd()
        {
            foreach (Enemy enemy in this.gameBL.GetWave().GetEnemies())
            {
                if (enemy.IsDead() || !enemy.IsAtEnd())
                {
                    return false;
                }
            }
            return true;
        }
        private bool checkIfAllAtEnd()
        {
            foreach (Enemy enemy in this.gameBL.GetWave().GetEnemies())
            {
                if (!enemy.IsAtEnd())
                {
                    return false;
                }
            }
            return true;
        }



        /// <summary>
        /// פעולה להוספת כסף של אותו משתמש
        /// </summary>
        /// <param name="amount">כמות של כסף</param>
        public void SetGameMoney(int amount)
        {
            this.gameBL.AddMoney(-amount);
        }


        /// <summary>
        /// פעולה לבדיהק אם אפשר לבנות פה מגדל
        /// </summary>
        /// <returns>מחזירה אמת אם אפשר לבנות מגדל ושקר אחרת</returns>
        public bool CanUserBuyTower()
        {
            return (this.gameBL.GetMoney() - 50 >= 0);
        }


        /// <summary>
        /// פעולה שהופכת את המשתנה של מבטה את המצב שהוא נמצא המשחק למצב התקפה 
        /// </summary>
        public void GoToAttackPhase()
        {
            this.attackPhase = true;
            this.nextWaveButton.IsEnabled = false;
        }
        /// <summary>
        /// פעולה שהופכת את המשתנה של מבטה את המצב שהוא נמצא המשחק למצב הגנה  
        /// </summary>
        public void GoToBuildingPhase()
        {
            this.attackPhase = false;
            this.nextWaveButton.IsEnabled = true;
            this.gameBL.UpdateGameInfo();
            this.gameBL.UpdateTowerInfo();
            
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
            if ((this.gameBL.GetMoney() - towerBL.GetTowerCost()) >= 0)
            {
                gameBL.AddTowerToGame(towerBL);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="towerBL"></param>
        public void AddTowerToGame(TowerBL towerBL)
        {
            this.gameBL.AddTowerToGame(towerBL);
        }



        /// <summary>
        /// פעולה לשידרוג המגדל
        /// </summary>
        /// <param name="towerBL">המגדל שעליו יחול השידרוג</param>
        /// <returns>אמת אם אפשר לעשות את השידרוג(בנוסף לכך אם כן יהיה אפשר לשדרג את המגדל הפעולה תשדרג את המגדל) ושקר אחרת
        public bool UpgradeTowerAttackSpeed(TowerBL towerBL)
        {
            return gameBL.UpgradeTowerAttackSpeed(towerBL);
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


        /// <summary>
        /// פעולה לעדכון המגדלים במשחק
        /// </summary>
        /// <param name="index">המיקום של המגדל בשרשרת של המגדלים</param>
        public void ChangeTowerType(int index, TowerType towerType)
        {
            gameBL.GetTowersList()[index].SetTowerType(towerType);
        }





        /// <summary>
        /// פעולה לשינוי המחזירה סוג של מגדל לפי הסטריג שהיא קיבלה
        /// </summary>
        /// <param name="input">סריטג שמייצג את סוג במגדל</param>
        /// <returns></returns>
        public TowerType GetTowerTypeFromString(string input)
        {
            switch (input.ToLower())
            {
                case "water":
                    return TowerType.Water;
                case "fire":
                    return TowerType.Fire;
                case "air":
                    return TowerType.Air;
                case "earth":
                    return TowerType.Earth;
                default:
                    return TowerType.defaultType;
            }
        }


        /// <summary>
        /// פעולה שמחזירה איזה סוג של בניינים כדאי לאותו משתמש לבנות
        /// </summary>
        /// <returns>סטרניג שמייצג את התגובה לאותו דבר</returns>
        public string ShouldBuildTowers()
        {
            return this.gameBL.ShouldBuilt();
        }








    }


}
