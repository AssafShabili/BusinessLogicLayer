using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GameDAL.DAL_Classess;
using System.Windows;
using System.Windows.Controls;

using GameBLL.GameComponents;

namespace GameBLL.BLL_Classess
{
    public class GameBL
    {
        private int gameID;

        private WaveBL wave;
        private MapBL map;
        private List<TowerBL> towersList;


        private int userHealth;
        private int score;
        private int money;


        private int winStreak;
        private int lossStreak;

        //פעולה בונה  של מחלקת משחק
        public GameBL(int gameID)
        {
            DataTable dataTable = GameDAL.DAL_Classess.Game.GetGameInfo(gameID);

            if (dataTable != null)
            {
                this.gameID = gameID;


                this.map = new MapBL((int)(dataTable.Rows[0]["Game_Map_ID"]));

                this.wave = new WaveBL((int)(dataTable.Rows[0]["Game_Wave_ID"]), map.GetMapRoad());
                //this.wave.SetMapRoad(map.GetMapRoad());

                this.userHealth = (int)(dataTable.Rows[0]["Game_UserHealth"]);
                this.score = (int)(dataTable.Rows[0]["Game_Score"]);
                this.money = (int)(dataTable.Rows[0]["Game_Money"]);

                this.winStreak = (int)(dataTable.Rows[0]["Game_WinStreak"]);
                this.lossStreak = (int)(dataTable.Rows[0]["Game_LossStreak"]);


                this.towersList = new List<TowerBL>();
                this.InitializeTowers();


            }
            else
            {
                this.gameID = -1;
            }
        }

        public GameBL()
        {

        }
       
        /// <summary>
        /// פעולה לעדכון המגדלים של המשתמש לתוך השרשרת של המגדלים
        /// </summary>
        private void InitializeTowers()
        {
            DataTable dataTable = GameDAL.DAL_Classess.Game.GetGameTowers(this.gameID);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                this.towersList.Add(new TowerBL(
                    (int)(dataTable.Rows[i]["Tower_ID"])));
            }

        }

        /// <summary>
        /// פעולה לקבלת מספר המגדלים שהם מסוג מסוים
        /// </summary>
        /// <param name="towerType">סוג של המגדל שלפיו הפעולה מחזירה את המספר המגדל שהם אותו סוג</param>
        /// <returns>את מספר המגדלים שהם אותו סוג כמו הסוג שהפעולה קיבלה</returns>
        public int GetNumberByType(TowerType towerType)
        {
            int count = 0;
            foreach (TowerBL tower in this.towersList)
            {
                if(tower.GetTowerType() == towerType)
                {
                    count++;
                }
            }
            return count;
        }

        //public GameBL GetGameBL()
        //{
        //    return this;
        //}

        /// <summary>
        /// פעולה לבדיקה אם אפשר לבנות מגדל לפי המיקום
        /// </summary>
        /// <param name="postion">מיקום בלוח</param>
        /// <returns>תחזיר אמת אם אפשר לבנות את המגדל באותו מיקום אם לא אז תחזיר שקר</returns>
        public bool CanBuildTowerHere(Point postion)
        {
            return (this.map.GetMapRoad().Exists(x =>
            (x.X != postion.X ||
            x.Y != postion.Y)));
        }

        /// <summary>
        /// פעולה להוסף מגדל לבסיס נתונים
        /// </summary>
        /// <param name="tower">מגדל </param>
        public void AddTowerToGame(TowerBL tower)
        {
            this.towersList.Add(tower);
                
            GameDAL.DAL_Classess.Game.MakeNewTower(this.gameID, tower.GetTowerID());
        }

        #region old-comments
        ///// <summary>
        ///// פעולה לבדיקה אם אפשר לשדרג את המגדל לפי כמות הכסף שיש
        ///// </summary>
        ///// <param name="towerBL">המגדל הנל</param>
        ///// <returns>אמת אם אפשר לשדרג את המגדל ושקר אחרת </returns>
        //public bool CanUpgradeTowerDamage(TowerBL towerBL)
        //{
        //    return (this.money - towerBL.GetCostToUpgradeDamage() >= 0);
        //}
        ///// <summary>
        ///// פעולה לבדיקה אם אפשר לשדרג את המגדל לפי כמות הכסף שיש
        ///// </summary>
        ///// <param name="towerBL">המגדל הנל</param>
        ///// <returns>אמת אם אפשר לשדרג את המגדל ושקר אחרת </returns>
        //public bool CanUpgradeTowerAttackSpeed(TowerBL towerBL)
        //{
        //    return (this.money - towerBL.GetCostToUpgradeAttackSpeed() >= 0);
        //}
        ///// <summary>
        ///// פעולה לבדיקה אם אפשר לשדרג את המגדל לפי כמות הכסף שיש
        ///// </summary>
        ///// <param name="towerBL">המגדל הנל</param>
        ///// <returns>אמת אם אפשר לשדרג את המגדל ושקר אחרת </returns>
        //public bool CanUpgradeTowerRange(TowerBL towerBL)
        //{
        //    return (this.money - towerBL.GetCostToUpgradeRange() >= 0);
        //}

