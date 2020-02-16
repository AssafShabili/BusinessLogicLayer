using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GameDAL.DAL_Classess
{
    /// <summary>
    ///  static Class for getting info out of it. 
    /// </summary>
    public static class Maps
    {
        /// <summary>
        ///  gets the maps name 
        /// </summary>
        /// <param name="ID">ID of the map</param>
        /// <returns>the name(string) of the map</returns>
        public static string GetMapName(int mapID)
        {
            DataTable dataTable = DBHelper.GetDataTable(0,"SELECT Maps.Map_name "+
                                        " FROM Maps "+
                                $" WHERE Maps.Map_ID = {mapID} ");
            return (dataTable.Rows[0][0]).ToString();
        }//I check 


        /// <summary>
        /// פעולה לקבלת השם של הקובץ של המפה
        /// </summary>
        /// <param name="mapID">ID of the map</param>
        /// <returns>השם של הקובץ של המפה </returns>
        public static string GetMapImg(int mapID)
        {
            DataTable dataTable = DBHelper.GetDataTable(0, "SELECT Maps.Map_File_Name " +
                                       " FROM Maps " +
                               $" WHERE Maps.Map_ID = {mapID} ");
            return (dataTable.Rows[0][0]).ToString();
        }//I check

        /// <summary>
        /// פעולה לקבלת הדרך של המפה
        /// </summary>
        /// <param name="mapID"><ID of the map/param>
        /// <returns>טבלה עם ה"דרך" של המפה</returns>
        public static DataTable GetMapRoad(int mapID)
        {
            return DBHelper.GetDataTable(0,
                " SELECT Roads.[Step], Roads.[road_point_X], Roads.[road_point_Y] "+
                " FROM Roads "+
               $" WHERE  Roads.[Road_Map_ID] = {mapID}");
        }//I check


        /// <summary>
        /// פעולה לקבלת מידע על המפה. מכיל גם את המפתח של טבלת הדרכים
        /// 'Roads'
        /// </summary>
        /// <param name="mapID">מפתח של הטבלה</param>
        /// <returns>מחזיר  הטבלה עם כל הנתונים של המפה והדרך </returns>
        public static DataTable GetMapInfoWithRoad(int mapID)
        {
            return DBHelper.GetDataTable(0,
                " SELECT Maps.Map_ID, Maps.Map_name, Maps.Map_File_Name, Roads.road_ID "+
                " FROM Maps INNER JOIN Roads ON Maps.[Map_ID] = Roads.[Road_Map_ID] "+
               $" WHERE Maps.Map_ID = {mapID} ");
        }


        public static DataTable GetAllMaps()
        {
            //I think this is worng plz check w/ multi maps in the dataBase!

            /*return DBHelper.GetDataTable(0,
                " SELECT Maps.Map_ID, Maps.Map_name, Maps.Map_File_Name, Roads.Step, Roads.road_point_X, Roads.road_point_Y "+
                " FROM Maps INNER JOIN Roads ON Maps.[Map_ID] = Roads.[Road_Map_ID];");*/

            return DBHelper.GetDataTable(0,
                " SELECT Maps.Map_ID "+
                " FROM Maps;");
        }

        


       

    }
}
