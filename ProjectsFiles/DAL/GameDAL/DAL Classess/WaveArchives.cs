using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GameDAL.DAL_Classess
{
    /// <summary>
    /// מחלקה לטיפול הטבלה "ארכיון סיבוב"ף
    /// </summary>
    public static class WaveArchives
    {
        /// <summary>
        /// פעןלה לקבלת הנתונים מטבלה
        /// </summary>
        /// <param name="waveID">מפתח של הסיבוב</param>
        /// <returns>מחזיר טבלת נתונים עם כל הנתונים של כל המשחקים עם הסיבובים של מפתח זה</returns>
        public static DataTable GetWaveArchivesInfo(int waveID)
        {
            return DBHelper.GetDataTable(0,
                " SELECT WaveArchives.[Wave_ID], WaveArchives.[Game_ID], WaveArchives.[Map_ID], WaveArchives.[Easy_mode], WaveArchives.[IsWon] "+
                " FROM WaveArchives "+
               $" WHERE WaveArchives.[Wave_ID] = {waveID}");
        }

        /// <summary>
        /// פעולה לקבלת הנתונים מטבלה של סיבובים 
        /// </summary>
        /// <param name="waveID">מפתח של הסיבוב</param>
        /// <param name="mapID">מפתח של המפה</param>
        /// <returns>טבלת נתונים שבה שיש את כל הנתונים של הסיבובים בהם שיחקו בסיבוב מסויים אם מפה מסויימת</returns>
        public static DataTable GetWaveArchivesInfo(int waveID,int mapID)
        {
            return DBHelper.GetDataTable(0,
               " SELECT WaveArchives.[Wave_ID], WaveArchives.[Game_ID], WaveArchives.[Map_ID], WaveArchives.[Easy_mode], WaveArchives.[IsWon] " +
               " FROM WaveArchives " +
              $" WHERE WaveArchives.[Wave_ID] = {waveID} AND WaveArchives.[Map_ID] = {mapID}");
        }

        /// <summary>
        /// פעולה לקבלת הנתונים מטבלה של סיבובים עם הקלות 
        /// </summary>
        /// <param name="waveID">מפתח של הסיבוב</param>
        /// <param name="mapID">מפתח של המפה</param>
        /// <returns>טבלת נתונים שבה שיש את כל הנתונים של הסיבובים בהם שיחקו בסיבוב מסויים אם מפה מסויימת </returns>
        public static DataTable GetWaveArchivesInfoEasy(int waveID, int mapID)
        {//this is with easy mode wave
            return DBHelper.GetDataTable(0,
              " SELECT WaveArchives.[Wave_ID], WaveArchives.[Game_ID], WaveArchives.[Map_ID], WaveArchives.[Easy_mode], WaveArchives.[IsWon] " +
              " FROM WaveArchives " +
             $" WHERE WaveArchives.[Wave_ID] = {waveID} AND WaveArchives.[Map_ID] = {mapID} AND WaveArchives.[Easy_mode] = True");
        }

        /// <summary>
        /// פעולה לקבלת המידע על סיבובים שניצחו בהם
        /// </summary>
        /// <param name="waveID">מפתח של הסיבוב</param>
        /// <param name="mapID">מפתח של המפה</param>
        /// <returns>טבלת נתונים שמכילה את כל הסיבובים שבהם ניצחו</returns>
        public static DataTable GetWaveArchivesWon(int waveID, int mapID)
        {
            return DBHelper.GetDataTable(0,
               " SELECT WaveArchives.[Wave_ID], WaveArchives.[Game_ID], WaveArchives.[Map_ID], WaveArchives.[Easy_mode], WaveArchives.[IsWon] " +
               " FROM WaveArchives " +
              $" WHERE WaveArchives.[Wave_ID] = {waveID} AND WaveArchives.[Map_ID] = {mapID} AND WaveArchives.[IsWon] = True");
        }

        /// <summary>
        /// פעולה לקבלת המידע על סיבובים שהפסידו בהם
        /// </summary>
        /// <param name="waveID">מפתח של הסיבוב</param>
        /// <param name="mapID">מפתח של המפה</param>
        /// <returns>טבלת נתונים שמכילה את כל הסיבובים שבהם הפסידו</returns>
        public static DataTable GetWaveArchivesLost(int waveID, int mapID)
        {
            return DBHelper.GetDataTable(0,
               " SELECT WaveArchives.[Wave_ID], WaveArchives.[Game_ID], WaveArchives.[Map_ID], WaveArchives.[Easy_mode], WaveArchives.[IsWon] " +
               " FROM WaveArchives " +
              $" WHERE WaveArchives.[Wave_ID] = {waveID} AND WaveArchives.[Map_ID] = {mapID} AND WaveArchives.[IsWon] = False");
        }

        /// <summary>
        /// פעולה להכנסת סיבוב לתוך הטבלה 
        /// </summary>
        /// <param name="waveID">מפתח של הסיבוב</param>
        /// <param name="gameID">מפתח של המשחק</param>
        /// <param name="mapID">מפתח של המפה</param>
        /// <param name="easyMode">אם המשחק שוחק עם הקלות</param>
        /// <param name="isWon">אם ניצח או לא</param>
        public static void InsertWaveToWaveArchives(int waveID,int gameID,int mapID,bool easyMode,bool isWon)
        {
            DBHelper.UpdateQuery(
                " INSERT INTO WaveArchives (Wave_ID,Game_ID,Map_ID,Easy_mode,IsWon) "+
               $" VALUES({waveID},{gameID},{mapID},{easyMode},{isWon}) ");
        }

        /// <summary>
        /// פעולה לקבלת המידע על על השמירות יחד עם מידע של הסיבוב 
        /// </summary>
        /// <param name="waveID"></param>
        /// <returns></returns>
        public static DataTable GetWaveArchivesWithWaveProperties(int waveID)
        {
            return DBHelper.GetDataTable(0,
            " SELECT WaveArchives.Wave_ID, WaveArchives.Game_ID, WaveArchives.Map_ID, WaveArchives.Easy_mode, WaveArchives.IsWon, Properties.numbers_of_wins, Properties.numbers_of_losess, Properties.numbers_of_water_towers, Properties.numbers_of_fire_towers, Properties.numbers_of_earth_towers, Properties.numbers_of_air_towers "+
            " FROM(Wave INNER JOIN WaveArchives ON Wave.[Wave_id] = WaveArchives.[Wave_ID]) INNER JOIN Properties ON Wave.[Wave_id] = Properties.[Wave_ID] " +
           $" WHERE WaveArchives.Wave_ID = {waveID}; ");            
        }

        
       

        /// <summary>
        /// פעולה לקבלת המידע על על השמירות יחד עם מידע של הסיבוב 
        /// </summary>
        /// <param name="waveID">מפתח של השמירה</param>
        /// <returns></returns>
        public static DataTable GetWaveArchivesWithWaveProperties(int waveID,int mapID)
        {
            return DBHelper.GetDataTable(0,
            " SELECT WaveArchives.Wave_ID, WaveArchives.Game_ID, WaveArchives.Map_ID, WaveArchives.Easy_mode, WaveArchives.IsWon, Properties.numbers_of_wins, Properties.numbers_of_losess, Properties.numbers_of_water_towers, Properties.numbers_of_fire_towers, Properties.numbers_of_earth_towers, Properties.numbers_of_air_towers " +
            " FROM(Wave INNER JOIN WaveArchives ON Wave.[Wave_id] = WaveArchives.[Wave_ID]) INNER JOIN Properties ON Wave.[Wave_id] = Properties.[Wave_ID] " +
           $" WHERE WaveArchives.Wave_ID = {waveID} WaveArchives.Map_ID = {mapID} ;");

        }

        









    }
}
