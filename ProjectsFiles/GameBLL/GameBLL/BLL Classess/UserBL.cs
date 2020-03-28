using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDAL.DAL_Classess;
using System.Data;

namespace GameBLL.BLL_Classess
{
    public class UserBL
    {
        private int userID;//מפתח של המשתמש בטבלה
        private string email;// אימייל של משתמש
        private string password;// סיסמא של המשתמש

        //TODO add GameSave
        // ==========  השמירות של המשתמש =======
        private List<GameBL> gameSaves;
        // =======  סיום השמירות של המשתמש =======

        /// <summary>
        /// פעולה בונה של המחלקה
        /// </summary>
        /// <param name="email">אימייל של המשתמש</param>
        /// <param name="password">סיסמא של המשתמש</param>
        public UserBL(string email,string password)
        {
            //בדיקה האם המשתמש קיים
            if(!Users.LoginIn(email,password))
            {
                DataTable userDataTable = Users.GetUserInfoWithOutGameInfo(email, password);
                  //Console.WriteLine(DataTablePrint.BuildTable(userDataTable,20));

                this.userID = Convert.ToInt32(userDataTable.Rows[0][0]);//ID
                this.email = userDataTable.Rows[0][1].ToString();//E-mail
                this.password = userDataTable.Rows[0][2].ToString();//Password

                List<int> gamesaveIDList = Users.UserGetGamesSavesID(email, password);
                this.gameSaves = new List<GameBL>();                
                for (int i = 0; i < gamesaveIDList.Count; i++)
                {
                    gameSaves.Add(new GameBL(gamesaveIDList[i]));
                }
            }
            else
            {
                this.userID = -1;
                this.email = "defultValue";
                this.password = "defultValue";
            }
        }

       

        /// <summary>
        /// פעולה לרישום המשתמש
        /// </summary>
        /// <param name="email">אימייל של המשתמש</param>
        /// <param name="password">סיסמא של המשתמש</param>
        public void SighIn(string email, string password)
        {
            Users.SignIn(email, password);
            this.email = email;
            this.password = password;
        }

        /// <summary>
        /// פעולה לבדיקה אם המשתמש קיים בסיס הנתונים
        /// </summary>
        /// <param name="email">אימייל של המשתמש</param>
        /// <param name="password">סיסמא של המשתמש</param>
        /// <returns>אמת אם המשתמש קיים במערכת ושקר אחרת</returns>
        public bool LogIn(string email, string password)
        {
            return !Users.LoginIn(email, password);
        }

        /// <summary>
        /// פעולה למחיקה של השמירה של אותו משתמש
        /// </summary>
        /// <param name="index">מיקום בבסיס הנתונים</param>
        public void RemoveGameSave(int index)
        {
            GameDAL.DAL_Classess.Users.DeleteGameSaveFromUser(this.userID,
                this.gameSaves[index].GetGameBLID());
        }

