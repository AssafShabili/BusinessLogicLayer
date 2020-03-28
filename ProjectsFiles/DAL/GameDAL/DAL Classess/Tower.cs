using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GameDAL.DAL_Classess
{
    /// <summary>
    /// מחלקת שירות לטיפול בטבלת מגדלים
    /// </summary>
    public static class Tower
    {
        /// <summary>
        ///  פעולה שמחזירה את הנתונים של המגדל לפי המפתח שהיא קיבלה
        /// </summary>
        /// <param name="towerID">מפתח של המגדל</param>
        /// <returns> טבלה עם הנתונים של המגדל</returns>
        public static DataTable GetTowerInfo(int towerID)
        {
            return DBHelper.GetDataTable(0,
                " SELECT Towers.[Tower_Type], Towers.[Tower_range], Towers.[Tower_damage], Towers.[Tower_attackSpeed], Towers.[Tower_X], Towers.[Tower_Y], Towers.[Tower_cost], Towers.[Tower_Img],Tower_damage_lvl,Tower_range_lvl,Tower_attackSpeed_lvl " +
                " FROM Towers "+
               $" WHERE Towers.[Tower_ID] = {towerID} " );
        }

        /// <summary>
        /// פעולה לשידרוג המרחק המגדל 
        /// </summary>
        /// <param name="towerID">מפתח של המגדל</param>
        /// <param name="newRange">מרחק החדש</param>
        public static void UpgradeTowerRange(int towerID, int newRange)
        {
            DBHelper.UpdateQuery(
               $"UPDATE Towers SET Tower_range = {newRange} " +
              $" WHERE Tower_ID = {towerID}");
        }

        /// <summary>
        /// פעולה לשידרוג הכוח המגדל 
        /// </summary>
        /// <param name="towerID">מפתח של המגדל</param>
        /// <param name="newRange">כוח החדש</param>
        public static void UpgradeTowerDamage(int towerID, int newDamage)
        {
            DBHelper.UpdateQuery(
               $" UPDATE Towers SET Tower_damage = {newDamage} " +
              $" WHERE Tower_ID = {towerID}");
        }

        /// <summary>
        /// פעולה לשידרוג קצב היריה של המגדל
        /// </summary>
        /// <param name="towerID">מפתח של המגדל</param>
        /// <param name="newAttackSpeed">קצב הירי החדש</param>
        public static void UpgradeTowerAttackSpeed(int towerID, int newAttackSpeed)
        {
            DBHelper.UpdateQuery(
             $" UPDATE Towers SET Tower_attackSpeed = {newAttackSpeed} " +
            $" WHERE Tower_ID = {towerID}");
        }

        /// <summary>
        /// פעולה לקבלת רמת השידרוג של אחד מהנתונים שיש למגדל
        /// Tower_damage_lvl,Tower_range_lvl,Tower_attackSpeed_lvl
        /// </summary>
        /// <param name="towerAttribute"> אחד מהנתונים שיש למגדל יכול להיות אחד מ
        /// Tower_damage_lvl,Tower_range_lvl,Tower_attackSpeed_lvl
        /// </param>
        /// <param name="towerID">מפתח של המגדל</param>
        /// <returns>את רמת שידרוג של אחד מהנתונים שיש למגדל כמספר</returns>
        public static int GetTowerLevel(string towerAttribute, int towerID)
        {
            DataTable dataTable = DBHelper.GetDataTable(0,
               $" SELECT Towers.[{towerAttribute}] " +
                " FROM Towers "+
               $" WHERE Tower_ID = {towerID} ");

            return (int)(dataTable.Rows[0][0]);
        }



        /// <summary>
        /// פעולה ליצירת מגדל 
        /// </summary>
        /// <returns>מפתח של המגדל שעתה נוצר</returns>
        public static int CreateDefaultTower()
        {
            DBHelper.UpdateQuery(
                "INSERT INTO Towers (Tower_Type,Tower_range,Tower_damage,Tower_attackSpeed,Tower_X,Tower_Y,Tower_cost,Tower_Img,Tower_damage_lvl,Tower_range_lvl,Tower_attackSpeed_lvl) " +
                " VALUES ('fire',120,10,45,0,0,40,'Tower_fire.png',1,1,1)");

            DataTable dataTable = DBHelper.GetDataTable(0,
                " SELECT Tower_ID " +
                " FROM Towers " +
                " ORDER BY Tower_ID DESC");

            return (int)(dataTable.Rows[0][0]);
        }


        /// <summary>
        /// פעולה ליצירת מגדל 
        /// </summary>
        /// <returns>מפתח של המגדל שעתה נוצר</returns>
        public static int CreateDefaultTower(string type,int x,int y)
        {
            type = type.ToLower();
            DBHelper.UpdateQuery(
                "INSERT INTO Towers (Tower_Type,Tower_range,Tower_damage,Tower_attackSpeed,Tower_X,Tower_Y,Tower_cost,Tower_Img,Tower_damage_lvl,Tower_range_lvl,Tower_attackSpeed_lvl) " +
               $" VALUES ('{type}',120,10,45,{x},{y},40,'Tower_{type}.png',1,1,1)");

            DataTable dataTable = DBHelper.GetDataTable(0,
                " SELECT Tower_ID " +
                " FROM Towers " +
                " ORDER BY Tower_ID DESC");

            return (int)(dataTable.Rows[0][0]);
        }


        /// <summary>
        /// פעולה לעדכון הערכים של המגדל
        /// </summary>
        /// <param name="towerID">מפתח של אתו מגדל</param>
        /// <param name="type">סוג של המגדל </param>
        /// <param name="range">מרחק הירייה של המגדל</param>
        /// <param name="attackSpeed">קצב התקיפה של אותו מגדל</param>
        /// <param name="damage">נזק של אותו מגדל</param>
        /// <param name="cost">עלות של מחירת המגדל</param>
        /// <param name="img">תמונת המגדל</param>
        /// <param name="Dlvl">רמת הנזק של המגדל</param>
        /// <param name="Rlvl">רמת המרחק של משידרוג המגדל</param>
        /// <param name="Alvl">רמת השידרוג של התקיפה של המגדל</param>
        public static void UpdateTowerInfo(int towerID, string type,int range,int attackSpeed,int damage,int cost,string img,int Dlvl,int Rlvl,int Alvl)
        {
            DBHelper.UpdateQuery(
                "UPDATE Towers " +
               $" SET Tower_Type = '{type}', " +
               $" Tower_range = {range}, " +
               $" Tower_damage = {damage}, " +
               $" Tower_attackSpeed = {attackSpeed}, " +
               $" Tower_cost = {cost}, " +
               $" Tower_Img = '{img}', " +
               $" Tower_damage_lvl = {Dlvl}, " +
               $" Tower_range_lvl = {Rlvl}, " +
               $" Tower_attackSpeed_lvl = {Alvl} " +
               $" WHERE Tower_ID = {towerID}");
        }


    }
}
