using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IAdminService
{
    [OperationContract]
    DataTable GetAdminPercentageTable();

    [OperationContract]
    void SetAdminPercentageLowestWinrate(double percentage);

    [OperationContract]
    void SetUpdateAdminPercentageHighestWinrate(double percentage);

    [OperationContract]
    void SetAdminPercentageHighestCurrentWinrate(double percentage);

    [OperationContract]
    void SetAdminPercentageLowestCurrentWinrate(double percentage);

    [OperationContract]
    int GetNumberOfCurrentUsers();

    [OperationContract]
    int GetNumberOfCurrentTowers();
}


