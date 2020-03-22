using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceMD5
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceMD5
    {
        [OperationContract]
        string GetMd5Hash(string password);

        [OperationContract]
        string GetMd5HashWithMD5Hash(MD5 md5Hash, string password);

        [OperationContract]
        bool VerifyMd5Hash(string password, string hashedPassword);     
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
   
}
