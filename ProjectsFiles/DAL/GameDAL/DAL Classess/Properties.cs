using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GameDAL.DAL_Classess
{
    public static class Properties
    {



        /// <summary>
        ///  לפי המפתח של הסיבוב שהפעולה מקבלת הפעולה מחזירה 
        ///  את הנתונים 
        /// </summary>
        /// <param name="waveID">מפתח של סיבוב</param>
        /// <returns>טבלת נתונים עם הנתונים של המשחק</returns>
        public static DataTable GetWaveProperties(int waveID)
        {
            return DBHelper.GetDataTable(0,
                " SELECT Properties.[Wave_ID], Properties.[numbers_of_wins], Properties.[numbers_of_losess], Properties.[numbers_of_water_towers], Properties.[numbers_of_fire_towers], Properties.[numbers_of_earth_towers], Properties.[numbers_of_air_towers] " +
                " FROM Properties " +
               $" WHERE Properties.[Wave_ID] = {waveID}");
        }



        /// <summary>
        /// פעולה שמחזירה את כל הנתונים של כל הסיבובים שנמצאים בתוך טבלת ה'מאפיינים' המבנה נתונים
        /// </summary>
        /// <returns>הפעולה תחזיר את כל הנתונים של כל הסיבובים</returns>
        public static DataTable GeAllWaveProperties()
        {
            return DBHelper.GetDataTable(0,
                " SELECT Properties.[Property_ID],Properties.[Wave_ID], Properties.[numbers_of_wins], Properties.[numbers_of_losess], Properties.[numbers_of_water_towers], Properties.[numbers_of_fire_towers], Properties.[numbers_of_earth_towers], Properties.[numbers_of_air_towers] " +
                " FROM Properties ");
        }

        /// <summary>
        ///  פעולה שמחזירה את מספר הניצחונות של סיבוב הנתון
        /// </summary>
        /// <param name="waveID">מפתח של הסיבוב </param>
        /// <returns>מחזיר את מספר הניצחונות של הסיבוב</returns>
        public static int GetNumbersOfWinsWave(int waveID)
        {
            DataTable dataTable = DBHelper.GetDataTable(0,
                " SELECT numbers_of_wins " +
                " FROM Properties " +
               $" WHERE Properties.[Wave_ID] = {waveID}");

            return (int)(dataTable.Rows[0][0]);
        }

        /// <summary>
        ///  פעולה שמחזירה את מספר ההפסדים של סיבוב הנתון
        /// </summary>
        /// <param name="waveID">מפתח של הסיבוב</param>
        /// <returns>מחזיר את מספר ההפסדים של הסיבוב</returns>
        public static int GetNumbersOfLosessWave(int waveID)
        {
            DataTable dataTable = DBHelper.GetDataTable(0,
               " SELECT numbers_of_losess " +
               " FROM Properties " +
              $" WHERE Properties.[Wave_ID] = {waveID}");

            return (int)(dataTable.Rows[0][0]);
        }

        /// <summary>
        /// פעולה לקבלת מספר הפעמים שנבנה בניין מסוג הנתון  
        /// </summary>
        /// <param name="waveID">מפתח של המשחק</param>
        /// <param name="type">סוג הבניין</param>
        /// <returns>פעולה לקבלת המשחק</returns>
        public static int GetNumberOfTowerTypeBuilt(int waveID, string type)
        {
            DataTable dataTable = DBHelper.GetDataTable(0,
                         $" SELECT numbers_of_{type.ToLower()}_towers " +
                          " FROM Properties " +
                         $" WHERE Properties.[Wave_ID] = {waveID}");

            return (int)(dataTable.Rows[0][0]);
        }


        /// <summary>
        /// פעולה לקבלת מספר הפעמים שנבנה בניין מכל הסוגים 
        /// </summary>
        /// <param name="waveID">מפתח של הסיבוב</param>
        /// <returns></returns>
        public static int GetNumberOfAllTowerTypeBuilt(int waveID)
        {
            DataTable dataTable = DBHelper.GetDataTable(0,
                       $" SELECT numbers_of_water_towers,numbers_of_fire_towers,numbers_of_earth_towers,numbers_of_air_towers " +
                        " FROM Properties " +
                       $" WHERE Properties.[Wave_ID] = {waveID}");

            return (int)(dataTable.Rows[0]["numbers_of_water_towers"]) +
                   (int)(dataTable.Rows[0]["numbers_of_fire_towers"]) +
                   (int)(dataTable.Rows[0]["numbers_of_earth_towers"]) +
                   (int)(dataTable.Rows[0]["numbers_of_air_towers"]);

        }

        //public int GetTheHighestTypeOfTowerBuilt(int waveID)
        //{
        //    DataTable dataTable = DBHelper.GetDataTable(0,
        //               $" SELECT numbers_of_water_towers,numbers_of_fire_towers,numbers_of_earth_towers,numbers_of_air_towers " +
        //                " FROM Properties " +
        //               $" WHERE Properties.[Wave_ID] = {waveID}");

        //    int water = (int)(dataTable.Rows[0]["numbers_of_water_towers"]);
        //}







        /// <summary>
        /// פעולה לקבלת המפתח אחוז הניצחות של סיבוב מסויים
        /// </summary>
        /// <param name="propertiesID"></param>
        /// <returns></returns>
        public static double GetWinRateOfWave(int propertiesID)
        {
            DataTable dt = DBHelper.GetDataTable(0,
                " SELECT Properties.[numbers_of_wins], Properties.[numbers_of_losess] " +
                " FROM Properties " +
               $" WHERE Properties.[Property_ID] = {propertiesID} ");

            double wins = (int)(dt.Rows[0][0]);
            double lose = (int)(dt.Rows[0][1]);

            return (wins / lose) * 100;
        }//TODO maybe change it a little bit and switch Properties.[Property_ID] for Properties.[Wave_ID]



        /// <summary>
        /// פעולה לעדכון הנתונים שבסיס הנתונים 
        /// </summary>
        /// <param name="waveID">יד של סיבוב</param>
        /// <param name="won">אם השמתמש ניצח או הפסיד</param>
        /// <param name="numbersWater">מספר של המגדלים של מים שהוא בנה</param>
        /// <param name="numbersFire">מספר של המגדלים של אש שהוא בנה</param>
        /// <param name="numbersAir">מספר של מגדלים של אוויר שהוא בנה</param>
        /// <param name="numbersEarth">מספר של מגדלי אדמה שהוא בנה</param>
        public static void UpdateWaveProperties(int waveID, bool won, int numbersWater, int numbersFire, int numbersAir, int numbersEarth)
        {
            if (won)
            {
                DBHelper.UpdateQuery("" +
                    " UPDATE Properties " +
                    " SET numbers_of_wins = numbers_of_wins + 1," +
                   $" numbers_of_water_towers = numbers_of_water_towers + {numbersWater}," +
                   $" numbers_of_fire_towers = numbers_of_fire_towers + {numbersFire}, " +
                   $" numbers_of_earth_towers = numbers_of_earth_towers + {numbersEarth}, " +
                   $" numbers_of_air_towers = numbers_of_air_towers + {numbersAir} " +
                   $" WHERE Properties.[Wave_ID] = {waveID}");
            }
            else
            {
                DBHelper.UpdateQuery("" +
                   " UPDATE Properties " +
                   " SET numbers_of_losess = numbers_of_losess + 1," +
                  $" numbers_of_water_towers = numbers_of_water_towers + {numbersWater}," +
                  $" numbers_of_fire_towers = numbers_of_fire_towers + {numbersFire}, " +
                  $" numbers_of_earth_towers = numbers_of_earth_towers + {numbersEarth}, " +
                  $" numbers_of_air_towers = numbers_of_air_towers + {numbersAir} " +
                  $" WHERE Properties.[Wave_ID] = {waveID}");
            }

        }

        public static void UpdateProperties(int PropertiesID,int waveID,int numWin,int numLost, int numbersWater, int numbersFire, int numbersAir, int numbersEarth)
        {
            DBHelper.UpdateQuery("" +
                   " UPDATE Properties " +
                  $" SET numbers_of_losess = {numLost}, " +
                  $" numbers_of_wins = {numWin}" +
                  $" numbers_of_water_towers = {numbersWater}," +
                  $" numbers_of_fire_towers = {numbersFire}, " +
                  $" numbers_of_earth_towers =  {numbersEarth}, " +
                  $" numbers_of_air_towers =  {numbersAir} " +
                  $" WHERE Properties.[Property_ID] = {PropertiesID}");
        }


        

        /// <summary>
        /// פעולה לקבלת המפתח אחוז הניצחות של סיבוב מסויים
        /// </summary>
        /// <param name="waveID">מפתח של הסיבוב</param>
        /// <returns>מחזיר את אחוז הניצחון של הסיבוב הנל</returns>
        public static double GetWinRateOfWaveByID(int waveID)
        {
            DataTable dt = DBHelper.GetDataTable(0,
                " SELECT Properties.[numbers_of_wins], Properties.[numbers_of_losess] " +
                " FROM Properties " +
               $" WHERE Properties.[Wave_ID] = {waveID} ");

            double wins = (int)(dt.Rows[0][0]);
            double lose = (int)(dt.Rows[0][1]);

            return (wins / lose) * 100;
        }



    }
}
