using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GameDAL.DAL_Classess;

namespace GameDAL
{
    
    public class Program
    {
        
        static void Main(string[] args)
        {
            //Console.WriteLine(Properties.GetWinRateOfWave(1));
            #region tests
            //  Console.WriteLine(Maps.GetMapName(1));
            // Console.WriteLine(Maps.GetMapImg(1));
            //Console.WriteLine(Game.MakeDefaultGame(1));
            // Console.WriteLine(Game.CanUserAddSave(1));
            // Game.UserAddSave(1, 1);
            // DataTable dataTable = DBHelper.GetDataTable(0,
            //      " SELECT Wave_id " +
            //      " FROM Wave " +
            //      " WHERE Wave_id = 300");

            //    if(dataTable.Rows.Count == 0 )
            //    {
            //        Console.WriteLine("fuck !");
            //    }
            //Console.WriteLine(DateTime.Now.Date);

            #region Testing-Users
            //Console.WriteLine("Test -> public static bool LoginIn(string email,string password) ");
            //Console.WriteLine("With - assafShabili@gmail.com,0524598498 " + Users.LoginIn("assafShabili@gmail.com", "0524598498"));
            //Console.WriteLine("With - assaf@gmail.com,08" + Users.LoginIn("assaf@gmail.com", "08"));

            //Console.WriteLine("--------------------------------------------------------------------");

            //Console.WriteLine("Test -> public static void SignIn(string email,string password) ");
            //Console.WriteLine("With - elad@gmail.com,486486 ");
            //Users.SignIn("elad@gmail.com", "486486");
            //Console.WriteLine("     [+] -> look in the database for changes!");

            //Console.WriteLine("-------------------------------------------------------");   

            //Console.WriteLine("Test -> public static void UpdatePassword(string email, string oldPassword, string newPassword) ");
            //Console.WriteLine("With - assafShabili@gmail.com,0524598498,789456132 ");
            //Users.UpdatePassword("assafShabili@gmail.com", "0524598498", "789456132");
            //Console.WriteLine("     [+] -> look in the database for changes!");

            //Console.WriteLine("Test -> public static bool DoesEmailExist(string email)");
            //Console.WriteLine("with - assafShabili@gmail.com");
            //Console.WriteLine(Users.DoesEmailExist("assafShabili@gmail.com"));

            Console.WriteLine(DataTablePrint.BuildTable(
                Users.GetUserInfo("assafShabili@gmail.com", "0524598498"),26));


            #endregion

            #region Testing-Maps
            //Console.WriteLine("Test -> public static string GetMapName(int mapID) ");
            //Console.WriteLine($"With - 1, '{Maps.GetMapName(1)}' " );

            //Console.WriteLine("--------------------------------------------------------------------");

            //Console.WriteLine("Test ->  public static string GetMapImg(int mapID) ");
            //Console.WriteLine($"With - 1, '{Maps.GetMapImg(1)}' ");

            //Console.WriteLine("--------------------------------------------------------------------");

            //Console.WriteLine("Test ->  public static DataTable GetMapRoad(int mapID) ");
            //Console.WriteLine($"With - 1 : ");
            //Console.WriteLine(DataTablePrint.BuildTable(
            //    Maps.GetMapRoad(1), 16));


            Console.WriteLine(DataTablePrint.BuildTable(
                Maps.GetAllMaps(),16));

            #endregion

            #region Testing-Tower
            //Console.WriteLine("Test -> public static DataTable GetTowerInfo(int towerID) ");
            //Console.WriteLine($"With - 1 :" );
            //Console.WriteLine(DataTablePrint.BuildTable(
            //    Tower.GetTowerInfo(1),20));

            //Console.WriteLine("--------------------------------------------------------------------");

            ////public static void UpgradeTowerRange(int towerID, int newRange)
            //Console.WriteLine("Test -> public static void UpgradeTowerRange(int towerID, int newRange) ");
            //Console.WriteLine($"With - 1,669");
            //Tower.UpgradeTowerRange(1, 669);
            //Console.WriteLine("UPDATED TOWER [1]");
            //Console.WriteLine("PRINTING TOWER INFO:");
            //Console.WriteLine(DataTablePrint.BuildTable(
            //   Tower.GetTowerInfo(1), 20));

            //Console.WriteLine("Test ->  public static void UpgradeTowerDamage(int towerID, int newDamage) ");
            //Console.WriteLine($"With - 1,669");
            //Tower.UpgradeTowerDamage(1, 669);
            //Console.WriteLine("UPDATED TOWER [1]");
            //Console.WriteLine("PRINTING TOWER INFO:");
            //Console.WriteLine(DataTablePrint.BuildTable(
            //   Tower.GetTowerInfo(1), 20));

            //Console.WriteLine("Test ->  public static void UpgradeTowerAttackSpeed(int towerID, int newAttackSpeed) ");
            //Console.WriteLine($"With - 1,669");
            //Tower.UpgradeTowerAttackSpeed(1, 669);
            //Console.WriteLine("UPDATED TOWER [1]");
            //Console.WriteLine("PRINTING TOWER INFO:");
            //Console.WriteLine(DataTablePrint.BuildTable(
            //   Tower.GetTowerInfo(1), 20));

            //Console.WriteLine("Test ->  public static int GetTowerLevel(string towerAttribute, int towerID) ");
            //Console.WriteLine($"With - 'Tower_damage_lvl',669");            
            //Console.WriteLine($"TOWER LEVEL OF Attribute -> 'Tower_damage_lvl' {Tower.GetTowerLevel("Tower_damage_lvl", 1)}");
            //Console.WriteLine(DataTablePrint.BuildTable(
            //   Tower.GetTowerInfo(1), 20));

            #endregion

            #region Testing-Properties
            //Console.WriteLine("Test -> public static DataTable GetWaveProperties(int waveID) ");
            //Console.WriteLine("With - 1 ");
            //Console.WriteLine(DataTablePrint.BuildTable(
            //    Properties.GetWaveProperties(1),27));

            //Console.WriteLine("----------------------------------------------------------------");

            //Console.WriteLine("Test ->  public static int GetNumbersOfWinsWave(int waveID) ");
            //Console.WriteLine("With - 1 ");
            //Console.WriteLine($"Numbers Of Wins in wave 1: {Properties.GetNumbersOfWinsWave(1)}");

            //Console.WriteLine("----------------------------------------------------------------");

            //Console.WriteLine("Test ->  public static int GetNumbersOfLosessWave(int waveID) ");
            //Console.WriteLine("With - 1 ");           
            //Console.WriteLine($"Numbers Of Losess in wave 1: {Properties.GetNumbersOfLosessWave(1)}");

            //Console.WriteLine("------------------------------------------------------------------");

            //Console.WriteLine("Test ->  public static int GetNumberOfTowerTypeBuilt(int waveID, string type) ");
            //Console.WriteLine("With - 1,fire ");
            //Console.WriteLine($"Numbers Of Tower 'type' built is: {Properties.GetNumberOfTowerTypeBuilt(1, "fire")}");

            //Console.WriteLine("------------------------------------------------------------------");

            //Console.WriteLine("Test ->  public static int GetNumberOfAllTowerTypeBuilt(int waveID, string type) ");
            //Console.WriteLine("With - 1,fire ");
            //Console.WriteLine($"Numbers Of Tower 'all-types' built is: \n" +
            //    $"{DataTablePrint.BuildTable(Properties.GetNumberOfAllTowerTypeBuilt(1, "fire"), 27)} ");

            //Console.WriteLine("------------------------------------------------------------------");
            ///*public static double GetWinRateOfWave(int propertiesID)*/
            //Console.WriteLine("Test ->  public static double GetWinRateOfWave(int propertiesID) ");
            //Console.WriteLine("With - 1 ");
            //Console.WriteLine($"Numbers Of Losess in wave 1: {Properties.GetWinRateOfWave(1)} ");
            #endregion

            #region Testing-WaveArchives
            /*
             *   public static void InsertWaveToWaveArchives(int waveID,int gameID,int mapID,bool easyMode,bool isWon)
             */

            //  Console.WriteLine("Test -> public static DataTable GetWaveArchivesInfo(int waveID) ");
            //  Console.WriteLine("With - 1 " +"\n"+
            //     DataTablePrint.BuildTable(WaveArchives.GetWaveArchivesInfo(1),27));

            //  Console.WriteLine("-----------------------------------------------------------------------------");

            //Console.WriteLine("Test -> public static DataTable GetWaveArchivesInfo(int waveID,int mapID) ");
            //Console.WriteLine("With - 1,1 " + "\n" +
            //   DataTablePrint.BuildTable(WaveArchives.GetWaveArchivesInfo(1,1), 27));

            //Console.WriteLine("-----------------------------------------------------------------------------");

            //Console.WriteLine("Test -> public static DataTable GetWaveArchivesInfoEasy(int waveID, int mapID) ");
            //Console.WriteLine("With - 1 " + "\n" +
            //   DataTablePrint.BuildTable(WaveArchives.GetWaveArchivesInfoEasy(1, 1), 27));

            //Console.WriteLine("-----------------------------------------------------------------------------");

            //Console.WriteLine("Test ->  public static DataTable GetWaveArchivesWon(int waveID, int mapID) ");
            //Console.WriteLine("With - 1 " + "\n" +
            //   DataTablePrint.BuildTable(WaveArchives.GetWaveArchivesWon(1, 1), 27));

            //Console.WriteLine("-----------------------------------------------------------------------------");

            //Console.WriteLine("Test ->  public static DataTable GetWaveArchivesLost(int waveID, int mapID) ");
            //Console.WriteLine("With - 1 " + "\n" +
            //   DataTablePrint.BuildTable(WaveArchives.GetWaveArchivesWon(1, 1), 27));

            //Console.WriteLine("-----------------------------------------------------------------------------");

            //Console.WriteLine("Test ->  public static void InsertWaveToWaveArchives(int waveID,int gameID,int mapID,bool easyMode,bool isWon) ");
            //Console.WriteLine("With - 2,2,1,False,True ");
            //WaveArchives.InsertWaveToWaveArchives(2, 2, 1, false, false);
            //Console.WriteLine(DataTablePrint.BuildTable(WaveArchives.GetWaveArchivesInfo(2), 27));


            #endregion

            #region Testing-Game
            //Console.WriteLine("Test -> public static DataTable GetGameInfo(int ID) ");
            //  Console.WriteLine("With - 1 " +"\n"+
            //     DataTablePrint.BuildTable(Game.GetGameInfo(1),27));

            //Console.WriteLine("------------------------------------------------------------");

            //Console.WriteLine("Test -> public static DataTable GetGameTowers(int gameID) ");
            //Console.WriteLine("With - 1 " + "\n" +
            //   DataTablePrint.BuildTable(Game.GetGameTowers(1), 27));

            //Console.WriteLine("------------------------------------------------------------");

            //Console.WriteLine("Test -> public static void DeleteGameTower(int gameID,int towerID) ");
            //Console.WriteLine("With - 1,1 ");
            //Game.DeleteGameTower(1, 1);

            //Console.WriteLine("------------------------------------------------------------");

            //Console.WriteLine("Test -> public static void MakeNewTower(int gameID,int towerID) ");
            //Console.WriteLine("With - 1,1 ");
            //Game.MakeNewTower(1, 1);

            //Console.WriteLine("--------------------------------------------------------------");

            //Console.WriteLine("Test -> public static void ChangeTypeTower(int towerID,string typeNew) ");
            //Console.WriteLine("With - 1,1 ");
            //Game.ChangeTypeTower(1, "water");

            //Console.WriteLine("------------------------------------------------------------");

            //Console.WriteLine("Test -> public static int MakeDefaultGame(int mapID) ");
            //Console.WriteLine("With - 1,1 ");
            //Console.WriteLine("new defult game created ID is :" +  Game.MakeDefaultGame(1));

            //Console.WriteLine("------------------------------------------------------------");

            //Console.WriteLine("Test -> public static bool CanUserAddSave(int userID)");
            //Console.WriteLine("With - 1 ");
            //Console.WriteLine("Can user add another save - "+ Game.CanUserAddSave(1));

            //Console.WriteLine("------------------------------------------------------------");

            //Console.WriteLine("Test -> public static void UserAddSave(int userID,int gameID)");
            //Console.WriteLine("With - 1,1 ");
            //Game.UserAddSave(1,6);

            //Console.WriteLine("------------------------------------------------------------");

            //Console.WriteLine("Test -> public static DataTable GetGameWaveInfo(int gameID) ");
            //Console.WriteLine("With - 1 " + "\n" +
            //   DataTablePrint.BuildTable(Game.GetGameWaveInfo(1), 27));

            //Console.WriteLine("------------------------------------------------------------");

            //Console.WriteLine("Test -> public static bool IsThereANextWave(int waveID)");
            //Console.WriteLine("With - 1 ");
            //Console.WriteLine("Can user add another save - " + Game.IsThereANextWave(1));

            //Console.WriteLine("------------------------------------------------------------");

            //Console.WriteLine("Test -> public static int GetGameHealth(int gameID)");
            //Console.WriteLine("With - 1,1 ");
            //Console.WriteLine("User health is [in game id 1 ] ->" + Game.GetGameHealth(1));

            //Console.WriteLine("------------------------------------------------------------");

            //Console.WriteLine("Test -> public static int GetGameScore(int gameID)");
            //Console.WriteLine("With - 1,1 ");
            //Console.WriteLine("User game score is [in game id 1 ] ->" + Game.GetGameScore(1));

            //Console.WriteLine("------------------------------------------------------------");

            //Console.WriteLine("Test -> public static int GetGameMoney(int gameID)");
            //Console.WriteLine("With - 1,1 ");
            //Console.WriteLine("User game money is [in game id 1 ] ->" + Game.GetGameMoney(1));

            //Console.WriteLine("------------------------------------------------------------");

            //Console.WriteLine("Test -> public static int GetGameWaveID(int gameID)");
            //Console.WriteLine("With - 1,1 ");
            //Console.WriteLine("User game wave is [in game id 1 ] ->" + Game.GetGameWaveID(1));


            #endregion

            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
            #endregion

            //List<int> test = Users.UserGetGamesSavesID("assafShabili@gmail.com", "0524598498");
            //foreach (var item in test)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
