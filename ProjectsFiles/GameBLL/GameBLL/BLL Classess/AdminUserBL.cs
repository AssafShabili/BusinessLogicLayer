using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDAL.DAL_Classess;
using System.Data;

namespace GameBLL.BLL_Classess
{
    /// <summary>
    /// מחלקה לטיפול בפעולות של מנהל המערכת של הפרויקט
    /// </summary>
    public class AdminUserBL
    {
        private string userName = "ADMIN-GAME";//שם המשתמש של מנהל המערכת
        private string password = "ADMINPASSWORD-GAME";// סיסמא של מנהל המערכת

        public AdminUserBL()
        {

        }

        /// <summary>
        /// פעולה לבדיקה ההתחברות של מנהל המערכת 
        /// </summary>
        /// <param name="userName">שם המשמש של מנהל המערכת</param>
        /// <param name="pssword">סיסמא של מנהל המערכת</param>
        /// <returns>אם הנתונים שהתקבלו שווים לנתונים הנתונים במחלקה תחזיר הפעולה אמת אחרת תחזיר שקר</returns>
        public bool AdminLogin(string userName, string pssword)
        {
            return (userName.Equals(userName) && this.password.Equals(password));
        }
        /// <summary>
        /// פעולה לקבלת כל נתונים של האחוזים מבסיס הנתונים
        /// </summary>
        /// <returns>טבלת נתונים שהיא מכילה את הנתונים של האחוזים</returns>
        public DataTable GetAdminPercentageTable()
        {
            return Users.GetAdminPercentage();
        }



        /*
         * בחלק הזה אני מעדכן את האחוזים ש"מחליטים " אם המשתמש צריך לקבלת את ההקלות
         *   לפי האחוז של הניצחון שבאותו סיבוב של המשחק
         *  לפי הנתנונים של המשתמשים במשחק
         */
        
        /// <summary>
        /// פעולה לעדכון אחוז הכי נמוך 
        /// לפי הנתונים של משתמשים אחרים
        /// לקבלת ההקלות
        /// </summary>
        /// <param name="percentage">אחוז חדש</param>
        public void SetAdminPercentageLowestWinrate(double percentage)
        {
            Users.UpdateAdminPercentageLowestWinrate(percentage);
        }
        /// <summary>
        /// פעולה לעדכון האחוז הכי גבוהה 
        /// לפי הנתונים של משתמשים אחרים
        /// לקבלת ההקלות
        /// </summary>
        /// <param name="percentage">אחוז חדש</param>
        public void SetUpdateAdminPercentageHighestWinrate(double percentage)
        {
            Users.UpdateAdminPercentageHighestWinrate(percentage);

        }




        /*
         * בחלק הזה אני מעדכן את האחוזים ש"מחליטים " אם המשתמש צריך לקבלת את ההקלות
         *   לפי אותו אחוז הניצחון שלו אותו משתמש במשחק מבלי קשר לסיבוב שהוא נמצא
         *  ואו לפי הנתונים של המשתמשים במשחק
         *  
         *  האחוז הוא נקבל לפי כמות נצחונות שלו המשחק הנוכחי שלו
         */

        /// <summary>
        /// פעולה לעדכון האחוז הכי גבוהה 
        /// לפי האחוז הניצחון של המשחק העכשיו שלו
        /// לקבלת ההקלות
        /// </summary>
        /// <param name="percentage">אחוז חדש</param>
        public void SetAdminPercentageHighestCurrentWinrate(double percentage)
        {
            Users.UpdateAdminPercentageHighestCurrentWinrate(percentage);
        }
        /// <summary>
        /// פעולה לעדכון אחוז הכי נמוך 
        /// לפי האחוז הניצחון של המשחק העכשיו שלו
        /// לקבלת ההקלות
        /// </summary>
        /// <param name="percentage">אחוז חדש</param>
        public void SetAdminPercentageLowestCurrentWinrate(double percentage)
        {
            Users.UpdateAdminPercentageLowestCurrentWinrate(percentage);
        }


        /// <summary>
        /// פעולה המחזירה את כמות המשתמשים שיש בסיס הנתונים שלי
        /// </summary>
        /// <returns></returns>
        public int NumberOfUsers()
        {
            return Users.GetAllUserID();
        }

        /// <summary>
        /// פעולה להחזרת השם משתמש של מנהל המערכת
        /// </summary>
        /// <returns>שם המשתמש של מנהל המערכת</returns>
        public string GetUserName()
        {
            return this.userName;
        }
        /// <summary>
        /// פעולה להחזרת הסיסמא של מנהל המערכת
        /// </summary>
        /// <returns>סיסמת מנהל המערכת</returns>
        public string GetPassword()
        {
            return this.password;
        }

    }
}
