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

	/// <summary>
	/// פעולה לקבלת כל המידע שבטבלת properties
	/// </summary>
	/// <returns>טבלת נתונים של כל הנתונים שבטבלת properties</returns>
	[WebMethod]
	public DataTable GetOtherUsersGameInfo()
	{
		return Properties.GeAllWaveProperties();
	}

	/// <summary>
	/// פעולה להחזרת המידע שבטבלת properties
	/// </summary>
	/// <param name="waveID"></param>
	/// <param name="won"></param>
	/// <param name="numbersOfWaterTowers"></param>
	/// <param name="numbersOfFireTowers"></param>
	/// <param name="numbersOfAirTowers"></param>
	/// <param name="numbersOfEarthTowers"></param>
	[WebMethod]
	public void SendPropertiesInfo(int waveID,bool won,
		int numbersOfWaterTowers, int numbersOfFireTowers, int numbersOfAirTowers, int numbersOfEarthTowers)
	{
		Properties.UpdateWaveProperties(waveID, won, numbersOfWaterTowers, numbersOfFireTowers, numbersOfAirTowers, numbersOfEarthTowers);
	}


	[WebMethod]
	public void SendPropertiesInfoByFullInfo(int PropertiesID, int waveID, int numWin, int numLost, int numbersOfWaterTowers, int numbersOfFireTowers, int numbersOfAirTowers, int numbersOfEarthTowers)
	{
		Properties.UpdateProperties(PropertiesID, waveID, numWin, numLost, numbersOfWaterTowers, numbersOfFireTowers, numbersOfAirTowers, numbersOfEarthTowers);
	}


}
