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

        //need function to update the TowerLevel!

    }
}