        ///// <summary>
        ///// פעולה לשידרוג הנזק של המגדל 
        ///// </summary>
        ///// <param name="towerBL">מגדל</param>
        //public void UpgradeTowerDamage(TowerBL towerBL)
        //{
        //    this.money -= towerBL.GetCostToUpgradeDamage();
        //    towerBL.UpgradeDamage();
        //}
        ///// <summary>
        ///// פעולה לשידרוג המספר התקיפות של המגדל
        ///// </summary>
        ///// <param name="towerBL">המגדל</param>
        //public void UpgradeTowerAttackSpeed(TowerBL towerBL)
        //{
        //    this.money -= towerBL.GetCostToUpgradeAttackSpeed();
        //    towerBL.UpgradeAttackSpeed();
        //}
        ///// <summary>
        ///// פעולה לשידרוג המרחק של המגדל
        ///// </summary>
        ///// <param name="towerBL">המגדל</param>
        //public void UpgradeTowerRange(TowerBL towerBL)
        //{
        //    this.money -= towerBL.GetCostToUpgradeRange();
        //    towerBL.UpgradeRange();
        //}
        #endregion

        /// <summary>
        /// פעולה לקבלת הסיבוב הבא
        /// </summary>
        /// <returns>עצם ממחלקת סיבוב </returns>
        public WaveBL NextWave()
        {
            if(GameDAL.DAL_Classess.Game.IsThereANextWave(this.wave.GetWaveID()))
            {
                //יש את הסיבוב הבא
                this.wave = new WaveBL(this.wave.GetWaveID() + 1);
                return this.wave;
            }
            return null;//Or we can return a wave obj which is the "winning wave" 
        }
        /// <summary>
        /// פעולה להוספת כסף למשחק
        /// </summary>
        /// <param name="amount"></param>
        public void AddMoney(int amount)
        {
            this.money += amount;
        }
        /// <summary>
        /// פעולה להוספת ניקוד למשחק
        /// </summary>
        /// <param name="score"></param>
        public void AddScore(int score)
        {
            this.score += score;
        }

        // חסר תןועלת אפשר להסיר
        public void DamageTaken()
        {
            if(this.userHealth-1 >= 0)
            {
                this.userHealth -= 1;
            }
        }

        /// <summary>
        /// פעולה להורדת כמות החיים של המשתמש 
        /// </summary>
        /// <param name="hitPoints">כמות הזק שהמשתמש לוקח</param>
        public void DamageTaken(int hitPoints)
        {
            if (this.userHealth - hitPoints >= 0)
            {
                this.userHealth -= hitPoints;
            }
        }


