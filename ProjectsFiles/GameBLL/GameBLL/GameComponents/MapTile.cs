using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameBLL.BLL_Classess;
using GameBLL.GameComponents;


namespace GameBLL.GameComponents
{
    public class MapTile
    {
        private Rectangle tileRectangle;//מלבן שמייצג את המשבצת

        private int tileWidth;//רוחב של המשבצת
        private int tileHeight;//גובה של המשבצת

        private Point postionOnTheMap;//מיקום על המפה
        private Point postionInTileArray;
        private bool IsRoad;//אם המשבצת היא דרך או לא דרך

        /// <summary>
        /// פעולה בונה של מחלקת משבצת
        /// </summary>
        /// <param name="tileRectangle">ריבוע המשבצת</param>
        /// <param name="postionOnTheMap">מיקום על מפה</param>
        /// <param name="IsRoad">אם המשבצת מייצגת דרך או לא</param>
        public MapTile(Rectangle tileRectangle, Point postionOnTheMap,Point postionInTileArray, bool IsRoad)
        {
            this.tileRectangle = tileRectangle;
            this.tileWidth = this.tileRectangle.Width;
            this.tileHeight = this.tileRectangle.Height;
            this.postionInTileArray = postionInTileArray;
            this.postionOnTheMap = postionOnTheMap;
            this.IsRoad = IsRoad;                        
        }

        /// <summary>
        /// פעולה בונה של מחלקת משבצת 
        /// </summary>
        /// <param name="width">רוחב המשבצת</param>
        /// <param name="height">גובה המשבצת</param>
        /// <param name="postionOnTheMap">מיקום על מפה</param>
        /// <param name="IsRoad">אם המשבצת מייצגת דרך או לא</param>
        public MapTile(int width,int height, Point postionOnTheMap, Point postionInTileArray, bool IsRoad)
        {
            this.tileRectangle = new Rectangle(postionOnTheMap.X, postionOnTheMap.Y, width, height);
            this.postionInTileArray = postionInTileArray;
            this.postionOnTheMap = postionOnTheMap;
            this.IsRoad = IsRoad;
        }

        /// <summary>
        /// פעולה החזרת אם המשבצת היא על דרך או לא
        /// </summary>
        /// <returns>מחזירה אמת עם המשבת היא דרך ושקר אחרת</returns>
        public bool GetIsRoad()
        {
            return this.IsRoad;
        }


        /// <summary>
        /// פעולה לבדיקה אם נקודה נמצאת בתוך המלבן של המשבצת
        /// </summary>
        /// <param name="point">נקודה</param>
        /// <returns>אמת אם הנקודה נמצאת בתוך המלבן של המשבצת ושקר אחרת</returns>
        public bool ContainsPoint(Point point)
        {
            return this.tileRectangle.Contains(point);
        }


        





    }
}
