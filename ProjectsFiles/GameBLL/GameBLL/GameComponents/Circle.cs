using Microsoft.Xna.Framework;

namespace GameBLL.BLL_Classess
{
    /// <summary>
    ///  מבנה המייצג מעגל
    /// </summary>
    public struct Circle
    {
        /*        
         * השימוש בסטרקט ולא במחלקה כי השימוש המבנה זה לא יהיה בעל חשיבות גודלה  
         * רוב הפעמים שיהיה שימוש במבנה זה ,זה לשימוש בתוך מחלקות אחרות
         * structלכן השימוש ב
         * Rectangle בנוסף לך גם  
         * struct הוא 
         * לכן עדיף לשמור על קביעות!
         */

        public int Radius { get; private set; } //רדיוס המעגל 
        public int X { get; private set; } // X מיקום על ציר ה
        public int Y { get; private set; } // Y מיקום על ציר ה

        /// <summary>
        /// פעולה בונה למבנה מעגל
        /// </summary>
        /// <param name="x"> X מיקום על ציר ה </param>
        /// <param name="y">  Y מיקום על ציר ה</param>
        /// <param name="radius"> רדיוס המעגל</param>
        public Circle(int x, int y, int radius) 
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
        }

        /// <summary>
        /// פעולה לבדיקה עם המעגל נפגש עם מלבן נתון
        /// </summary>
        /// <param name="rectangle">מלבן </param>
        /// <returns>אם המלבן הנתון מתלכד עם המעגל או לא</returns>
        public bool Intersects(Rectangle rectangle)
        {
            // דבר ראשון בודקים אם פינות המלבן נפגשות עם המעגל
            Point[] corners = new Point[]
            {
                new Point(rectangle.Top, rectangle.Left),
                new Point(rectangle.Top, rectangle.Right),
                new Point(rectangle.Bottom, rectangle.Right),
                new Point(rectangle.Bottom, rectangle.Left)
            };

            foreach (var corner in corners)
            {
                if (ContainsPoint(corner))
                {
                    return true;
                }
            }


            //בודקים אם קצוות המלבן חופפים למעגל
            if (X - Radius > rectangle.Right || X + Radius < rectangle.Left)
                return false;
            //בודקים אם קצוות המלבן חופפים למעגל
            if (Y - Radius > rectangle.Bottom || Y + Radius < rectangle.Top)
                return false;

            // אם לא הם נפגשים
            return true;
        }

        /// <summary>
        /// פעולה לבדיקה עם המעגל נפגש או מתלקד עם מעגל אחר
        /// </summary>
        /// <param name="circle">מעגל</param>
        /// <returns>אם המעגל הנתון מתלכד עם המעגל או לא </returns>
        public bool Intersects(Circle circle)
        {
            // אנחנו בודקים אם סכום הרדיוסים שלהם גדול מהמרחק של מרכזי המעגלים
            Vector2 centre0 = new Vector2(circle.X, circle.Y);
            Vector2 centre1 = new Vector2(X, Y);

            return Vector2.Distance(centre0, centre1) <= Radius + circle.Radius;
            // השווה מציין שהמעגלים משיקים מבחוץ
            // לעוד מידע תראה את https://www.m-math.co.il/geometry/2-circles/
        }

        /// <summary>
        /// פעולה לבדיקה עם נקודה נמצאת בתוך המעגל
        /// </summary>
        /// <param name="point">נקודה</param>
        /// <returns>אם הנקודה נצאת בתוך המעגל או לא</returns>
        public bool ContainsPoint(Point point)
        {
            Vector2 vector2 = new Vector2(point.X - X, point.Y - Y);
            return vector2.Length() <= Radius;
        }
    }
}
