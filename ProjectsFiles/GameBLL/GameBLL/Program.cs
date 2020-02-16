using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameBLL.BLL_Classess;
using System.Data;
using GameDAL.DAL_Classess;
using System.IO;
using Microsoft.Xna.Framework;

namespace GameBLL
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            //DataTable dataTable = GameDAL.DAL_Classess.Properties.GeAllWaveProperties();
            //Console.WriteLine(DataTablePrint.BuildTable(dataTable,18));

            UserBL userBL = new UserBL("assafShabili@gmail.com", "0524598498");
            Console.WriteLine(userBL);

            

            //MapBL mapBL = new MapBL(1);
            //mapBL.InitializeMapRoad();



            GameBL game = userBL.GetGameSave(0);


            List<Tuple<TowerType, int>> lst = game.GetMostCommonTower();

            foreach (Tuple<TowerType, int> item in lst)
            {
                Console.WriteLine($"{item.Item1} - {item.Item2}");
            }

            TowerType towerType = TowerType.Fire;

            Console.WriteLine(towerType);

            Console.WriteLine(DataTablePrint.BuildTable(
                GameDAL.DAL_Classess.Game.GetHighestBossByBossHealth(),27));


            Console.WriteLine(DataTablePrint.BuildTable(
               WaveArchives.GetWaveArchivesWithWaveProperties(1, 1), 27));

            Console.WriteLine(DataTablePrint.BuildTable(
                GameDAL.DAL_Classess.Maps.GetMapInfoWithRoad(1), 15));

            Console.WriteLine(DataTablePrint.BuildTable(
                GameDAL.DAL_Classess.Maps.GetMapInfoWithRoad(2), 15));

            Console.WriteLine(DataTablePrint.BuildTable(
               GameDAL.DAL_Classess.Game.GetHighestBossByBossHealth(), 27));

            Console.WriteLine(DataTablePrint.BuildTable(
                GameDAL.DAL_Classess.Maps.GetMapInfoWithRoad(3), 15));

           


            Console.ReadKey();

            //Console.WriteLine(Properties.GetNumberOfAllTowerTypeBuilt(1));


            //DataTable table = GameDAL.DAL_Classess.Game.GetBossInfoByBossID(1);
            //Console.WriteLine(DataTablePrint.BuildTable(table,25));

            //DataTable table1 = GameDAL.DAL_Classess.Game.GetBossInfoByType("fire");
            //Console.WriteLine(DataTablePrint.BuildTable(table1,25));

            //TowerBL towerBL = new TowerBL(1);
            //Point p = new Point(1, 1);            
            //Console.WriteLine(towerBL.DoesTowerAttackRangeContainsPoint(p));

            ////Console.WriteLine();
            ////WaveBL waveBL = new WaveBL(1);
            //DataTable dataTable = Game.GetGameWaveInfo(1);
            //Console.WriteLine(dataTable.Rows[0]["Wave_Normal_Unit"]);
            //MapBL mapBL = new MapBL(1);

            //List<int> ts = new List<int>();
            //ts.Add(1);
            //ts.Add(6);
            //ts.Add(5);
            //ts.Add(4);
            //ts.Add(3);

            //Console.WriteLine(ts.IndexOf(2));

            //GameDAL.DAL_Classess.Users.DeleteGameSaveFromUser(2,6);


            //mapBL.initializeMapRoad();

            //List<MapBL> lst = mapBL.GetAllMapsInfo();
            //foreach (var item in lst)
            //{
            //    Console.WriteLine(item);
            //}
            // Console.WriteLine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseGameAssafShabili.accdb"));
            // Console.WriteLine(TowerType.Air.ToString());
            //TowerBL towerBL = new TowerBL(1);
            //Console.WriteLine(SellTower(1));

            //Console.WriteLine("wow very cool !=");
            Console.ReadKey();
        }
    }
}
