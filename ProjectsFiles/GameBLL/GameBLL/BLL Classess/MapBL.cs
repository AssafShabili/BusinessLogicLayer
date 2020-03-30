using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


using System.Data;
using GameDAL.DAL_Classess;
using GameBLL.GameComponents;



namespace GameBLL.BLL_Classess
{
    
    public class MapBL
    {
        //public const int MapSizeWidth = 1280;
        //public const int MapSizeHeight = 720;


        //מפתח של המפה 
        private int mapID;
        //שם של המפה
        private string name;
        //שם של קובץ המפה
        private string pathOfImg;
        // pointsArray - מייצג את כל הנקודות שעל המפה 
      
        


        // mapRoad - מייצג את כל הנקודות שהם הדרך שבה ילכו האויבים
        private List<Point> mapRoad;

        // needs to be added to the dataBase propblay!
        private int mapWidth;
        private int mapHeight;


        /// <summary>
        /// פעולה בונה של מחלקת מפה 
        /// </summary>
        /// <param name="mapID">מפתח של אותה מפה</param>     
        public MapBL(int mapID)
        {
            this.mapID = mapID;
            this.name = Maps.GetMapName(this.mapID);
            this.pathOfImg = Maps.GetMapImg(this.mapID);
            this.mapRoad = new List<Point>();

            InitializeMapRoad();//מייצר את הדרך            
        }

        /// <summary>
        /// פעולה בונה ריקה
        /// </summary>
        public MapBL()
        {

        }

        /// <summary>
        ///  פעולה בונה של מחלקת מפה מקבלת טבלת נתונים שאותה היא 
        ///  מוציאה את הנתונים של המפה
        /// </summary>
        /// <param name="dataTableMap">טבלת נתונים של המפה</param>
        public MapBL(DataTable dataTableMap)
        {
            //אני לא חושב שאני צריך את זה
        }//i dont need it



     


        /// <summary>
        /// פעולה ל"הכנת" שרשרת של נקודות הדרך
        /// </summary>
        public void InitializeMapRoad()
        {
            DataTable dataTableRoad = Maps.GetMapRoad(this.mapID);           
            for (int i = 0; i < dataTableRoad.Rows.Count; i++)
            {
                this.mapRoad.Add(new Point((int)dataTableRoad.Rows[i][1], (int)dataTableRoad.Rows[i][2]));
            }            
        }
        /// <summary>
        /// פעולה לקבלת כל המפות שבסיס הנתונים
        /// </summary>
        /// <returns>שרשרת המכילה את כל המפות שבסיס הנתונים. חשוב לציין כי אותן מפות לא יתחילו להם את </returns>
        public List<MapBL> GetAllMapsInfo()
        {
            List<MapBL> mapBLs = new List<MapBL>();

            //Console.WriteLine(DataTablePrint.BuildTable(
            //    Maps.GetAllMaps(),23));

            DataTable dataTableMap = Maps.GetAllMaps();

            for (int i = 0; i < dataTableMap.Rows.Count; i++)
            {
                mapBLs.Add(new MapBL((int)dataTableMap.Rows[i][0]));
                
            }
            return mapBLs;
        }

        /// <summary>
        /// פעולה איחזור לשרשרת הנקודות של הדרך
        /// </summary>
        /// <returns></returns>
        public List<Point> GetMapRoad()
        {
            return this.mapRoad;
        }    

        /// <summary>
        /// פעולה להחזרת מפתח של המפה
        /// </summary>
        /// <returns>מפתח המפה</returns>
        public int GetMapID()
        {
            return this.mapID;
        }    

        /// <summary>
        /// פעולה להחזרת השם של המפה
        /// </summary>
        /// <returns>הפועלה מחזירה סטריג שמייצג את השם של המפה</returns>
        public string GetMapName()
        {
            return this.name;
        }
        



        
        /// <summary>
        /// פעולה להדפסת 
        /// </summary>
        /// <returns>סטרינג </returns>
        public override string ToString()
        {
            return $" NAME - {this.name} " +
                   $" IMG - {this.pathOfImg} " +
                   $" mapRoad POINTS - {this.mapRoad} ";
        }



    }
}
