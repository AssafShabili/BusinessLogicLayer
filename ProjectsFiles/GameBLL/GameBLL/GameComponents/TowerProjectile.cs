
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;


namespace GameBLL.GameComponents
{
    public class TowerProjectile
    {
        private Enemy target;//אויב שהנמצא של המפה
        private Point position;// מיקום שמימנו נורה הקליע
        private Image projectileImage;// איך נראה הקליע
        private int damage;// כמות הנזק של אותו קליע
        private int speed;// מהירות הקליע


        private bool hit;

       
        private bool addToCanvas;

        /// <summary>
        /// פעולה בונה למחלקת קליע של מגדל
        /// </summary>
        /// <param name="enemy">אויב </param>
        /// <param name="point">מיקום שמימנו נורה הקליע</param>
        /// <param name="texture2D">איך שנראה הקליע</param>
        /// <param name="dmg">כמות שנזק של אותו קליע</param>
        public TowerProjectile(Enemy enemy, Point point,int dmg,int speed=15)
        {
            this.target = enemy;
            this.position = point;
            this.damage = dmg;
            this.projectileImage = new Image();
            this.projectileImage.Width = 15;
            this.projectileImage.Height = 15;

            this.speed = speed;

            this.hit = false;
           

            this.addToCanvas = false;
            this.projectileImage.Source = GetBitmapImage("Projectial");
        }



        /// <summary>
        /// פעולה לעדכון התמונות של המשחק
        /// </summary>
        /// <param name="gameCanvas">הרק של המשחק</param>
        public void Update(Canvas gameCanvas)
        {
            this.projectileImage.Source = null;
            this.projectileImage.Visibility = Visibility.Hidden;
            gameCanvas.Children.Remove(this.projectileImage);
        }

        /// <summary>
        /// פעולה להזזת הקליע
        /// </summary>
        /// <returns>אמת אם אפשר לפגוע (ואם כן אז הפעולה מורידה חיים לאותו אויב) ושקר אם לא אפשר לפגוע בקליע</returns>
        public bool Move(Canvas gameCanvas)
        {
            if(!target.IsDead())
            {
                Microsoft.Xna.Framework.Point positionXna = new Microsoft.Xna.Framework.Point((int)this.position.X, (int)this.position.Y);
                Microsoft.Xna.Framework.Point targetXna = new Microsoft.Xna.Framework.Point((int)this.target.GetLocation().X,
                    (int)this.target.GetLocation().Y);

                Microsoft.Xna.Framework.Vector2 direction = (positionXna - targetXna).ToVector2();

                if (direction != Microsoft.Xna.Framework.Vector2.Zero)
                {
                    direction.Normalize();
                }
                positionXna -= (direction * speed).ToPoint();

                this.position = new Point(positionXna.X, positionXna.Y);

                if (!this.addToCanvas)
                {
                    gameCanvas.Children.Add(this.projectileImage);
                    Canvas.SetLeft(this.projectileImage, this.position.X);
                    Canvas.SetTop(this.projectileImage, this.position.Y);
                    this.addToCanvas = true;
                }
                else
                {
                    Canvas.SetZIndex(this.projectileImage, 3);
                    Canvas.SetLeft(this.projectileImage, this.position.X);
                    Canvas.SetTop(this.projectileImage, this.position.Y);

                }
              




                if (Microsoft.Xna.Framework.Vector2.Distance(positionXna.ToVector2(), targetXna.ToVector2()) < 20)
                {
                    DamageTarget();
                    this.projectileImage.Source = null;
                    gameCanvas.Children.Remove(this.projectileImage);
                    this.projectileImage.Visibility = Visibility.Hidden;

                    this.hit = true;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                this.projectileImage.Source = null;
                gameCanvas.Children.Remove(this.projectileImage);
                this.projectileImage.Visibility = Visibility.Hidden;

                this.hit = true;

                return false;
            }
                      
        }


        /// <summary>
        /// פעולה שמקבלת את השם של המפה  
        /// ומחזירה את המפה כ - bitmapImage
        /// </summary>
        /// <param name="mapName">שם של המפה של המשחק</param>
        /// <returns>הפעולה תחזיר את התמונה  שכדאי שנוכל להכניס אותה לתוך הפקד של התמונה</returns>
        public BitmapImage GetBitmapImage(string mapName)
        {
            BitmapImage bitMap = new BitmapImage();
            bitMap.BeginInit();
            bitMap.UriSource = new Uri($@"\MapImg\{mapName}.png", UriKind.Relative);
            bitMap.EndInit();
            return bitMap;
        }

        /// <summary>
        /// פעולה המורידה את כמות החיים של האויב לי כמות הנזק של הבניין
        /// </summary>
        public void DamageTarget()
        {
            target.Hit(damage);
        }

        /// <summary>
        /// פעולה להחזרה אם הקליע פגע במטרה או לא
        /// </summary>
        /// <returns>אמת אם פגע במטרה ושקר אחרת</returns>
        public bool projectileHit()
        {
            return this.hit;
        }
    }
}
