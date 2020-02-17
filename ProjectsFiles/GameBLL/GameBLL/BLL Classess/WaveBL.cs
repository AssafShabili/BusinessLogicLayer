using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameBLL.GameComponents;
using GameDAL.DAL_Classess;
using System.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace GameBLL.BLL_Classess
{
    
    /// <summary>
    /// מחלקת לסיבוב במשחק
    /// </summary>
    public class WaveBL
    {
        private int waveID;// מפתח של אותו סיבוב
        private List<Enemy> Enemylst;// שרשרת של האויבים
        private int bossID;// מפתח של הבוס

        private int completeScore;// כמות הנקודות שמקבל אותו משתמש
        private TowerType waveType;// סוג הסיבוב
        private int moneyGive;// כמות הכסף שמביא הסיבוב למשתמש אם המשתמש ניצח את הסיבוב

        //TODO: ADD bool which is if there is more waves or not (see GameBL NextWave(); )
        // אולי לא צריך את זה....


        /// <summary>
        /// פעולה בונה למחלקת סיבוב
        /// </summary>
        /// <param name="waveID">מפתח של הסיבוב</param>
        public WaveBL(int waveID)
        {
            DataTable dataT = GameDAL.DAL_Classess.Game.GetGameWaveInfo(waveID);
            //Console.WriteLine(DataTablePrint.BuildTable(dataT, 20));
            if (dataT != null)
            {
                this.waveID = waveID;
                Enemylst = new List<Enemy>();
                this.AddWaveUnit(dataT, "Wave_Normal_Unit");
                this.AddWaveUnit(dataT, "Wave_Normal_Range");
                this.AddWaveUnit(dataT, "Wave_Adv_Unit");
                this.AddWaveUnit(dataT, "Wave_Adv_Range");
                this.AddWaveUnit(dataT, "Wave_Ultra_Unit");
                this.AddWaveUnit(dataT, "Wave_Ultra_range");

                this.bossID = (int)(dataT.Rows[0]["Wave_Boss_id"]);
                this.completeScore = (int)(dataT.Rows[0]["Wave_Complete_Score"]);
                this.waveType = this.GetWaveTypeFromString((string)(dataT.Rows[0]["Wave_type"]));
                this.moneyGive = (int)(dataT.Rows[0]["Wave_Money_Give"]);
            }
            else
            {
                this.waveID = -1;
            }

        }

        /// <summary>
        /// פעולה לקבלת טֶקְסְטוּרָה מתוך שם של הסוג של האויב
        /// או בוס
        /// </summary>
        /// <param name="type">שם </param>
        /// <returns>מחזיר את טֶקְסְטוּרָה לפי הסטריג שנקלט </returns>
        private Texture2D GetBossTexture2D(string type)
        {
            switch (type.ToLower())
            {
                case "fire":
                    return GameConstants.fireBoss;
                case "water":
                    return GameConstants.waterBoss;
                case "air":
                    return GameConstants.airBoss;
                case "earth":
                    return GameConstants.earthBoss;
                default:
                    return null;
            }

        }

        /// <summary>
        /// פעולה שמקבלת מפתח של בוס 
        /// מכינה את הבוס ומוסיפה לשרשרת של האויבים
        /// </summary>
        /// <param name="bossID">מפתח של בוס</param>
        public void AddBossToWave(int bossID)
        {

            DataTable dataTable = GameDAL.DAL_Classess.Game.GetBossInfoByBossID(bossID);
            if(dataTable != null)
            {
                string bossType = (dataTable.Rows[0]["Boss_Type"]).ToString();
                Enemy boss = new Enemy(
                    (int)(dataTable.Rows[0]["Boss_health"]),
                    this.GetBossTexture2D(bossType),
                    this.GetTowerTypeFromString(bossType), 40, 36);

                this.Enemylst.Add(boss);
            }

        }

        /// <summary>
        /// פעולה לשינוי המחזירה סוג של מגדל לפי הסטריג שהיא קיבלה
        /// </summary>
        /// <param name="input">סריטג שמייצג את סוג במגדל</param>
        /// <returns>מחזירה את סוג המגדל</returns>
        private TowerType GetTowerTypeFromString(string input)
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
        /// פעולה להוספת בוס לתוך הסיבוב
        /// </summary>
        /// <param name="towerType">סוג של אותו הבוס</param>
        /// <param name="esayBoss">אם להוסיף את הבוס בתור בוס קל אותו בתור בוס קשה</param>
        /// בוס קל - בוס אם כמות חיים הנמוכה ביותר מאותו סוג של בוס
        /// בוס קשה - בוס אם כמות חיים הגדולה ביותר מאותו סוג של בוס
        public void AddBossToWave(TowerType towerType,bool esayBoss)
        {
            DataTable dataTable;
            if (esayBoss)
            {
                dataTable = GameDAL.DAL_Classess.Game.GetLowerestHealthBossByType(towerType.ToString());
            }
            else
            {
                dataTable = GameDAL.DAL_Classess.Game.GetHighestHealthBossByType(towerType.ToString());
            }

            if (dataTable != null)
            {
                string bossType = (dataTable.Rows[0]["Boss_Type"]).ToString();
                Enemy boss = new Enemy(
                    (int)(dataTable.Rows[0]["Boss_health"]),
                    this.GetBossTexture2D(bossType),
                    this.GetTowerTypeFromString(bossType), 40, 36);

                this.Enemylst.Add(boss);
            }
        }

        /// <summary>
        /// פעולת עזר שהופכת את שם השדה לסוג המתאים
        /// </summary>
        /// <param name="input">שם השדה</param>
        /// <returns>את סוג הסיבוב כ towertype</returns>
        private TowerType GetWaveTypeFromString(string input)
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
        /// פעולה לחישוב אם המשתמש צריך הקלות
        /// אם כן הפעולה "מקלה" על המשתמש 
        ///  באותה דרך הפעולה גם מקשה על המשתמש
        /// </summary>
        /// <param name="game">משחק של המשתמש</param>
        /// <param name="mapID">המפה של אותו משתמש</param>
        public void RecalculateEnemyWave(GameBL game, int mapID)
        {
            double currentWaveWinRate = Properties.GetWinRateOfWaveByID(this.waveID);

            if (currentWaveWinRate <= 36.5)
            {//בדיקה של אחוז הניצחון בסיבוב הנל
                if (currentWaveWinRate >= 10 && currentWaveWinRate <= 20)
                {
                    //אני מסיר 10 אחוז מכמות האויבים
                    for (int i = 0; i < this.Enemylst.Count * 0.9; i++)
                    {
                        this.Enemylst.RemoveAt(i);
                    }
                }
                else if (currentWaveWinRate >= 20 && currentWaveWinRate <= 30)
                {
                    //אני מסיר 20 אחוז מכמות האויבים
                    for (int i = 0; i < this.Enemylst.Count * 0.8; i++)
                    {
                        this.Enemylst.RemoveAt(i);
                    }
                }
                else if (currentWaveWinRate >= 30 && currentWaveWinRate <= 35)
                {
                    //אני מסיר 30 אחוז מכמות האויבים
                    for (int i = 0; i < this.Enemylst.Count * 0.7; i++)
                    {
                        this.Enemylst.RemoveAt(i);
                    }
                }
            }
            else if (currentWaveWinRate <= 50.5)
            {
                /*
                 * אם אחוז הניצחון שלי הוא מתחת ל50.5 אני מחליש את שאר האויבים 
                 */
                for (int i = 0; i < this.Enemylst.Count; i++)
                {
                    this.Enemylst[i].Hit(
                         (this.Enemylst[i].GetHp() / 2));
                }
            }
            
            // אם אחוז הניצחון של המשתמש גבוהה מאוד 
            if(game.CalculateWinStreak() >= 80 )
            {
                List<Tuple<TowerType, int>> towerList = game.GetMostCommonTower();
                Tuple<TowerType, int> maxTowerTuple = new Tuple<TowerType, int>(TowerType.defaultType,-1);

                foreach(Tuple<TowerType, int> towerTuple in towerList)
                {
                    if(maxTowerTuple.Item2 < towerTuple.Item2)
                    {
                        maxTowerTuple = towerTuple;
                    }
                }

                if( game.GetMoney() <= game.GetWave().GetMoneyGive())
                {
                    //אנו עכשיו יודעים שאם כמות הכסף של המשתמש קטנה 
                    //מכמות של הכסף שהסיבוב הולך לתת
                    // הבוס הולך להיות מסוג הנגדי לסוג של כל המגדלים שלו

                    this.AddBossToWave(this.GetCounterTowerType(maxTowerTuple.Item1), true);
                }
                //אנחנו מוסיפים לסיבוב בוס בכדי להקשות עם המשתמש     
                this.AddBossToWave(this.GetCounterTowerType(maxTowerTuple.Item1),false);

            }
            else if (game.CalculateWinStreak() <= 29)
            {
                List<Tuple<TowerType, int>> towerList = game.GetMostCommonTower();
                Tuple<TowerType, int> maxTowerTuple = new Tuple<TowerType, int>(TowerType.defaultType, -1);

                foreach (Tuple<TowerType, int> towerTuple in towerList)
                {
                    if (maxTowerTuple.Item2 < towerTuple.Item2)
                    {
                        maxTowerTuple = towerTuple;
                    }
                }
                this.AddBossToWave((maxTowerTuple.Item1), true);
            }
            
        }

        



        /// <summary>
        /// פעולה שמקבלת סוג של מגדל (או של אויבים זה לא משנה לפי התכנון שלי) ומחזירה את הסוג שמנוגד אליו
        /// ראה את התרשים שבתוך הפעולה הנ"ל
        /// </summary>
        /// <param name="towerType">סוג של המגדל ואו של אויב</param>
        /// <returns>הפעולה מחזירה את הסוג המנוגד שזה שהתקבל</returns>
        private TowerType GetCounterTowerType(TowerType towerType)
        {

            /*
             * fire -> air
             * air -> water 
             * water -> earth
             * earth -> fire
             */
            switch (towerType)
            {
                case TowerType.Air:
                    return TowerType.Water;
                case TowerType.Water:
                    return TowerType.Earth;
                case TowerType.Fire:
                    return TowerType.Air;
                case TowerType.Earth:
                    return TowerType.Fire;
                default:
                    return TowerType.defaultType;
            }

        }


        /// <summary>
        /// פעולה להוספת אויבים לתוך השרשרת 
        /// </summary>
        /// <param name="dataTable">טבלת הנתונים שבא יש את נתוני אותו סיבוב</param>
        /// <param name="databaseFields">הערך של איזה מהאויבים להוסיף לשרשרת האויבים</param>
        private void AddWaveUnit(DataTable dataTable, string databaseFields)
        {

            int numberofUnits = (int)(dataTable.Rows[0][databaseFields]);
            if (numberofUnits != -1)
            {
                for (int i = 0; i < numberofUnits; i++)
                {
                    //I should add BLL and
                    this.Enemylst.Add(new Enemy(
                        (this.waveID * 10) / 2, this.GetEnemyTextureFromString(databaseFields), this.waveType, 20, 18));
                    //                      ^ needs to be removed ASAP
                }
            }

        }

        /// <summary>
        /// פעולת עזר לשינוי משם השדה לאילך שהוא אמור להראות
        /// </summary>
        /// <param name="field">שם של השדה</param>
        /// <returns>איך שאותו אויב אמור להיראות</returns>
        private Texture2D GetEnemyTextureFromString(string field)
        {
            switch (field)
            {
                case "Wave_Normal_Unit":
                    return GameConstants.Wave_Normal_Unit;
                case "Wave_Normal_Range":
                    return GameConstants.Wave_Normal_Range;
                case "Wave_Adv_Unit":
                    return GameConstants.Wave_Adv_Unit;
                case "Wave_Adv_Range":
                    return GameConstants.Wave_Adv_Range;
                case "Wave_Ultra_Unit":
                    return GameConstants.Wave_Adv_Unit;
                case "Wave_Ultra_Range":
                    return GameConstants.Wave_Adv_Range;
                default:
                    return null;
            }
        }

        
        


        // ================= פעולות איחזור של הנתונים של הסיבוב ========
        public int GetCompleteScore()
        {
            return this.completeScore;
        }
        public TowerType GetWaveType()
        {
            return this.waveType;
        }
        public int GetMoneyGive()
        {
            return this.moneyGive;
        }
        public int GetWaveID()
        {
            return this.waveID;
        }
        // ================= סיום פעולות איחזור של הנתונים של הסיבוב ========

        
    }
}
