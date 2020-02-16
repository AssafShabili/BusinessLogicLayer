using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
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
        private MapTile[,] tileArray;
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
            InitializePointsArray();//מייצר את המערך של הנקודות
            
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
        /// פעולה ליצירת שרשרת הנקודות של הדרך
        /// </summary>
        public void InitializePointsArray()
        {
            int actualY = 0;/*MapSizeHeight*/
            int actualX = 0;/*MapSizeWidth*/
            this.tileArray = new MapTile[GameConstants.MapWidth, GameConstants.MapHeight];
            for (int i = 0; i < /*MapSizeWidth16*/GameConstants.MapWidth; i++)
            {
                for (int j = 0; j < /*MapSizeHeight*21*/GameConstants.MapHeight; j++)
                {
                    if (this.mapRoad.Exists(p => p.X == i && p.Y == j))
                    {
                        this.tileArray[i, j] = new MapTile(GameConstants.TileWidth,
                            GameConstants.TileHeight, new Point(actualX, actualY), new Point(i, j), true);
                    }
                    else
                    {
                        this.tileArray[i, j] = new MapTile(50, 50, new Point(actualX, actualY), new Point(i, j), false);
                    }
                    actualY += GameConstants.TileHeight;
                }
                actualY = 0;
                actualX += GameConstants.TileWidth;
            }
        }
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
        /// פעולה לאיחזור המערך של הנקודות של המפה כולה
        /// </summary>
        /// <returns></returns>
        public MapTile[,] GetMapPointsArray()
        {
            return this.tileArray;
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
        /// פעולה לקבלת המשבצת לפי מיקום בלוח של משחק 
        /// </summary>
        /// <param name="postion">מיקום בלוח של המשחק</param>
        /// <returns>אם נמצא משבצת שהיא מכילה את המיקום הנ"ל אז הפעולה תחזיר את המשבצת ,אחרת תחזיר null</returns>
        public MapTile GetTileInMap(Point position)
        {
            foreach(MapTile mapTile in this.tileArray)
            {
                if(mapTile.ContainsPoint(position))
                {
                    return mapTile;
                }
            }
            return null;
        }

        /// <summary>
        ///  פעולה לקבלת המיקום במערך לפי מיקום בלוח
        /// </summary>
        /// <param name="position">מיקום בלוח</param>
        /// <returns>נקודה מייצגת את המיקום במערך</returns>
        public Point GetPositionInArray(Point position)
        {
            for (int i = 0; i < this.tileArray.GetLength(0); i++)
            {
                for (int j = 0; j < this.tileArray.GetLength(1); j++)
                {
                    if(this.tileArray[i,j].ContainsPoint(position))
                    {
                        return new Point(i,j);
                    }
                }
            }
            return Point.Zero;
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
