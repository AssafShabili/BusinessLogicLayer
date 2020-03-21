using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GameDAL.DAL_Classess
{
    /// <summary>
    /// מחלקה לטיפול למשחק 
    /// </summary>
    public static class Game
    {
               
        /// <summary>
        /// פונקציה לקבלת הנתונים של המשחק 
        /// </summary>
        /// <param name="ID">מפתח של השמירה של המשחק</param>
        /// <returns>טבלת נתונים שמכילה את הנתנים של המשחק</returns>
        public static DataTable GetGameInfo(int ID)
        {
            return DBHelper.GetDataTable
                (0, " SELECT Game.Game_Wave_ID, Game.Game_Map_ID, Game.Game_UserHealth, Game.Game_Score, Game.Game_Money,Game_LossStreak,Game_WinStreak  " +
                        " FROM Game "+
                        $" WHERE Game.Game_ID = {ID} ");
        }

        /// <summary>
        /// פונקציה לקבלת הנתונים של המגדלים של המשחק
        /// </summary>
        /// <param name="ID">מפתח של השמירה של המשחק</param>
        /// <returns>טבלת נתונים שמחזירה את הנתונים של המגדלים</returns>
        public static DataTable GetGameTowers(int gameID)
        {
            return DBHelper.GetDataTable(0,
                " SELECT Towers.[Tower_ID],Towers.Tower_Type, Towers.Tower_range, Towers.Tower_damage, Towers.Tower_attackSpeed, Towers.Tower_X, Towers.Tower_Y, Towers.Tower_cost, Towers.Tower_Img,Tower_damage_lvl,Tower_range_lvl,Tower_attackSpeed_lvl " +
                " FROM Game INNER JOIN(Towers INNER JOIN GameTowers ON Towers.[Tower_ID] = GameTowers.[Tower_ID]) ON Game.[Game_ID] = GameTowers.[Game_ID] "+
               $" WHERE Game.[Game_ID] = {gameID} ");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameID">מפתח של השמירה של המשחק</param>
        /// <param name="towerID">מפתח של המגדל</param>
        public static void DeleteGameTower(int gameID,int towerID)
        {
            DBHelper.UpdateQuery(" DELETE FROM GameTowers "+
            $" WHERE GameTowers.Game_ID = {gameID}  AND GameTowers.Tower_ID = {towerID} ");
        }

        /// <summary>
        /// פעולה ךהוספת המגדל למשחק המתאים
        /// </summary>
        /// <param name="gameID">מפתח מזהה של אותו מגדל</param>
        /// <param name="towerID">מפתח מזהה של אותו משחק </param>
        public static void MakeNewTower(int gameID,int towerID)
        {
            DBHelper.UpdateQuery(" INSERT INTO GameTowers([Game_ID],Tower_ID) "+
                $" VALUES({gameID},{towerID}) ");
        } 
      
        #region move to busines logic or delete 
        /// <summary>
        /// פונקציה לשידרוג המגדלים
        /// </summary>
        /// <param name="gameID">מפתח של השמירה של המשחק</param>
        /// <param name="towerID">מפתח של המגדל</param>
        /// <param name="currentLevel">הרמה של המגדל</param>
        /// <param name="towerType">הסוג של המגדל</param>
        //public static void UpgradeTower(int gameID,int towerID,int currentLevel,string towerType)
        //{
        //    DataTable dataTable = DBHelper.GetDataTable(0,
        //        "SELECT Towers.[Tower_ID],Towers.[Tower_lvl]" +
        //        "FROM Towers"+      // gets the next level tower
        //       $"WHERE Towers.[Tower_lvl] = {currentLevel + 1} AND Towers.[Tower_type] = '{towerType}' ");

        //    //Gets the next level Tower
        //    int newTowerID = Convert.ToInt32(dataTable.Rows[0][0]);

        //    DBHelper.UpdateQuery(
        //        " UPDATE GameTowers "+
        //        $" SET GameTowers.Game_ID = {gameID}, GameTowers.Tower_ID = {newTowerID} "+
        //        $" WHERE GameTowers.Game_ID = {gameID} AND GameTowers.Tower_ID = {towerID}; ");
        //}//NEED CHECKING
        #endregion


      
        /// <summary>
        /// פונקציה לשינוי הסוג של המגדל 
        /// </summary>
        /// <param name="towerID">מפתח של המגדל</param>
        /// <param name="typeNew">הסוג החדש של המגדל</param>
        public static void ChangeTypeTower(int towerID,string typeNew)
        {            
            DBHelper.UpdateQuery(
                "  UPDATE Towers  " +
                $" SET Towers.[Tower_Type] = '{typeNew}' " +
                $" WHERE Towers.[Tower_ID] = {towerID}; ");
        }

        


        /// <summary>
        ///  פעולה ליצירת משחק דיפולטיי
        /// </summary>
        /// <param name="mapID"> מפתח של המפה</param>
        /// <returns>מחזיר את המפתח של המשחק החדש או שיחזיר -1 במקרה שזה לא הצליח</returns>
        public static int MakeDefaultGame(int mapID)
        {
            bool action =  DBHelper.UpdateQuery($"INSERT INTO Game ([Game_Wave_ID],[Game_Map_ID],Game_UserHealth,Game_Score,Game_Money)" +
                $" VALUES(1,{mapID},250,0,150)");
            if(action)
            {
                DataTable dataTable = DBHelper.GetDataTable(0,
                    "SELECT Game.[Game_ID] FROM Game ORDER BY Game_ID DESC");
                return (int)(dataTable.Rows[0][0]);
            }
            return -1;           
        }

        
        /// <summary>
        ///  פעולה לבדיקה אם המשתמש יכול ליצור עוד שמירה  
        /// </summary>
        /// <param name="userID">מפתח של המשחק </param>
        /// <returns>מחזיר אם אפשר ליצור שמירה או לא </returns>
        public static bool CanUserAddSave(int userID)
        {
            DataTable dt = DBHelper.GetDataTable(0," SELECT UsersSavesGames_ID "+
                                " FROM UsersSavesGames "+
           $" WHERE  UsersSavesGames.[User_ID] = {userID} ");
            int counter = 0;
            foreach(var item in dt.Columns)
            {
                counter++;
            }
            return (counter < 3);
        }//checked

        //public static פעולה לסטרט אף של המשחק שלי מביא את הלכ הנתונים של המחשק ואת כל המגדלים

        /// <summary>
        /// פעולה להוספת משחק 
        /// </summary>
        /// <param name="userID">מפתח של המשתמש </param>
        /// <param name="gameID">מפתח של המשחק </param>
        public static void UserAddSave(int userID,int gameID)
        {
            DBHelper.UpdateQuery($" INSERT INTO UsersSavesGames (User_ID,Game_ID) " +
                $" VALUES({userID},{gameID}) ");
        }//checked

        /// <summary>
        ///  פעולה לקבלת המידע של המשחק 
        /// </summary>
        /// <param name="gameID">מפתח של המשחק</param>
        /// <returns>מחזיר טבלה לקבלת המידע על הטבלה</returns>
        public static DataTable GetGameWaveInfo(int gameID)
        {
            return DBHelper.GetDataTable(0,
                " SELECT Wave.[Wave_Normal_Unit], Wave.[Wave_Normal_Range], Wave.[Wave_Adv_Unit], Wave.[Wave_Adv_Range], Wave.[Wave_Ultra_Unit], Wave.[Wave_Ultra_range], Wave.[Wave_Boss_id], Wave.[Wave_Complete_Score], Wave.[Wave_type], Wave.[Wave_Money_Give] "+
                " FROM Wave "+
               $" WHERE Wave_id = {gameID}");

        }


        #region TOBE Removed maybe?
        /// <summary>
        /// פעולה לבדיקה אם מגדל נמצא במשחק מסויים
        /// </summary>
        /// <param name="gameID">מפתח של משחק</param>
        /// <param name="TowerID">מפתח של מגדל</param>
        /// <returns>פעולה לבדיקה אם מגדל א' נמצא במשחק ב  </returns>
        public static bool CheckTowerIsInGame(int gameID,int TowerID)
        {
            DataTable dataTable = DBHelper.GetDataTable(0,
                " SELECT GameTowers.[Game_ID], GameTowers.[Tower_ID] "+
                " FROM GameTowers "+
              $" WHERE GameTowers.[Game_ID] = {gameID} AND  GameTowers.[Tower_ID] = {TowerID} ");

            return (dataTable.Rows.Count == 0);
        } // לא צריך ניראלי

        /// <summary>
        ///  פעולה לקבלת את כמות החיים
        /// </summary>
        /// <param name="gameID">מפתח של המשחק</param>
        /// <returns>מחזיר את כמות החיים </returns>
        public static int GetGameHealth(int gameID)
        {
            DataTable dataTable = DBHelper.GetDataTable(0,
                " SELECT Game.[Game_UserHealth] " +
                " FROM Game " +
               $" WHERE Game.[Game_ID] = {gameID} ");

            return (int)(dataTable.Rows[0][0]);
        }

        public static int GetGameScore(int gameID)
        {
            DataTable dataTable = DBHelper.GetDataTable(0,
                " SELECT Game.[Game_Score] " +
                " FROM Game " +
               $" WHERE Game.[Game_ID] = {gameID} ");

            return (int)(dataTable.Rows[0][0]);
        }

        public static int GetGameMoney(int gameID)
        {
            DataTable dataTable = DBHelper.GetDataTable(0,
                " SELECT Game.[Game_Money] " +
                " FROM Game " +
               $" WHERE Game.[Game_ID] = {gameID} ");

            return (int)(dataTable.Rows[0][0]);
        }

        public static int GetGameWaveID(int gameID)
        {
            return Convert.ToInt32((DBHelper.GetDataTable(0,
                 " SELECT Game.[Game_Wave_ID] " +
                 " FROM Game " +
                $" WHERE Game_ID = {gameID}")).Rows[0][0]);
        }
        #endregion

        /// <summary>
        /// פעולה לבדיקה אם הסיבוב הנתון קיים או לא
        /// </summary>
        /// <param name="waveID">מפתח של הסיבוב </param>
        /// <returns>אם הסיבוב הנתון קיים או לא</returns>
        public static bool IsThereANextWave(int waveID)
        {
            DataTable dataTable = DBHelper.GetDataTable(0,
                  " SELECT Wave_id " +
                  " FROM Wave " +   
                 $" WHERE Wave_id = {waveID+1}"); //בודק אם יש לנו את הסיבוב הבא 
            //בודק אם יש את הסיבוב הבא
            return (dataTable.Rows.Count > 0);               
        }

        /*add to busines logic*/
        //public static DataTable GetGameNextWaveInfo(int gameID)
        //{
        //    DataTable dataTable = DBHelper.GetDataTable(0,
        //      " SELECT Wave_id " +
        //      " FROM Wave " +   //בודק אם ישלנו את הסיבוב הבא 
        //      $" WHERE Wave_id = {gameID+1}");

        //    //בודק אם יש את הסיבוב הבא
        //    if (dataTable.Rows.Count == 0)
        //    { return null; }

        //    return DBHelper.GetDataTable(0,
        //        " SELECT Wave.[Wave_Normal_Unit], Wave.[Wave_Normal_Range], Wave.[Wave_Adv_Unit], Wave.[Wave_Adv_Range], Wave.[Wave_Ultra_Unit], Wave.[Wave_Ultra_range], Wave.[Wave_Boss_id], Wave.[Wave_Complete_Score], Wave.[Wave_type], Wave.[Wave_Money_Give]" +
        //        " FROM Wave " +
        //       $"WHERE Wave_id = {gameID+1}");
        //}

        /// <summary>
        ///  הפעולה הזאת מחזירה את הנתונים של הסיבוב אם הבוס
        /// </summary>
        /// <param name="waveID">מפתח של הסיבוב</param>
        /// <returns></returns>
        public static DataTable GetWaveInfoWithBoss(int waveID)
        {
            return DBHelper.GetDataTable(0,
                " SELECT Wave.Wave_Normal_Unit, Wave.Wave_Normal_Range, Wave.Wave_Adv_Unit, Wave.Wave_Adv_Range, Wave.Wave_Ultra_Unit, Wave.Wave_Ultra_range, Wave.Wave_Complete_Score, Wave.Wave_type, Wave.Wave_Money_Give, Boss.[Boss_health], Boss.[Boss_Type], Boss.[Boss_img] " +
                " FROM Boss INNER JOIN Wave ON Boss.[Boss_id] = Wave.[Wave_Boss_id] " +
               $" WHERE Wave.[Wave_id] = {waveID}"
            );
        }

        /// <summary>
        ///  פעולה לקבלת המידע של אותו בוס לפי מפתח של הסיבוב
        /// </summary>
        /// <param name="waveID">מפתח של הסיבוב</param>
        /// <returns> טבלת נתונים שמכילה את הנתונים של אותו בוס</returns>
        public static DataTable GetBossInfo(int waveID)
        {
            return DBHelper.GetDataTable(0,
                " SELECT Boss.[Boss_id], Boss.[Boss_health], Boss.[Boss_Type], Boss.[Boss_img] " +
                " FROM Boss INNER JOIN Wave ON Boss.[Boss_id] = Wave.[Wave_Boss_id] " +
                $" WHERE Wave.[Wave_id] = {waveID} "
              );
        }

        /// <summary>
        /// פעולה שמביא בוס לפי המפתח
        /// </summary>
        /// <param name="bossID">מפתח של הבוס</param>
        /// <returns>טבלת נתונים של הבוס</returns>
        public static DataTable GetBossInfoByBossID(int bossID)
        {
            return DBHelper.GetDataTable(0,
                " SELECT Boss.[Boss_health], Boss.[Boss_Type], Boss.[Boss_img] "+
                " FROM Boss "+
               $" WHERE Boss.[Boss_id] = {bossID} ;"
                );
        }

        /// <summary>
        /// פעולה לקבלת מידע על בוס לפי הסוג הנתון
        /// </summary>
        /// <param name="type">הסוג של הבוס שאותו אתה רוצה לקבל</param>
        /// <returns>טבלת נתונים לקבלת הבוסים לפי הסוג הנתון</returns>
        public static DataTable GetBossInfoByType(string type)
        {
            return DBHelper.GetDataTable(0,
                " SELECT Boss.[Boss_health], Boss.[Boss_Type], Boss.[Boss_img] " +
                " FROM Boss " +
               $" WHERE  Boss.[Boss_Type] = '{type.ToLower()}' ;"
                );
        }

        /// <summary>
        /// פעולה לקבלת הבוסים לפי סדר החיים שלהם
        /// בוס עם הכי הרבה חיים למעלה והבוס אם הכי קצת חיים למטה
        /// </summary>
        /// <returns>טבלת נתונים שמכילה את נתוני הבוסים לפי בסדר החיים שלהם</returns>
        public static DataTable GetHighestBossByBossHealth()
        {
            return DBHelper.GetDataTable(0,
                " SELECT Boss.[Boss_health], Boss.[Boss_Type], Boss.[Boss_img] " +
                " FROM Boss " +
                "ORDER BY Boss.[Boss_health] DESC; ");
        }

        /// <summary>
        /// פעולה לקבלת הבוסים לפי סדר החיים שלהם ולפי אותו סוג שהתקבל
        /// בוס עם הכי הרבה חיים למעלה והבוס אם הכי קצת חיים למטה
        /// </summary>
        /// <param name="type">סוג של הבוסים</param>
        /// <returns>טבלת נתונים שמכילה את כל הנתונים של הבוסים מסוג שהתקבל </returns>
        public static DataTable GetHighestHealthBossByType(string type)
        {
            return DBHelper.GetDataTable(0,
                " SELECT Boss.[Boss_health], Boss.[Boss_Type], Boss.[Boss_img] " +
                " FROM Boss " +
               $" WHERE  Boss.[Boss_Type] = '{type.ToLower()}' " +
                " ORDER BY Boss.[Boss_health] DESC; ");
        }

        public static DataTable GetLowerestHealthBossByType(string type)
        {
            return DBHelper.GetDataTable(0,
                " SELECT Boss.[Boss_health], Boss.[Boss_Type], Boss.[Boss_img] " +
                " FROM Boss " +
               $" WHERE  Boss.[Boss_Type] = '{type.ToLower()}' " +
                " ORDER BY Boss.[Boss_health] ASC; ");
        }

        /// <summary>
        /// פעולה לקבלת מידע על השמירה של המשחק 
        /// המידע כולל את שם המפה 
        /// שם הקובץ של המפה 
        /// כמות החיים שיש לשחקן
        /// את המפתח של הסיבוב שלו
        /// </summary>
        /// <param name="gameID">מפתח של המשחק</param>
        /// <returns></returns>
        public static DataTable GetUserGameSavePreviewData(int gameID)
        {
            return DBHelper.GetDataTable(0,
                " SELECT  Game.Game_UserHealth, Game.Game_Wave_ID, Maps.Map_name, Maps.[Map_File_Name] " +
                " FROM Maps INNER JOIN Game ON Maps.[Map_ID] = Game.[Game_Map_ID] " +
               $" WHERE Game.Game_ID = {gameID}");
        }



        /// <summary>
        /// פעולה לעדכון כמות הכסף שבמשחק
        /// </summary>
        /// <param name="gameID">מפתח של המשחק</param>
        /// <param name="amount">כמות הכסף המעודכן</param>
        public static void UpdateGameMoney(int gameID,int amount)
        {
            DBHelper.UpdateQuery(
                " UPDATE Game " +
               $" SET Game_Money = {amount} " +
               $" WHERE Game_ID = {gameID} ");
        }

        /// <summary>
        /// פעולה לעדכון כמות הנקודות 
        /// </summary>
        /// <param name="gameID">מפתח של המשחק</param>
        /// <param name="score">ניקוד המשחק החדש</param>
        public static void UpdateGameScore(int gameID, int score)
        {
            DBHelper.UpdateQuery(
                " UPDATE Game " +
               $" SET Game_Score = {score} " +
               $" WHERE Game_ID = {gameID} ");
        }

        /// <summary>
        /// פעולה לעדכון חלק מהחלקים של המשחק
        /// </summary>
        /// <param name="gameID">מפתח המשחק</param>
        /// <param name="waveID">מפתח של הסיבוב</param>
        /// <param name="userHP">כמות החיים של המשתמש</param>
        /// <param name="score">ניקוד המשתמש</param>
        /// <param name="money">כמות הכסף</param>
        public static void UpdateGameInfo(int gameID,int waveID,int userHP,int score,int money)
        {
            DBHelper.UpdateQuery(
               " UPDATE Game " +
              $" SET Game_Score = {score}," +
              $" Game_Wave_ID = {waveID}, " +
              $" Game_UserHealth = {userHP}, " +
              $" Game_Money = {money}" +
              $" WHERE Game_ID = {gameID} ");
        }



        

        ///// <summary>
        ///// פעולה לקבלת הנתונים של מגדל במשודרג
        ///// </summary>
        ///// <param name="level">רמת מגדל</param>
        ///// <param name="towerType">סוג המגדל </param>
        ///// <returns>טבלה נתונים עם הנתונים של מגדל המשודרג </returns>
        //public static DataTable GetNextTower(int level, string towerType)
        //{
        //    return DBHelper.GetDataTable(0,
        //         " SELECT Towers.[Tower_ID],Towers.[Tower_lvl],Towers.[Tower_Type],Tower_range,Tower_damage,Tower_attackSpeed " +
        //         " FROM Towers " +      // gets the next level tower
        //        $" WHERE Towers.[Tower_lvl] = {level + 1} AND Towers.[Tower_type] = '{towerType}' ");
        //}

    }
}
 