        /// <summary>
        /// פעולה לשידרוג המגדל
        /// </summary>
        /// <param name="towerBL">המגדל שעליו יחול השידרוג</param>
        /// <returns>אמת אם אשפר לעשות את השידרוג(בנוסף לכך אם כן יהיה אפשר לשדרג את המגדל הפעולה תשדרג את המגדל) ושקר אחרת</returns>
        public bool UpgradeTowerDamage(TowerBL towerBL)
        {
           int index = this.towersList.IndexOf(towerBL);
           if(index != -1)
           {
                int cost = this.towersList[index].GetCostToUpgradeDamage();
                if(cost <= this.money)
                {
                    this.towersList[index].UpgradeDamage();
                    this.money -= cost;

                    return true;
                }
                else
                {
                    return false;
                }                
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
            int index = this.towersList.IndexOf(towerBL);
            if(index != -1)
            {
                int cost = this.towersList[index].GetCostToUpgradeAttackSpeed();
                if(cost <= this.money)
                {
                    this.towersList[index].UpgradeAttackSpeed();
                    this.money -= cost;
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// פעולה לשידרוג המגדל
        /// </summary>
        /// <param name="towerBL">המגדל שעליו יחול השידרוג</param>
        /// <returns>אמת אם אפשר לעשות את השידרוג(בנוסף לכך אם כן יהיה אפשר לשדרג את המגדל הפעולה תשדרג את המגדל) ושקר אחרת
        public bool UpgradeTowerRange(TowerBL towerBL)
        {
            int index = this.towersList.IndexOf(towerBL);
            if (index != -1)
            {
                int cost = this.towersList[index].GetCostToUpgradeRange();
                if (cost <= this.money)
                {
                    this.towersList[index].UpgradeRange();
                    this.money -= cost;
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// פעולה שמחזירה איזה מגדל ש"כדאי" למשתמש לבנות
        /// </summary>
        /// <returns>סטריג שהוא הודעה למשתמש מה כדאי לאותו משתמש לבנות</returns>
        public string ShouldBuilt()
        {
            //int sum = Properties.GetNumberOfAllTowerTypeBuilt(this.wave.GetWaveID());            
            int waterTower = Properties.GetNumberOfTowerTypeBuilt(this.wave.GetWaveID(), "water");
            int fireTower = Properties.GetNumberOfTowerTypeBuilt(this.wave.GetWaveID(), "fire");
            int earthTower = Properties.GetNumberOfTowerTypeBuilt(this.wave.GetWaveID(), "earth");
            int airTower = Properties.GetNumberOfTowerTypeBuilt(this.wave.GetWaveID(), "air");

            if (Properties.GetWinRateOfWaveByID(this.wave.GetWaveID()) >= 55 ||
                Properties.GetWinRateOfWaveByID(this.wave.GetWaveID()) <= 65 )
            {
                if(waterTower >= fireTower && waterTower >= earthTower && waterTower >= airTower)
                {
                    return "You should build more Water towers! ";
                }
                else if(fireTower >= waterTower && fireTower >= airTower && fireTower >= earthTower)
                {
                    return "You should build more Fire towers!";
                }
                else if(earthTower >= fireTower && earthTower >= waterTower && earthTower >= airTower)
                {
                    return "You should build more Earth towers!";
                }
                else if(airTower >= waterTower && airTower >= fireTower && airTower >= earthTower)
                {
                    return "You should build more Air towers!";
                }
            }
            return null;
        }

        /// <summary>
        /// לפי המידע שנאגר מכל המשתמשים, הפעולה תמליץ מה כדי לבנות
        /// </summary>
        /// <returns>סטריג שמייצג מהכדי למשתמש לבנות</returns>
        public  string RecommendedToBuildByOtherUser()
        {//אויל לא צריך את זה
            
            DataTable dataTableWaveArchives = WaveArchives.GetWaveArchivesWithWaveProperties(this.wave.GetWaveID(), this.map.GetMapID());
            for (int i = 0; i < dataTableWaveArchives.Rows.Count; i++)
            {


            }
            return null;

        }

       

        /// <summary>
        /// פעולה לחישוב אחוז הניצחון של המשחק הנוכחי
        /// </summary>
        /// <returns>מחזיר את אחוז הניצחון </returns>
        public double CalculateWinStreak()
        {
            if(this.winStreak != 0 || this.lossStreak != 0)
            {
                return (this.winStreak) / (double)(this.winStreak + this.lossStreak);
            }
            return 0.0;
        }

        /// <summary>
        /// פעולה שסורקת אתה השרשרת של המגדלים 
        /// ומחזירה את מספר המגדלים
        /// </summary>
        /// <returns>זוג שמורכב מסוג המגדל וכמות של אותו סוג</returns>
        public List<Tuple<TowerType,int>> GetMostCommonTower()
        {
            List<Tuple<TowerType, int>> towersCommonList = new List<Tuple<TowerType, int>>();
            int water = 0;
            int fire = 0;
            int earth = 0;
            int air = 0;
            int normal = 0;

            foreach(TowerBL tower in this.towersList)
            {
                switch (tower.GetTowerType())
                {
                    case (TowerType.Fire):
                        fire++;
                        break;
                    case (TowerType.Water):
                        water++;
                        break;
                    case TowerType.Air:
                        air++;
                        break;
                    case TowerType.Earth:
                        earth++;
                        break;
                    case TowerType.defaultType:
                        normal++;
                        break;
                }
            }

            towersCommonList.Add(new Tuple<TowerType, int>(TowerType.Air, air));
            towersCommonList.Add(new Tuple<TowerType, int>(TowerType.Fire, fire));
            towersCommonList.Add(new Tuple<TowerType, int>(TowerType.Water, water));
            towersCommonList.Add(new Tuple<TowerType, int>(TowerType.Earth, earth));
            towersCommonList.Add(new Tuple<TowerType, int>(TowerType.defaultType, normal));

            towersCommonList.Sort();

            return towersCommonList;
        }

        /// <summary>
        /// פעולה לחישוב אחוז ההפסד של המשחק הנוכחי
        /// </summary>
        /// <returns>מחזיר את אחוז ההפסד</returns>
        public double CalculateLossStreak()
        {
            if (this.winStreak != 0 || this.lossStreak != 0)
            {
                return (this.lossStreak) / (double)(this.winStreak + this.lossStreak);
            }
            return 0.0;
        }


        /// <summary>
        /// פעולה לקידום מספר הניצחונות של המשתמש
        /// </summary>
        public void Won()
        {
            this.winStreak += 1;
        }
        /// <summary>
        /// פעולה לקידום מספר ההפסדים של המשתמש
        /// </summary>
        public void Loss()
        {
            this.lossStreak += 1;
        }


        


        // ======= פעולות איחזור ============
        public int GetWinStreak()
        {
            return this.winStreak;
        }
        public int GetLossStreak()
        {
            return this.lossStreak;
        }
        public WaveBL GetWave()
        {
            return this.wave;
        }
        public MapBL GetMap()
        {
            return this.map;
        }
        public int GetUserHealth()
        {
            return this.userHealth;
        }
        public int GetScore()
        {
            return this.score;
        }
        public int GetMoney()
        {
            return this.money;
        }
        public int GetGameBLID()
        {
            return this.gameID;
        }
        public List<TowerBL> GetTowersList()
        {
            return this.towersList;
        }
        // ======= סיום פעולות איחזור ============
    }
}
