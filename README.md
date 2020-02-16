# Business-Logic-Layer
 this is my business logic layer for my grade 12 project.

 זהו הפרויקט 5 יח"ל שלי במדעי המחשב

## pre-run action:
 
 in this files at GameDAL.

 בקבצים של הפרויקט בתיקיית GameDAL
 ```
    .
    ├── App.config
    ├── DAL Classess
    │   ├── DataTablePrint.cs
    │   ├── Game.cs
    │   ├── Maps.cs
    │   ├── Properties.cs
    │   ├── Tower.cs
    │   ├── Users.cs
    │   └── WaveArchives.cs
    ├── DBHelper.cs <-- this one!
   ...
```

change the path of the database in said file to the current path of the file
```cs
    private static string MakeConnectionString()
    {
        return String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source ={0};Persist Security Info=False",
        @"E:\ProjectsFiles\DAL\GameDAL\DataBase\DataBaseGameAssafShabili.accdb");
        // .. this ^ need to be change in order for the project to work
        // צריך לשנות את הקטע הזה כדי שהפרויקט יעבוד
    }
```

```
└── ProjectsFiles
    ├── DAL
    │   ├── GameDAL
    │   │   ├── bin
    │   │   │   └── Debug
    │   │   │       └── DataBase
    │   │   ├── DAL Classess
    │   │   ├── DataBase
    │   │   ├── obj
    │   │   │   └── Debug
    │   │   │       └── TempPE
    │   │   └── Properties
    │   └── Visual Studio 2017
    │       └── Visualizers
    └── GameBLL
        ├── GameBLL
        │   ├── bin
        │   │   └── Debug
        │   ├── BLL Classess
        │   ├── Content
        │   ├── GameComponents
        │   ├── obj
        │   │   └── Debug
        │   │       └── TempPE
        │   └── Properties
        └── Visual Studio 2017
            ├── ArchitectureExplorer
            ├── Backup Files
            │   └── GameBLL
            └── Visualizers
```







# DAL

