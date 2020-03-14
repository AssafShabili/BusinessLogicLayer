using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
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

}
