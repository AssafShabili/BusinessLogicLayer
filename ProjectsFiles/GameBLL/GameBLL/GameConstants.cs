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
        public static double lowestWinrate;
        public static double highestWinrate;
        public static double highestCurrentWinrate;
        public static double lowestCurrentWinrate;

        /// <summary>
        /// פעולה להשמת הנתונים בתוך הנתונים המתאימים
        /// </summary>
        /// <param name="dataTable">טבלת נתונים שהובאה מבסיס הנתונים שלי</param>
        public static void InitializeVariables(DataTable dataTable)
        {
            lowestWinrate = (double)(dataTable.Rows[0]["AdminPercentage_Lowest_winrate"]);
            highestWinrate = (double)(dataTable.Rows[0]["AdminPercentage_Highest_winrate"]);
            highestCurrentWinrate = (double)(dataTable.Rows[0]["AdminPercentage_Highest_Current_Winrate"]);
            lowestCurrentWinrate = (double)(dataTable.Rows[0]["AdminPercentage_Lowest_Current_Winrate"]);
        }
    }
}
