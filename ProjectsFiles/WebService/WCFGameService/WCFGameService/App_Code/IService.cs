﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;




// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{	
	[OperationContract]
	DataTable GetOtherUsersGameInfo();

	[OperationContract]
	void SendPropertiesInfo(int waveID,bool won,int numbersOfWaterTowers, int numbersOfFireTowers, int numbersOfAirTowers, int numbersOfEarthTowers);	

	[OperationContract]
	void SendPropertiesInfoBy()
}


