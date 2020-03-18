using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace GameBLL
{
    public static class GameConstants
    {
        public const double FireToFire = 0.5;
        public const double FireToWater = 0.5;
        public const double FireToAir = 0.5;
        public const double FireToEarth = 1.5;


        public const double WaterToFire = 1.5;
        public const double WaterToWater = 0.5;
        public const double WaterToAir = 0.5;
        public const double WaterToEarth = 0.5;


        public const int TileWidth = 50;
        public const int TileHeight = 50;
        public const int MapWidth = 16;
        public const int MapHeight = 21;
        public const Image projectileTexture = null;

        public const Image Wave_Normal_Unit = null;
        public const Image Wave_Normal_Range = null;
        public const Image Wave_Adv_Unit = null;
        public const Image Wave_Adv_Range = null;
        public const Image Wave_Ultra_Unit = null;
        public const Image Wave_Ultra_Range = null;


        public const Image fireBoss = null;
        public const Image waterBoss = null;
        public const Image airBoss = null;
        public const Image earthBoss = null;

        






    }
}
