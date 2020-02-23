using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using GameBLL.BLL_Classess;
using GameBLL.GameComponents;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{
	/*
	 * הסבר מורחב על הפעולות ועל למה אני צריך אותם בטופס הבא
	 * https://docs.google.com/document/d/1pIE5dvvhTxHKVjIUsluiukqhzAhGTV-natD5P90Ayik/edit?usp=sharing
	 */

	[OperationContract]
	DataTable GetOtherUsersGameInfo();

	[OperationContract]
	DataTable GetOtherUsersGameInfo(int waveID);

	[OperationContract]
	DataTable GetOtherUsersGameInfo(int waveID,int mapID);

	[OperationContract]
	void SendUserGameInfo(GameBL userGame,bool esayMode, bool isWon);

	[OperationContract]
	void SendUserGameInfo(GameBL userGame,bool easyMode);

}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class CompositeType
{
	bool boolValue = true;
	string stringValue = "Hello ";

	[DataMember]
	public bool BoolValue
	{
		get { return boolValue; }
		set { boolValue = value; }
	}

	[DataMember]
	public string StringValue
	{
		get { return stringValue; }
		set { stringValue = value; }
	}
}
