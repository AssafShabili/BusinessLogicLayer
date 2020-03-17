using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using GameBLL.BLL_Classess;
using System.Data;

/// <summary>
/// Summary description for AdminWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class AdminWebService : System.Web.Services.WebService
{
    private AdminUserBL AdminUserBL = new AdminUserBL();

    public AdminWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    /// <summary>
    /// פעולה לקבלת כל נתונים של האחוזים מבסיס הנתונים
    /// </summary>
    /// <returns>טבלת נתונים שהיא מכילה את הנתונים של האחוזים</returns>
    [WebMethod]
    public DataTable GetAdminPercentageTable()
    {

        return this.AdminUserBL.GetAdminPercentageTable();
    }

    /// <summary>
    /// פעולה לעדכון אחוז הכי נמוך 
    /// לפי הנתונים של משתמשים אחרים
    /// לקבלת ההקלות
    /// </summary>
    /// <param name="percentage">אחוז חדש</param>
    [WebMethod]
    public void SetAdminPercentageLowestWinrate(double percentage)
    {

        this.AdminUserBL.SetAdminPercentageLowestWinrate(percentage);
    }
    /// <summary>
    /// פעולה לעדכון האחוז הכי גבוהה 
    /// לפי הנתונים של משתמשים אחרים
    /// לקבלת ההקלות
    /// </summary>
    /// <param name="percentage">אחוז חדש</param>
    [WebMethod]
    public void SetUpdateAdminPercentageHighestWinrate(double percentage)
    {
        this.AdminUserBL.SetUpdateAdminPercentageHighestWinrate(percentage);
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
    [WebMethod]
    public void SetAdminPercentageHighestCurrentWinrate(double percentage)
    {

        this.AdminUserBL.SetAdminPercentageHighestCurrentWinrate(percentage);
    }
    /// <summary>
    /// פעולה לעדכון אחוז הכי נמוך 
    /// לפי האחוז הניצחון של המשחק העכשיו שלו
    /// לקבלת ההקלות
    /// </summary>
    /// <param name="percentage">אחוז חדש</param>
    [WebMethod]
    public void SetAdminPercentageLowestCurrentWinrate(double percentage)
    {

        this.AdminUserBL.SetAdminPercentageLowestCurrentWinrate(percentage);
    }

}