```cs
 public static class Users
    {
        
        #region פעולות פשוטות
        /// <summary>
        /// פונקציה ליצירה משתמש חדש 
        /// </summary>
        /// <param name="email">אימייל של המשתמש </param>
        /// <param name="password">סיסמא של המשתמש</param>
        public static void SignIn(string email,string password)
        {
            DBHelper.UpdateQuery($" INSERT INTO Users ([User_email], [User_password]) VALUES ('{email}','{password}')");
        }

        /// <summary>
        /// פעולה לבדיקה אם מייל נמצא בתוך המבנה התנתונים 
        /// </summary>
        /// <param name="email"> אימייל של המשתמש </param>
        /// <returns>אם הכתובת אימייל שקיבלנו נמצאת בתוך המבנה התנונים</returns>
        public static bool DoesEmailExist(string email)
        {
            DataTable dt = DBHelper.GetDataTable(0,
                " SELECT Users.[User_email] " +
                " FROM Users " +
               $" WHERE Users.[User_email] = '{email}' AND User_Deleted = FALSE ");

            return (dt.Rows.Count != 0);
        }

        public static DataTable GetUserInfo(string email, string password)
        {
            return DBHelper.GetDataTable(0,
                " SELECT Users.[User_ID], Users.[User_email], Users.[User_password],Game.[Game_ID] " +
                " FROM Game INNER JOIN (Users INNER JOIN UsersSavesGames ON Users.[User_ID] = UsersSavesGames.[User_ID]) ON Game.[Game_ID] = UsersSavesGames.[Game_ID] " +
               $" WHERE Users.[User_email] = '{email}' AND Users.[User_password] = '{password}' AND User_Deleted = FALSE  ");
        }

        /// <summary>
        ///  פונקציה לבדיקת התחברות של משתמש 
        /// </summary>
        /// <param name="email">אימייל של המשתמש </param>
        /// <param name="password">סיסמא של המשתמש</param>
        /// <returns>אם המשתמש נמצא </returns>
        public static bool LoginIn(string email,string password)
        {
            return (DBHelper.GetDataTable(0, "SELECT Users.User_email, Users.User_password " +
                                   " FROM Users " +
                    $" WHERE (((Users.User_email) = '{email}') AND ((Users.User_password) = '{password}')); ")) == null;   
        }

        /// <summary>
        ///  "פונקציה ל"מחיקה של משתמש 
        /// </summary>
        /// <param name="email">אימייל של המשתמש </param>
        /// <param name="password">סיסמא של המשתמש</param>
        public static void DeleteUser(string email,string password)
        {
            DBHelper.UpdateQuery($" UPDATE Users SET Users.User_Deleted = True "+
           $" WHERE(([Users].[User_email] = '{email}')) AND (([Users].[User_password] = '{password}')); ");
        }

        /// <summary>
        ///  פונקציה לשינוי הסיסמא של השחקן
        /// </summary>
        /// <param name="email">אימייל של המשתמש </param>
        /// <param name="oldPassword">סיסמא הישנה של המשתמש</param>
        /// <param name="newPassword">סיסמא החדשה של המשתמש</param>
        public static void UpdatePassword(string email, string oldPassword, string newPassword)
        {
            DBHelper.UpdateQuery($" UPDATE Users SET Users.[User_password] = {newPassword} " +
           $" WHERE(([Users].[User_email] = '{email}')) AND (([Users].[User_password] = '{oldPassword}')); ");
        }

        public static void UpdateEmail(string oldEmail,string newEmail,string password)
        {
            DBHelper.UpdateQuery(
                $" UPDATE Users SET Users.[User_email] = {oldEmail} " +
                $" WHERE(([Users].[User_email] = '{oldEmail}')) AND (([Users].[User_password] = '{password}')); ");
        }


        /// <summary>
        /// פעולה לקבלת כל השמירות של המשתמש
        /// </summary>
        /// <param name="email">אימייל של המשתמש</param>
        /// <param name="password">סיסמא של המשתמש</param>
        /// <returns>ליסט עם כל המפתחות של המשמירות של המשתמש</returns>
        public static List<int> UserGetGamesSavesID(string email,string password)
        {
            DataTable dt = DBHelper.GetDataTable(0,
                " SELECT Users.User_email, Users.User_password, UsersSavesGames.Game_ID "+
                " FROM Users INNER JOIN UsersSavesGames ON Users.[User_ID] = UsersSavesGames.[User_ID] "+
               $" WHERE  Users.User_email = '{email}' and Users.[User_password] = '{password} ' ");

            //Console.WriteLine(DataTablePrint.BuildTable(dt,16));

            List<int> savesID = new List<int>();

            for(int i = 0;i<dt.Columns.Count;i++)
            {
                savesID.Add((int)(dt.Rows[i][2]));
            }

            return savesID;
        }

        #endregion

        /// <summary>
        ///  פעולה להכנת שמירה חדשה למשתמש
        /// </summary>
        /// <param name="userID">מפתח של השחקן</param>
        /// <param name="mapID">מפתח של המפה של המשחק</param>
        /// <returns>פונקציה תחזירה אמת אם אפשר להכין שמירה והיא תכין אותה,ושקר אם היא לא יכולה להכין אותה  </returns>
        public static bool MakeNewSave(int userID,int mapID) // maybe not good!
        {
            //במשחק שלי אני רוצה שלכל משתמש יהיה 3 שמירות בסך הכל אז 
            // אני צריך לבדוק אם המשתמש יכול להוסיף את השמירה 
            if (Game.CanUserAddSave(userID))//אמת -> אפשר להוסיף למשתמש עוד שמירה
            {
                // המפתח של השמירה של המשחק
                int gameID = Game.MakeDefaultGame(mapID);
                //הוספה לטבלה המקשרת
                Game.UserAddSave(userID, gameID);
                return true;
            }// end if
            return false;                    
        }
```
