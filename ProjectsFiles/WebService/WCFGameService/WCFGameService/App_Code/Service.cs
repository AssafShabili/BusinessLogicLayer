using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services;
using GameDAL.DAL_Classess;






// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.

public class Service : IService
{
	

	[WebMethod]
	public DataTable GetOtherUsersGameInfo()
	{
		return Properties.GeAllWaveProperties();
	}

	[WebMethod]
	public void SendPropertiesInfo(int waveID,bool won,
		int numbersOfWaterTowers, int numbersOfFireTowers, int numbersOfAirTowers, int numbersOfEarthTowers)
	{
		Properties.UpdateWaveProperties(waveID, won, numbersOfWaterTowers, numbersOfFireTowers, numbersOfAirTowers, numbersOfEarthTowers);
	}

	//[WebMethod]
	//public DataTable GetOtherUsersGameInfoByWaveID(int waveID)
	//{

	//}

	//[WebMethod]
	//public DataTable GetOtherUsersGameInfoByWaveIDAndMapID(int waveID, int mapID)
	//{
	//	throw new NotImplementedException();
	//}

	//[WebMethod]
	//public void SendUserGameInfoWithWinCondition(GameBL userGame,bool esayMode,bool isWon)
	//{
	//	GameDAL.DAL_Classess.WaveArchives.
	//		InsertWaveToWaveArchives(userGame.GetWave().GetWaveID(),
	//								 userGame.GetGameBLID(),
	//								 userGame.GetMap().GetMapID(),
	//								 esayMode, isWon);
	//}

	//[WebMethod]
	//public void SendUserGameInfo(GameBL userGame, bool easyMode)
	//{
	//	throw new NotImplementedException();
	//}
}
