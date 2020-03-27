using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace GameBLL.GameComponents
{

    // המחלקת הזאת חסרת תועלת אפשר להסיר אותה!


    /// <summary>
    /// מחלקת שירות לניהול הקלט מהמשתמש
    /// </summary>
    public class InputHandler
    {
        private Point position;
        public bool SelectionOccurring { get; set; }
        public bool SelectionHandled { get; set; }
        public object SelectedObject { get; set; }

        // נתונים השומרים את נתוני העכבר של המשתמש
        private MouseState mouseState;
        

        public void Update(GameTime gameTime, Vector2 gameScale)
        {
            this.mouseState = Mouse.GetState();
           


            this.position = (this.mouseState.Position.ToVector2() / gameScale).ToPoint();
            this.SelectionOccurring = this.mouseState.LeftButton == ButtonState.Pressed;
            if (this.mouseState.LeftButton == ButtonState.Released)
            {
                SelectionHandled = false;
            }
        }

       

        /// <summary>
        /// פעולה לבדיקה אם מיקום הבחירה היא הבתוך שדה המשחק!
        /// </summary>
        /// <returns>אמת אם הלחיצה הייתה בתוך הלוח או שקר אם הלחיצה הייתה החוץ ללוח</returns>
        public bool SelectionInGameBounds()//can Delete it
        {
            return false;
            //int topY = 0;
            //int leftX = 0;

            //return this.position.Y > topY && this.position.X > leftX &&
            //            this.position.Y < topY + (GameConstants.MapHeight * GameConstants.TileHeight) &&
            //            this.position.X < leftX + (GameConstants.MapWidth * GameConstants.MapWidth);
        }
    }       
}
