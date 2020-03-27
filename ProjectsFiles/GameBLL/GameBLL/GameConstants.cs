using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Data;

namespace GameBLL
{
    public static class GameConstants
    {
        public static double lowestWinrate = 36.5;
        public static double highestWinrate = 50.5;
        public static double highestCurrentWinrate = 80;
        public static double lowestCurrentWinrate = 29;



        /// <summary>
        /// פעולה להשמת הנתונים בתוך הנתונים המתאימים
        /// </summary>
        /// <param name="dataTable">טבלת נתונים שהובאה מבסיס הנתונים שלי</param>
        public static void InitializeVariables(DataTable dataTable)
        {
            lowestWinrate = Convert.ToDouble((dataTable.Rows[0]["AdminPercentage_Lowest_winrate"]));
            highestWinrate = Convert.ToDouble(dataTable.Rows[0]["AdminPercentage_Highest_winrate"]);
            highestCurrentWinrate = Convert.ToDouble(dataTable.Rows[0]["AdminPercentage_Highest_Current_Winrate"]);
            lowestCurrentWinrate = Convert.ToDouble(dataTable.Rows[0]["AdminPercentage_Lowest_Current_Winrate"]);
        }
    }
}