        /// <summary>
        /// פעולה למציאת המיקום של שמירה של משחק
        /// </summary>
        /// <param name="game">משחק שאותו אנחנו רוצים לחפש</param>
        /// <returns>הפעולה מחזירה את המיקום של כל המשחקים</returns>
        public int GetIndexOfGameBL(GameBL game)
        {
            int index = 0;
            foreach (GameBL gameSave in this.gameSaves)
            {
                if(gameSave.GetGameBLID() == game.GetGameBLID())
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        
        /// <summary>
        /// פעולה בונה של משתמש
        /// </summary>
        public UserBL()
        {
            this.userID = -1;
            this.email = "defultValue";
            this.password = "defultValue";
        }

       

        /// <summary>
        /// פעולה לשינוי סיסמא המשתמש
        /// </summary>
        /// <param name="newPassoword">סיסמא חדשה</param>
        public void ChangeUserPassword(string newPassoword)
        {
            if(!Users.LoginIn(email, password))
            {
                Users.UpdatePassword(this.email, this.password, newPassoword);
                this.password = newPassoword;
            }
            
        }

        /// <summary>
        /// פעולה לשינוי האימייל של המשתמש
        /// </summary>
        /// <param name="newEmail">אימייל של השחקן</param>
        public void ChangeUserEmail(string newEmail)
        {
            if (!Users.LoginIn(email, password))
            {
                Users.UpdateEmail(this.email, newEmail,this.password);
                this.email = newEmail;
            }
        }

        /// <summary>
        /// פעולה לבדיהק אם הכתובת אימייל שהתקבלה נמצאת בתוך בסיס הנתונים שלי
        /// </summary>
        /// <param name="email">כתובת האימייל </param>
        /// <returns>אמת אם הכתובת קיימת ושקר אחרת </returns>
        public bool DoesEmailExist(string email)
        {
            return Users.DoesEmailExist(email);
        }


        /// <summary>
        /// פעולה לקבלת השמירות של המשתמש
        /// </summary>
        /// <param name="index">המיקום של המשחק של המשתמש בתוך השרשרת שבמחלקה</param>
        /// <returns>את השמירה של משתמש לפי המיקום בשרשרת</returns>
        public GameBL GetGameSave(int index)
        {
            return this.gameSaves[index];
        }


        /// <summary>
        /// פעולה למציאת המיקום הפנוי בשרשרת של השמירות
        /// הנחה: הפעולה אף פעם לא תחזיר 1- אם הכול יעבוד כמו שצריך
        /// זאת אומרת שקודם יבדק אם אפשר בכלל להוסיף שמירה
        /// </summary>
        /// <returns>את המיקום הראשון הפנוי הראשון</returns>
        private int GetAvailableSaveIndex()
        {
            for (int i = 0; i < 3; i++)
            {
                if(this.gameSaves[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }

        

        /// <summary>
        /// פעולה להוספה שמירה לשחקן
        /// </summary>
        /// <param name="gameSave">שמירה של משחק</param>
        public void AddGameSave(GameBL gameSave)
        {
            int index = this.GetAvailableSaveIndex();

            if (index != -1)//failed-key
            {
                //מוחקים את השמירה מהבסיס נתונים שלי
                Users.DeleteGameSaveFromUser(this.userID, this.gameSaves[index].GetGameBLID());
                // מכניס את משחק לשרשרת של המשתמש 
                this.gameSaves[index] = gameSave;
                // מכניס לבסיס נתונים שלי את השמירה החדשה
                Game.UserAddSave(this.userID, gameSave.GetGameBLID());               
            }
        }

        /// <summary>
        /// פעולה לבדיקה אם המשתמש יכול ליצור עוד שמירה
        /// </summary>
        /// <returns>אמתאם המשתמש יכול ליצור עוד שמירה אחרת שקר</returns>
        public bool CanAddNewGameSave()
        {
            if(this.gameSaves[0].GetGameBLID() == -1 ||
                this.gameSaves[1].GetGameBLID() == -1 ||
                this.gameSaves[2].GetGameBLID() == -1)
            {
                return true;
            }
            return false;

        }
        
        /// <summary>
        /// פעולה לקבלת המפות מכל השמירות של המשתמש
        /// </summary>
        /// <returns>אם למשתמש יש שמירות אז הפעולה תחזיר רשימה של כל המפות של כל המשחקים של המשתמש אחרת 
        /// אם למשתמש יש אפס שמירות קיימות הפעולה תחזיר שרשרת ריקה</returns>
        public List<MapBL> GetUserGamesMaps()
        {
            if(this.gameSaves.Count > 0)
            {
                List<MapBL> mapBLLists = new List<MapBL>();
                foreach (GameBL game in this.gameSaves)
                {
                    mapBLLists.Add(game.GetMap());
                }
                return mapBLLists;
            }
            return new List<MapBL>();

        }
        /// <summary>
        /// פעולה לחזרת השמירות של המשתמש שלי
        /// </summary>
        /// <returns>הפעולה מחזירה את השרשרת של השמירות של המשתמש</returns>
        public List<GameBL> GetUsersGameSaves()
        {
            return this.gameSaves;
        }

        /// <summary>
        /// פעולה להחזרת המחלקה בתור סטרינג
        /// </summary>
        /// <returns>סטרינג שמייצג את המחלקה</returns>
        public override string ToString()
        {
            return $"User [{this.userID}] \n" +
                   $"email - {this.email} \n " +
                   $"Password - {this.password} ";
        }

        /// <summary>
        /// פעולה לקבלת השם של המשתמש לפי האימייל שלו
        /// </summary>
        /// <returns>סטרינ שמכיל את השם של המשתמש לפי האימייל שלו</returns>
        public string GetNameByEmail()
        {
            return this.email.Split('@')[0];
        }

    }
}
